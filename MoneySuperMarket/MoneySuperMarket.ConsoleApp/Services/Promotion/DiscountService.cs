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
                 promoDiscount.ApplyDiscount(shoppingBasket);
            }

            CalculateTotal(shoppingBasket);
        }

        private void CalculateTotal(ShoppingBasket shoppingBasket)
        {
            var total = (from product in shoppingBasket.Products
                        select product.Price).Sum();
            shoppingBasket.Total = Math.Round(total, 2);
        }
    }
}
