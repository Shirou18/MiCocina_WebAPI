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
using MiCocina_WebAPI.Models;

namespace MiCocina_WebAPI.Controllers
{
    public class FAVORITOS_APIController : ApiController
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: api/FAVORITOS_API
        public IQueryable<FAVORITO> GetFAVORITOS()
        {
            return db.FAVORITOS;
        }

        // GET: api/FAVORITOS_API/5
        [ResponseType(typeof(FAVORITO))]
        public IHttpActionResult GetFAVORITO(int id)
        {
            FAVORITO fAVORITO = db.FAVORITOS.Find(id);
            if (fAVORITO == null)
            {
                return NotFound();
            }

            return Ok(fAVORITO);
        }

        // PUT: api/FAVORITOS_API/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFAVORITO(int id, FAVORITO fAVORITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fAVORITO.IdFavoritos)
            {
                return BadRequest();
            }

            db.Entry(fAVORITO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FAVORITOExists(id))
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

        // POST: api/FAVORITOS_API
        [ResponseType(typeof(FAVORITO))]
        public IHttpActionResult PostFAVORITO(FAVORITO fAVORITO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.FAVORITOS.Add(fAVORITO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = fAVORITO.IdFavoritos }, fAVORITO);
        }

        // DELETE: api/FAVORITOS_API/5
        [ResponseType(typeof(FAVORITO))]
        public IHttpActionResult DeleteFAVORITO(int id)
        {
            FAVORITO fAVORITO = db.FAVORITOS.Find(id);
            if (fAVORITO == null)
            {
                return NotFound();
            }

            db.FAVORITOS.Remove(fAVORITO);
            db.SaveChanges();

            return Ok(fAVORITO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FAVORITOExists(int id)
        {
            return db.FAVORITOS.Count(e => e.IdFavoritos == id) > 0;
        }
    }
}