using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Data.Models.RequestModels
{
    public class ComponentUpdate
    {
        public decimal CoffeNeed { get; set; }
        public decimal WaterNeed { get; set; }
        public decimal MilkNeed { get; set; }

        public bool ExtraCoffe { get; set; }
        public bool ExtraWater { get; set; }
        public bool ExtraMilk { get; set; }




    }
}
