using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Globalization;

namespace QuienEsJesus.Services;

public class BibleService
{
    private readonly HttpClient _httpClient;
    private const string PrimaryApiUrl = "https://bible-api.com";
    private const string DefaultTranslation = "rvr"; // Reina-Valera Revisada (Spanish)
    
    private static readonly Dictionary<string, string> SpanishBookNames = new()
    {
        // Old Testament
        {"genesis", "Génesis"}, {"gen", "Génesis"},
        {"exodus", "Éxodo"}, {"exo", "Éxodo"},
        {"leviticus", "Levítico"}, {"lev", "Levítico"},
        {"numbers", "Números"}, {"num", "Números"},
        {"deuteronomy", "Deuteronomio"}, {"deut", "Deuteronomio"},
        {"joshua", "Josué"}, {"josh", "Josué"},
        {"judges", "Jueces"}, {"judg", "Jueces"},
        {"ruth", "Rut"},
        {"1 samuel", "1 Samuel"}, {"1sam", "1 Samuel"},
        {"2 samuel", "2 Samuel"}, {"2sam", "2 Samuel"},
        {"1 kings", "1 Reyes"}, {"1kgs", "1 Reyes"},
        {"2 kings", "2 Reyes"}, {"2kgs", "2 Reyes"},
        {"1 chronicles", "1 Crónicas"}, {"1chr", "1 Crónicas"},
        {"2 chronicles", "2 Crónicas"}, {"2chr", "2 Crónicas"},
        {"ezra", "Esdras"},
        {"nehemiah", "Nehemías"}, {"neh", "Nehemías"},
        {"esther", "Ester"}, {"est", "Ester"},
        {"job", "Job"},
        {"psalms", "Salmos"}, {"psalm", "Salmos"}, {"ps", "Salmos"},
        {"proverbs", "Proverbios"}, {"prov", "Proverbios"},
        {"ecclesiastes", "Eclesiastés"}, {"eccl", "Eclesiastés"},
        {"song of solomon", "Cantares"}, {"song", "Cantares"},
        {"isaiah", "Isaías"}, {"isa", "Isaías"},
        {"jeremiah", "Jeremías"}, {"jer", "Jeremías"},
        {"lamentations", "Lamentaciones"}, {"lam", "Lamentaciones"},
        {"ezekiel", "Ezequiel"}, {"ezek", "Ezequiel"},
        {"daniel", "Daniel"}, {"dan", "Daniel"},
        {"hosea", "Oseas"}, {"hos", "Oseas"},
        {"joel", "Joel"},
        {"amos", "Amós"},
        {"obadiah", "Abdías"}, {"obad", "Abdías"},
        {"jonah", "Jonás"}, {"jon", "Jonás"},
        {"micah", "Miqueas"}, {"mic", "Miqueas"},
        {"nahum", "Nahúm"}, {"nah", "Nahúm"},
        {"habakkuk", "Habacuc"}, {"hab", "Habacuc"},
        {"zephaniah", "Sofonías"}, {"zeph", "Sofonías"},
        {"haggai", "Hageo"}, {"hag", "Hageo"},
        {"zechariah", "Zacarías"}, {"zech", "Zacarías"},
        {"malachi", "Malaquías"}, {"mal", "Malaquías"},
        // New Testament
        {"matthew", "Mateo"}, {"matt", "Mateo"}, {"mat", "Mateo"},
        {"mark", "Marcos"}, {"mar", "Marcos"},
        {"luke", "Lucas"}, {"luk", "Lucas"},
        {"john", "Juan"}, {"joh", "Juan"},
        {"acts", "Hechos"}, {"act", "Hechos"},
        {"romans", "Romanos"}, {"rom", "Romanos"},
        {"1 corinthians", "1 Corintios"}, {"1cor", "1 Corintios"},
        {"2 corinthians", "2 Corintios"}, {"2cor", "2 Corintios"},
        {"galatians", "Gálatas"}, {"gal", "Gálatas"},
        {"ephesians", "Efesios"}, {"eph", "Efesios"},
        {"philippians", "Filipenses"}, {"phil", "Filipenses"},
        {"colossians", "Colosenses"}, {"col", "Colosenses"},
        {"1 thessalonians", "1 Tesalonicenses"}, {"1thess", "1 Tesalonicenses"},
        {"2 thessalonians", "2 Tesalonicenses"}, {"2thess", "2 Tesalonicenses"},
        {"1 timothy", "1 Timoteo"}, {"1tim", "1 Timoteo"},
        {"2 timothy", "2 Timoteo"}, {"2tim", "2 Timoteo"},
        {"titus", "Tito"},
        {"philemon", "Filemón"}, {"philem", "Filemón"},
        {"hebrews", "Hebreos"}, {"heb", "Hebreos"},
        {"james", "Santiago"}, {"jam", "Santiago"},
        {"1 peter", "1 Pedro"}, {"1pet", "1 Pedro"},
        {"2 peter", "2 Pedro"}, {"2pet", "2 Pedro"},
        {"1 john", "1 Juan"}, {"1jn", "1 Juan"},
        {"2 john", "2 Juan"}, {"2jn", "2 Juan"},
        {"3 john", "3 Juan"}, {"3jn", "3 Juan"},
        {"jude", "Judas"},
        {"revelation", "Apocalipsis"}, {"rev", "Apocalipsis"}
    };

