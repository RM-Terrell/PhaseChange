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
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerId);

            var games = _context.Games.Where(
                m => newRental.GameIds.Contains(m.Id)).ToList();

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