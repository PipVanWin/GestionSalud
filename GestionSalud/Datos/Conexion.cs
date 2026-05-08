using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace GestionSalud.Datos
{
    /// Clase que centraliza toda comunicación con SQL Server.
    public class Conexion
    {
        private static readonly string _cadena =
            "Server=localhost\\SQLEXPRESS;" +
            "Database=GestionSaludDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        public static SqlConnection Abrir()
        {
            var conn = new SqlConnection(_cadena);
            conn.Open();
            return conn;
        }

        /// Ejecuta SELECT y devuelve un DataTable
        public static DataTable EjecutarConsulta(string sql, Action<SqlCommand> configurar = null)
        {
            var tabla = new DataTable();
            using (var conn = Abrir())
            using (var cmd = new SqlCommand(sql, conn))
            {
                configurar?.Invoke(cmd);
                using (var adapter = new SqlDataAdapter(cmd))
                    adapter.Fill(tabla);
            }
            return tabla;
        }

        /// Ejecuta INSERT / UPDATE / DELETE. Devuelve filas afectadas
        public static int EjecutarComando(string sql, Action<SqlCommand> configurar = null)
        {
            using (var conn = Abrir())
            using (var cmd = new SqlCommand(sql, conn))
            {
                configurar?.Invoke(cmd);
                return cmd.ExecuteNonQuery();
            }
        }

        /// Devuelve un único valor escalar
        public static object EjecutarEscalar(string sql, Action<SqlCommand> configurar = null)
        {
            using (var conn = Abrir())
            using (var cmd = new SqlCommand(sql, conn))
            {
                configurar?.Invoke(cmd);
                return cmd.ExecuteScalar();
            }
        }
    }
}
