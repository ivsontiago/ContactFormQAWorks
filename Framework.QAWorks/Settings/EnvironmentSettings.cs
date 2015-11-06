using System.Configuration;

namespace Ve.Test.Framework.Base.EnvironmentSettings
{
    public class EnvironmentSettings : ISettings
    {
       public string ContactUsPageUrl
        {
            get
            {
                return ConfigurationSettings.AppSettings["ContactUsPageUrl"];
            }
        }
    }
}