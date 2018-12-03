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

        [HttpGet("/city/newSearch")]
        public ActionResult Create()
        {
            return View("newSearch");
        }

        [HttpPost("/city/search")]
        public ActionResult Search(string inputCity)
        {
            List<City> searchResults = City.SearchCity(inputCity);
            return View("search", searchResults);
        }
    }
}