using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FuelEfficiency.Models;
using Microsoft.AspNetCore.Mvc;

namespace FuelEfficiency.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// //gets information from user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {   
            //resets page
            ViewBag.MPG = 0;
            ViewBag.LPK = 0;
            TempData.Clear();
            return View();
        }
        /// <summary>
        /// //shows information from user
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(CarValueModel model)
        {
            //declaring listContainer
            ListContainer listContainer = TempDataChanger.Get<ListContainer>(TempData, "ListContainer");

            //if it doesn't exsit, make one
            if (listContainer == null)
            {
                listContainer = new ListContainer();
            }

            //if validations are corrtect run code, otherwise set bag to default
            if (ModelState.IsValid)
            {
                ViewBag.MPG = model.CalculateMilesPerGallon();
                ViewBag.LPK = model.CalculateLitersPerKilometer();
                listContainer.ModelList.Add(model);
                TempDataChanger.Put<ListContainer>(TempData, "ListContainer", listContainer);
            }
            else
            {
                ViewBag.MPG = 0;
                ViewBag.LPK = 0;
            }
            return View(model);
        }
    }
}
