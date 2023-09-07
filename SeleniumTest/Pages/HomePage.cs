using OpenQA.Selenium;

namespace SeleniumTest.Pages
{
	public class HomePage : BasePage
	{
		private readonly By _contactButton = By.Id("nav-contact");
		private readonly By _shopButton = By.Id("nav-shop");
		private readonly By _cartButton = By.Id("nav-cart");

		public HomePage(IWebDriver driver): base(driver)
		{
		}

		public void ClickContactButton()
		{
			Click(_contactButton);
		}

        public void ClickShopButton()
        {
            Click(_shopButton);
        }

        public void ClickCartButton()
        {
            Click(_cartButton);
        }
    }
}