    // Mapping from Spanish book names (normalized, no accents) to English for API calls
    private static readonly Dictionary<string, string> SpanishToEnglishBooks = new(StringComparer.OrdinalIgnoreCase)
    {
        {"genesis", "genesis"},
        {"exodo", "exodus"},
        {"levitico", "leviticus"},
        {"numeros", "numbers"},
        {"deuteronomio", "deuteronomy"},
        {"josue", "joshua"},
        {"jueces", "judges"},
        {"rut", "ruth"},
        {"samuel", "samuel"},
        {"reyes", "kings"},
        {"cronicas", "chronicles"},
        {"esdras", "ezra"},
        {"nehemias", "nehemiah"},
        {"ester", "esther"},
        {"job", "job"},
        {"salmos", "psalms"},
        {"salmo", "psalm"},
        {"proverbios", "proverbs"},
        {"eclesiastes", "ecclesiastes"},
        {"cantares", "song of solomon"},
        {"isaias", "isaiah"},
        {"jeremias", "jeremiah"},
        {"lamentaciones", "lamentations"},
        {"ezequiel", "ezekiel"},
        {"daniel", "daniel"},
        {"oseas", "hosea"},
        {"joel", "joel"},
        {"amos", "amos"},
        {"abdias", "obadiah"},
        {"jonas", "jonah"},
        {"miqueas", "micah"},
        {"nahum", "nahum"},
        {"habacuc", "habakkuk"},
        {"sofonias", "zephaniah"},
        {"hageo", "haggai"},
        {"zacarias", "zechariah"},
        {"malaquias", "malachi"},
        {"mateo", "matthew"},
        {"marcos", "mark"},
        {"lucas", "luke"},
        {"juan", "john"},
        {"hechos", "acts"},
        {"romanos", "romans"},
        {"corintios", "corinthians"},
        {"galatas", "galatians"},
        {"efesios", "ephesians"},
        {"filipenses", "philippians"},
        {"colosenses", "colossians"},
        {"tesalonicenses", "thessalonians"},
        {"timoteo", "timothy"},
        {"tito", "titus"},
        {"filemon", "philemon"},
        {"hebreos", "hebrews"},
        {"santiago", "james"},
        {"pedro", "peter"},
        {"judas", "jude"},
        {"apocalipsis", "revelation"}
    };

