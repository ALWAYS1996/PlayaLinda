
using System;
using System.Collections.Generic;
using System.IO;

using System.Web;

namespace NEGOCIO
{
    public class CapaNegocio
    {

        DATOS.CapaDato capaDatos = new DATOS.CapaDato();


        public IEnumerable<ENTIDAD.Cliente> listadoClientes()
        {
            return capaDatos.listadoClientes();
        }
        public IEnumerable<ENTIDAD.InformacionTexto> listadoGaleriaImagenes()
        {
            return capaDatos.listadoGaleriaImagenes();
        }
        public IEnumerable<ENTIDAD.InformacionTexto> listadoGaleriaTexto()
        {
            return capaDatos.listadoGaleriaTexto();
        }
        public int registrarGaleriaImagenes(ENTIDAD.InformacionTexto galeria) {
            return capaDatos.registrarGaleriaImagenes(galeria);
        }
        public int registrarGaleriaTexto(ENTIDAD.InformacionTexto galeria) { 
           return capaDatos.registrarGaleriaTexto(galeria);
        }
    }
}
