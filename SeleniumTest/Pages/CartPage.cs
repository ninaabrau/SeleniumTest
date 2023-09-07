using System.Globalization;
using OpenQA.Selenium;

namespace SeleniumTest.Pages
{
	public class CartPage : BasePage
	{
		private readonly By _cartItems = By.ClassName("cart-item");
		private readonly By _total = By.ClassName("total");
		
		public CartPage(IWebDriver driver) : base(driver)
		{
		}

		public int GetCartItemCount()
		{
			return GetElements(_cartItems).Count;
        }

		public double GetItemPriceByProductName(string productName)
        {
			var price = GetElement(getRowElementByProductName(productName)).FindElements(By.TagName("td"))[1].Text;
			return double.Parse(price, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
        }

        public double GetItemSubTotalProductName(string productName)
        {
            var price = GetElement(getRowElementByProductName(productName)).FindElements(By.TagName("td"))[3].Text;
			return double.Parse(price, NumberStyles.AllowCurrencySymbol | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, new CultureInfo("en-US"));
        }

		public double GetTotalPrice()
		{
			var total = GetElement(_total).Text.Split(':')[1].Trim();
			return double.Parse(total, CultureInfo.InvariantCulture);
		}

        private By getRowElementByProductName(string productName)
		{
			return By.XPath(string.Format("//tr[./td[contains(text(), '{0}')]]", productName));
		}

	}

}

