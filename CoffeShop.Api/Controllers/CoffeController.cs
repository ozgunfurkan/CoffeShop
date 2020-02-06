using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Bussiness.Bussiness;
using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeController : ControllerBase
    {
        [HttpGet("getcoffes")]
        public IActionResult GetCoffes()
        {
            //CoffeBussiness coffe = new CoffeBussiness();
            //List<Coffe_CoffeSize_View> coffeList = coffe.GetCoffes();
            return Ok();
        }
    }
}