using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeShop.Bussiness.Bussiness;
using CoffeShop.Data.Models.GeneralModels;
using CoffeShop.Data.Models.RequestModels;
using CoffeShop.Data.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        [HttpGet("getoffer")]
        public IActionResult GetOffer(string milkNeed, string coffeNeed, string waterNeed, bool milkCheck, bool coffeCheck, bool waterCheck)
        {
            ComponentBussiness component = new ComponentBussiness();
            ResponseBase response = component.GetOffer(decimal.Parse(milkNeed),decimal.Parse(coffeNeed),decimal.Parse(waterNeed), milkCheck,coffeCheck,waterCheck);
            return Ok(response);
        }

        [HttpPut("confirmorder")]
        public IActionResult ConfirmOrder([FromBody] ComponentUpdate componentUpdate)
        {
            ComponentBussiness component = new ComponentBussiness();
            ComponentStocks componentStocks = component.ConfirmOrder(componentUpdate);
            return Ok(componentStocks);
        }
    }
}