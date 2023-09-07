using System.Globalization;
using OpenQA.Selenium;

namespace SeleniumTest.Pages
{
	public class ShopPage : BasePage
	{

		public ShopPage(IWebDriver driver) : base(driver) 
		{
		}

		private IWebElement getProductByName(string name)
		{
			return GetElement(By.XPath(string.Format(@"//li[./div/h4[contains(text(), '{0}')]]", name)));
		}

		public void BuyProductByName(string productName, int qty)
		{
			var productBuyButton = getProductByName(productName).FindElement(By.ClassName("btn-success"));
			for(int i = 0; i < qty; i++) { productBuyButton.Click(); }
		}

		public double GetPriceByName(string productName)
		{
			var price = getProductByName(productName).FindElement(By.ClassName("product-price")).Text;
			return double.Parse(price, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
        }
	}
}

