
using System.Collections.Generic;
using FluentAssertions;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.Services.Promotion;
using MoneySuperMarket.ConsoleApp.Utils;
using Xunit;

namespace MoneySuperMarket.Tests.Services.Promotion
{
    public class DiscountServiceTests
    {
        private readonly IDiscountService _discountService;

        public DiscountServiceTests()
        {
            _discountService = new DiscountService();
        }


        [Fact]
        public void ShouldApplyNoDiscountsfor1Bread1Butter1MilkInShoppingBasket()
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

            var expectedCount = shoppingBasket.Products.Count;
            double expectedTotal = 2.95;


            // When
            _discountService.ApplyDiscounts(shoppingBasket);

            // Then
            Assert.Equal(expectedCount, shoppingBasket.Products.Count);
            Assert.Equal(expectedTotal, shoppingBasket.Total);
        }


        [Fact]
        public void ShouldApplyAllDiscountsFor2Butter2Bread()
        {
            // Given
            var shoppingBasket = new ShoppingBasket
            {
                Products = new List<Product>
                {
                    new Butter
                    {
                        ProductType = ProductType.BUTTER
                    },
                    new Butter
                    {
                        ProductType = ProductType.BUTTER
                    },
                    new Bread
                    {
                        ProductType = ProductType.BREAD
                    },
                    new Bread
                    {
                        ProductType = ProductType.BREAD
                    },
                },
                Total = 0.0
            };

            var expectedCount = shoppingBasket.Products.Count;
            double expectedTotal = 3.10;


            // When
            _discountService.ApplyDiscounts(shoppingBasket);

            // Then
            Assert.Equal(expectedCount, shoppingBasket.Products.Count);
            Assert.Equal(expectedTotal, shoppingBasket.Total);
        }

        [Fact]
        public void ShouldApplyAllDiscountsFor4Milk()
        {
            // Given
            var shoppingBasket = new ShoppingBasket
            {
                Products = new List<Product>
                {
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                },
                Total = 0.0
            };

            var expectedCount = shoppingBasket.Products.Count;
            double expectedTotal = 3.45;


            // When
            _discountService.ApplyDiscounts(shoppingBasket);

            // Then
            Assert.Equal(expectedCount, shoppingBasket.Products.Count);
            Assert.Equal(expectedTotal, shoppingBasket.Total);
        }

        [Fact]
        public void ShouldApplyAllDiscountsFor2Butter1Bread8Milk()
        {
            // Given
            var shoppingBasket = new ShoppingBasket
            {
                Products = new List<Product>
                {
                    new Butter
                    {
                        ProductType = ProductType.BUTTER
                    },
                    new Butter
                    {
                        ProductType = ProductType.BUTTER
                    },
                    new Bread
                    {
                        ProductType = ProductType.BREAD
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                    new Milk
                    {
                        ProductType = ProductType.MILK
                    },
                },
                Total = 0.0
            };

            var expectedCount = shoppingBasket.Products.Count;
            double expectedTotal = 9.00;


            // When
            _discountService.ApplyDiscounts(shoppingBasket);

            // Then
            Assert.Equal(expectedCount, shoppingBasket.Products.Count);
            Assert.Equal(expectedTotal, shoppingBasket.Total);
        }
    }
}
