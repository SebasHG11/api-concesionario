namespace apiconcesionario.Models
{
    public class Auto
    {
        public int Id {get; set;}
        public int MarcaId {get; set;}
        public string Modelo {get; set;}
        public string Color {get; set; }
        public string Descripcion {get; set;}
        public string Image {get; set;}
        public virtual Marca Marca {get; set;}
    }
}