using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoffeShop.Models;
using CoffeShop.ServiceHelpers;
using CoffeShop.Data.Models.DataModels;
using CoffeShop.Data.Models.ViewModel;

namespace CoffeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            CoffeServiceHelper coffeService = new CoffeServiceHelper();
            List<Coffe> coffeList = await coffeService.GetCoffesAsync();

            ComponentServiceHelper componentService = new ComponentServiceHelper();
            List<Component> componentList = await componentService.GetStockDataAsync();

            ViewBag.CoffeInStock = componentList[0].Stock;
            ViewBag.MilkInStock = componentList[1].Stock;
            ViewBag.WaterInStock = componentList[2].Stock;

            return View(coffeList);
        }

        public async Task<IActionResult> GetCoffeSizes(int coffeId)
        {
            Coffe_CoffeSize_MappingServiceHelper coffe_CoffeSize = new Coffe_CoffeSize_MappingServiceHelper();
            List<Coffe_CoffeSize_View> coffeList = await coffe_CoffeSize.GetCoffeSizesAsync(coffeId);
            return PartialView("~/Views/Home/Partial/SizeDropDown.cshtml", coffeList);
        }

        public async Task<IActionResult> GetOrderDetail(decimal milkNeed, 
            decimal coffeNeed,decimal waterNeed,bool milkCheck,bool coffeCheck,bool waterCheck)
        {
            ComponentServiceHelper componentService = new ComponentServiceHelper();
            var response = await componentService.GetOrderAsync(milkNeed,coffeNeed,waterNeed,milkCheck,coffeCheck,waterCheck);
            return Json(response);
        }

        public async Task<IActionResult> ConfirmOrder(decimal milkNeed,
            decimal coffeNeed, decimal waterNeed, bool milkCheck, bool coffeCheck, bool waterCheck)
        {
            ComponentServiceHelper componentService = new ComponentServiceHelper();
            var response = await componentService.ConfirmOrderAsync(milkNeed, coffeNeed, waterNeed, milkCheck, coffeCheck, waterCheck);
            return Json(response);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
