using System;

namespace GestionSalud.Modelos
{
    public class Incidencia
    {
        public int      IdIncidencia        { get; set; }
        public DateTime FechaRegistro       { get; set; }
        public string   DescripcionProblema { get; set; }
        public string   TipoAccion          { get; set; }  // 'Mantenimiento','Reparación','Calibración'
        public int      IdInventario        { get; set; }
        public string   CodigoMunicipal     { get; set; }
        public int      IdEmpleadoReporta   { get; set; }
        public string   NombreEmpleado      { get; set; }
    }
}
