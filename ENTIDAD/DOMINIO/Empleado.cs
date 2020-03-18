using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD.DOMINIO
{
  public  class Empleado {
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Identificación")]
        [Key]
        public int codigoEmpleado { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "TipoEmpleado")]
        public int tipoEmpleado { get; set; }



        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Usuario")]
        public string usuario { get; set; }


        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Contraseña")]
        public string clave { get; set; }

        public Empleado()
        {
        }

        public Empleado(int codigoEmpleado, int tipoEmpleado, string usuario, string clave)
        {
            this.codigoEmpleado = codigoEmpleado;
            this.tipoEmpleado = tipoEmpleado;
            this.usuario = usuario;
            this.clave = clave;
        }
    }
}
