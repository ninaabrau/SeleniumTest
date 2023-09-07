using System;
using NUnit.Framework;
using SeleniumTest.Pages;
using Assert = NUnit.Framework.Assert;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class ShopTest : BaseTest
	{
        private HomePage _homePage;
        private ShopPage _shopPage;
        private CartPage _cartPage;

        [SetUp]
        public void Before()
        {
            _homePage = new HomePage(Driver);
            _shopPage = new ShopPage(Driver);
            _cartPage = new CartPage(Driver);
        }

        [Test(Description = "Verify shopping cart details")]
        public void TestShoppingCart()
        {
            //Navigate to Shop
            _homePage.ClickShopButton();

            var itemList = new List<Item>
            {
                new Item
                {
                    ItemName = "Stuffed Frog",
                    Qty = 2
                },

                new Item
                {
                    ItemName = "Fluffy Bunny",
                    Qty = 5
                },

                new Item
                {
                    ItemName = "Valentine Bear",
                    Qty = 3
                }
            };


            //Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
            foreach (Item item in itemList)
            {
                _shopPage.BuyProductByName(item.ItemName, item.Qty);
                item.Price = _shopPage.GetPriceByName(item.ItemName);
            }

            //Navigate to cart
            _homePage.ClickCartButton();

            var expectedTotal = 0.0;

            foreach (Item item in itemList)
            {
                var expectedSubtotal = item.Price * item.Qty;
                //Verify subtotal for each item
                Assert.AreEqual(expectedSubtotal, _cartPage.GetItemSubTotalProductName(item.ItemName));


                //Verify price for each item
                Assert.AreEqual(item.Price, _cartPage.GetItemPriceByProductName(item.ItemName));

                expectedTotal += expectedSubtotal;
            }

            Assert.AreEqual(expectedTotal, _cartPage.GetTotalPrice());

        }


    }

    public class Item
    {
        public required string ItemName { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
    }
}

