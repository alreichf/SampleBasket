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
        public (bool Found, int? Count) Check(IList<Product> products)
        {
            var milkProductCount = products.GroupBy(p => p.ProductType)
                .Select(group => new ProductCount { ProductType = group.Key, Count = group.Count() })
                .FirstOrDefault(pc => pc.ProductType.Equals(ProductType.MILK));

            return (milkProductCount?.Count >= 3, milkProductCount?.Count/3);
        }

        public void ApplyDiscount(ShoppingBasket shoppingBasket)
        {
            var discountRule = Check(shoppingBasket.Products);
            if (discountRule.Found)
            {
                if (discountRule.Count is object && discountRule.Count > 0)
                {
                    var milk = shoppingBasket.Products.Where(p => p.ProductType.Equals(ProductType.MILK));

                    if (milk is object)
                    {
                        int index = 0;
                        foreach (var m in milk)
                        {
                            if (index < discountRule.Count)
                            {
                                m.Price = 0.0;
                            }
                            else
                            {
                                break;
                            }
                            index++;
                        }

                        var remainingToAdd = discountRule.Count - index;
                        if (remainingToAdd > 0)
                        {
                            AddNewMilk(shoppingBasket, remainingToAdd);
                        }
                    }
                    else
                    {
                        if (discountRule.Count > 0)
                        {
                            AddNewMilk(shoppingBasket, discountRule.Count);
                        }
                    }
                }
            }
        }

        private void AddNewMilk(ShoppingBasket shoppingBasket, int? times = default)
        {
            var product = new Milk
            {
                ProductType = ProductType.MILK,
                Price = 0.00
            };

            Enumerable.Range(0, times.Value - 1).ToList().ForEach(i => shoppingBasket.Products.Add(product));
        }
    }
}
