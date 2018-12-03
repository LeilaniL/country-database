using Microsoft.AspNetCore.Mvc;
using WorldDatabase.Models;
using System.Collections.Generic;
using System;

namespace WorldDatabase.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet("/country/index")]
        public ActionResult Index()
        {
            List<Country> allCountries = Country.GetAll();
            return View("index", allCountries);
        }

        [HttpGet("/country/newSearch")]
        public ActionResult Create()
        {
            return View("newSearch");
        }

        [HttpPost("/country/search")]
        public ActionResult Search(string inputCountry)
        {
            List<Country> searchResults = Country.SearchCountry(inputCountry);
            return View("search", searchResults);
        }
    }
}