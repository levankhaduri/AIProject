using AIProject.Models;
using AIProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AIProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchService _searchService;

        public HomeController(ILogger<HomeController> logger, ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SearchAsync(IFormCollection form)
        {
            var search = form["search"].FirstOrDefault();

            var url = await _searchService.GetImage(search);

            return View(url);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}