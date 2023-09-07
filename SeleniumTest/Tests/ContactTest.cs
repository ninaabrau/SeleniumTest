using NUnit.Framework;
using SeleniumTest.Pages;
using Assert = NUnit.Framework.Assert;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class ContactTest : BaseTest
    {
        private HomePage _homePage;
        private ContactPage _contactPage;

        [SetUp]
        public void Before()
        {
            _homePage = new HomePage(Driver);
            _contactPage = new ContactPage(Driver);
        }

        [Test(Description = "Verify errors for required fields")]
        public void TestContactRequiredFields()
        {
            //Navigate to contact page from home page
            _homePage.ClickContactButton();

            //Click submit button
            _contactPage.ClickSubmitButton();

            //Verify error messages
            Assert.AreEqual("Forename is required", _contactPage.GetForenameError());
            Assert.AreEqual("Email is required", _contactPage.GetEmailError());
            Assert.AreEqual("Message is required", _contactPage.GetMessageError());

            //Populate mandatory fields
            _contactPage.PopulateRequiredFields("John Doe", "jd@mail.co", "This is an automation test");

            //Validate errors are not displayed
            Assert.IsFalse(_contactPage.ForenameErrorDisplayed());
            Assert.IsFalse(_contactPage.EmailErrorDisplayed());
            Assert.IsFalse(_contactPage.MessageErrorDisplayed());
        }

        [Test(Description = "Validate success submission message")]
        public void TestSuccessContactSubmission()
        {
            //Navigate to contact page from home page
            _homePage.ClickContactButton();

            //Populate mandatory fields
            var forename = "John Doe";
            _contactPage.PopulateRequiredFields(forename, "jd@mail.co", "This is an automation test");
            _contactPage.ClickSubmitButton();

            //Validate success submission message
            var expectedMessage = string.Format("Thanks {0}, we appreciate your feedback.", forename);
            Assert.AreEqual(expectedMessage, _contactPage.GetSuccessMessage());
        }
    }
}

