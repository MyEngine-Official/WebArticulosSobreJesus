using QuienEsJesus.Models;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace QuienEsJesus.Services;

/// <summary>
/// Servicio para acceder a la Biblia LBLA local en formato JSON
/// </summary>
public class BibleService
{
    private readonly HttpClient _httpClient;
    private Bible? _bible;
    private bool _initialized = false;

    public BibleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Inicializa el servicio cargando la Biblia desde el archivo JSON
    /// </summary>
    public async Task InitializeAsync()
    {
        if (_initialized) return;

        try
        {
            var json = await _httpClient.GetStringAsync("LBLAxmm.json");
            _bible = JsonSerializer.Deserialize<Bible>(json);
            _initialized = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading Bible: {ex.Message}");
            _bible = new Bible { Name = "LBLA", Books = new List<BibleBook>() };
            _initialized = true;
        }
    }

    /// <summary>
    /// Obtiene todos los libros de la Biblia
    /// </summary>
    public List<BibleBook> GetAllBooks()
    {
        return _bible?.Books ?? new List<BibleBook>();
    }

    /// <summary>
    /// Obtiene un libro por su nombre (case-insensitive y accent-insensitive)
    /// </summary>
    public BibleBook? GetBookByName(string bookName)
    {
        var searchNormalized = RemoveAccents(bookName.ToLowerInvariant());
        return _bible?.Books.FirstOrDefault(b => 
            RemoveAccents(b.Name.ToLowerInvariant()).Contains(searchNormalized) ||
            RemoveAccents(b.Id.ToLowerInvariant()).Contains(searchNormalized));
    }

    /// <summary>
    /// Obtiene un versículo específico
    /// </summary>
    public BibleVerse? GetVerse(string bookName, int chapter, int verse)
    {
        var book = GetBookByName(bookName);
        return book?.Verses.FirstOrDefault(v => v.Chapter == chapter && v.Verse == verse);
    }

    /// <summary>
    /// Obtiene el texto de un versículo específico
    /// </summary>
    public string? GetVerseText(string bookName, int chapter, int verse)
    {
        return GetVerse(bookName, chapter, verse)?.Text;
    }

    /// <summary>
    /// Obtiene todos los versículos de un capítulo
    /// </summary>
    public List<BibleVerse> GetChapter(string bookName, int chapter)
    {
        var book = GetBookByName(bookName);
        return book?.Verses.Where(v => v.Chapter == chapter).ToList() ?? new List<BibleVerse>();
    }

    /// <summary>
    /// Obtiene un rango de versículos
    /// </summary>
    public List<BibleVerse> GetVerseRange(string bookName, int chapter, int startVerse, int endVerse)
    {
        var book = GetBookByName(bookName);
        return book?.Verses
            .Where(v => v.Chapter == chapter && v.Verse >= startVerse && v.Verse <= endVerse)
            .OrderBy(v => v.Verse)
            .ToList() ?? new List<BibleVerse>();
    }

    /// <summary>
    /// Busca versículos que contengan un texto específico (case-insensitive y accent-insensitive)
    /// Busca en el texto del versículo, nombre del libro y referencia
    /// </summary>
    public List<BibleSearchResult> SearchByText(string searchText, int maxResults = 50)
    {
        if (_bible == null || string.IsNullOrWhiteSpace(searchText))
            return new List<BibleSearchResult>();

        var results = new List<BibleSearchResult>();
        var searchNormalized = RemoveAccents(searchText.ToLowerInvariant());

        foreach (var book in _bible.Books)
        {
            var bookNameNormalized = RemoveAccents(book.Name.ToLowerInvariant());
            
            foreach (var verse in book.Verses)
            {
                var textNormalized = RemoveAccents(verse.Text.ToLowerInvariant());
                var reference = $"{book.Name} {verse.Chapter}:{verse.Verse}";
                var referenceNormalized = RemoveAccents(reference.ToLowerInvariant());

                // Search in text, book name, or reference
                if (textNormalized.Contains(searchNormalized) || 
                    bookNameNormalized.Contains(searchNormalized) ||
                    referenceNormalized.Contains(searchNormalized))
                {
                    results.Add(new BibleSearchResult
                    {
                        BookName = book.Name,
                        Chapter = verse.Chapter,
                        Verse = verse.Verse,
                        Text = verse.Text
                    });

                    if (results.Count >= maxResults)
                        return results;
                }
            }
        }

        return results;
    }

    /// <summary>
    /// Remueve los acentos de un texto para búsqueda normalizada
    /// </summary>
    private static string RemoveAccents(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    /// <summary>
    /// Obtiene el número de capítulos en un libro
    /// </summary>
    public int GetChapterCount(string bookName)
    {
        var book = GetBookByName(bookName);
        if (book == null || !book.Verses.Any())
            return 0;
        return book.Verses.Max(v => v.Chapter);
    }

    /// <summary>
    /// Obtiene el número de versículos en un capítulo
    /// </summary>
    public int GetVerseCount(string bookName, int chapter)
    {
        var book = GetBookByName(bookName);
        if (book == null)
            return 0;
        return book.Verses.Count(v => v.Chapter == chapter);
    }

    /// <summary>
    /// Formatea una referencia bíblica completa
    /// </summary>
    public string FormatReference(string bookName, int chapter, int verse)
    {
        return $"{bookName} {chapter}:{verse}";
    }

    /// <summary>
    /// Formatea una referencia bíblica con rango de versículos
    /// </summary>
    public string FormatReferenceRange(string bookName, int chapter, int startVerse, int endVerse)
    {
        return $"{bookName} {chapter}:{startVerse}-{endVerse}";
    }
}

/// <summary>
/// Resultado de búsqueda en la Biblia
/// </summary>
public class BibleSearchResult
{
    public string BookName { get; set; } = string.Empty;
    public int Chapter { get; set; }
    public int Verse { get; set; }
    public string Text { get; set; } = string.Empty;

    public string Reference => $"{BookName} {Chapter}:{Verse}";
}
