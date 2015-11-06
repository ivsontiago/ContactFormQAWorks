using Framework.QAWorks.Base;
using Framework.QAWorks.Base.Helpers;
using TechTalk.SpecFlow;

namespace Tests.QAWorks.Setup
{
    [Binding]
    public static class TestsSetUp
    {
        [BeforeTestRun]
        public static void StartExecution()
        {
                Browser.Initialize();
                Browser.MaximizeBrowser();
        }

        [AfterScenario]
        public static void FinishExecution()
        {
            Utilities.ZoomBackToNormal();
            if (ScenarioContext.Current.TestError != null)
            {
                Browser.TakeScreenshotOnException(ScenarioContext.Current.ScenarioInfo.Title);
            }
        }

        [AfterTestRun]
        public static void CloseDriverAfterAllTests()
        {
            Browser.Quit();
        }
    }
}