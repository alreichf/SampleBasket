
using MoneySuperMarket.ConsoleApp.Models;

namespace MoneySuperMarket.ConsoleApp.Services.Shopping
{
    public interface IShoppingBasketService
    {
        void Add(Product product);
        void Remove(Product product);
        ShoppingBasket Get();
    }
}
