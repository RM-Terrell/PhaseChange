using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PhaseChange.Models;
using PhaseChange.DTOs;
using AutoMapper;
using System.Data.Entity;

namespace PhaseChange.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customerDTOs = _context.Customers
                .Include(c=>c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);

            return Ok(customerDTOs);

        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO) //Could also name this PostCustomer by framework convention but that wont hold up under renaming
                                                          //Using HttpPost explicitley is more versitile
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDTO, customerInDb);
            

            _context.SaveChanges();

            return Ok();



        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();


        }



    }
}
