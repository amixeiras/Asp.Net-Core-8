using Application.Interfaces;
using AspNetCore8.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AspNetCore8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEnderecoAppService enderecoAppService;

        public HomeController(ILogger<HomeController> logger, IEnderecoAppService enderecoAppService)
        {
            this.enderecoAppService = enderecoAppService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Endereco = enderecoAppService.GetAll();
            return View();
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
