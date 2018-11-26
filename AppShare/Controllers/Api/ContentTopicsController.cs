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
using AppShare.Models;

namespace AppShare.Controllers.Api
{
    public class ContentTopicsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ContentTopics
        public IQueryable<ContentTopics> GetContentTopics()
        {
            return db.ContentTopics;
        }




        /*
             // GET: api/ContentTopics/5
             [ResponseType(typeof(ContentTopics))]
             public async Task<IHttpActionResult> GetContentTopics(int id)
             {
                 ContentTopics contentTopics = await db.ContentTopics.FindAsync(id);
                 if (contentTopics == null)
                 {
                     return NotFound();
                 }

                 return Ok(contentTopics);
             }
     */
        // GET: api/ContentTopics/5
        public List<ContentTopics> GetContentTopics(int id)
        {
            List<ContentTopics> result = new List<ContentTopics>();
            GetTopic(id, result);
            return result;
        }

        private void GetTopic(int id, List<ContentTopics> result)
        {
            var customer = db.ContentTopics.SingleOrDefault(c => c.Id == id);
            result.Add(customer);
            if (customer.ParentId != 0)
            {
                GetTopic(customer.ParentId, result);
            }
        }





        // PUT: api/ContentTopics/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutContentTopics(int id, ContentTopics contentTopics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contentTopics.Id)
            {
                return BadRequest();
            }

            db.Entry(contentTopics).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContentTopicsExists(id))
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

        // POST: api/ContentTopics
        [ResponseType(typeof(ContentTopics))]
        public async Task<IHttpActionResult> PostContentTopics(ContentTopics contentTopics)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContentTopics.Add(contentTopics);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = contentTopics.Id }, contentTopics);
        }

        // DELETE: api/ContentTopics/5
        [ResponseType(typeof(ContentTopics))]
        public async Task<IHttpActionResult> DeleteContentTopics(int id)
        {
            ContentTopics contentTopics = await db.ContentTopics.FindAsync(id);
            if (contentTopics == null)
            {
                return NotFound();
            }

            db.ContentTopics.Remove(contentTopics);
            await db.SaveChangesAsync();

            return Ok(contentTopics);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContentTopicsExists(int id)
        {
            return db.ContentTopics.Count(e => e.Id == id) > 0;
        }
    }
}