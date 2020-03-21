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
            return View();
        }
        public ActionResult Contacto()
        {
            return View();
        }
        public ActionResult Nosotros()
        {

            ViewData["listadoGaleriaTexto"] = capaNegocios.listadoGaleriaTexto();
            return View(capaNegocios.listadoGaleriaImagenes());
        }

       


        [HttpPost]
        public ActionResult RegistrarGaleriaImagenes(HttpPostedFileBase fileUpload)
        {
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
        public ActionResult Facilidades()
        {
            return View();
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