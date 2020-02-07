using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeShop.Data.Models.DataModels
{
    [Table("Component")]
    public class Component
    {
        public int Id { get; set; }
        public string ComponentName { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal Stock { get; set; }

    }
}
