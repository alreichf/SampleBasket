using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneySuperMarket.ConsoleApp.Utils;

namespace MoneySuperMarket.ConsoleApp.Models
{
    public class Butter : Product
    {
        public override ProductType ProductType { get; set; } = ProductType.BUTTER;
        public override double Price { get; set; } = 0.80;
    }
}
