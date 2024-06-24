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
    public class RECETAS_WebController : Controller
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: RECETAS_Web
        public ActionResult Index()
        {
            var rECETAS = db.RECETAS.Include(r => r.USUARIO);
            return View(rECETAS.ToList());
        }

        // GET: RECETAS_Web/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECETA rECETA = db.RECETAS.Find(id);
            if (rECETA == null)
            {
                return HttpNotFound();
            }
            return View(rECETA);
        }

        // GET: RECETAS_Web/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario");
            return View();
        }

        // POST: RECETAS_Web/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRecetas,TituloReceta,DescripcionReceta,IngredientesReceta,ImagenRecetas,DificultadRecetas,PorcionRecetas,IdUsuario")] RECETA rECETA)
        {
            if (ModelState.IsValid)
            {
                db.RECETAS.Add(rECETA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", rECETA.IdUsuario);
            return View(rECETA);
        }

        // GET: RECETAS_Web/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECETA rECETA = db.RECETAS.Find(id);
            if (rECETA == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", rECETA.IdUsuario);
            return View(rECETA);
        }

        // POST: RECETAS_Web/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRecetas,TituloReceta,DescripcionReceta,IngredientesReceta,ImagenRecetas,DificultadRecetas,PorcionRecetas,IdUsuario")] RECETA rECETA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rECETA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", rECETA.IdUsuario);
            return View(rECETA);
        }

        // GET: RECETAS_Web/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECETA rECETA = db.RECETAS.Find(id);
            if (rECETA == null)
            {
                return HttpNotFound();
            }
            return View(rECETA);
        }

        // POST: RECETAS_Web/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECETA rECETA = db.RECETAS.Find(id);
            db.RECETAS.Remove(rECETA);
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
