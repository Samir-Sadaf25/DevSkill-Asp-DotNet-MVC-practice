using Demo.web.Models.Test;
using Microsoft.AspNetCore.Mvc;

namespace Demo.web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            var model = new TestHome { Name = "samir", Email = "samirsadaf@gmail.com" };
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
