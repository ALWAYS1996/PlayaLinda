
using System;
using System.Collections.Generic;
using System.IO;

using System.Web;

namespace NEGOCIO
{
    public class CapaNegocio
    {

        DATOS.CapaDato capaDatos = new DATOS.CapaDato();


        public IEnumerable<ENTIDAD.Mapa> listadoCoordenadasOrigen()
        {
            return capaDatos.listadoCoordenadasOrigen();
        }
        public IEnumerable<ENTIDAD.Cliente> listadoClientes()
        {
            return capaDatos.listadoClientes();
        }
        public IEnumerable<ENTIDAD.InformacionTexto> listadoGaleriaImagenes(ENTIDAD.InformacionTexto informacionTexto)
        {
            return capaDatos.listadoGaleriaImagenes(informacionTexto);
        }
        public IEnumerable<ENTIDAD.InformacionTexto> listadoTexto(ENTIDAD.InformacionTexto informacionTexto)
        {
            return capaDatos.listadoTexto(informacionTexto);
        }
        public int registrarGaleriaImagenes(ENTIDAD.InformacionTexto informacionTexto) {
            return capaDatos.registrarGaleriaImagenes(informacionTexto);
        }
        public int registrarGaleriaTexto(ENTIDAD.InformacionTexto informacionTexto) { 
           return capaDatos.registrarGaleriaTexto(informacionTexto);
        }
        public int modificarCoordenadasOrigen(ENTIDAD.Mapa mapa)
        {
            return capaDatos.modificarCoordenadasOrigen(mapa);
        }
    }
}
