using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeShop.Data.Models.DataModels
{
    [Table("Coffe_CoffeSize_Mapping")]
    public class Coffe_CoffeSize_Mapping
    {
        public int Id { get; set; }
        public int CoffeSizeId { get; set; }

        public int CoffeId { get; set; }

        public double CoffeNeed { get; set; }
        public double WaterNeed { get; set; }
        public double MilkNeed { get; set; }

    }
}
