using System.Text.Json.Serialization;

namespace apiconcesionario.Models
{
    public class Marca
    {
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Image {get; set;}
        
        [JsonIgnore]
        public ICollection<Auto> Autos {get; set;}
    }
}