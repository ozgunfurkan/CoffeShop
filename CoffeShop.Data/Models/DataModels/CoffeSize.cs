using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeShop.Data.Models.DataModels
{
    [Table("CoffeSize")]
    public class CoffeSize
    {
        public int Id { get; set; }
        public string Size { get; set; }

    }
}
