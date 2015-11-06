namespace Ve.Test.Framework.Base.EnvironmentSettings
{
    public static class Settings
    {        
        public readonly static ISettings Instance;

        static Settings()
        {
            Instance = new EnvironmentSettings();
        }
        
    }
}