using Demo.web.Codes;
using Demo.web.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Diagnostics;

namespace Demo.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMembership _membership;
        private readonly ILogger<HomeController> _logger;
        public HomeController([FromKeyedServices("setup-1")] IMembership membership, ILogger<HomeController> logger)
        {
            _membership = membership;
            _logger = logger;
        }


        public IActionResult Index(string? id)
        {

            List<Product> product = new List<Product>();
            product.Add(new Product());

            UnitOfWork uow = new UnitOfWork();
            uow.Products.Add(new Product());
            //uow.orders.Add(new Order());
            uow.save(); // works like db context

            Log.Debug("i am in home controller");
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
            _membership.CreateUserAccount(model.username, model.password);

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
