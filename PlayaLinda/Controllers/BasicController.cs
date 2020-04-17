using ENTIDAD;
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

        NEGOCIO.FacilidadesCapaNegocio FacilidadesCapaNegocio = new NEGOCIO.FacilidadesCapaNegocio();
        NEGOCIO.HabitacionCapaNegocio HabitacionesCapaNegocio = new NEGOCIO.HabitacionCapaNegocio();
        NEGOCIO.ReservacionCapaNegocios reservacionCapaNegocios = new NEGOCIO.ReservacionCapaNegocios();

        public ActionResult Facilidades()
        {
            ENTIDAD.Facilidades tipo = new ENTIDAD.Facilidades();
            //ViewData["listaTipoHabitaciones"] = habitacionCapaNegocio.listadoTipoHabitaciones();
            return View(FacilidadesCapaNegocio.listadoFacilidades());
        }

        public ActionResult Reservar()
        {
            return View(HabitacionesCapaNegocio.listadoTipoHabitaciones());
        }
        public ActionResult CrearReservacion(Reservacion reservacion) {
            string mensaje;
            if (this.reservacionCapaNegocios.registrarReservacion(reservacion) == 0)
            {
                //mensaje de error
                mensaje = "<script language='javascript' type='text/javascript'>" +
                     "alert('No agregado');window.location.href=" +
                     "'Reservar';</script>";
            }
            else
            {
                mensaje = "<script language='javascript' type='text/javascript'>" +
                    "alert('agregado');window.location.href=" +
                    "'Reservar';</script>";
            }
            //reservacionCapaNegocios.registrarReservacion(reservacion);
            
            return Content(mensaje);
        }

        public ActionResult Tarifas()
        {
            return View(HabitacionesCapaNegocio.listadoTipoHabitaciones());
        }


    }
}