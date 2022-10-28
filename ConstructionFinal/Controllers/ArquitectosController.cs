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
    public class ArquitectosController : Controller
    {
        private DB_CONSTRUCTIONEntities db = new DB_CONSTRUCTIONEntities();

        // GET: Arquitectos
        public ActionResult Index()
        {
            return View(db.Arquitectos.ToList());
        }

        public ActionResult Contrato(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitectos arquitectos = db.Arquitectos.Find(id);
            if (arquitectos == null)
            {
                return HttpNotFound();
            }
            return View(arquitectos);
            //return View();
        }

        public ActionResult GenerarContrato(int? id)
        {
            var ruta = "Contrato/"+id.ToString();
            return new ActionAsPdf(ruta) { FileName = "Contrato.pdf" };
        }

        // GET: Arquitectos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitectos arquitectos = db.Arquitectos.Find(id);
            if (arquitectos == null)
            {
                return HttpNotFound();
            }
            return View(arquitectos);
        }

        // GET: Arquitectos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arquitectos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoAr,nombreCompleto,foto,ciudad,domicilio,aniosExpe,telefono,correo")] Arquitectos arquitectos)
        {
            if (ModelState.IsValid)
            {
                db.Arquitectos.Add(arquitectos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arquitectos);
        }

        // GET: Arquitectos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitectos arquitectos = db.Arquitectos.Find(id);
            if (arquitectos == null)
            {
                return HttpNotFound();
            }
            return View(arquitectos);
        }

        // POST: Arquitectos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoAr,nombreCompleto,foto,ciudad,domicilio,aniosExpe,telefono,correo")] Arquitectos arquitectos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arquitectos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arquitectos);
        }

        // GET: Arquitectos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arquitectos arquitectos = db.Arquitectos.Find(id);
            if (arquitectos == null)
            {
                return HttpNotFound();
            }
            return View(arquitectos);
        }

        // POST: Arquitectos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Arquitectos arquitectos = db.Arquitectos.Find(id);
            db.Arquitectos.Remove(arquitectos);
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
