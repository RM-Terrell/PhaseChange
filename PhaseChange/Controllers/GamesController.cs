using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhaseChange.Models;

namespace PhaseChange.Controllers
{
    public class GamesController : Controller
    {
        // GET: Games
        public ActionResult Random()
        {
            var game = new Game() { Name = "Horizon: Zero Dawn" };

            return View(game);
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