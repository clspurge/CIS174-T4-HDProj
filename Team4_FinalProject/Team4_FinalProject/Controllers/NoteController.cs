using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team4_FinalProject.Models;

namespace Team4_FinalProject.Controllers
{
    public class NoteController : Controller
    {
        private TicketManagerDbContext context { get; set; }
        public NoteController(TicketManagerDbContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Add(int id)
        {
            Note n = new();
            n.TicketId = id;
            return View(n);
        }

        [HttpPost]
        public IActionResult Add(Note n)
        {
            if (ModelState.IsValid)
            {
                if (n.NoteId == 0)
                {
                    context.Notes.Add(n);
                    context.SaveChanges();
                }
                var routeId = new RouteValueDictionary
                {
                    {"id", n.TicketId}
                };
                return RedirectToAction("Details", "Ticket", routeId);
            }
            else
            {
                ModelState.AddModelError("", "Something is wrong with the input! Try again.");
                return View(n);
            }
        }
    }
}
