using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class BasicController : Controller
    {

        NEGOCIO.CapaNegocio capaNegocios = new NEGOCIO.CapaNegocio();
        public ActionResult Inicio()
        {
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(2);
            ViewData["listadoVistazoHotel"] = capaNegocios.listadoTexto(infoTexto);
            return View(capaNegocios.listadoGaleriaImagenes(infoTexto));
        }
        public ActionResult Contacto(){
            return View();
        }
        [HttpPost]
        public ViewResult Mapa(string lat,string lng)
        {
            ENTIDAD.Mapa mapa = new ENTIDAD.Mapa();  mapa.latitudOrigen = lat;  mapa.longitudOrigen = lng;
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(3);
            ViewData["listadoTexto"] = capaNegocios.listadoTexto(infoTexto);
            capaNegocios.modificarCoordenadasOrigen(mapa);
           return View(capaNegocios.listadoCoordenadasOrigen());
  
        }
        public ActionResult Nosotros(){
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(1);
            ViewData["listadoGaleriaTexto"] = capaNegocios.listadoTexto(infoTexto);
            return View(capaNegocios.listadoGaleriaImagenes(infoTexto));
        }

       


        [HttpPost]
        public ActionResult RegistrarGaleriaImagenes(HttpPostedFileBase fileUpload) {
            try {
                 string path = Server.MapPath("~/Content/img/");
                   if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                fileUpload.SaveAs(path +Path.GetFileName(fileUpload.FileName));
                ENTIDAD.InformacionTexto galeria = new ENTIDAD.InformacionTexto();
                galeria.rutaImagen = "\\Content\\img\\" + fileUpload.FileName;
                galeria.tipoInformacion = 1;
                capaNegocios.registrarGaleriaImagenes(galeria);
            } catch (Exception e) {
                return Json(new { Value=false,Message="Error"+e.Message},JsonRequestBehavior.AllowGet);
            }
            return Json(new {Value=false, Message="Subido con exito" }, JsonRequestBehavior.AllowGet);
       }
        NEGOCIO.FacilidadesCapaNegocio FacilidadesCapaNegocio = new NEGOCIO.FacilidadesCapaNegocio();
        public ActionResult Facilidades()
        {
            ENTIDAD.Facilidades tipo = new ENTIDAD.Facilidades();
            //ViewData["listaTipoHabitaciones"] = habitacionCapaNegocio.listadoTipoHabitaciones();
            return View(FacilidadesCapaNegocio.listadoFacilidades());
        }
        public ActionResult Llegar()
        {
            return View();
        }

        public ActionResult Tarifas()
        {
            return View();
        }

        public ActionResult Reservar()
        {
            return View();
        }

    }
}