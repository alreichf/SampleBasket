using System.Collections.Generic;
using MoneySuperMarket.ConsoleApp.Models;

namespace MoneySuperMarket.ConsoleApp.Utils.Discount
{
    public interface IRule
    {
        (bool Found, int? Count) Check(IList<Product> products);
        void ApplyDiscount(ShoppingBasket shoppingBasket);
    }
}
