using Demo.Application.Contracts;
using Demo.Domain.Entities;
using Demo.web.Codes;
using Demo.web.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace Demo.web.Controllers
{
    public class HomeController : Controller
    {
       // private readonly IMembership _membership;
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationUnitOfWork _unitOfWork;
        public HomeController(IApplicationUnitOfWork unitOfWork, ILogger<HomeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }


        public IActionResult Index(string? id)
        {

            _unitOfWork.ProductRepository.add(new Product { Id = Guid.NewGuid(), Name = "sample product", Price = 9.99 });
            _unitOfWork.save();
            //Log.Debug("i am in home controller");
            return View();
        }

        public IActionResult CreateAccount()
        {
            var model = new AccountModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateAccount(AccountModel model)
        {
          

            return View(model);
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
