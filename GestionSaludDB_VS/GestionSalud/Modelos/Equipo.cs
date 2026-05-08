namespace GestionSalud.Modelos
{
    public class Equipo
    {
        public int    IdInventario       { get; set; }
        public string CodigoMunicipal    { get; set; }
        public string NumeroSerie        { get; set; }
        public string Marca              { get; set; }
        public string Modelo             { get; set; }
        public string DescripcionTecnica { get; set; }
        public string EstadoActual       { get; set; }
        public int?   IdEspacio          { get; set; }  // NULL = sin asignar
        public string NombreEspacio      { get; set; }
    }
}
