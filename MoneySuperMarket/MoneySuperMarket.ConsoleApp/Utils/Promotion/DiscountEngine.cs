using System.Collections.Generic;
using MoneySuperMarket.ConsoleApp.Utils.Discount;

namespace MoneySuperMarket.ConsoleApp.Utils.Promotion
{
    public static class DiscountEngine
    {
        public static IDictionary<DiscountType,IRule> DiscountRules = new Dictionary<DiscountType, IRule>
        {
            { DiscountType.BUY2BUTTERGET1BREADHALFPRICE, new Buy2ButterGet1BreadHalfPrice() },
            { DiscountType.BUY3MILKGET1FREE, new Buy3MilkGet1Free() },
        };
    }
}
