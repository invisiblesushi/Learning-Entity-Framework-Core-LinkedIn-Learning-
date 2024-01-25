using WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.NetworkInformation;

namespace WebApplication.Controllers
{
    public class ActorsController : Controller
    {
        private ActorDbContext _context;

        public ActorsController(ActorDbContext context) 
        { 
            _context = context;
        }

        public ActionResult Index()
        {
            return View(_context.Actors.ToList());
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Actors actors) 
        { 
            if (ModelState.IsValid)
            {
                _context.Actors.Add(actors);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
