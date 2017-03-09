using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhaseChange.Models;
using System.Web.Mvc;
using System.Data.Entity;
using PhaseChange.ViewModels;

namespace PhaseChange.Controllers
{

    public class CustomersController : Controller

    {
        private ApplicationDbContext _context; //Must set up dbcontext to use customer database
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost] //If action modifies data best security practice to use http post and not get
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id); //Single will toss exception

                customerInDb.Name = customer.Name;  //"normal" way to do this is "TryUpdate" which has massive security holes
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewLetter = customer.IsSubscribedToNewLetter;
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers"); //Redirects into the index of customer controller
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList(); 
            //BOOM can get all customers this way from DB. 
            //ToList executes immediatly. "Include" is for eager loading

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id); 
            //Single or default also executes immediatly
            //More eager loading here 

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel); // you HAVE to specify "new" here or mvc defaults to looking for "edit"
        }

        
    }
}
