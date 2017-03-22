using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PhaseChange.DTOs;
using PhaseChange.Models;

namespace PhaseChange.Controllers.API
{
    public class NewRentalsController: ApiController

    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTO newRental)
        {

            if (newRental.GameIds.Count == 0) //Placed this first since if we dont have any games no reseason for the extra customer queries
                return BadRequest("No Game Ids have been given");

            var customer = _context.Customers.SingleOrDefault(
                c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid");
           
            var games = _context.Games.Where(  //Some of these checks are a form of defensive programmig and may not be needed. Leaving them in for maintenance practice
                m => newRental.GameIds.Contains(m.Id)).ToList();

            if (games.Count != newRental.GameIds.Count)
                return BadRequest("One or more GameIds are invalid");

            foreach(var game in games)
            {
                if (game.NumberAvailable == 0)
                    return BadRequest("Game is not available");

                game.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Game = game,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }


    }


}