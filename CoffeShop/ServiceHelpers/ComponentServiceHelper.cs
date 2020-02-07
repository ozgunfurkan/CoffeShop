using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using CoffeShop.Data.Models.RequestModels;
using CoffeShop.Data.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoffeShop.ServiceHelpers
{
    public class ComponentServiceHelper
    {
        public async Task<ResponseBase> GetOrderAsync(decimal milkNeed,decimal coffeNeed,decimal waterNeed,bool milkCheck,bool coffeCheck,bool waterCheck)
        {
            var httpClient = new HttpClient();
            var servicePath = new ServicePath();
            var getResponse = await httpClient.GetStringAsync(new Uri(string.Format(servicePath.ServiceURL + "component/getoffer?milkNeed={0}&coffeNeed={1}&waterNeed={2}&milkCheck={3}&coffeCheck={4}&waterCheck={5}", milkNeed,coffeNeed,waterNeed,milkCheck,coffeCheck,waterCheck)));
            var response = JsonConvert.DeserializeObject<ResponseBase>(getResponse);
            return response;
        }

        public async Task<ComponentStocks> ConfirmOrderAsync(decimal milkNeed, decimal coffeNeed, decimal waterNeed, bool milkCheck, bool coffeCheck, bool waterCheck)
        {
            var httpClient = new HttpClient();
            var servicePath = new ServicePath();

            ComponentUpdate componentUpdate = new ComponentUpdate();
            componentUpdate.MilkNeed = milkNeed;
            componentUpdate.CoffeNeed = coffeNeed;
            componentUpdate.WaterNeed = waterNeed;
            componentUpdate.ExtraMilk = milkCheck;
            componentUpdate.ExtraCoffe = coffeCheck;
            componentUpdate.ExtraWater = waterCheck;

            var serialazeJSON = JsonConvert.SerializeObject(componentUpdate);
            var returnResult = await httpClient.PutAsync(servicePath.ServiceURL + "component/confirmorder", new StringContent(serialazeJSON, Encoding.UTF8, "application/json"));
            var contents = await returnResult.Content.ReadAsStringAsync();
            ComponentStocks response = JsonConvert.DeserializeObject<ComponentStocks>(contents);
            return response;
        }

        public async Task<List<Component>> GetStockDataAsync()
        {
            var httpClient = new HttpClient();
            var servicePath = new ServicePath();
            var getResponse = await httpClient.GetStringAsync(new Uri(string.Format(servicePath.ServiceURL + "component/getstockdata")));
            var response = JsonConvert.DeserializeObject<List<Component>>(getResponse);
            return response;
        }
    }
}
