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
    public class SiteContentsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SiteContents
        public IQueryable<SiteContent> GetSiteContents()
        {
            return db.SiteContents;
        }

        // GET: api/SiteContents/5
        [ResponseType(typeof(SiteContent))]
        public async Task<IHttpActionResult> GetSiteContent(int id)
        {
            SiteContent siteContent = await db.SiteContents.FindAsync(id);
            if (siteContent == null)
            {
                return NotFound();
            }

            return Ok(siteContent);
        }

        // PUT: api/SiteContents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSiteContent(int id, SiteContent siteContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != siteContent.Id)
            {
                return BadRequest();
            }

            db.Entry(siteContent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteContentExists(id))
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

        // POST: api/SiteContents
        [ResponseType(typeof(SiteContent))]
        public async Task<IHttpActionResult> PostSiteContent(SiteContent siteContent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SiteContents.Add(siteContent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = siteContent.Id }, siteContent);
        }

        // DELETE: api/SiteContents/5
        [ResponseType(typeof(SiteContent))]
        public async Task<IHttpActionResult> DeleteSiteContent(int id)
        {
            SiteContent siteContent = await db.SiteContents.FindAsync(id);
            if (siteContent == null)
            {
                return NotFound();
            }

            db.SiteContents.Remove(siteContent);
            await db.SaveChangesAsync();

            return Ok(siteContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SiteContentExists(int id)
        {
            return db.SiteContents.Count(e => e.Id == id) > 0;
        }
    }
}