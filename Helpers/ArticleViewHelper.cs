using QuienEsJesus.Models;

namespace QuienEsJesus.Helpers;

public class ArticleViewHelper
{
    private bool _productionMode = false;

    public bool ProductionMode
    {
        get => _productionMode;
        set => _productionMode = value;
    }

    public bool ShouldShowArticle(Article article)
    {
        // En modo release, solo mostrar públicos
        if (BuildConfiguration.IsReleaseMode)
        {
            return article.EsPublico;
        }

        // En modo debug, depende del toggle
        if (_productionMode)
        {
            return article.EsPublico;
        }

        // En modo debug sin toggle, mostrar todos
        return true;
    }

    public bool CanEditArticles()
    {
        return BuildConfiguration.IsDebugMode && !_productionMode;
    }

    public bool ShowDebugControls()
    {
        return BuildConfiguration.IsDebugMode;
    }

    public void ToggleProductionMode()
    {
        if (BuildConfiguration.IsDebugMode)
        {
            _productionMode = !_productionMode;
        }
    }
}
