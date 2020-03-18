using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ENTIDAD { 
    public class InformacionTexto { 
{

    [DisplayFormat(NullDisplayText = "Sin Respuesta")]
    [Display(Name = "Código")]
    [Key]
    public string codigoInformacionTexto { get; set; }

    [DisplayFormat(NullDisplayText = "Sin Respuesta")]
    [Display(Name = "Contenido")]
    public string contenido { get; set; }

    [DisplayFormat(NullDisplayText = "Sin Respuesta")]
    [Display(Name = "Imagen")]
    public string rutaImagen { get; set; }

    public InformacionTexto()
    {
    }

    public InformacionTexto(string codigoInformacionTexto, string contenido, string rutaImagen)
    {
        this.codigoInformacionTexto = codigoInformacionTexto;
        this.contenido = contenido;
        this.rutaImagen = rutaImagen;
    }
}
}
