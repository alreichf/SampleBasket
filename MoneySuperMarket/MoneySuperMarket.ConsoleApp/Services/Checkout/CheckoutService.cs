using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySuperMarket.ConsoleApp.Models;
using MoneySuperMarket.ConsoleApp.Services.Promotion;

namespace MoneySuperMarket.ConsoleApp.Services.Checkout
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IDiscountService _discountService;

        public CheckoutService(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public void Checkout(ShoppingBasket shoppingBasket)
        {
            _discountService.ApplyDiscounts(shoppingBasket);
        }
    }
}
