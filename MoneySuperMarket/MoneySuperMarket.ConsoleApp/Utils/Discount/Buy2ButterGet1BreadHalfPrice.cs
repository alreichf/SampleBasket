using System;
using System.Collections.Generic;
using System.Linq;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.ValueObjects;

namespace MoneySuperMarket.ConsoleApp.Utils.Discount
{
    public class Buy2ButterGet1BreadHalfPrice : IRule
    {
        public (bool Found, int? Count) Check(IList<Product> products)
        {
            var butterCount = products.GroupBy(p => p.ProductType)
                .Select(group => new ProductCount { ProductType = group.Key, Count = group.Count() })
                .FirstOrDefault(pc => pc.ProductType.Equals(ProductType.BUTTER));

            return (butterCount?.Count > 1, butterCount?.Count/2); // this tells if we can apply the promo and also the number of times to apply
        }

        public void ApplyDiscount(ShoppingBasket shoppingBasket)
        {
            var discountRule = Check(shoppingBasket.Products);
            if (discountRule.Found)
            {
                if (discountRule.Count is object && discountRule.Count > 0)
                {
                    var bread = shoppingBasket.Products.Where(p => p.ProductType.Equals(ProductType.BREAD));

                    if (bread is object)
                    {
                        int index = 0;
                        foreach (var b in bread)
                        {
                            if (index < discountRule.Count)
                            {
                                b.Price /= 2;
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
                            AddNewBread(shoppingBasket, remainingToAdd);
                        }
                    }
                    else
                    {
                        if (discountRule.Count > 0)
                        {
                            AddNewBread(shoppingBasket, discountRule.Count);
                        }
                    }
                }
            }
        }

        private void AddNewBread(ShoppingBasket shoppingBasket, int? times = default)
        {
            var halfPriceBread = new Bread
            {
                ProductType = ProductType.BREAD
            };
            halfPriceBread.Price /= 2;

            Enumerable.Range(0, times.Value - 1).ToList().ForEach(i => shoppingBasket.Products.Add(halfPriceBread));
        }
    }
}
