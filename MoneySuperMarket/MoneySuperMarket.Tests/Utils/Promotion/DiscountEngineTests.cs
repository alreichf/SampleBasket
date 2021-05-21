using MoneySuperMarket.ConsoleApp.Utils.Promotion;
using Xunit;
using FluentAssertions;

namespace MoneySuperMarket.Tests.Utils.Promotion
{
    public class DiscountEngineTests
    {
        public DiscountEngineTests()
        {

        }

        [Fact]
        public void ShouldGetListOfDiscounts()
        {
            // Given


            // When
            var discountRules = DiscountEngine.DiscountRules;

            // Then
            discountRules.Should().NotBeEmpty();
        }
    }
}
