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

            /*
              AppDbContext c = new AppDbContext();
              var products = c.Products.Where(x => x.Price > 100); 🚫 Direct DbContext now allowed

            // var products = _productRepository.GetBestSellingProducts(5);//Controller does NOT know DB logic

             */

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
