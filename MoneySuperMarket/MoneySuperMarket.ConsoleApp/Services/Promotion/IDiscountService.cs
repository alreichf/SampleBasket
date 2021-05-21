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
        void ApplyBuy2ButterGet1BreadHalfPrice(ShoppingBasket shoppingBasket, int? times=default);
        void ApplyBuy3MilkGet1Free(ShoppingBasket shoppingBasket, int? times=default);
    }
}
