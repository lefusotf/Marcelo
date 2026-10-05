using Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistass
{
    // GestionActivos ahora es solo el CATALOGO (tipo de activo).
    // El estado vive en cada unidad física (dbo.UnidadesActivo).
    public class Activo
    {
        // Una fila por tipo de activo con totales (ya no hay Estado/IdEstado por tipo)
        public static DataTable ListarActivos()
        {
            return Leer("SELECT IdActivo, Nombre, Categoria, IdCategoria, TotalUnidades, UnidadesConProblema " +
                        "FROM vw_ActivosDetalle ORDER BY IdActivo");
        }

        public static DataTable ObtenerEstados()
        {
            return Leer("SELECT IdEstado, NombreEstado FROM Estados ORDER BY IdEstado");
        }

        public static DataTable ObtenerCategorias()
        {
            return Leer("SELECT IdCategoria, NombreCategoria FROM Categorias ORDER BY IdCategoria");
        }

        public static int ObtenerSiguienteId()
        {
            using (SqlConnection con = Conexion.Conectar())
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ISNULL(MAX(IdActivo), 0) + 1 FROM GestionActivos", con);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // GestionActivos.IdActivo NO es IDENTITY, por eso se inserta el id calculado.
        // Ya no recibe estado: se asigna al agregar unidades (AgregarUnidades).
        public static bool GuardarActivo(int id, string nombre, int idCategoria)
        {
            try
            {
                using (SqlConnection con = Conexion.Conectar())
                {
                    con.Open();
                    string query = @"INSERT INTO GestionActivos (IdActivo, Nombre, IdCategoria)
                                 VALUES (@id, @nombre, @idCategoria)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
        }

        public static DataTable BuscarActivos(string criterio)
        {
            return Leer(@"SELECT IdActivo, Nombre, Categoria, TotalUnidades, UnidadesConProblema
                      FROM vw_ActivosDetalle
                      WHERE Nombre LIKE @criterio OR CAST(IdActivo AS VARCHAR) = @criterioExacto",
                        new SqlParameter("@criterio", "%" + criterio + "%"),
                        new SqlParameter("@criterioExacto", criterio));
        }

        // Solo datos del catalogo; el estado se cambia por unidad (CambiarEstadoUnidad)
        public static bool ActualizarActivo(int idActivo, string nombre, int idCategoria)
        {
            try
            {
                using (SqlConnection con = Conexion.Conectar())
                {
                    con.Open();
                    string query = @"UPDATE GestionActivos
                                 SET Nombre = @nombre, IdCategoria = @idCategoria
                                 WHERE IdActivo = @idActivo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idActivo", idActivo);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
        }

        // ---------------- UNIDADES INDIVIDUALES ----------------

        // Una fila por unidad con SU estado. Filtros opcionales (null = todos).
        public static DataTable ListarUnidades(int? idActivo = null, int? idSalon = null)
        {
            return Leer(@"SELECT IdUnidad, CodigoInventario, IdActivo, Activo, Categoria,
                                 IdSalon, Ubicacion, IdEstado, Estado
                          FROM vw_UnidadesDetalle
                          WHERE (@idActivo IS NULL OR IdActivo = @idActivo)
                            AND (@idSalon  IS NULL OR IdSalon  = @idSalon)
                          ORDER BY Activo, CodigoInventario",
                        new SqlParameter("@idActivo", (object)idActivo ?? DBNull.Value),
                        new SqlParameter("@idSalon", (object)idSalon ?? DBNull.Value));
        }

        // Cambia el estado de UNA sola unidad (los demas pupitres no se tocan)
        public static void CambiarEstadoUnidad(int idUnidad, int idEstado)
        {
            Ejecutar("dbo.sp_CambiarEstadoUnidad",
                     new SqlParameter("@IdUnidad", idUnidad),
                     new SqlParameter("@IdEstado", idEstado));
        }

        // Da de alta N unidades de un tipo en un salon, cada una con su codigo y estado inicial
        public static void AgregarUnidades(int idActivo, int idSalon, int cantidad, int idEstado)
        {
            Ejecutar("dbo.sp_AgregarUnidades",
                     new SqlParameter("@IdActivo", idActivo),
                     new SqlParameter("@IdSalon", idSalon),
                     new SqlParameter("@Cantidad", cantidad),
                     new SqlParameter("@IdEstado", idEstado));
        }

        private static void Ejecutar(string procedimiento, params SqlParameter[] parametros)
        {
            try
            {
                using (SqlConnection con = Conexion.Conectar())
                using (SqlCommand cmd = new SqlCommand(procedimiento, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(parametros);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
        }

        // Lector generico (Fill abre y cierra la conexion solo)
        private static DataTable Leer(string sql, params SqlParameter[] parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = Conexion.Conectar())
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddRange(parametros);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error SQL: " + ex.Message);
            }
            return dt;
        }
    }
}
