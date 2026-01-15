namespace QuienEsJesus.Helpers;

public static class BuildConfiguration
{
    public static bool IsDebugMode
    {
        get
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }

    public static bool IsReleaseMode => !IsDebugMode;
}
