using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DATOS
{
    public class ReservacionCapaDatos
    {

        public SqlConnection conexion;
        public SqlTransaction transaccion;
        public string error;

        public ReservacionCapaDatos()
        {
            this.conexion = Conexion.getConexion();
        }
        public int registrarReservacion(ENTIDAD.Reservacion reservacion)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandText = "exec PA_RegistrarReservacion @idTipoHabitacion,@idCliente,@fechaLlegada,@fechaSalida";
                comando.Parameters.AddWithValue("@idTipoHabitacion", reservacion.codigoHabitacion);
                comando.Parameters.AddWithValue("@idCliente", reservacion.codigoCliente);
                comando.Parameters.AddWithValue("@fechaLlegada", reservacion.fechaLlegada);
                comando.Parameters.AddWithValue("@fechaSalida", reservacion.fechaSalida);
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

        /*Obtener*/
        public int verificarReservacion(ENTIDAD.Reservacion reservacion) {
            int cantidad = 0;// ""; 
            try
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("PA_VerificarReservacion", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fechaLlegada", reservacion.fechaLlegada);
                cmd.Parameters.AddWithValue("@fechaSalida", reservacion.fechaSalida);
                cmd.Parameters.AddWithValue("@tipoHabitacion", reservacion.codigoHabitacion);
                
                SqlDataReader rdr = cmd.ExecuteReader();
                // while (
                rdr.Read();//)
                           //{

                cantidad = (rdr.GetInt32(rdr.GetOrdinal("rangoFechas")));

                //}
            }
            catch (Exception)
            {

            }
            finally
            {
                conexion.Close();
            }
            return cantidad;


        }//fin


        private List<ENTIDAD.Reservacion> sugerenciaReservacion = new List<ENTIDAD.Reservacion>();
        public IEnumerable<ENTIDAD.Reservacion> sugerirReservacion(ENTIDAD.Reservacion reserva)
        {
            SqlCommand comando = new SqlCommand();
            try
            {
                comando.Connection = conexion;
                conexion.Open();
                comando.CommandText = "exec PA_SugerenciaReservacion @fechaLlegada, @fechaSalida,@tipoHabitacion";
                comando.Parameters.AddWithValue("@fechaLlegada", reserva.fechaL);
                comando.Parameters.AddWithValue("@fechaSalida", reserva.fechaS);
                comando.Parameters.AddWithValue("@tipoHabitacion", reserva.codigoHabitacion);
                SqlDataAdapter da = new SqlDataAdapter(comando);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ENTIDAD.Reservacion reservacion = null;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        reservacion = new ENTIDAD.Reservacion();
                        reservacion.fechaL = (ds.Tables[0].Rows[i][0].ToString());
                        reservacion.fechaS = (ds.Tables[0].Rows[i][1].ToString());
                        sugerenciaReservacion.Add(reservacion);
                    }
                }
                int result = comando.ExecuteNonQuery();

                return sugerenciaReservacion;
            }
            catch (Exception) { }
            finally { conexion.Close(); }
            return sugerenciaReservacion;
        }//Fin
    }
}
