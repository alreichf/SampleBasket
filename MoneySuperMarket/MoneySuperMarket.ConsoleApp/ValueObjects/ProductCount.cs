using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySuperMarket.ConsoleApp.Utils;

namespace MoneySuperMarket.ConsoleApp.ValueObjects
{
    public class ProductCount
    {
        public ProductType ProductType { get; set; }
        public int Count { get; set; }
    }
}
