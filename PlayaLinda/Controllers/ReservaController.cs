using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult ReservaLinea(Reservacion reservacion) {

            ViewBag.mensaje = "Habitación disponible para ser reservada"+ reservacion.codigoHabitacion;
            return View();
        }
        NEGOCIO.ReservacionCapaNegocios reservacionCapaNegocios = new NEGOCIO.ReservacionCapaNegocios();
        NEGOCIO.HabitacionCapaNegocio HabitacionesCapaNegocio = new NEGOCIO.HabitacionCapaNegocio();


        public ActionResult Reservar()
        {
            return View(HabitacionesCapaNegocio.listadoTipoHabitaciones());
        }
      
        public ActionResult Estado(Reservacion reservacion){

            if (reservacionCapaNegocios.verificarReservacion(reservacion) > 0)
            {
                ViewBag.mensaje = "Lo sentimos, ese rango de Habitaciones  están Ocupadas en ese rango de fechas.Pero tenemos estas disponibles:";
                return View();
            } else {
                ViewData["idHabitacion"] = reservacion.codigoHabitacion;
                ViewData["fechaInicio"] = reservacion.fechaLlegada;
                ViewData["fechaFin"] = reservacion.fechaSalida;
                ViewBag.mensaje = "Habitación disponible para ser reservada";
                return View("ReservaLinea");


            }
      
            
        }
        public ActionResult CrearReservacion(Reservacion reservacion)  {
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
    }
}