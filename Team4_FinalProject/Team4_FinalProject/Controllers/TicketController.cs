using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team4_FinalProject.Models;

namespace Team4_FinalProject.Controllers
{
    public class TicketController : Controller
    {
        private TicketManagerDbContext context;

        public TicketController(TicketManagerDbContext ctx)
        {
            context = ctx;
        }
        public IActionResult Index()
        {
            return View("List");
        }

        [HttpGet]
        public IActionResult Add(int id)
        {
            //To display user name
            var user = context.Users.Find(id);
            ViewBag.User = user;
            Ticket model = new();
            model.UserId = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                ViewBag.User = context.Users.Find(ticket.UserId);
                ModelState.AddModelError("Invalid", "Model State was invalid what did you do?");
                return View(ticket);
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Ticket ticket = context.Tickets.Find(id);
            ViewBag.Ticket = ticket;
            ViewBag.TicketId = id;
            //Also grabbing tickets like I showed in others I don't know how to load related
            //Entities whilst grabbing only one entity 
            List<Note> notes = context.Notes.Where(c => c.TicketId == id).ToList();
            ViewBag.Notes = notes;
            return View(ticket);
        }
    }
}
