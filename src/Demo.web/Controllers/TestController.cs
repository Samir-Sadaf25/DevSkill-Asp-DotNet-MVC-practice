using Demo.web.Models.Test;
using Microsoft.AspNetCore.Mvc;
using Demo.web.Models;
namespace Demo.web.Controllers
{
    public class TestController : Controller
    {
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
