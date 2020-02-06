using CoffeShop.Data.Models.GeneralModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
    }
}
