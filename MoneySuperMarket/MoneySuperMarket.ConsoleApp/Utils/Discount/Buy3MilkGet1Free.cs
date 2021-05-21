using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.ValueObjects;

namespace MoneySuperMarket.ConsoleApp.Utils.Discount
{
    public class Buy3MilkGet1Free : IRule
    {
        public (bool Found, int? Count) Apply(IList<Product> products)
        {
            var milkProductCount = products.GroupBy(p => p.ProductType)
                .Select(group => new ProductCount { ProductType = group.Key, Count = group.Count() })
                .FirstOrDefault(pc => pc.ProductType.Equals(ProductType.MILK));

            return (milkProductCount?.Count >= 3, milkProductCount?.Count/3);
        }
    }
}
