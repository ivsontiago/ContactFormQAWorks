using Framework.QAWorks.Base.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Framework.QAWorks.Pages
{
    public class ContactUs
    {
        [FindsBy(How = How.Id, Using = "ctl00_MainContent_NameBox")]
        private IWebElement _name;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_EmailBox")]
        private IWebElement _email;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_MessageBox")]
        private IWebElement _message;
                
        [FindsBy(How = How.XPath, Using = "//input[contains(@type, 'submit') and contains(@name, 'ctl00$MainContent$SendButton')]")]
        private IWebElement _submitButton;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_rfvName")]
        private IWebElement _nameFieldErrorMessageMissing;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_rfvEmailAddress")]
        private IWebElement _emailFieldErrorMessageMissing;

        [FindsBy(How = How.Id, Using = "ctl00_MainContent_revEmailAddress")]
        private IWebElement _emailFieldErrorMessageInvalid;
        
        [FindsBy(How = How.Id, Using = "ctl00_MainContent_rfvMessage")]
        private IWebElement _messageFieldErrorMessageMissing;


        public void EnterName(string name)
        {
            _name.SendKeys(name);
        }

        public void EnterEmail(string email)
        {
            _email.SendKeys(email);
        }

        public void EnterMessage(string message)
        {
            _message.SendKeys(message);
        }

        public void ClickSubmitButton()
        {
            Utilities.ZoomOut();
            _submitButton.Click();
        }

        public bool IsNameEmpty()
        {
            return _name.Text == "";
        }

        public bool IsNameMandatory()
        {
            return _nameFieldErrorMessageMissing.IsVisible();
        }

        public bool IsEmailMandatory()
        {
            return _emailFieldErrorMessageMissing.IsVisible();
        }

        public bool IsMessageMandatory()
        {
            return _messageFieldErrorMessageMissing.IsVisible();
        }

        public void EnterLongMessage(int size)
        {
            string longMessage = new string('A', size);
            _message.SendKeys(longMessage);
        }

        public void ClickNameField()
        {
            _name.Click();
        }

        public void ClickEmailField()
        {
            _email.Click();
        }

        public string GetMissingFieldErrorMessage(string field)
        {
            ClickSubmitButton();
            switch (field)
            {
                case "email":
                    return _emailFieldErrorMessageMissing.Text;
                case "name":
                    return _nameFieldErrorMessageMissing.Text;
                case "message":
                    return _messageFieldErrorMessageMissing.Text;
                default:
                    return "";
            }
        }

        public string GetInvalidEmailErrorMessage()
        {
            return _emailFieldErrorMessageInvalid.Text;
        }
    }
}