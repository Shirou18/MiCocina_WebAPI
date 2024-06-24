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
    public class USUARIOS_APIController : ApiController
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: api/USUARIOS_API
        public IQueryable<USUARIO> GetUSUARIOs()
        {
            return db.USUARIOs;
        }

        // GET: api/USUARIOS_API/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult GetUSUARIO(int id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            return Ok(uSUARIO);
        }

        // PUT: api/USUARIOS_API/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUSUARIO(int id, USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uSUARIO.IdUsuario)
            {
                return BadRequest();
            }

            db.Entry(uSUARIO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!USUARIOExists(id))
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

        // POST: api/USUARIOS_API
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult PostUSUARIO(USUARIO uSUARIO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.USUARIOs.Add(uSUARIO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = uSUARIO.IdUsuario }, uSUARIO);
        }

        // DELETE: api/USUARIOS_API/5
        [ResponseType(typeof(USUARIO))]
        public IHttpActionResult DeleteUSUARIO(int id)
        {
            USUARIO uSUARIO = db.USUARIOs.Find(id);
            if (uSUARIO == null)
            {
                return NotFound();
            }

            db.USUARIOs.Remove(uSUARIO);
            db.SaveChanges();

            return Ok(uSUARIO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool USUARIOExists(int id)
        {
            return db.USUARIOs.Count(e => e.IdUsuario == id) > 0;
        }
    }
}