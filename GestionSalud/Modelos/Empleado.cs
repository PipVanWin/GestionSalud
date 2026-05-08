namespace GestionSalud.Modelos
{
    public class Empleado
    {
        public int    IdEmpleado        { get; set; }
        public string Nombre            { get; set; }
        public string Apellido          { get; set; }
        public string CorreoElectronico { get; set; }
        public int    IdRol             { get; set; }
        public string NombreRol         { get; set; }
        public int    IdCentro          { get; set; }

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
