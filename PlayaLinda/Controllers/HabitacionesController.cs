using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayaLinda.Controllers
{
    public class HabitacionesController : Controller
    {
        // GET: Habitaciones
        NEGOCIO.HabitacionCapaNegocio capaNegocios = new NEGOCIO.HabitacionCapaNegocio();
        [HttpPost]
        public ViewResult Facilidades()
        {
            ENTIDAD.TipoHabitacion tipo = new ENTIDAD.TipoHabitacion();
            ViewData["listaTipoHabitaciones"] = capaNegocios.listadoTipoHabitaciones();
            return View(capaNegocios.listadoTipoHabitaciones());
        }
    }
}