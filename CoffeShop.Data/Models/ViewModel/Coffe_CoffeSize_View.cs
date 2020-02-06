using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Data.Models.ViewModel
{
    public class Coffe_CoffeSize_View
    {
        public int Id { get; set; }

        public int CoffeId { get; set; }

        public int CoffeSizeId { get; set; }
        public string Size { get; set; }

        public decimal CoffeNeed { get; set; }
        public decimal WaterNeed { get; set; }
        public decimal MilkNeed { get; set; }

    }
}
