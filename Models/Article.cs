using System.Text.Json.Serialization;

namespace QuienEsJesus.Models;

public class Article
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = string.Empty;

    [JsonPropertyName("descripcion")]
    public string Descripcion { get; set; } = string.Empty;

    [JsonPropertyName("contenido")]
    public string Contenido { get; set; } = string.Empty;

    [JsonPropertyName("pieDePagina")]
    public string PieDePagina { get; set; } = string.Empty;

    [JsonPropertyName("esPublico")]
    public bool EsPublico { get; set; } = true;

    [JsonPropertyName("fechaPublicacion")]
    public DateTime FechaPublicacion { get; set; } = DateTime.Now;
}
