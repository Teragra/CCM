using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    public class CustomerContactsController : ApiController
    {
        private BackEndContext db = new BackEndContext();

        // GET: api/CustomerContacts
        public IQueryable<CustomerContact> GetCustomerContacts()
        {
            return db.CustomerContacts;
        }

        // GET: api/CustomerContacts/5
        [ResponseType(typeof(CustomerContact))]
        public async Task<IHttpActionResult> GetCustomerContact(int id)
        {
            CustomerContact customerContact = await db.CustomerContacts.FindAsync(id);
            if (customerContact == null)
            {
                return NotFound();
            }

            return Ok(customerContact);
        }

        // PUT: api/CustomerContacts/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerContact(int id, CustomerContact customerContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerContact.ID)
            {
                return BadRequest();
            }

            db.Entry(customerContact).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerContacts
        [ResponseType(typeof(CustomerContact))]
        public async Task<IHttpActionResult> PostCustomerContact(CustomerContact customerContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerContacts.Add(customerContact);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerContact.ID }, customerContact);
        }

        // DELETE: api/CustomerContacts/5
        [ResponseType(typeof(CustomerContact))]
        public async Task<IHttpActionResult> DeleteCustomerContact(int id)
        {
            CustomerContact customerContact = await db.CustomerContacts.FindAsync(id);
            if (customerContact == null)
            {
                return NotFound();
            }

            db.CustomerContacts.Remove(customerContact);
            await db.SaveChangesAsync();

            return Ok(customerContact);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerContactExists(int id)
        {
            return db.CustomerContacts.Count(e => e.ID == id) > 0;
        }
    }
}