    public BibleService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<BibleVerseResult?> GetVerseAsync(string reference, string? translation = null)
    {
        // Use Spanish RVR translation by default
        translation ??= DefaultTranslation;
        
        // Normalize the reference - translate Spanish book names to English for the API
        var normalizedReference = NormalizeReferenceForApi(reference);
        
        try
        {
            var encodedRef = Uri.EscapeDataString(normalizedReference);
            var url = $"{PrimaryApiUrl}/{encodedRef}?translation={translation}";
            
            var response = await _httpClient.GetAsync(url);
            
            if (!response.IsSuccessStatusCode)
                return null;

            var result = await response.Content.ReadFromJsonAsync<BibleApiResponse>();
            
            if (result == null)
                return null;

            // Get the Spanish translation name
            var translationName = GetSpanishTranslationName(translation);

            return new BibleVerseResult
            {
                Reference = result.Reference ?? reference,
                ReferenceSpanish = TranslateReference(result.Reference ?? reference),
                Text = result.Text ?? string.Empty,
                Translation = translationName,
                Verses = result.Verses?.Select(v => new BibleVerse
                {
                    BookName = v.BookName ?? string.Empty,
                    Chapter = v.Chapter,
                    Verse = v.Verse,
                    Text = v.Text ?? string.Empty
                }).ToList() ?? new List<BibleVerse>()
            };
        }
        catch (HttpRequestException)
        {
            return null;
        }
        catch (TaskCanceledException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private string NormalizeReferenceForApi(string reference)
    {
        // Remove accents from the reference for consistent dictionary lookup
        var normalizedInput = RemoveAccents(reference.Trim());
        
        // Split the reference to find book name (handles numbered books like "1 Juan")
        var words = normalizedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        
        for (int i = 0; i < words.Count; i++)
        {
            var word = words[i];
            
            // Check if this is a numbered book prefix
            if (i < words.Count - 1 && char.IsDigit(word[0]) && word.Length == 1)
            {
                continue; // Skip the number, will be handled with next word
            }
            
            // Check if previous was a number (for books like "1 Juan")
            var lookupWord = word;
            if (i > 0 && words[i - 1].Length == 1 && char.IsDigit(words[i - 1][0]))
            {
                // This is part of a numbered book, lookup just the book name
            }
            
            if (SpanishToEnglishBooks.TryGetValue(lookupWord, out var englishBook))
            {
                words[i] = englishBook;
            }
        }
        
        return string.Join(" ", words);
    }

    private static string RemoveAccents(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new System.Text.StringBuilder();

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

    private static string GetSpanishTranslationName(string translation)
    {
        return translation.ToLower() switch
        {
            "rvr" => "Reina-Valera Revisada",
            "rvr60" => "Reina-Valera 1960",
            "rvr95" => "Reina-Valera 1995",
            "lbla" => "La Biblia de las Américas",
            "nvi" => "Nueva Versión Internacional",
            _ => translation.ToUpper()
        };
    }

    public async Task<List<BibleVerseResult>> SearchVersesAsync(string query, string? translation = null)
    {
        // bible-api.com doesn't have search, so we'll return suggestions based on common references
        var results = new List<BibleVerseResult>();
        
        // Try to parse as a reference first
        var verse = await GetVerseAsync(query, translation);
        if (verse != null)
        {
            results.Add(verse);
        }
        
        return results;
    }

    public List<string> GetPopularReferences()
    {
        return new List<string>
        {
            "Juan 3:16",
            "Salmos 23",
            "Romanos 8:28",
            "Filipenses 4:13",
            "Jeremías 29:11",
            "Proverbios 3:5-6",
            "Isaías 40:31",
            "Mateo 11:28-30",
            "Romanos 12:1-2",
            "1 Corintios 13:4-8"
        };
    }

    private string TranslateReference(string reference)
    {
        var result = reference;
        foreach (var kvp in SpanishBookNames)
        {
            var pattern = $@"\b{Regex.Escape(kvp.Key)}\b";
            result = Regex.Replace(result, pattern, kvp.Value, RegexOptions.IgnoreCase);
        }
        return result;
    }
}

public class BibleApiResponse
{
    [JsonPropertyName("reference")]
    public string? Reference { get; set; }

    [JsonPropertyName("verses")]
    public List<BibleApiVerse>? Verses { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("translation_id")]
    public string? TranslationId { get; set; }

    [JsonPropertyName("translation_name")]
    public string? TranslationName { get; set; }

    [JsonPropertyName("translation_note")]
    public string? TranslationNote { get; set; }
}

public class BibleApiVerse
{
    [JsonPropertyName("book_id")]
    public string? BookId { get; set; }

    [JsonPropertyName("book_name")]
    public string? BookName { get; set; }

    [JsonPropertyName("chapter")]
    public int Chapter { get; set; }

    [JsonPropertyName("verse")]
    public int Verse { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

public class BibleVerseResult
{
    public string Reference { get; set; } = string.Empty;
    public string ReferenceSpanish { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
    public List<BibleVerse> Verses { get; set; } = new();
}

public class BibleVerse
{
    public string BookName { get; set; } = string.Empty;
    public int Chapter { get; set; }
    public int Verse { get; set; }
    public string Text { get; set; } = string.Empty;
}
