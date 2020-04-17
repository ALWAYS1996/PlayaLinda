using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class InformacionTextoCapaDatos
    {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public InformacionTextoCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }


        public int registrarImagenes(ENTIDAD.InformacionTexto infoTexto)
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
        public int registrarTexto(ENTIDAD.InformacionTexto infoTexto)
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

        private List<ENTIDAD.InformacionTexto> listarImagenes = new List<ENTIDAD.InformacionTexto>();
        public IEnumerable<ENTIDAD.InformacionTexto> listadoImagenes(ENTIDAD.InformacionTexto tipoTexto)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarGaleriaImagen @tipoInformacion";
                comando.Parameters.AddWithValue("@tipoInformacion", tipoTexto.tipoInformacion);
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
                        listarImagenes.Add(galeria);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarImagenes;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarImagenes;
        }//Fin


        private List<ENTIDAD.InformacionTexto> listarTexto = new List<ENTIDAD.InformacionTexto>();
        public IEnumerable<ENTIDAD.InformacionTexto> listadoTexto(ENTIDAD.InformacionTexto tipoT)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_ListarGaleriaTexto @tipoInformacion";
                comando.Parameters.AddWithValue("@tipoInformacion", tipoT.tipoInformacion);
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
                        listarTexto.Add(galeria);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return listarTexto;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return listarTexto;
        }//Fin

    }
}
