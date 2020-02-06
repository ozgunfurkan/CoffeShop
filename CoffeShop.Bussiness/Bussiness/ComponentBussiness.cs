using CoffeShop.Bussiness.Helpers;
using CoffeShop.Data;
using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeShop.Bussiness.Bussiness
{
    public class ComponentBussiness
    {
        public ResponseBase GetOffer(decimal milkneed, decimal coffeneed, decimal waterneed, bool milkCheck, bool coffeCheck, bool waterCheck)
        {
            ComponentHelper componentHelper = new ComponentHelper();
            using (var ctx = new CoffeShopContext())
            {
                List<Component> componentList = ctx.Components.ToList();
                var checkStocksAreValid = componentHelper.CheckStocksAreValid(milkneed, coffeneed, waterneed, componentList);
                if(checkStocksAreValid.IsOk)
                {
                    decimal price = componentHelper.CalculatePrice(milkneed, coffeneed, waterneed, componentList);
                    
                    if(milkCheck)
                    {
                        decimal milkPrice = componentList.Where(x => x.ComponentName == "Milk").Select(x => x.UnitPrice).FirstOrDefault();
                        price = componentHelper.AddExtraUnitPricePriceToPrice(price, milkPrice);
                    }

                    if(coffeCheck)
                    {
                        decimal coffePrice = componentList.Where(x => x.ComponentName == "Coffe").Select(x => x.UnitPrice).FirstOrDefault();
                        price = componentHelper.AddExtraUnitPricePriceToPrice(price, coffePrice);
                    }

                    if (waterCheck)
                    {
                        decimal waterPrice = componentList.Where(x => x.ComponentName == "Water").Select(x => x.UnitPrice).FirstOrDefault();
                        price = componentHelper.AddExtraUnitPricePriceToPrice(price, waterPrice);
                    }

                    return new ResponseBase { ExtraData=price.ToString("#.##"),IsOk=true};
                }

                return checkStocksAreValid;
            }
        }
    }
}
