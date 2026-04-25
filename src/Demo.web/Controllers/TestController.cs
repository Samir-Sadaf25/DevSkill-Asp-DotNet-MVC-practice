using Demo.web.Codes;
using Demo.web.Models;
using Demo.web.Models.Test;
using Microsoft.AspNetCore.Mvc;
namespace Demo.web.Controllers
{
    public class TestController : Controller
    {
        private readonly IMembership _membership;

        public TestController([FromKeyedServices("setup-2")] IMembership membership)
        {
            _membership = membership;
        }

        public IActionResult Index()
        {
            var model = new TestHome
            { Name = "samir",
              Email = "samirsadaf@gmail.com",
              partialModel = new PartialModel
              {
                  Address = "Dhaka"
              }
            };
            
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Index(TestHome model)
        {
            if(ModelState.IsValid)
            {
                var name = model.Name;
                var email = model.Email;
            }
            return View(model);
        }
    }
}
