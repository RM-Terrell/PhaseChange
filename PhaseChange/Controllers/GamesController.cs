using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhaseChange.Models;
using PhaseChange.ViewModels;
using System.Data.Entity;
using PhaseChange.Migrations;


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
            if (User.IsInRole(RoleName.CanManageGames))
                return View("List");

            return View("ReadOnlyList"); //Dont need to put this in an else block
        }


        [Authorize(Roles = RoleName.CanManageGames)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new GameFormViewModel
            {
                Genres = genres
            };
            return View("GameForm", viewModel);


        }

        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(c => c.Id == id);

            if (game == null)
                return HttpNotFound();

            var viewModel = new GameFormViewModel(game)
            {
                
                Genres = _context.Genres.ToList()
            };

            return View("GameForm", viewModel);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel(game)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("GameForm", viewModel);
            }



            if(game.Id == 0)
            {
                game.DateAdded = DateTime.Now;
                _context.Games.Add(game);

            }
            else
            {
                var gameInDb = _context.Games.Single(g => g.Id == game.Id);
                gameInDb.Name = game.Name;
                gameInDb.GenreId = game.GenreId;
                gameInDb.NumberInStock = game.NumberInStock;
                gameInDb.ReleaseDate = game.ReleaseDate;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Games"); //send user back to the index page for games after editing

        }





    }
}