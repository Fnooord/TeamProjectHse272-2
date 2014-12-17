using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamProjectHse272_2.Data.Tests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void TotalPrice_CartIsEmpty_0()
        {
            var cart = new Cart();

            var expectedResult = 0;
            var actualResult = cart.TotalPrice;

            Assert.AreEqual(expectedResult, actualResult, "Total price for empty cart should be 0.");
        }

        [TestMethod]
        public void TotalPrice_CartContainsOneItem_PriceShouldBeEqualToItemPrice()
        {
            var cart = new Cart();
            cart.Items.Add(new CartItem
            {
                Product = new Product { Price = 100 },
                Quantity = 3
            });

            var expectedResult = 100 * 3;
            var actualResult = cart.TotalPrice;

            Assert.AreEqual(expectedResult, actualResult, "Total price for cart with 3 items with price of 100 should be equal to 300.");
        }
    }
}
