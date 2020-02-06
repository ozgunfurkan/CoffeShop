using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Data.Models.DataModels
{
    public class Component
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }

        public double UnitPrice { get; set; }
        public int Stock { get; set; }

    }
}
