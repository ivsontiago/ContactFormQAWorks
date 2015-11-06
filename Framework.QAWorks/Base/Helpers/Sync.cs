using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Framework.QAWorks.Base.Helpers
{
    public static class Sync
    {
        public static void SetImplicitlyWait(int timeInSeconds)
        {
            Browser.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(timeInSeconds));
        }

        public static T WaitFor<T>(int timeInSeconds, Func<IWebDriver, T> condition)
        {
            IWait<IWebDriver> wait = new WebDriverWait(Browser.Driver, TimeSpan.FromSeconds(timeInSeconds));
            return wait.Until(condition);
        }

        public static IWebElement WaitForElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds <= 0) return driver.FindElement(by);
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
                
    }
}
