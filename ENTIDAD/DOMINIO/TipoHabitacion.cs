using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD.DOMINIO
{
    public class TipoHabitacion
    {

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Codigo")]
        [Key]
        public int codigoTipoHabitacion { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Nombre")]
    
        public string nombre { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Precio")]
        public int precio { get; set; }

        public TipoHabitacion()
        {
        }

        public TipoHabitacion(int codigoTipoHabitacion, string nombre, int precio)
        {
            this.codigoTipoHabitacion = codigoTipoHabitacion;
            this.nombre = nombre;
            this.precio = precio;
        }
    }
}
