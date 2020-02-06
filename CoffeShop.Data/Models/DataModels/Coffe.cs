using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CoffeShop.Data.Models.DataModels
{
    [Table("Coffe")]
    public class Coffe
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
