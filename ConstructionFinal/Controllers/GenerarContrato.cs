using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConstructionFinal.Controllers
{
    public class GenerarContrato
    {
        public ActionResult PDF(int? id)
        {
            var ruta = "Contrato/" + id.ToString();
            return new ActionAsPdf(ruta) { FileName = "Contrato.pdf" };
        }
    }
}