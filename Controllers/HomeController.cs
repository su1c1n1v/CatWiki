using CatWiki.Data;
using CatWiki.Models;
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
        private readonly ICatsRepository _catRepository;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory, ICatsRepository catRepository)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            _catRepository = catRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Cats> cats;
            cats = await _catRepository.GetQuantityOfCats(4);
            return View(cats);
        }

        public async Task<IActionResult>  Breeds()
        {
            List<Cats> cats;
            cats = await _catRepository.GetAllCats();
            return View(cats);
        }
        public async Task<IActionResult> CatPage(string name)
        {
            List<Cats> cats;
            cats = await _catRepository.GetCatByName(name);
            return View(cats);
        }
    }
}
