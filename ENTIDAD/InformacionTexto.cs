using System.ComponentModel.DataAnnotations;
using System.IO;
namespace ENTIDAD
{
    public class InformacionTexto
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
        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }

        [DisplayFormat(NullDisplayText = "Sin Respuesta")]
        [Display(Name = "Tipo")]
        public int tipoInformacion { get; set; }

    
        public InformacionTexto()
        {
        }

        public InformacionTexto(string codigoInformacionTexto, string contenido, string rutaImagen)
        {
            this.codigoInformacionTexto = codigoInformacionTexto;
            this.contenido = contenido;
            this.rutaImagen = rutaImagen;
        }
        public InformacionTexto(int tipoInformacion, string rutaImagen)
        {
            this.tipoInformacion = tipoInformacion;
            this.rutaImagen = rutaImagen;
        }
        public InformacionTexto(string contenido, string titulo)
        {
            this.titulo = titulo;
            this.contenido = contenido;
        }

    }
}
