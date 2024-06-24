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
    public class FAVORITOS_WebController : Controller
    {
        private MiCocinaBDEntities db = new MiCocinaBDEntities();

        // GET: FAVORITOS_Web
        public ActionResult Index()
        {
            var fAVORITOS = db.FAVORITOS.Include(f => f.RECETA).Include(f => f.USUARIO);
            return View(fAVORITOS.ToList());
        }

        // GET: FAVORITOS_Web/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITO fAVORITO = db.FAVORITOS.Find(id);
            if (fAVORITO == null)
            {
                return HttpNotFound();
            }
            return View(fAVORITO);
        }

        // GET: FAVORITOS_Web/Create
        public ActionResult Create()
        {
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta");
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario");
            return View();
        }

        // POST: FAVORITOS_Web/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFavoritos,IdUsuario,IdRecetas")] FAVORITO fAVORITO)
        {
            if (ModelState.IsValid)
            {
                db.FAVORITOS.Add(fAVORITO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", fAVORITO.IdRecetas);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", fAVORITO.IdUsuario);
            return View(fAVORITO);
        }

        // GET: FAVORITOS_Web/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITO fAVORITO = db.FAVORITOS.Find(id);
            if (fAVORITO == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", fAVORITO.IdRecetas);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", fAVORITO.IdUsuario);
            return View(fAVORITO);
        }

        // POST: FAVORITOS_Web/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFavoritos,IdUsuario,IdRecetas")] FAVORITO fAVORITO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fAVORITO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRecetas = new SelectList(db.RECETAS, "IdRecetas", "TituloReceta", fAVORITO.IdRecetas);
            ViewBag.IdUsuario = new SelectList(db.USUARIOs, "IdUsuario", "CodigoUsuario", fAVORITO.IdUsuario);
            return View(fAVORITO);
        }

        // GET: FAVORITOS_Web/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FAVORITO fAVORITO = db.FAVORITOS.Find(id);
            if (fAVORITO == null)
            {
                return HttpNotFound();
            }
            return View(fAVORITO);
        }

        // POST: FAVORITOS_Web/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FAVORITO fAVORITO = db.FAVORITOS.Find(id);
            db.FAVORITOS.Remove(fAVORITO);
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
