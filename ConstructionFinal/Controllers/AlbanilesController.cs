using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionFinal;
using Rotativa;

namespace ConstructionFinal.Controllers
{
    public class AlbanilesController : Controller
    {
        private DB_CONSTRUCTIONEntities db = new DB_CONSTRUCTIONEntities();

        // GET: Albaniles
        public ActionResult Index()
        {
            return View(db.Albaniles.ToList());
        }

        public ActionResult Contrato(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albaniles albaniles = db.Albaniles.Find(id);
            if (albaniles == null)
            {
                return HttpNotFound();
            }
            return View(albaniles);
            //return View();
        }

        public ActionResult GenerarContrato(int? id)
        {
            var ruta = "Contrato/" + id.ToString();
            return new ActionAsPdf(ruta) { FileName = "Contrato.pdf" };
        }

        // GET: Albaniles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albaniles albaniles = db.Albaniles.Find(id);
            if (albaniles == null)
            {
                return HttpNotFound();
            }
            return View(albaniles);
        }

        // GET: Albaniles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albaniles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoAl,nombreCompleto,foto,ciudad,domicilio,aniosExpe,telefono,correo")] Albaniles albaniles)
        {
            if (ModelState.IsValid)
            {
                db.Albaniles.Add(albaniles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(albaniles);
        }

        // GET: Albaniles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albaniles albaniles = db.Albaniles.Find(id);
            if (albaniles == null)
            {
                return HttpNotFound();
            }
            return View(albaniles);
        }

        // POST: Albaniles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoAl,nombreCompleto,foto,ciudad,domicilio,aniosExpe,telefono,correo")] Albaniles albaniles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albaniles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(albaniles);
        }

        // GET: Albaniles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Albaniles albaniles = db.Albaniles.Find(id);
            if (albaniles == null)
            {
                return HttpNotFound();
            }
            return View(albaniles);
        }

        // POST: Albaniles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Albaniles albaniles = db.Albaniles.Find(id);
            db.Albaniles.Remove(albaniles);
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
