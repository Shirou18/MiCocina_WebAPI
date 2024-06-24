using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiCocina_WebAPI.Models;

namespace MiCocina_WebAPI.Controllers
{
    public class COMENTARIOS_WebController : Controller
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: COMENTARIOS_Web
        public ActionResult Index()
        {
            var cOMENTARIOs = db.COMENTARIOs.Include(c => c.RECETA).Include(c => c.USUARIO);
            return View(cOMENTARIOs.ToList());
        }

        // GET: COMENTARIOS_Web/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMENTARIO cOMENTARIO = db.COMENTARIOs.Find(id);
            if (cOMENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(cOMENTARIO);
        }

        // GET: COMENTARIOS_Web/Create
        public ActionResult Create()
        {
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta");
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario");
            return View();
        }

        // POST: COMENTARIOS_Web/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdComentario,Comentario1,FechaComentario,IdUsuario,IdRecetas")] COMENTARIO cOMENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.COMENTARIOs.Add(cOMENTARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", cOMENTARIO.IdRecetas);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", cOMENTARIO.IdUsuario);
            return View(cOMENTARIO);
        }

        // GET: COMENTARIOS_Web/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMENTARIO cOMENTARIO = db.COMENTARIOs.Find(id);
            if (cOMENTARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", cOMENTARIO.IdRecetas);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", cOMENTARIO.IdUsuario);
            return View(cOMENTARIO);
        }

        // POST: COMENTARIOS_Web/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdComentario,Comentario1,FechaComentario,IdUsuario,IdRecetas")] COMENTARIO cOMENTARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cOMENTARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", cOMENTARIO.IdRecetas);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", cOMENTARIO.IdUsuario);
            return View(cOMENTARIO);
        }

        // GET: COMENTARIOS_Web/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            COMENTARIO cOMENTARIO = db.COMENTARIOs.Find(id);
            if (cOMENTARIO == null)
            {
                return HttpNotFound();
            }
            return View(cOMENTARIO);
        }

        // POST: COMENTARIOS_Web/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            COMENTARIO cOMENTARIO = db.COMENTARIOs.Find(id);
            db.COMENTARIOs.Remove(cOMENTARIO);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
