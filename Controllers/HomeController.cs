﻿using CatWiki.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CatWiki.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            List<Cats> cats;
            string getBreeds;
            string errorString;

            getBreeds = "https://api.thecatapi.com/v1/breeds?limit=4&page=4";
            var request = new HttpRequestMessage(HttpMethod.Get, getBreeds);
            errorString = "Error to call " + getBreeds;

            var Client = _clientFactory.CreateClient();

            HttpResponseMessage response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                cats = await response.Content.ReadFromJsonAsync<List<Cats>>();
                return View(cats);
            }
            return View();
        }

        public async Task<IActionResult>  Breeds()
        {
            List<Cats> cats = new List<Cats>();
            string errorString;
            string getBreeds;

            getBreeds = "https://api.thecatapi.com/v1/breeds";
            var request = new HttpRequestMessage(HttpMethod.Get,getBreeds);
            errorString = "Error to call " + getBreeds;

            var Client = _clientFactory.CreateClient();

            HttpResponseMessage response = await Client.SendAsync(request);
            if(response.IsSuccessStatusCode)
            {
                var catsList = await response.Content.ReadFromJsonAsync<List<Cats>>();
                return View(catsList);
            }
            return Ok(errorString);
        }
        public async Task<IActionResult> CatPage(string name)
        {
            string errorString;
            string getBreeds;
            List<Cats> cat;

            getBreeds = "https://api.thecatapi.com/v1/breeds/search?q=" + name;
            var request = new HttpRequestMessage(HttpMethod.Get, getBreeds);
            errorString = "Error to call " + getBreeds;

            var Client = _clientFactory.CreateClient();

            HttpResponseMessage response = await Client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                cat = await response.Content.ReadFromJsonAsync<List<Cats>>();
                return View(cat);
            }
            return Ok(errorString);
        }
    }
}
