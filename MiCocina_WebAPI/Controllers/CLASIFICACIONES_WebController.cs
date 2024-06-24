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
    public class CLASIFICACIONES_WebController : Controller
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: CLASIFICACIONES_Web
        public ActionResult Index()
        {
            var cLASIFICACIONs = db.CLASIFICACIONs.Include(c => c.RECETA);
            return View(cLASIFICACIONs.ToList());
        }

        // GET: CLASIFICACIONES_Web/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACIONs.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACIONES_Web/Create
        public ActionResult Create()
        {
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta");
            return View();
        }

        // POST: CLASIFICACIONES_Web/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdClasificacion,IdRecetas,Calificacion")] CLASIFICACION cLASIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.CLASIFICACIONs.Add(cLASIFICACION);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", cLASIFICACION.IdRecetas);
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACIONES_Web/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACIONs.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", cLASIFICACION.IdRecetas);
            return View(cLASIFICACION);
        }

        // POST: CLASIFICACIONES_Web/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdClasificacion,IdRecetas,Calificacion")] CLASIFICACION cLASIFICACION)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLASIFICACION).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", cLASIFICACION.IdRecetas);
            return View(cLASIFICACION);
        }

        // GET: CLASIFICACIONES_Web/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLASIFICACION cLASIFICACION = db.CLASIFICACIONs.Find(id);
            if (cLASIFICACION == null)
            {
                return HttpNotFound();
            }
            return View(cLASIFICACION);
        }

        // POST: CLASIFICACIONES_Web/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLASIFICACION cLASIFICACION = db.CLASIFICACIONs.Find(id);
            db.CLASIFICACIONs.Remove(cLASIFICACION);
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
