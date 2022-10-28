using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionFinal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        //Metodo para generar el contrato
        public ActionResult GenerarContrato()
        {
            //Linea de codigo para instanciar Rotativa y crear archivo.
            return new ActionAsPdf("Contrato") { FileName = "Contrato.pdf" };
        }

        public ActionResult Contrato()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}