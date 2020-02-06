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
        //public List<Coffe_CoffeSize_View> GetCoffes()
        //{
        //    using (var ctx = new CoffeShopContext())
        //    {
        //        List<Coffe_CoffeSize_View> coffeList = (from cmapping in ctx.CoffeSize_Mappings
        //                                                join coffe in ctx.Coffes on cmapping.CoffeId equals coffe.Id
        //                                                join coffeSize in ctx.CoffeSizes on cmapping.CoffeSizeId equals coffeSize.Id
        //                                                select new Coffe_CoffeSize_View()
        //                                                {
        //                                                    Name = coffe.Name,
        //                                                    Id = coffe.Id,
        //                                                    CoffeSizeList = coffeSize.ToString().ToList()
        //                                                }).ToList();
        //        return coffeList;
        //    }
        //}
    }
}
