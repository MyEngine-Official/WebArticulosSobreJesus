using System.Text.Json.Serialization;

namespace QuienEsJesus.Models;

/// <summary>
/// Representa la estructura completa de la Biblia en formato JSON
/// </summary>
public class Bible
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("books")]
    public List<BibleBook> Books { get; set; } = new();
}

/// <summary>
/// Representa un libro de la Biblia
/// </summary>
public class BibleBook
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("verses")]
    public List<BibleVerse> Verses { get; set; } = new();
}

/// <summary>
/// Representa un versículo de la Biblia
/// </summary>
public class BibleVerse
{
    [JsonPropertyName("Chapter")]
    public int Chapter { get; set; }

    [JsonPropertyName("Verse")]
    public int Verse { get; set; }

    [JsonPropertyName("Text")]
    public string Text { get; set; } = string.Empty;
}
