using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class CapaDato
    {
        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public CapaDato()
        {
            this.conexion = Conexion.getConexion();
        }

        private List<ENTIDAD.Cliente> listarCliente = new List<ENTIDAD.Cliente>();
        public IEnumerable<ENTIDAD.Cliente> listadoClientes()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarClientes";

                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Cliente cliente = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        cliente = new ENTIDAD.Cliente();
                        cliente.codigoCliente = int.Parse(ds.Tables[0].Rows[i][0].ToString());
                        cliente.pasaporte = (ds.Tables[0].Rows[i][1].ToString());
                        cliente.nombre = (ds.Tables[0].Rows[i][2].ToString());
                        cliente.apellido1 = (ds.Tables[0].Rows[i][3].ToString());
                        cliente.apellido2 = (ds.Tables[0].Rows[i][4].ToString());
                        cliente.edad = int.Parse(ds.Tables[0].Rows[i][5].ToString());
                        cliente.correo = (ds.Tables[0].Rows[i][6].ToString());
                        cliente.nacionalidad = (ds.Tables[0].Rows[i][7].ToString());
                        listarCliente.Add(cliente);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarCliente;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
                    return listarCliente;
        }//Fin

        public int registrarGaleriaImagenes(ENTIDAD.InformacionTexto infoTexto)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_RegistrarGaleriaImagen @rutaImagen,@tipoInformacion";
                comando.Parameters.AddWithValue("@rutaImagen", infoTexto.rutaImagen);
                comando.Parameters.AddWithValue("@tipoInformacion", infoTexto.tipoInformacion);
                int result = comando.ExecuteNonQuery();
                if (result == -1){
                    return 1;
                }
                else {
                    return -1;
                }
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return 0;
        }//fin
        public int registrarGaleriaTexto(ENTIDAD.InformacionTexto infoTexto)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_RegistrarGaleriaTexto @contenido,@titulo,@tipoInformacion";
                comando.Parameters.AddWithValue("@contenido", infoTexto.contenido);
                comando.Parameters.AddWithValue("@titulo", infoTexto.titulo);
                comando.Parameters.AddWithValue("@tipoInformacion", infoTexto.tipoInformacion);
                int result = comando.ExecuteNonQuery();
                if (result == -1)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return 0;
        }//fin

        private List<ENTIDAD.InformacionTexto> listarGaleriaImagenes = new List<ENTIDAD.InformacionTexto>();
        public IEnumerable<ENTIDAD.InformacionTexto> listadoGaleriaImagenes()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
              conexion.Open();
                comando.CommandText = "exec PA_ListarGaleriaImagen @tipoInformacion";
                comando.Parameters.AddWithValue("@tipoInformacion", 1);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.InformacionTexto galeria = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        galeria = new ENTIDAD.InformacionTexto();
                        galeria.rutaImagen = (ds.Tables[0].Rows[i][0].ToString());
                        listarGaleriaImagenes.Add(galeria);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarGaleriaImagenes;
            }
            catch (Exception) { }
            finally {conexion.Close(); }
            return listarGaleriaImagenes;
        }//Fin
        private List<ENTIDAD.InformacionTexto> listarGaleriaTexto = new List<ENTIDAD.InformacionTexto>();
        public IEnumerable<ENTIDAD.InformacionTexto> listadoGaleriaTexto()
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarGaleriaTexto @tipoInformacion";
                comando.Parameters.AddWithValue("@tipoInformacion", 1);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.InformacionTexto galeria = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        galeria = new ENTIDAD.InformacionTexto();
                        galeria.titulo = (ds.Tables[0].Rows[i][0].ToString());
                        galeria.contenido = (ds.Tables[0].Rows[i][1].ToString());
                        listarGaleriaTexto.Add(galeria);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarGaleriaTexto;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarGaleriaTexto;
        }//Fin


    }


}
