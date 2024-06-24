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
    public class RECETAS_APIController : ApiController
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: api/RECETAS_API
        public IQueryable<RECETA> GetRECETAS()
        {
            return db.RECETAS;
        }

        // GET: api/RECETAS_API/5
        [ResponseType(typeof(RECETA))]
        public IHttpActionResult GetRECETA(int id)
        {
            RECETA rECETA = db.RECETAS.Find(id);
            if (rECETA == null)
            {
                return NotFound();
            }

            return Ok(rECETA);
        }

        // PUT: api/RECETAS_API/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRECETA(int id, RECETA rECETA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rECETA.IdRecetas)
            {
                return BadRequest();
            }

            db.Entry(rECETA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RECETAExists(id))
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

        // POST: api/RECETAS_API
        [ResponseType(typeof(RECETA))]
        public IHttpActionResult PostRECETA(RECETA rECETA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RECETAS.Add(rECETA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rECETA.IdRecetas }, rECETA);
        }

        // DELETE: api/RECETAS_API/5
        [ResponseType(typeof(RECETA))]
        public IHttpActionResult DeleteRECETA(int id)
        {
            RECETA rECETA = db.RECETAS.Find(id);
            if (rECETA == null)
            {
                return NotFound();
            }

            db.RECETAS.Remove(rECETA);
            db.SaveChanges();

            return Ok(rECETA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RECETAExists(int id)
        {
            return db.RECETAS.Count(e => e.IdRecetas == id) > 0;
        }
    }
}