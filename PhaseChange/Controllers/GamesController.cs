using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhaseChange.Models;
using PhaseChange.ViewModels;
using System.Data.Entity;


namespace PhaseChange.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext _context; //hey dont be stupid and make this public
        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ViewResult Index()
        {
            var games = _context.Games.Include(g=>g.Genre).ToList();

            return View(games);
        }

        public ActionResult Details(int id)
        {
            var game = _context.Games.Include(g => g.Genre).SingleOrDefault(g => g.Id == id);
            if (game == null)
                return HttpNotFound();
            return View(game);
            
        }




        // GET: Games
        public ActionResult Random()
        {
            var game = new Game() { Name = "Horizon: Zero Dawn" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer {Name = "Cusomter 2" }
            };
            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Customers = customers
            };
            
            return View(viewModel);
            // examples of return types
            // return Content("Hello World!");
            // return HttpNotFound():
            // return new EmptyResult();


        }
        [Route("games/released/{year}/{month:regex(\\d{2}):range(1,12)}")] //regex is for regular expression for attribute routing
        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content(year+"/"+month); //takes two parameters since we gave it two
        }
        
    }
}