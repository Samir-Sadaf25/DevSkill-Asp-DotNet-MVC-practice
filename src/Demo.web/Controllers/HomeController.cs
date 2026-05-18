using Cortex.Mediator;
using Demo.Application.Contracts;
using Demo.Application.Features.Products.Command;
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
        private readonly IMediator _mediator;

        public HomeController( ILogger<HomeController> logger,IMediator mediator)
        {
            
            _logger = logger;
            _mediator = mediator;
        }


        public IActionResult Index(string? id)
        {
            var command = new ProductAddCommand
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Price = 100
            };
            var result = _mediator.SendCommandAsync(command).Result;
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
