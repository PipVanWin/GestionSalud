using System;
using System.Data;
using GestionSalud.Datos;
using GestionSalud.Modelos;

namespace GestionSalud.Servicios
{
    /// <summary>
    /// Toda la lógica de equipos, espacios e incidencias.
    /// Los formularios SOLO llaman métodos de este servicio.
    /// </summary>
    public class InventarioService
    {
        // ── EQUIPOS ────────────────────────────────────────────────────

        /// <summary>Equipos sin asignar (IdEspacio IS NULL).</summary>
        public DataTable ListarEquiposDisponibles()
        {
            return Conexion.EjecutarConsulta(@"
                SELECT IdInventario, CodigoMunicipal, NumeroSerie,
                       Marca, Modelo, EstadoActual
                FROM   Inventario_Equipo
                WHERE  IdEspacio IS NULL
                ORDER  BY CodigoMunicipal");
        }

        /// <summary>Todos los equipos con el espacio donde están instalados.</summary>
        public DataTable ListarTodosLosEquipos()
        {
            return Conexion.EjecutarConsulta(@"
                SELECT ie.IdInventario, ie.CodigoMunicipal, ie.NumeroSerie,
                       ie.Marca, ie.Modelo, ie.EstadoActual,
                       ISNULL(em.NombreEspacio, 'Sin asignar') AS Espacio,
                       ISNULL(ic.NombreCentro,  'Sin asignar') AS Centro
                FROM   Inventario_Equipo             ie
                LEFT JOIN Espacio_Medico             em ON ie.IdEspacio  = em.IdEspacio
                LEFT JOIN Infraestructura_Centro     ic ON em.IdCentro   = ic.IdCentro
                ORDER  BY ie.CodigoMunicipal");
        }

        /// <summary>Inserta un equipo nuevo.</summary>
        public void InsertarEquipo(Equipo e)
        {
            Conexion.EjecutarComando(@"
                INSERT INTO Inventario_Equipo
                       (IdInventario, CodigoMunicipal, NumeroSerie,
                        Marca, Modelo, DescripcionTecnica, EstadoActual)
                VALUES (@id, @codigo, @serie, @marca, @modelo, @desc, @estado)",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id",     e.IdInventario);
                    cmd.Parameters.AddWithValue("@codigo", e.CodigoMunicipal);
                    cmd.Parameters.AddWithValue("@serie",  e.NumeroSerie);
                    cmd.Parameters.AddWithValue("@marca",  e.Marca   ?? "");
                    cmd.Parameters.AddWithValue("@modelo", e.Modelo  ?? "");
                    cmd.Parameters.AddWithValue("@desc",   e.DescripcionTecnica ?? "");
                    cmd.Parameters.AddWithValue("@estado", e.EstadoActual ?? "Activo");
                });
        }

        /// <summary>Actualiza un equipo existente.</summary>
        public void ActualizarEquipo(Equipo e)
        {
            Conexion.EjecutarComando(@"
                UPDATE Inventario_Equipo
                SET    CodigoMunicipal    = @codigo,
                       NumeroSerie        = @serie,
                       Marca              = @marca,
                       Modelo             = @modelo,
                       DescripcionTecnica = @desc,
                       EstadoActual       = @estado
                WHERE  IdInventario = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id",     e.IdInventario);
                    cmd.Parameters.AddWithValue("@codigo", e.CodigoMunicipal);
                    cmd.Parameters.AddWithValue("@serie",  e.NumeroSerie);
                    cmd.Parameters.AddWithValue("@marca",  e.Marca   ?? "");
                    cmd.Parameters.AddWithValue("@modelo", e.Modelo  ?? "");
                    cmd.Parameters.AddWithValue("@desc",   e.DescripcionTecnica ?? "");
                    cmd.Parameters.AddWithValue("@estado", e.EstadoActual ?? "Activo");
                });
        }

