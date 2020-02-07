using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using CoffeShop.Data.Models.RequestModels;
using CoffeShop.Data.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Bussiness.Helpers
{
    public class ComponentHelper
    {
        public ResponseBase CheckStocksAreValid(decimal milkneed, 
            decimal coffeneed, decimal waterneed, List<Component> componentList,
             bool milkCheck, bool coffeCheck, bool waterCheck)
        {
            for(int i=0;i<componentList.Count;i++)
            {
                if(componentList[i].ComponentName=="Milk")
                {
                    if(componentList[i].Stock<milkneed)
                    {
                        return new ResponseBase { IsOk = false, Message = "There is no enough milk stock" };
                    }
                    
                    if(milkCheck)
                    {
                        if (componentList[i].Stock < milkneed+1)
                        {
                            return new ResponseBase { IsOk = false, Message = "There is no enough milk to add extra unit in stock" };
                        }
                    }
                }
                else if (componentList[i].ComponentName == "Coffe")
                {
                    if (componentList[i].Stock < coffeneed)
                    {
                        return new ResponseBase { IsOk = false, Message = "There is no enough coffe stock" };
                    }

                    if (coffeCheck)
                    {
                        if (componentList[i].Stock < coffeneed + 1)
                        {
                            return new ResponseBase { IsOk = false, Message = "There is no enough coffe to add extra unit in stock" };
                        }
                    }
                }
                else if (componentList[i].ComponentName == "Water")
                {
                    if (componentList[i].Stock < waterneed)
                    {
                        return new ResponseBase { IsOk = false, Message = "There is no enough water in stock" };
                    }

                    if (waterCheck)
                    {
                        if (componentList[i].Stock < waterneed + 1)
                        {
                            return new ResponseBase { IsOk = false, Message = "There is no enough water to add extra unit in stock" };
                        }
                    }
                }

            }
            return new ResponseBase { IsOk = true };
        }

       

        public decimal CalculatePrice(decimal milkneed, decimal coffeneed, decimal waterneed, List<Component> componentList)
        {
            decimal price = 0; ;
            for (int i = 0; componentList.Count > i; i++)
            {
                if (componentList[i].ComponentName == "Milk")
                {
                    price += componentList[i].UnitPrice * milkneed; 
                }
                else if (componentList[i].ComponentName == "Coffe")
                {
                    price += componentList[i].UnitPrice * coffeneed;
                }
                else if (componentList[i].ComponentName == "Water")
                {
                    price += componentList[i].UnitPrice * waterneed;
                }

            }

            return price;
        }

        public decimal AddExtraUnitPricePriceToPrice(decimal price, decimal extraPrice)
        {
            return price + extraPrice;
        }

        public ComponentStocks CalculateNewStocks(ComponentUpdate componentUpdate, List<Component> componentList)
        {
            ComponentStocks componentStocks = new ComponentStocks();
            for (int i = 0; i < componentList.Count; i++)
            {
                if (componentList[i].ComponentName == "Milk")
                {

                    componentStocks.MilkInStock = componentList[i].Stock - componentUpdate.MilkNeed;
                    if (componentUpdate.ExtraMilk)
                    {
                        componentStocks.MilkInStock -= 1;
                    }
                }
                else if (componentList[i].ComponentName == "Coffe")
                {
                    componentStocks.CoffeInStock = componentList[i].Stock - componentUpdate.CoffeNeed;
                    if (componentUpdate.ExtraCoffe)
                    {
                        componentStocks.CoffeInStock -= 1;
                    }
                }
                else if (componentList[i].ComponentName == "Water")
                {
                    componentStocks.WaterInStock = componentList[i].Stock - componentUpdate.WaterNeed;
                    if (componentUpdate.ExtraWater)
                    {
                        componentStocks.WaterInStock -= 1;
                    }
                }
                
            }
            return componentStocks;
        }
    }
}
