using System.Collections.Generic;
using GestionSalud.Datos;
using GestionSalud.Modelos;

namespace GestionSalud.Servicios
{
    /// <summary>
    /// Gestiona autenticación y roles de usuario.
    /// </summary>
    public class SeguridadService
    {
        /// <summary>
        /// Valida correo y contraseña contra la base de datos.
        /// Devuelve el Empleado con su Rol, o null si falla.
        /// </summary>
        public Empleado ValidarLogin(string correo, string contrasena)
        {
            const string sql = @"
                SELECT e.IdEmpleado, e.Nombre, e.Apellido,
                       e.CorreoElectronico, e.IdRol, e.IdCentro,
                       r.NombreRol
                FROM   Personal_Empleado e
                JOIN   Sistema_Rol       r ON e.IdRol = r.IdRol
                WHERE  e.CorreoElectronico = @correo
                  AND  e.Contrasena        = @clave";

            var tabla = Conexion.EjecutarConsulta(sql, cmd =>
            {
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@clave",  contrasena);
            });

            if (tabla.Rows.Count == 0)
                return null;

            var fila = tabla.Rows[0];
            return new Empleado
            {
                IdEmpleado        = (int)fila["IdEmpleado"],
                Nombre            = fila["Nombre"].ToString(),
                Apellido          = fila["Apellido"].ToString(),
                CorreoElectronico = fila["CorreoElectronico"].ToString(),
                IdRol             = (int)fila["IdRol"],
                NombreRol         = fila["NombreRol"].ToString(),
                IdCentro          = (int)fila["IdCentro"]
            };
        }

        /// <summary>Lista todos los roles para ComboBox de mantenimiento.</summary>
        public List<Rol> ListarRoles()
        {
            var roles = new List<Rol>();
            var tabla = Conexion.EjecutarConsulta(
                "SELECT IdRol, NombreRol, Permisos FROM Sistema_Rol ORDER BY NombreRol");

            foreach (System.Data.DataRow fila in tabla.Rows)
                roles.Add(new Rol
                {
                    IdRol     = (int)fila["IdRol"],
                    NombreRol = fila["NombreRol"].ToString(),
                    Permisos  = fila["Permisos"].ToString()
                });

            return roles;
        }
    }
}
