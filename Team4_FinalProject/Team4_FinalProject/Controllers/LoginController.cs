using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team4_FinalProject.Models;
using Team4_FinalProject.ViewModels;
using Microsoft.AspNetCore.Http;

namespace Team4_FinalProject.Controllers
{
    public class LoginController : Controller
    {
        private TicketManagerDbContext context;

        public LoginController(TicketManagerDbContext ctx)
        {
            context = ctx;
        }
        
        public IActionResult Index()
        {
            var model = new LoginViewModel();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = context.Users.Single(u => u.Username == model.Username);
                    if (user.Password == model.Password)
                    {
                        HttpContext.Session.SetInt32("user_id", user.UserId);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Passwords Do Not Match");
                        return View(model);
                    }
                }
                catch {
                    ModelState.AddModelError("", "Username is not valid");
                    return View(model);
                };

            }
            else
            {
                return View(model);
            }
           
        }

        public IActionResult Logout(LoginViewModel model)
        {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
        }
    }
}