        /// <summary>
        /// Elimina un equipo solo si no tiene incidencias.
        /// Devuelve false si no se puede eliminar.
        /// </summary>
        public bool EliminarEquipo(int idInventario)
        {
            var count = Convert.ToInt32(Conexion.EjecutarEscalar(
                "SELECT COUNT(*) FROM Gestion_Incidencia WHERE IdInventario = @id",
                cmd => cmd.Parameters.AddWithValue("@id", idInventario)));

            if (count > 0) return false;

            Conexion.EjecutarComando(
                "DELETE FROM Inventario_Equipo WHERE IdInventario = @id",
                cmd => cmd.Parameters.AddWithValue("@id", idInventario));

            return true;
        }

        // ── ASIGNACIÓN ─────────────────────────────────────────────────

        /// <summary>Vincula un equipo a un espacio físico.</summary>
        public void AsignarEquipoAEspacio(int idInventario, int idEspacio)
        {
            Conexion.EjecutarComando(@"
                UPDATE Inventario_Equipo
                SET    IdEspacio = @espacio
                WHERE  IdInventario = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@espacio", idEspacio);
                    cmd.Parameters.AddWithValue("@id",      idInventario);
                });
        }

        /// <summary>Quita la asignación de un equipo (lo deja disponible).</summary>
        public void DesasignarEquipo(int idInventario)
        {
            Conexion.EjecutarComando(
                "UPDATE Inventario_Equipo SET IdEspacio = NULL WHERE IdInventario = @id",
                cmd => cmd.Parameters.AddWithValue("@id", idInventario));
        }

        // ── INCIDENCIAS ────────────────────────────────────────────────

        /// <summary>Registra una incidencia o mantenimiento.</summary>
        public void RegistrarIncidencia(int idInventario, int idEmpleado,
            string descripcion, string tipoAccion)
        {
            Conexion.EjecutarComando(@"
                INSERT INTO Gestion_Incidencia
                       (DescripcionProblema, TipoAccion, IdInventario, IdEmpleadoReporta)
                VALUES (@desc, @tipo, @idEquipo, @idEmp)",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@desc",     descripcion);
                    cmd.Parameters.AddWithValue("@tipo",     tipoAccion);
                    cmd.Parameters.AddWithValue("@idEquipo", idInventario);
                    cmd.Parameters.AddWithValue("@idEmp",    idEmpleado);
                });
        }

        // ── CENTROS Y ESPACIOS ─────────────────────────────────────────

        public DataTable ListarCentros()
        {
            return Conexion.EjecutarConsulta(
                "SELECT IdCentro, NombreCentro FROM Infraestructura_Centro ORDER BY NombreCentro");
        }

        public DataTable ListarEspaciosPorCentro(int idCentro)
        {
            return Conexion.EjecutarConsulta(@"
                SELECT em.IdEspacio, em.NombreEspacio, et.NombreTipo
                FROM   Espacio_Medico em
                JOIN   Espacio_Tipo   et ON em.IdTipoEspacio = et.IdTipoEspacio
                WHERE  em.IdCentro = @id
                ORDER  BY em.NombreEspacio",
                cmd => cmd.Parameters.AddWithValue("@id", idCentro));
        }

        /// <summary>Todos los equipos de un espacio para la hoja de inventario.</summary>
        public DataTable HojaInventarioPorEspacio(int idEspacio)
        {
            return Conexion.EjecutarConsulta(@"
                SELECT ie.CodigoMunicipal, ie.NumeroSerie, ie.Marca,
                       ie.Modelo, ie.DescripcionTecnica, ie.EstadoActual,
                       em.NombreEspacio, ic.NombreCentro
                FROM   Inventario_Equipo         ie
                JOIN   Espacio_Medico             em ON ie.IdEspacio = em.IdEspacio
                JOIN   Infraestructura_Centro     ic ON em.IdCentro  = ic.IdCentro
                WHERE  ie.IdEspacio = @id
                ORDER  BY ie.CodigoMunicipal",
                cmd => cmd.Parameters.AddWithValue("@id", idEspacio));
        }

        /// <summary>Genera el siguiente ID disponible para un equipo nuevo.</summary>
        public int SiguienteIdEquipo()
        {
            var resultado = Conexion.EjecutarEscalar(
                "SELECT ISNULL(MAX(IdInventario), 0) + 1 FROM Inventario_Equipo");
            return Convert.ToInt32(resultado);
        }
    }
}
