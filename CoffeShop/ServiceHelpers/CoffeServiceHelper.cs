using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.GeneralModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoffeShop.ServiceHelpers
{
    public class CoffeServiceHelper
    {
        public async Task<List<Coffe>> GetCoffesAsync()
        {
            var httpClient = new HttpClient();
            var servicePath = new ServicePath();
            var getResponse = await httpClient.GetStringAsync(new Uri(servicePath.ServiceURL + "coffe/getcoffes"));
            var getCoffes = JsonConvert.DeserializeObject<List<Coffe>>(getResponse);
            return getCoffes;
        }
    }
}
