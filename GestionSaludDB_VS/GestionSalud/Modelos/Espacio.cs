namespace GestionSalud.Modelos
{
    public class Espacio
    {
        public int    IdEspacio       { get; set; }
        public string NombreEspacio   { get; set; }
        public int    IdCentro        { get; set; }
        public string NombreCentro    { get; set; }
        public int    IdTipoEspacio   { get; set; }
        public string NombreTipo      { get; set; }
        public int?   CapacidadEspera { get; set; }
    }
}
