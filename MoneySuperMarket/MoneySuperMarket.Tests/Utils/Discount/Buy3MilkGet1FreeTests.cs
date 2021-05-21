using System.Collections.Generic;
using FluentAssertions;
using FluentAssertions.Common;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.Utils;
using MoneySuperMarket.ConsoleApp.Utils.Discount;
using Xunit;

namespace MoneySuperMarket.Tests.Utils.Discount
{
    public class Buy3MilkGet1FreeTests
    {
        private readonly IRule _buy3MilkGet1FreeTestsRule;

        public Buy3MilkGet1FreeTests()
        {
            _buy3MilkGet1FreeTestsRule = new Buy3MilkGet1Free();
        }


        [Fact]
        public void ShouldApplyRuleAndReturnFalseWitnCountZero()
        {
            // Given
            var products = new List<Product>
            {
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                }
            };

            // When
            var result = _buy3MilkGet1FreeTestsRule.Apply(products);

            // Then
            result.Item1.Should().BeFalse();
            result.Item2.Should().IsSameOrEqualTo(0);
        }

        [Fact]
        public void ShouldApplyRuleAndReturnTrueWithCount()
        {
            // Given
            var products = new List<Product>
            {
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
            };

            // When
            var result = _buy3MilkGet1FreeTestsRule.Apply(products);

            // Then
            result.Item1.Should().BeTrue();
            result.Item2.Should().IsSameOrEqualTo(1);
        }

        [Fact]
        public void ShouldApplyRuleAndReturnTrueWithCountGreaterThan1()
        {
            // Given
            var products = new List<Product>
            {
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
                new Milk
                {
                    Price = 1.15,
                    ProductType = ProductType.MILK
                },
            };

            // When
            var result = _buy3MilkGet1FreeTestsRule.Apply(products);

            // Then
            result.Item1.Should().BeTrue();
            result.Item2.Should().BeGreaterOrEqualTo(2);
        }
    }
}
