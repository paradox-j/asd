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
    public class VisitorsController : ApiController
    {
        private TestEntities db = new TestEntities();

        // GET: api/Visitors
        public IQueryable<Visitors> GetVisitors()
        {
            return db.Visitors;
        }

        // GET: api/Visitors/5
        [ResponseType(typeof(Visitors))]
        public IHttpActionResult GetVisitors(int id)
        {
            Visitors visitors = db.Visitors.Find(id);
            if (visitors == null)
            {
                return NotFound();
            }

            return Ok(visitors);
        }

        // PUT: api/Visitors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitors(int id, Visitors visitors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitors.VisitorID)
            {
                return BadRequest();
            }

            db.Entry(visitors).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitorsExists(id))
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

        // POST: api/Visitors
        [ResponseType(typeof(Visitors))]
        public IHttpActionResult PostVisitors(Visitors visitors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Visitors.Add(visitors);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visitors.VisitorID }, visitors);
        }

        // DELETE: api/Visitors/5
        [ResponseType(typeof(Visitors))]
        public IHttpActionResult DeleteVisitors(int id)
        {
            Visitors visitors = db.Visitors.Find(id);
            if (visitors == null)
            {
                return NotFound();
            }

            db.Visitors.Remove(visitors);
            db.SaveChanges();

            return Ok(visitors);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitorsExists(int id)
        {
            return db.Visitors.Count(e => e.VisitorID == id) > 0;
        }
    }
}