using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class InformacionTextoController : Controller
    {

        NEGOCIO.PromocionCapaNegocio promocionCapaNegocio = new NEGOCIO.PromocionCapaNegocio();
        NEGOCIO.InformacionTextoCapaNegocio capaNegocios = new NEGOCIO.InformacionTextoCapaNegocio();
        //public ActionResult Inicio()
        //{
        //    ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(2);
        //    ViewData["listadoVistazoHotel"] = capaNegocios.listadoTexto(infoTexto);
        //    return View(capaNegocios.listadoImagenes(infoTexto));
        //}
        public ActionResult Inicio()
        {
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(2);

            ViewData["listadoVistazoHotel"] = capaNegocios.listadoTexto(infoTexto);
            ViewData["listadoPromociones"] = promocionCapaNegocio.listadoPromociones();
            return View(capaNegocios.listadoImagenes(infoTexto));
        }

        public ActionResult Contacto()
        {
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(4);
            ViewData["listadoContactenos"] = capaNegocios.listadoTexto(infoTexto);
            return View();
        }


        public ActionResult Nosotros()
        {
            ENTIDAD.InformacionTexto infoTexto = new ENTIDAD.InformacionTexto(1);
            ViewData["listadoGaleriaTexto"] = capaNegocios.listadoTexto(infoTexto);
            return View(capaNegocios.listadoImagenes(infoTexto));
        }
        [HttpPost]
        public ActionResult RegistrarGaleriaImagenes(HttpPostedFileBase fileUpload)
        {
            try
            {
                string path = Server.MapPath("~/Content/img/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                fileUpload.SaveAs(path + Path.GetFileName(fileUpload.FileName));
                ENTIDAD.InformacionTexto galeria = new ENTIDAD.InformacionTexto();
                galeria.rutaImagen = "\\Content\\img\\" + fileUpload.FileName;
                galeria.tipoInformacion = 1;
                capaNegocios.registrarImagenes(galeria);
            }
            catch (Exception e)
            {
                return Json(new { Value = false, Message = "Error" + e.Message }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Value = false, Message = "Subido con exito" }, JsonRequestBehavior.AllowGet);
        }


    }
}