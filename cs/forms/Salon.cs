using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{

    public class Salon
    {
 
        public int IdSalon { get; set; }
        public string NombreSalon { get; set; }


        public DataTable ObtenerSalones()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string query = "SELECT IdSalon, NombreSalon FROM Salones";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerActivosDisponibles()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string query = "SELECT IdActivo, Nombre FROM GestionActivos ORDER BY Nombre";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(dt);
            }
            return dt;
        }

        public DataTable ObtenerActivosPorSalon(int idSalon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            using (SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT IdActivo, Activo AS NombreActivo, Categoria, 1 AS Cantidad, CodigoInventario, Estado
          FROM vw_UnidadesDetalle
          WHERE IdSalon = @IdSalon
          ORDER BY Activo, CodigoInventario", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@IdSalon", idSalon);
                da.Fill(dt);
            }
            return dt;
        }

        // Estado con el que nacen las unidades nuevas (cada una cambia después por separado)
        public int ObtenerIdEstadoInicial()
        {
            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 IdEstado FROM Estados WHERE NombreEstado IN ('Bueno', 'Nuevo') ORDER BY CASE NombreEstado WHEN 'Bueno' THEN 0 ELSE 1 END", con))
            {
                con.Open();
                object r = cmd.ExecuteScalar();
                return r == null ? 1 : Convert.ToInt32(r);
            }
        }

        // Crea N unidades individuales (cada una con su código y su propio estado)
        public bool AsignarActivo(int idSalon, int idActivo, int cantidad)
        {
            int idEstado = ObtenerIdEstadoInicial();
            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand("dbo.sp_AgregarUnidades", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                cmd.Parameters.AddWithValue("@IdSalon", idSalon);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                cmd.Parameters.AddWithValue("@IdEstado", idEstado);
                conexion.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
        }

        // Retira N unidades del salón (solo las que no tienen historial de préstamos/mantenimiento/reportes)
        public bool QuitarActivo(int idSalon, int idActivo, int cantidadAQuitar, out string mensajeError)
        {
            mensajeError = string.Empty;
            using (SqlConnection conexion = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(
                @"DELETE TOP (@n) FROM UnidadesActivo
                  WHERE IdSalon = @IdSalon AND IdActivo = @IdActivo
                    AND NOT EXISTS (SELECT 1 FROM Prestamos p WHERE p.IdUnidad = UnidadesActivo.IdUnidad)
                    AND NOT EXISTS (SELECT 1 FROM MantenimientosActivo m WHERE m.IdUnidad = UnidadesActivo.IdUnidad)
                    AND NOT EXISTS (SELECT 1 FROM ReportesDanio r WHERE r.IdUnidad = UnidadesActivo.IdUnidad)", conexion))
            {
                cmd.Parameters.AddWithValue("@n", cantidadAQuitar);
                cmd.Parameters.AddWithValue("@IdSalon", idSalon);
                cmd.Parameters.AddWithValue("@IdActivo", idActivo);
                conexion.Open();
                int borradas = cmd.ExecuteNonQuery();
                if (borradas < cantidadAQuitar)
                    mensajeError = "Solo se pudieron retirar " + borradas + " unidades; las demás tienen historial. Cámbieles el estado a 'Dado de baja'.";
                return borradas > 0;
            }
        }

        public DataTable BuscarActivosEnSalon(int idSalon, string criterio)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            using (SqlDataAdapter da = new SqlDataAdapter(
                @"SELECT IdActivo, Activo AS NombreActivo, Categoria, 1 AS Cantidad, CodigoInventario, Estado
          FROM vw_UnidadesDetalle
          WHERE IdSalon = @IdSalon
            AND LOWER(LTRIM(RTRIM(Activo))) LIKE @Criterio
          ORDER BY Activo, CodigoInventario", con))
            {
                da.SelectCommand.Parameters.AddWithValue("@IdSalon", idSalon);
                da.SelectCommand.Parameters.AddWithValue("@Criterio", "%" + criterio.Trim().ToLower() + "%");
                da.Fill(dt);
            }
            return dt;
        }

        public bool ModificarAsignacionActivo(int idSalon, int idActivoAnterior, int idActivoNuevo)
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                string query = @"UPDATE UnidadesActivo 
                         SET IdActivo = @idActivoNuevo 
                         WHERE IdSalon = @idSalon AND IdActivo = @idActivoAnterior";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idActivoNuevo", idActivoNuevo);
                cmd.Parameters.AddWithValue("@idSalon", idSalon);
                cmd.Parameters.AddWithValue("@idActivoAnterior", idActivoAnterior);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}