using Microsoft.AspNetCore.Mvc;
using WorldDatabase.Models;
using System.Collections.Generic;
using System;

namespace WorldDatabase.Controllers
{
    public class CityController : Controller
    {
        [HttpGet("/city/index")]
        public ActionResult Index()
        {
            List<City> allCities = City.GetAll();
            return View("index", allCities);
        }
        [HttpGet("search")]
        public ActionResult Search()
        {
            List<City> searchResults = City.SearchCity("'Se%'");
            return View("search", searchResults);

        }


    }
}