﻿using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class ReservacionCapaNegocios
    {
        DATOS.ReservacionCapaDatos reservacionCapaDatos= new DATOS.ReservacionCapaDatos();
        public int registrarReservacion(Reservacion reservacion)
        { return reservacionCapaDatos.registrarReservacion(reservacion); }
    }
}