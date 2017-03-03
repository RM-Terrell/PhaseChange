using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhaseChange.Models;
using System.Web.Mvc;

namespace PhaseChange.Controllers
{

    public class CustomersController : Controller

    {
        private ApplicationDbContext _context; //Must do set up dbcontext to use customer database
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.ToList(); //BOOM can get all customers this way from DB. 
                                                        //ToList executes immediatly

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id); //Single or default also executes immediatly

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        
    }
}
