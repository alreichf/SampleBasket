using System.Collections.Generic;
using MoneySuperMarket.ConsoleApp.Utils.Discount;

namespace MoneySuperMarket.ConsoleApp.Utils.Promotion
{
    public static class DiscountEngine
    {
        public static IList<IRule> DiscountRules = new List<IRule>
        {
            new Buy2ButterGet1BreadHalfPrice(),
            new Buy3MilkGet1Free(),
        };
    }
}
