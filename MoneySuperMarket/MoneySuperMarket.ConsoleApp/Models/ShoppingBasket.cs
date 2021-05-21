using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneySuperMarket.ConsoleApp.Models
{
    public class ShoppingBasket
    {
        public IList<Product> Products { get; set; }
        public double Total { get; set; } = 0.0;
    }
}
