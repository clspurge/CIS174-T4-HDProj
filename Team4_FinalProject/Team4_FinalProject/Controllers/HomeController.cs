using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Team4_FinalProject.Models;
using Microsoft.AspNetCore.Http;

namespace Team4_FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private TicketManagerDbContext context;

        public HomeController(TicketManagerDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var user_id = HttpContext.Session.GetInt32("user_id");
            if (user_id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                List<Ticket> user_tickets;
                TempData["userId"] = user_id;
                var user = context.Users.Single(u => u.UserId == user_id);
                //Can't find a way to lazy load tickets with a single user query only all users so
                //tickets had to be retrieves separate
                if(user.IsTechnician == true)
                {
                    user_tickets = context.Tickets.ToList();
                }
                else
                {
                    user_tickets = context.Tickets.Where(t => t.UserId == user_id).ToList();
                }
                
                ViewBag.User = user;
                ViewBag.Tickets = user_tickets;

                return View();
            }
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
