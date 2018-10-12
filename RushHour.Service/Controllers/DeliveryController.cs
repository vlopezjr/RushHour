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
    public class DeliveryController : ApiController
    {
        private IDeliveryRepo Repo { get; set; }
       

        public DeliveryController() : this(new DeliveryRepo()) { }

        public DeliveryController(IDeliveryRepo repository)
        {
            Repo = repository;
           
        }

        [HttpGet]
        [Route("api/delivery")]
        public IHttpActionResult Get() => Ok(Repo.GetAll());
        
        
        // GET api/values/5
        [HttpGet]
        [Route("api/delivery/{id}")]
        public IHttpActionResult Get(int id)
        {
            var item = Repo.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

        }       

        // POST api/values
        public IHttpActionResult Post([FromBody]Delivery item)
        {
            if (item == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            item.Freights.ForEach(x => x.DeliveryId = item.Id);
            Repo.Add(item);
            return CreatedAtRoute("GetCustomerDeliveries", new { controller = "Delivery", customerId = item.CustomerId }, item);

            
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
