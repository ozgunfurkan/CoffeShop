using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeShop.Bussiness.Helpers
{
    public class ComponentHelper
    {
        public ResponseBase CheckStocksAreValid(decimal milkneed, decimal coffeneed, decimal waterneed, List<Component> componentList)
        {
            for(int i=0;i<componentList.Count;i++)
            {
                if(componentList[i].ComponentName=="Milk")
                {
                    if(componentList[i].Stock<milkneed)
                    {
                        return new ResponseBase { IsOk = false, Message = "There is no enough milk stock" };
                    }
                }
                else if (componentList[i].ComponentName == "Coffe")
                {
                    if (componentList[i].Stock < coffeneed)
                    {
                        return new ResponseBase { IsOk = false, Message = "There is no enough coffe stock" };
                    }
                }
                else if (componentList[i].ComponentName == "Water")
                {
                    if (componentList[i].Stock < waterneed)
                    {
                        return new ResponseBase { IsOk = false, Message = "There is no enough water in stock" };
                    }
                }

            }
            return new ResponseBase { IsOk = true };
        }

        public decimal AddExtraUnitPricePriceToPrice(decimal price, decimal extraPrice)
        {
            return price + extraPrice;
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
    }
}
