using CoffeShop.Bussiness.Helpers;
using CoffeShop.Data;
using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using CoffeShop.Data.Models.RequestModels;
using CoffeShop.Data.Models.ViewModel;
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
                var checkStocksAreValid = componentHelper.CheckStocksAreValid(milkneed, coffeneed, waterneed, componentList,milkCheck,coffeCheck,waterCheck);
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

        public ComponentStocks ConfirmOrder(ComponentUpdate componentUpdate)
        {
            ComponentHelper componentHelper = new ComponentHelper();
            using (var ctx = new CoffeShopContext())
            {
                List<Component> componentList = ctx.Components.ToList();
                var componentStocks = componentHelper.CalculateNewStocks(componentUpdate,componentList);

                for(int i=0;i<componentList.Count;i++)
                {
                    if (componentList[i].ComponentName == "Milk")
                    {
                        componentList[i].Stock = componentStocks.MilkInStock;
                    }
                    else if (componentList[i].ComponentName == "Coffe")
                    {
                        componentList[i].Stock = componentStocks.CoffeInStock;
                    }
                    else if (componentList[i].ComponentName == "Water")
                    {
                        componentList[i].Stock = componentStocks.WaterInStock;
                    }
                }

                ctx.SaveChanges();
                return componentStocks;
            }
        }

        public List<Component> GetStockData()
        {
            using (var ctx = new CoffeShopContext())
            {
                List<Component> componentList = ctx.Components.ToList();
                return componentList;
            }
        }
    }
}
