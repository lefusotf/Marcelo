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
    public static class Datos
    {

        public static SqlParameter P(string nombre, object valor)
        {
            return new SqlParameter(nombre, valor ?? DBNull.Value);
        }


        // Cada unidad física tiene su código de inventario: (tipo de activo + código) -> IdUnidad
        public static int IdUnidad(int idActivo, string codigoInventario)
        {
            if (string.IsNullOrWhiteSpace(codigoInventario))
                throw new InvalidOperationException("Indique el código de inventario de la unidad.");
            object r = Escalar("SELECT IdUnidad FROM UnidadesActivo WHERE IdActivo = @a AND CodigoInventario = @c",
                               P("@a", idActivo), P("@c", codigoInventario.Trim()));
            if (r == null || r == DBNull.Value)
                throw new InvalidOperationException("No existe una unidad con el código '" + codigoInventario.Trim() +
                                                    "' para el activo seleccionado.");
            return Convert.ToInt32(r);
        }

        public static SqlParameter PTexto(string nombre, string valor)
        {
            return new SqlParameter(nombre, string.IsNullOrWhiteSpace(valor) ? (object)DBNull.Value : valor.Trim());
        }

        public static DataTable Tabla(string sql, params SqlParameter[] ps)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = Conexion.Conectar())
            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                if (ps != null) da.SelectCommand.Parameters.AddRange(ps);
                da.Fill(dt);
            }
            return dt;
        }

        public static object Escalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                con.Open();
                return cmd.ExecuteScalar();
            }
        }

        public static void Ejecutar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void Procedimiento(string nombre, params SqlParameter[] ps)
        {
            using (SqlConnection con = Conexion.Conectar())
            using (SqlCommand cmd = new SqlCommand(nombre, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (ps != null) cmd.Parameters.AddRange(ps);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}