using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionFinal;

namespace ConstructionFinal.Controllers
{
    public class ContratistasController : Controller
    {
        private DB_CONSTRUCTIONEntities db = new DB_CONSTRUCTIONEntities();

        // GET: Contratistas
        public ActionResult Index()
        {
            return View(db.Contratistas.ToList());
        }

        // GET: Contratistas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratistas contratistas = db.Contratistas.Find(id);
            if (contratistas == null)
            {
                return HttpNotFound();
            }
            return View(contratistas);
        }

        // GET: Contratistas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contratistas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoC,nombreCompleto,foto,ciudad,domicilio,telefono,correo")] Contratistas contratistas)
        {
            if (ModelState.IsValid)
            {
                db.Contratistas.Add(contratistas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contratistas);
        }

        // GET: Contratistas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratistas contratistas = db.Contratistas.Find(id);
            if (contratistas == null)
            {
                return HttpNotFound();
            }
            return View(contratistas);
        }

        // POST: Contratistas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoC,nombreCompleto,foto,ciudad,domicilio,telefono,correo")] Contratistas contratistas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contratistas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contratistas);
        }

        // GET: Contratistas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contratistas contratistas = db.Contratistas.Find(id);
            if (contratistas == null)
            {
                return HttpNotFound();
            }
            return View(contratistas);
        }

        // POST: Contratistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contratistas contratistas = db.Contratistas.Find(id);
            db.Contratistas.Remove(contratistas);
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
