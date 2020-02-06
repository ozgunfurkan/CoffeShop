using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using CoffeShop.Data.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoffeShop.ServiceHelpers
{
    public class Coffe_CoffeSize_MappingServiceHelper
    {
        public async Task<List<Coffe_CoffeSize_View>> GetCoffeSizesAsync(int coffeId)
        {
            var httpClient = new HttpClient();
            var servicePath = new ServicePath();
            var getResponse = await httpClient.GetStringAsync(new Uri(servicePath.ServiceURL + "coffesizemapping/getcoffesizes?coffeId="+ coffeId));
            var getCoffeSizes = JsonConvert.DeserializeObject<List<Coffe_CoffeSize_View>>(getResponse);
            return getCoffeSizes;
        }
    }
}
