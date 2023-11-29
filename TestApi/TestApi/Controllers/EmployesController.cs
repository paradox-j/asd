using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestApi.Entities;

namespace TestApi.Controllers
{
    public class EmployesController : ApiController
    {
        private TestEntities db = new TestEntities();

        // GET: api/Employes
        public IQueryable<Employes> GetEmployes()
        {
            return db.Employes;
        }

        // GET: api/Employes/5
        [ResponseType(typeof(Employes))]
        public IHttpActionResult GetEmployes(int id)
        {
            Employes employes = db.Employes.Find(id);
            if (employes == null)
            {
                return NotFound();
            }

            return Ok(employes);
        }

        // PUT: api/Employes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployes(int id, Employes employes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employes.EmployeeID)
            {
                return BadRequest();
            }

            db.Entry(employes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployesExists(id))
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

        // POST: api/Employes
        [ResponseType(typeof(Employes))]
        public IHttpActionResult PostEmployes(Employes employes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employes.Add(employes);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployesExists(employes.EmployeeID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employes.EmployeeID }, employes);
        }

        // DELETE: api/Employes/5
        [ResponseType(typeof(Employes))]
        public IHttpActionResult DeleteEmployes(int id)
        {
            Employes employes = db.Employes.Find(id);
            if (employes == null)
            {
                return NotFound();
            }

            db.Employes.Remove(employes);
            db.SaveChanges();

            return Ok(employes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployesExists(int id)
        {
            return db.Employes.Count(e => e.EmployeeID == id) > 0;
        }
    }
}