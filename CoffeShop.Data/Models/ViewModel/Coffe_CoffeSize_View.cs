using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Data.Models.ViewModel
{
    public class Coffe_CoffeSize_View
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CoffeSizeView> CoffeSizeList { get; set; }

    }

    public class CoffeSizeView
    {
        public string Size { get; set; }
        public CoffeNeeds CoffeNeedsList{get;set;}
    }

    public class CoffeNeeds
    {
        public string WaterNeed { get; set; }
        public string MilkNeed { get; set; }
        public string CoffeNeed { get; set; }
    }

}
