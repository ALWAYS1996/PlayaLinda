using System;
using System.Collections.Generic;
using System.Text;

namespace NEGOCIO
{
    public class InformacionTextoCapaNegocio
    {
        DATOS.InformacionTextoCapaDatos capaDatos = new DATOS.InformacionTextoCapaDatos();

        public IEnumerable<ENTIDAD.InformacionTexto> listadoImagenes(ENTIDAD.InformacionTexto informacionTexto)
        {
            return capaDatos.listadoImagenes(informacionTexto);
        }
        public IEnumerable<ENTIDAD.InformacionTexto> listadoTexto(ENTIDAD.InformacionTexto informacionTexto)
        {
            return capaDatos.listadoTexto(informacionTexto);
        }
        public int registrarImagenes(ENTIDAD.InformacionTexto informacionTexto)
        {
            return capaDatos.registrarImagenes(informacionTexto);
        }
        public int registrarTexto(ENTIDAD.InformacionTexto informacionTexto)
        {
            return capaDatos.registrarTexto(informacionTexto);
        }
    }
}
