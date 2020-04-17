using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class MapaController : Controller
    {
        // GET: Mapa

        NEGOCIO.MapaCapaNegocio capaNegocios = new NEGOCIO.MapaCapaNegocio();
        NEGOCIO.InformacionTextoCapaNegocio capaNegocios2 = new NEGOCIO.InformacionTextoCapaNegocio();
        public ViewResult Mapa(string lat, string lng)
        {
            ENTIDAD.Mapa mapa = new ENTIDAD.Mapa(); mapa.latitudOrigen = lat; mapa.longitudOrigen = lng;
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(3);
            ViewData["listadoTexto"] = capaNegocios2.listadoTexto(infoTexto);
            capaNegocios.modificarCoordenadasOrigen(mapa);
            return View(capaNegocios.listadoCoordenadasOrigen());

        }

        public ActionResult Llegar()
        {
            return View();
        }
    }
}