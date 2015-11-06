using Framework.QAWorks.Base;
using OpenQA.Selenium.Support.PageObjects;


namespace Framework.QAWorks.Pages
{
    public static class Pages
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Browser.Driver, page);

            return page;
        }

        public static ContactUs ContactUs
        {
            get
            {
                return GetPage<ContactUs>();
            }
        }
               
    }
}