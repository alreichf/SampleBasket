
using System.Collections.Generic;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.Services.Checkout;
using MoneySuperMarket.ConsoleApp.Services.Promotion;
using MoneySuperMarket.ConsoleApp.Utils;
using Moq;
using Xunit;

namespace MoneySuperMarket.Tests.Services.Checkout
{
    public class CheckoutServiceTests
    {
        private readonly Mock<IDiscountService> _mockDiscountService;
        private readonly ICheckoutService _checkoutService;

        public CheckoutServiceTests()
        {
            _mockDiscountService = new Mock<IDiscountService>();
            _checkoutService = new CheckoutService(_mockDiscountService.Object);
        }

        [Fact]
        public void ShouldApplyDiscountsOnCheckout()
        {
            // Given
            var shoppingBasket = new ShoppingBasket
            {
                Products = new List<Product>
                {
                    new Bread
                    {
                        ProductType = ProductType.BREAD
                    },
                    new Butter
                    {
                        ProductType = ProductType.BUTTER
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    }
                },
                Total = 0.0
            };

            _mockDiscountService.Setup(d => d.ApplyDiscounts(It.IsAny<ShoppingBasket>()));

            // When
            _checkoutService.Checkout(shoppingBasket);

            // Then
            _mockDiscountService.Verify(d => d.ApplyDiscounts(It.IsAny<ShoppingBasket>()), Times.Once);
        }
    }
}
