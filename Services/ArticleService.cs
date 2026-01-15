using QuienEsJesus.Models;
using Microsoft.JSInterop;
using System.Text.Json;

namespace QuienEsJesus.Services;

public class ArticleService
{
    private const string StorageKey = "articles";
    private List<Article> _articles = new();
    private readonly IJSRuntime? _jsRuntime;
    private bool _initialized = false;

    public ArticleService()
    {
        // Constructor vacío para cuando no hay JSRuntime disponible
    }

    public ArticleService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task InitializeAsync()
    {
        if (_initialized || _jsRuntime == null) return;

        try
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", StorageKey);
            if (!string.IsNullOrEmpty(json))
            {
                _articles = JsonSerializer.Deserialize<List<Article>>(json) ?? new();
            }
            else
            {
                // Si no hay datos en localStorage, cargar datos de ejemplo
                await LoadSampleData();
            }
            _initialized = true;
        }
        catch
        {
            // Si falla, usar datos de ejemplo
            LoadSampleDataSync();
            _initialized = true;
        }
    }

    private async Task LoadSampleData()
    {
        // Crear algunos artículos de ejemplo
        _articles = new List<Article>
        {
            new Article
            {
                Titulo = "¿Quién es Jesús? Una Introducción",
                Descripcion = "Explorando la figura central del cristianismo y su impacto en la historia.",
                Contenido = @"## La Pregunta Fundamental

""¿Quién es Jesús?"" Es una de las preguntas más importantes de la historia humana. La respuesta a esta pregunta ha moldeado civilizaciones, inspirado arte, literatura y música, y continúa siendo relevante para millones de personas en todo el mundo.

### El Jesús Histórico

Jesús de Nazaret vivió en Palestina durante el siglo I d.C., bajo el dominio romano. Las fuentes históricas, tanto cristianas como no cristianas, confirman su existencia y algunos hechos básicos de su vida:

- Nació en Belén durante el reinado de Herodes el Grande
- Creció en Nazaret, una pequeña aldea de Galilea
- Comenzó su ministerio público alrededor de los 30 años
- Fue crucificado bajo Poncio Pilato

### Sus Enseñanzas

Jesús enseñó sobre:

1. **El Reino de Dios**: Un nuevo orden basado en el amor y la justicia
2. **El Amor al Prójimo**: Incluyendo a enemigos y marginados
3. **La Transformación Interior**: Más allá del cumplimiento externo de normas
4. **La Misericordia y el Perdón**: Como camino hacia la reconciliación

> ""Ama a tu prójimo como a ti mismo"" - Una de sus enseñanzas más conocidas

### Su Identidad

Las afirmaciones de Jesús sobre sí mismo han sido objeto de estudio y debate durante siglos. Él:

- Se presentó con autoridad para perdonar pecados
- Afirmó tener una relación única con Dios
- Habló de su propia muerte y resurrección
- Invitó a sus seguidores a seguirle completamente

## Conclusión

La pregunta ""¿Quién es Jesús?"" no tiene una respuesta simple. Requiere explorar la evidencia histórica, las fuentes bíblicas, y las diversas perspectivas teológicas. Este es solo el comienzo de una exploración más profunda.",
                PieDePagina = @"**Referencias Sugeridas**:
- *Jesús de Nazaret* - Joseph Ratzinger (Benedicto XVI)
- *The Historical Jesus* - John Dominic Crossan
- *Simply Jesus* - N.T. Wright

*Este artículo busca presentar información objetiva para el estudio y la reflexión personal.*",
                EsPublico = true,
                FechaPublicacion = DateTime.Now.AddDays(-5)
            },
            new Article
            {
                Titulo = "Las Enseñanzas de Jesús: El Sermón del Monte",
                Descripcion = "Un análisis del discurso más famoso de Jesús y su relevancia contemporánea.",
                Contenido = @"## El Sermón del Monte

El Sermón del Monte (Mateo 5-7) es considerado uno de los discursos éticos más influyentes de la historia humana.

### Las Bienaventuranzas

Jesús comenzó con declaraciones que desafiaban las normas sociales:

- ""Bienaventurados los pobres en espíritu""
- ""Bienaventurados los mansos""
- ""Bienaventurados los misericordiosos""

Estas afirmaciones revolucionaron el concepto de bendición y éxito.

### Principios Revolucionarios

El sermón incluye enseñanzas sobre:

1. **No resistir al mal con violencia**
2. **Amar a los enemigos**
3. **Orar en secreto**
4. **No juzgar a otros**
5. **La regla de oro**: ""Trata a los demás como quieres ser tratado""

## Impacto Histórico

Estas enseñanzas han influido en:
- Movimientos de no violencia (Gandhi, MLK)
- Sistemas éticos occidentales
- Arte y literatura universal
- Organizaciones humanitarias",
                PieDePagina = @"**Fuente Principal**: Evangelio según San Mateo, capítulos 5-7

*Estas enseñanzas han sido interpretadas de diversas formas a lo largo de la historia cristiana.*",
                EsPublico = true,
                FechaPublicacion = DateTime.Now.AddDays(-3)
            }
        };

        await SaveArticlesAsync();
    }

    private void LoadSampleDataSync()
    {
        _articles = new List<Article>
        {
            new Article
            {
                Titulo = "Bienvenido",
                Descripcion = "Crea tu primer artículo explorando la identidad de Jesús",
                Contenido = "Este es un artículo de ejemplo. Haz clic en 'Nuevo Artículo' para comenzar.",
                EsPublico = true,
                FechaPublicacion = DateTime.Now
            }
        };
    }

    private async Task SaveArticlesAsync()
    {
        if (_jsRuntime == null) return;

        try
        {
            var json = JsonSerializer.Serialize(_articles);
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", StorageKey, json);
        }
        catch
        {
            // Error guardando en localStorage
        }
    }

    public List<Article> GetAllArticles() => _articles.OrderByDescending(a => a.FechaPublicacion).ToList();

    public List<Article> GetPublicArticles() => _articles
        .Where(a => a.EsPublico)
        .OrderByDescending(a => a.FechaPublicacion)
        .ToList();

    public Article? GetArticleById(string id) => _articles.FirstOrDefault(a => a.Id == id);

    public async Task AddArticleAsync(Article article)
    {
        article.Id = Guid.NewGuid().ToString();
        article.FechaPublicacion = DateTime.Now;
        _articles.Add(article);
        await SaveArticlesAsync();
    }

    public async Task UpdateArticleAsync(Article article)
    {
        var index = _articles.FindIndex(a => a.Id == article.Id);
        if (index >= 0)
        {
            _articles[index] = article;
            await SaveArticlesAsync();
        }
    }

    public async Task DeleteArticleAsync(string id)
    {
        var article = _articles.FirstOrDefault(a => a.Id == id);
        if (article != null)
        {
            _articles.Remove(article);
            await SaveArticlesAsync();
        }
    }
}
