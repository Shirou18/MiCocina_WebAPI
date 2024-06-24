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
    public class CLASIFICACIONES_APIController : ApiController
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: api/CLASIFICACIONES_API
        public IQueryable<CLASIFICACION> GetCLASIFICACIONs()
        {
            return db.CLASIFICACIONs;
        }

        // GET: api/CLASIFICACIONES_API/5
        [ResponseType(typeof(CLASIFICACION))]
        public IHttpActionResult GetCLASIFICACION(int id)
        {
            CLASIFICACION cLASIFICACION = db.CLASIFICACIONs.Find(id);
            if (cLASIFICACION == null)
            {
                return NotFound();
            }

            return Ok(cLASIFICACION);
        }

        // PUT: api/CLASIFICACIONES_API/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCLASIFICACION(int id, CLASIFICACION cLASIFICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLASIFICACION.IdClasificacion)
            {
                return BadRequest();
            }

            db.Entry(cLASIFICACION).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLASIFICACIONExists(id))
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

        // POST: api/CLASIFICACIONES_API
        [ResponseType(typeof(CLASIFICACION))]
        public IHttpActionResult PostCLASIFICACION(CLASIFICACION cLASIFICACION)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLASIFICACIONs.Add(cLASIFICACION);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cLASIFICACION.IdClasificacion }, cLASIFICACION);
        }

        // DELETE: api/CLASIFICACIONES_API/5
        [ResponseType(typeof(CLASIFICACION))]
        public IHttpActionResult DeleteCLASIFICACION(int id)
        {
            CLASIFICACION cLASIFICACION = db.CLASIFICACIONs.Find(id);
            if (cLASIFICACION == null)
            {
                return NotFound();
            }

            db.CLASIFICACIONs.Remove(cLASIFICACION);
            db.SaveChanges();

            return Ok(cLASIFICACION);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLASIFICACIONExists(int id)
        {
            return db.CLASIFICACIONs.Count(e => e.IdClasificacion == id) > 0;
        }
    }
}