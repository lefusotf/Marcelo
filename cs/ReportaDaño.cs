using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ReportaDaño
    {
        public static DataTable ListarAbiertos()
        {
            return Leer(@"SELECT IdReporte, IdSalon, IdActivo, IdUnidad, Activo, Categoria, Salon, CodigoInventario,
                                 Cantidad, Prioridad, Descripcion, ReportadoPor, FechaReporte
                          FROM vw_ReportesDanio
                          WHERE Estado = 'Abierto'
                          ORDER BY CASE Prioridad WHEN 'Alta' THEN 0 WHEN 'Media' THEN 1 ELSE 2 END,
                                   FechaReporte");
        }

        public static DataTable ListarHistorial()
        {
            return Leer(@"SELECT IdReporte, Activo, Categoria, Salon, CodigoInventario, Cantidad, Prioridad,
                                 Descripcion, ReportadoPor, FechaReporte, Estado,
                                 FechaReparacion, ReparadoPor, ObservacionReparacion
                          FROM vw_ReportesDanio
                          ORDER BY FechaReporte DESC");
        }

        // Ahora se reporta UNA unidad concreta, identificada por su codigo de inventario
        // (todas las unidades tienen codigo tras la migracion). 'cantidad' se conserva en la
        // firma por compatibilidad con los formularios, pero siempre se guarda 1.
        public static void Registrar(int idSalon, int idActivo, string codigoInventario, int cantidad,
                                     string prioridad, string descripcion, string reportadoPor)
        {
            if (string.IsNullOrWhiteSpace(codigoInventario))
                throw new ArgumentException("Debe seleccionar la unidad (codigo de inventario) que se reporta.");

            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO ReportesDanio
                      (IdSalon, IdActivo, IdUnidad, CodigoInventario, Cantidad, Prioridad, Descripcion, ReportadoPor)
                  SELECT @salon, u.IdActivo, u.IdUnidad, u.CodigoInventario, 1, @prioridad, @descripcion, @usuario
                  FROM UnidadesActivo u
                  WHERE u.IdActivo = @activo AND u.CodigoInventario = @codigo", con))
            {
                cmd.Parameters.AddWithValue("@salon", idSalon);
                cmd.Parameters.AddWithValue("@activo", idActivo);
                cmd.Parameters.AddWithValue("@codigo", codigoInventario.Trim());
                cmd.Parameters.AddWithValue("@prioridad", prioridad);
                cmd.Parameters.AddWithValue("@descripcion", Cortar(descripcion, 500));
                cmd.Parameters.AddWithValue("@usuario", Cortar(reportadoPor, 50));

                con.Open();
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException("No existe una unidad con ese codigo de inventario.");
            }
        }

        public static bool Resolver(int idReporte, string observacion, string reparadoPor)
        {
            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE ReportesDanio
                  SET Estado = 'Reparado',
                      FechaReparacion = GETDATE(),
                      ReparadoPor = @usuario,
                      ObservacionReparacion = @obs
                  WHERE IdReporte = @id AND Estado = 'Abierto'", con))
            {
                cmd.Parameters.AddWithValue("@id", idReporte);
                cmd.Parameters.AddWithValue("@usuario", Cortar(reparadoPor, 50));
                cmd.Parameters.AddWithValue("@obs",
                    string.IsNullOrWhiteSpace(observacion) ? (object)DBNull.Value : Cortar(observacion, 500));

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Ahora cambian el estado SOLO de la unidad indicada por su codigo de inventario
        // (antes cambiaban el estado de todo el tipo de activo).
        public bool CambiarEstadoMantenimientoPorSalon(int idActivo, int idSalon, string codigoInventario)
        {
            return CambiarEstadoUnidad(idActivo, codigoInventario, "Mantenimiento Pendiente");
        }

        public bool CambiarEstadoABueno(int idActivo, string codigoInventario, string nombreSalon)
        {
            return CambiarEstadoUnidad(idActivo, codigoInventario, "Bueno");
        }

        private static bool CambiarEstadoUnidad(int idActivo, string codigoInventario, string nombreEstado)
        {
            if (string.IsNullOrWhiteSpace(codigoInventario))
                throw new ArgumentException("Se requiere el codigo de inventario de la unidad.");

            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(
                @"UPDATE UnidadesActivo
                  SET IdEstado = (SELECT TOP 1 IdEstado FROM Estados WHERE NombreEstado = @estado)
                  WHERE IdActivo = @id AND CodigoInventario = @codigo", con))
            {
                cmd.Parameters.AddWithValue("@estado", nombreEstado);
                cmd.Parameters.AddWithValue("@id", idActivo);
                cmd.Parameters.AddWithValue("@codigo", codigoInventario.Trim());
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private static string Cortar(string texto, int max)
        {
            texto = (texto ?? "").Trim();
            return texto.Length <= max ? texto : texto.Substring(0, max);
        }

        private static DataTable Leer(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                da.Fill(dt);
            }
            return dt;
        }
    }
}
