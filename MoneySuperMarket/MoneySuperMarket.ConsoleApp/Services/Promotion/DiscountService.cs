using System;
using System.Linq;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.Utils;
using MoneySuperMarket.ConsoleApp.Utils.Promotion;

namespace MoneySuperMarket.ConsoleApp.Services.Promotion
{
    public class DiscountService : IDiscountService
    {

        public void ApplyDiscounts(ShoppingBasket shoppingBasket)
        {
            foreach(var promoDiscount in DiscountEngine.DiscountRules)
            {
                if (promoDiscount.Key.Equals(DiscountType.BUY2BUTTERGET1BREADHALFPRICE))
                {
                    var discountRule = promoDiscount.Value.Apply(shoppingBasket.Products);
                    if (discountRule.Found)
                    {
                        ApplyBuy2ButterGet1BreadHalfPrice(shoppingBasket, discountRule.Count);
                    }
                }
                else if (promoDiscount.Key.Equals(DiscountType.BUY3MILKGET1FREE))
                {
                    var discountRule = promoDiscount.Value.Apply(shoppingBasket.Products);
                    if (discountRule.Found)
                    {
                        ApplyBuy3MilkGet1Free(shoppingBasket, discountRule.Count);
                    }
                }
            }

            CalculateTotal(shoppingBasket);
        }
        public void ApplyBuy2ButterGet1BreadHalfPrice(ShoppingBasket shoppingBasket, int? times = default)
        {
            if(times is object && times > 0)
            {
                var bread = shoppingBasket.Products.Where(p => p.ProductType.Equals(ProductType.BREAD));

                if (bread is object)
                {
                    int index = 0;
                    foreach(var b in bread)
                    {
                        if(index < times)
                        {
                            b.Price /= 2;
                        }
                        else
                        {
                            break;
                        }
                        index++;
                    }

                    var remainingToAdd = times - index;
                    if(remainingToAdd > 0)
                    {
                        AddNewBread(shoppingBasket, remainingToAdd);
                    }
                }
                else {
                    if (times > 0)
                    {
                        AddNewBread(shoppingBasket, times);
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

        public void ApplyBuy3MilkGet1Free(ShoppingBasket shoppingBasket, int? times = default)
        {
            if (times is object && times > 0)
            {
                var milk = shoppingBasket.Products.Where(p => p.ProductType.Equals(ProductType.MILK));

                if (milk is object)
                {
                    int index = 0;
                    foreach (var m in milk)
                    {
                        if (index < times)
                        {
                            m.Price = 0.0;
                        }
                        else
                        {
                            break;
                        }
                        index++;
                    }

                    var remainingToAdd = times - index;
                    if (remainingToAdd > 0)
                    {
                        AddNewMilk(shoppingBasket, remainingToAdd);
                    }
                }
                else
                {
                    if (times > 0)
                    {
                        AddNewMilk(shoppingBasket, times);
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

        private void CalculateTotal(ShoppingBasket shoppingBasket)
        {
            var total = (from product in shoppingBasket.Products
                        select product.Price).Sum();
            shoppingBasket.Total = Math.Round(total, 2);
        }
    }
}
