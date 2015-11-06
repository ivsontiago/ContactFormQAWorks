using Framework.QAWorks.Base;
using TechTalk.SpecFlow;
using Ve.Test.Framework.Base.EnvironmentSettings;
using Framework.QAWorks.Pages;
using Shouldly;

namespace Tests.QAWorks.Steps
{
    [Binding]
    public class ContactUsPage
    {
        [Given(@"I am on the QAWorks Staging Site")]
        public void GivenIAmOnTheQAWorksStagingSite()
        {
            Browser.NavigateTo(Settings.Instance.ContactUsPageUrl);
        }

        [Then(@"I should be able to contact QAWorks with the following information")]
        public void ThenIShouldBeAbleToContactQAWorksWithTheFollowingInformation(Table input)
        {
            var name = ((string[])(input.Rows[0].Values))[0];
            var email = ((string[])(input.Rows[0].Values))[1];
            var message = ((string[])(input.Rows[0].Values))[2];
            Pages.ContactUs.EnterName(name);
            Pages.ContactUs.EnterEmail(email);
            Pages.ContactUs.EnterMessage(message);
            Pages.ContactUs.ClickSubmitButton();
            Pages.ContactUs.IsNameEmpty().ShouldBe(true);
        }
        
        [When(@"I enter the name '(.*)'")]
        public void WhenIEnterTheName(string name)
        {
            Pages.ContactUs.EnterName(name);
        }

        [When(@"I enter the email '(.*)'")]
        public void WhenIEnterTheEmail(string email)
        {
            Pages.ContactUs.EnterEmail(email);
        }

        [When(@"I enter the message '(.*)'")]
        public void WhenIEnterTheMessage(string message)
        {
            Pages.ContactUs.EnterMessage(message);
        }

        [Then(@"The '(.*)' should show an '(.*)'")]
        public void ThenTheShouldShowAn(string missingField, string expectedErrorMessage)
        {
            Pages.ContactUs.GetMissingFieldErrorMessage(missingField).ShouldBe(expectedErrorMessage);
        }

        [Then(@"I should be able to contact QAWorks")]
        public void ThenIShouldBeAbleToContactQAWorks()
        {
            Pages.ContactUs.ClickSubmitButton();
            Pages.ContactUs.IsNameEmpty().ShouldBe(true);
        }

        [Then(@"I should not be able to contact QAWorks")]
        public void ThenIShouldNotBeAbleToContactQAWorks()
        {
            Pages.ContactUs.ClickSubmitButton();

            bool isThereAnErrorMessage =
                Pages.ContactUs.IsNameMandatory() 
                || Pages.ContactUs.IsEmailMandatory() 
                || Pages.ContactUs.IsMessageMandatory();
            isThereAnErrorMessage.ShouldBe(true);
        }

        [When(@"I enter a message with (.*) characters")]
        public void WhenIEnterAMessageWithCharacters(int size)
        {
            Pages.ContactUs.EnterLongMessage(size);
        }

        [When(@"I click the name field")]
        public void WhenIClickTheNameField()
        {
            Pages.ContactUs.ClickNameField();
        }

        [When(@"I click the email field")]
        public void WhenIClickTheEmailField()
        {
            Pages.ContactUs.ClickEmailField();
        }

        [Then(@"The form should show the message ""(.*)""")]
        public void ThenTheFormShouldShowTheMessage(string errorMessage)
        {
            Pages.ContactUs.GetInvalidEmailErrorMessage().ShouldBe(errorMessage);
        }
    }
}