using System;
using System.Data;
using GestionSalud.Datos;

namespace GestionSalud.Servicios
{
    /// <summary>
    /// Genera los 5 reportes requeridos por el Director Municipal de Salud.
    /// </summary>
    public class ReporteService
    {
        /// <summary>
        /// Reporte 1 — Número de espacios por centro agrupados por tipo.
        /// </summary>
        public DataTable EspaciosPorCentro()
        {
            return Conexion.EjecutarConsulta(@"
                SELECT ic.NombreCentro,
                       et.NombreTipo,
                       COUNT(*) AS CantidadEspacios
                FROM   Espacio_Medico           em
                JOIN   Infraestructura_Centro   ic ON em.IdCentro      = ic.IdCentro
                JOIN   Espacio_Tipo             et ON em.IdTipoEspacio  = et.IdTipoEspacio
                GROUP  BY ic.NombreCentro, et.NombreTipo
                ORDER  BY ic.NombreCentro, et.NombreTipo");
        }

        /// <summary>
        /// Reporte 2 — Incidencias y mantenimientos entre dos fechas.
        /// </summary>
        public DataTable IncidenciasPorFechas(DateTime desde, DateTime hasta)
        {
            return Conexion.EjecutarConsulta(@"
                SELECT gi.FechaRegistro,
                       gi.TipoAccion,
                       gi.DescripcionProblema,
                       ie.CodigoMunicipal,
                       ie.Marca + ' ' + ie.Modelo       AS Equipo,
                       ISNULL(em.NombreEspacio, 'N/A')  AS Espacio,
                       ISNULL(ic.NombreCentro,  'N/A')  AS Centro,
                       pe.Nombre + ' ' + pe.Apellido    AS Reportante
                FROM   Gestion_Incidencia          gi
                JOIN   Inventario_Equipo           ie ON gi.IdInventario      = ie.IdInventario
                JOIN   Personal_Empleado           pe ON gi.IdEmpleadoReporta = pe.IdEmpleado
                LEFT JOIN Espacio_Medico           em ON ie.IdEspacio         = em.IdEspacio
                LEFT JOIN Infraestructura_Centro   ic ON em.IdCentro          = ic.IdCentro
                WHERE  gi.FechaRegistro BETWEEN @desde AND @hasta
                ORDER  BY gi.FechaRegistro DESC",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@desde", desde.Date);
                    cmd.Parameters.AddWithValue("@hasta", hasta.Date.AddDays(1).AddSeconds(-1));
                });
        }

        /// <summary>
        /// Reporte 3 — Top 3 consultorios mejor equipados por centro.
        /// Usa ROW_NUMBER() OVER PARTITION BY para el ranking por centro.
        /// </summary>
        public DataTable Top3ConsultoriosMejorEquipados()
        {
            return Conexion.EjecutarConsulta(@"
                WITH Ranking AS (
                    SELECT em.IdEspacio,
                           em.NombreEspacio,
                           ic.NombreCentro,
                           COUNT(ie.IdInventario) AS TotalEquipos,
                           ROW_NUMBER() OVER (
                               PARTITION BY ic.IdCentro
                               ORDER BY COUNT(ie.IdInventario) DESC
                           ) AS Posicion
                    FROM   Espacio_Medico           em
                    JOIN   Espacio_Tipo             et ON em.IdTipoEspacio = et.IdTipoEspacio
                    JOIN   Infraestructura_Centro   ic ON em.IdCentro      = ic.IdCentro
                    LEFT JOIN Inventario_Equipo     ie ON ie.IdEspacio     = em.IdEspacio
                    WHERE  et.NombreTipo = 'Consultorio Médico'
                    GROUP  BY em.IdEspacio, em.NombreEspacio,
                              ic.IdCentro,  ic.NombreCentro
                )
                SELECT NombreCentro, Posicion, NombreEspacio, TotalEquipos
                FROM   Ranking
                WHERE  Posicion <= 3
                ORDER  BY NombreCentro, Posicion");
        }

        /// <summary>
        /// Reporte 4 — Detalle de todos los equipos de un espacio por su ID.
        /// </summary>
        public DataTable EquiposPorEspacio(int idEspacio)
        {
            return Conexion.EjecutarConsulta(@"
                SELECT ie.CodigoMunicipal, ie.NumeroSerie,
                       ie.Marca, ie.Modelo,
                       ie.DescripcionTecnica, ie.EstadoActual
                FROM   Inventario_Equipo ie
                WHERE  ie.IdEspacio = @id
                ORDER  BY ie.CodigoMunicipal",
                cmd => cmd.Parameters.AddWithValue("@id", idEspacio));
        }

        /// <summary>
        /// Reporte 5 — Buscar equipo por código municipal o número de serie.
        /// Muestra en qué centro y espacio está instalado.
        /// </summary>
        public DataTable BuscarEquipo(string codigoOSerie)
        {
            return Conexion.EjecutarConsulta(@"
                SELECT ie.CodigoMunicipal, ie.NumeroSerie,
                       ie.Marca, ie.Modelo, ie.EstadoActual,
                       ISNULL(em.NombreEspacio, 'Sin asignar') AS Espacio,
                       ISNULL(ic.NombreCentro,  'Sin asignar') AS Centro
                FROM   Inventario_Equipo           ie
                LEFT JOIN Espacio_Medico           em ON ie.IdEspacio = em.IdEspacio
                LEFT JOIN Infraestructura_Centro   ic ON em.IdCentro  = ic.IdCentro
                WHERE  ie.CodigoMunicipal = @val
                   OR  ie.NumeroSerie     = @val",
                cmd => cmd.Parameters.AddWithValue("@val", codigoOSerie.Trim()));
        }
    }
}
