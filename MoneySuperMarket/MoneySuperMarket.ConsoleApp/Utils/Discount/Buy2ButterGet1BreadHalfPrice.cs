using System;
using System.Collections.Generic;
using System.Linq;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.ValueObjects;

namespace MoneySuperMarket.ConsoleApp.Utils.Discount
{
    public class Buy2ButterGet1BreadHalfPrice : IRule
    {
        public (bool Found, int? Count) Apply(IList<Product> products)
        {
            var butterCount = products.GroupBy(p => p.ProductType)
                .Select(group => new ProductCount { ProductType = group.Key, Count = group.Count() })
                .FirstOrDefault(pc => pc.ProductType.Equals(ProductType.BUTTER));

            return (butterCount?.Count > 1, butterCount?.Count/2); // this tells if we can apply the promo and also the number of times to apply
        }
    }
}
