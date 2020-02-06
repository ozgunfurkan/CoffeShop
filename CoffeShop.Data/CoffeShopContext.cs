using CoffeShop.Data.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CoffeShop.Data
{
    public class CoffeShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-0CK4SGB\\SQLEXPRESS;Database=CoffeShop;Trusted_Connection=True;");
            }
        }

        public DbSet<Coffe> Coffes { get; set; }
        public DbSet<Coffe_CoffeSize_Mapping> CoffeSize_Mappings { get; set; }
        public DbSet<CoffeSize> CoffeSizes { get; set; }
        public DbSet<Component> Components { get; set; }

    }
}
