using Lesson_7_Validation.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lesson_7_Validation.Controllers
{
    public class LoginRegisterController : Controller
    {
      
        private static List<RegisterViewModel> users = new List<RegisterViewModel>();

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

                if (user != null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
            }
            ViewBag.PostAttempt = true; 
            return View(login);
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.PostAttempt = false; 
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
               
                if (users.Any(u => u.Username == register.Username))
                {
                    ModelState.AddModelError(string.Empty, "Username already exists.");
                }
                else
                {
                  
                    users.Add(register);
                   
                    return RedirectToAction("Login");
                }
            }
            return View(register);
        }
    }
}
