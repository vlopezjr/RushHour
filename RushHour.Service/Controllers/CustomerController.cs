using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using RushHour.DAL.Repos;
using RushHour.DAL.Repos.Interfaces;
using RushHour.Models.Entities;

namespace RushHour.Service.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerRepo Repo { get; set; }
        private ICustomerAddressRepo AddressRepo { get; set; }

        public CustomerController() : this(new CustomerRepo(), new CustomerAddressRepo()) { }

        public CustomerController(ICustomerRepo repository, ICustomerAddressRepo addressRepo)
        {
            Repo = repository;
            AddressRepo = addressRepo;
        }

        [HttpGet]
        [Route("api/customer")]
        public IHttpActionResult Get() => Ok(Repo.GetAll());
        
        
        // GET api/values/5
        [HttpGet]
        [Route("api/customer/{id}")]
        public IHttpActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

        }

        // GET api/values/5
        [HttpGet]
        [Route("api/customer/{id}/address")]
        public IHttpActionResult GetCustomerAddresses(int id)
        {
            var addresses = AddressRepo.GetAllForCustomer(id);
            return Ok(addresses);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
    }
}
