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
        private readonly ICatsRepository _catRepository;
        private readonly IImageRepository _imageRepository;

        public HomeController(ICatsRepository catRepository, IImageRepository imageRepository)
        {
            _catRepository = catRepository;
            _imageRepository = imageRepository;
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
            cats = await _catRepository.GetQuantityOfCats(10);
            return View(cats);
        }
        public async Task<IActionResult> CatPage(string name)
        {
            List<Cats> cats;
            cats = await _catRepository.GetCatByName(name);
            ImageViewModel image = await _imageRepository.GetImageById(cats[0].reference_image_id);
            if(image != null)
            {
                image.Cats = await _catRepository.GetQuantityOfCats(8);
                return View(image);
            }
            cats = await _catRepository.GetQuantityOfCats(10);
            return View(cats);
        }
    }
}
