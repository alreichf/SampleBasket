using MoneySuperMarket.ConsoleApp.Utils;

namespace MoneySuperMarket.ConsoleApp.Models
{
    public class Milk : Product
    {
        public override ProductType ProductType { get; set; } = ProductType.MILK;
        public override double Price { get; set; } = 1.15;
    }
}
