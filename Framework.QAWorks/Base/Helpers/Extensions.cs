using OpenQA.Selenium;

namespace Framework.QAWorks.Base.Helpers
{
    public static class Extensions
    {
        public static bool IsVisible(this IWebElement element)
        {
            try
            {
                var isVisible = element.Displayed;
                return isVisible;
            }
            catch (ElementNotVisibleException)
            {
                return false;
            }
        }
        
    }
}