using CoffeShop.Data;
using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeShop.Bussiness.Bussiness
{
    public class CoffeBussiness
    {
        public List<Coffe> GetCoffes()
        {
            using (var ctx = new CoffeShopContext())
            {
                List<Coffe> coffeList = ctx.Coffes.ToList();
                return coffeList;
            }
        }
    }
}
