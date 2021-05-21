using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Common;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.Utils;
using MoneySuperMarket.ConsoleApp.Utils.Discount;
using Xunit;

namespace MoneySuperMarket.Tests.Utils.Discount
{
    public class Buy2ButterGet1BreadHalfPriceTests
    {
        private readonly IRule _buy2ButterGet1BreadHalfPriceRule;

        public Buy2ButterGet1BreadHalfPriceTests()
        {
            _buy2ButterGet1BreadHalfPriceRule = new Buy2ButterGet1BreadHalfPrice();
        }


        [Fact]
        public void ShouldApplyRuleAndReturnFalseWitnCountZero()
        {
            // Given
            var products = new List<Product>
            {
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                }
            };

            // When
            var result = _buy2ButterGet1BreadHalfPriceRule.Apply(products);

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
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
            };

            // When
            var result = _buy2ButterGet1BreadHalfPriceRule.Apply(products);

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
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
                new Butter
                {
                    Price = 0.80,
                    ProductType = ProductType.BUTTER
                },
            };

            // When
            var result = _buy2ButterGet1BreadHalfPriceRule.Apply(products);

            // Then
            result.Item1.Should().BeTrue();
            result.Item2.Should().BeGreaterOrEqualTo(2);
        }
    }
}
