using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Framework.QAWorks.Base.Helpers
{
    public static class Utilities
    {
        public static void ZoomOut()
        {
            Actions zoomOut = new Actions(Browser.Driver);
            zoomOut.KeyDown(Keys.Control)
                .SendKeys(Keys.Subtract)
                .SendKeys(Keys.Subtract)
                .KeyUp(Keys.Control);
            zoomOut.Perform();
        }

        public static void ZoomBackToNormal()
        {
            Actions zoomBackToNormal = new Actions(Browser.Driver);
            zoomBackToNormal.KeyDown(Keys.Control)
                .SendKeys("0")
                .KeyUp(Keys.Control);
            zoomBackToNormal.Perform();
        }

        public static void DismissAlert()
        {
            if (Browser.IsAlertPresent())
                Browser.Driver.SwitchTo().Alert().Dismiss();
        }

    }
}