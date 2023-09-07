using System;
using OpenQA.Selenium;

namespace SeleniumTest.Pages
{
	public class ContactPage : BasePage
	{
		private readonly By _submitButton = By.ClassName("btn-contact");

		//error messages
		private readonly By _forenameError = By.Id("forename-err");
		private readonly By _emailError = By.Id("email-err");
		private readonly By _messageError = By.Id("message-err");

        //contact fields
        private readonly By _forenameField = By.Id("forename");
        private readonly By _emailField = By.Id("email");
        private readonly By _messageField = By.Id("message");

        //
        private readonly By _successfulMessage = By.XPath("//div[contains(@class,'alert-success')]");

        private readonly By _sendingFeedbackModal = By.ClassName("popup");

        public ContactPage(IWebDriver driver) : base(driver)
		{
		}

		public void ClickSubmitButton()
		{
			Click(_submitButton);
		}

		public bool ForenameErrorDisplayed()
		{
			return IsElementVisible(_forenameError);
		}

        public bool EmailErrorDisplayed()
        {
            return IsElementVisible(_emailError);
        }

        public bool MessageErrorDisplayed()
        {
            return IsElementVisible(_messageError);
        }

        public string GetForenameError()
        {
            return GetElement(_forenameError).Text;
        }

        public string GetEmailError()
        {
            return GetElement(_emailError).Text;
        }

        public string GetMessageError()
        {
            return GetElement(_messageError).Text;
        }

        public void PopulateRequiredFields(string forename, string email, string message)
        {
            SendKeys(_forenameField, forename);
            SendKeys(_emailField, email);
            SendKeys(_messageField, message);
        }

        public string GetSuccessMessage()
        {
            return GetElement(_successfulMessage).Text;
        }

    }
}

