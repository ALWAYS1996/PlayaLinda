using System;
using System.ComponentModel.DataAnnotations;

namespace ENTIDAD
{
    public class Reservacion
    {
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Codigo Reserva")]
        [Key]
        public int codigoReservacion { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Codigo Habitacion")]

        public int codigoHabitacion { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Codigo Cliente")]

        public string codigoCliente { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Fecha Llegada")]

        public DateTime fechaLlegada { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Fecha Salida")]

        public DateTime fechaSalida { get; set; }

        public Reservacion()
        {
        }

        public Reservacion(int codigoReservacion, int codigoHabitacion, string codigoCliente, DateTime fechaLlegada, DateTime fechaSalida)
        {
            this.codigoReservacion = codigoReservacion;
            this.codigoHabitacion = codigoHabitacion;
            this.codigoCliente = codigoCliente;
            this.fechaLlegada = fechaLlegada;
            this.fechaSalida = fechaSalida;
        }
    }
}
