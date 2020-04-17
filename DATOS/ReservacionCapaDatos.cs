using System;
using System.Collections.Generic;
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
    }
}
