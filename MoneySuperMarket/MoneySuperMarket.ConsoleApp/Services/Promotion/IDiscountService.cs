using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySuperMarket.ConsoleApp.Models;

namespace MoneySuperMarket.ConsoleApp.Services.Promotion
{
    public interface IDiscountService
    {
        void ApplyDiscounts(ShoppingBasket shoppingBasket);
    }
}
