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
    public class COMENTARIOS_APIController : ApiController
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: api/COMENTARIOS_API
        public IQueryable<COMENTARIO> GetCOMENTARIOs()
        {
            return db.COMENTARIOs;
        }

        // GET: api/COMENTARIOS_API/5
        [ResponseType(typeof(COMENTARIO))]
        public IHttpActionResult GetCOMENTARIO(int id)
        {
            COMENTARIO cOMENTARIO = db.COMENTARIOs.Find(id);
            if (cOMENTARIO == null)
            {
                return NotFound();
            }

            return Ok(cOMENTARIO);
        }

        // PUT: api/COMENTARIOS_API/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCOMENTARIO(int id, COMENTARIO cOMENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cOMENTARIO.IdComentario)
            {
                return BadRequest();
            }

            db.Entry(cOMENTARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!COMENTARIOExists(id))
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

        // POST: api/COMENTARIOS_API
        [ResponseType(typeof(COMENTARIO))]
        public IHttpActionResult PostCOMENTARIO(COMENTARIO cOMENTARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.COMENTARIOs.Add(cOMENTARIO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cOMENTARIO.IdComentario }, cOMENTARIO);
        }

        // DELETE: api/COMENTARIOS_API/5
        [ResponseType(typeof(COMENTARIO))]
        public IHttpActionResult DeleteCOMENTARIO(int id)
        {
            COMENTARIO cOMENTARIO = db.COMENTARIOs.Find(id);
            if (cOMENTARIO == null)
            {
                return NotFound();
            }

            db.COMENTARIOs.Remove(cOMENTARIO);
            db.SaveChanges();

            return Ok(cOMENTARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool COMENTARIOExists(int id)
        {
            return db.COMENTARIOs.Count(e => e.IdComentario == id) > 0;
        }
    }
}