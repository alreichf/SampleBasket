using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySuperMarket.ConsoleApp.Utils;

namespace MoneySuperMarket.ConsoleApp.Models
{
    public class Product
    {
        public virtual ProductType ProductType { get; set; }
        public virtual double Price { get; set; }
    }
}
