using CoffeShop.Data;
using CoffeShop.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoffeShop.Bussiness.Bussiness
{
    public class CoffeSizeMappingBussiness
    {
        public List<Coffe_CoffeSize_View> GetCoffeSizeByCoffeId(int coffeId)
        {
            using (var ctx = new CoffeShopContext())
            {
                List<Coffe_CoffeSize_View> coffeList = (from cmapping in ctx.CoffeSize_Mappings
                                                        join coffe in ctx.Coffes on cmapping.CoffeId equals coffe.Id
                                                        join coffeSize in ctx.CoffeSizes on cmapping.CoffeSizeId equals coffeSize.Id
                                                        where cmapping.CoffeId == coffeId
                                                        select new Coffe_CoffeSize_View()
                                                        {
                                                            CoffeId = coffe.Id,
                                                            Id = cmapping.Id,
                                                            CoffeSizeId = coffeSize.Id,
                                                            MilkNeed = (decimal)cmapping.MilkNeed,
                                                            CoffeNeed = (decimal)cmapping.CoffeNeed,
                                                            WaterNeed = (decimal)cmapping.WaterNeed,
                                                            Size = coffeSize.Size
                                                        }).ToList();
                return coffeList;
            }
        }
    }   
}
