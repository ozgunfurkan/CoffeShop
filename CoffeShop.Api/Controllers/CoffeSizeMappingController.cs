using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Bussiness.Bussiness;
using CoffeShop.Data.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeSizeMappingController : ControllerBase
    {
        [HttpGet("getcoffesizes")]
        public IActionResult GetCoffeSize(int coffeId)
        {
            CoffeSizeMappingBussiness coffeSizeMapping = new CoffeSizeMappingBussiness();
            List<Coffe_CoffeSize_View> coffeList = coffeSizeMapping.GetCoffeSizeByCoffeId(coffeId);
            return Ok(coffeList);
        }
    }
}