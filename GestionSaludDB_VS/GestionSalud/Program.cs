using System;
using System.Windows.Forms;
using GestionSalud.Presentacion;

namespace GestionSalud
{
    static class Program
    {
        /// Flujo: Login → (si OK) → FormMenuPrincipal con el empleado autenticado.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var formLogin = new FormLogin())
            {
                // Si el usuario cancela o cierra el login → salir
                if (formLogin.ShowDialog() != DialogResult.OK)
                    return;

                // Pasar el empleado autenticado al menú principal
                Application.Run(new FormMenuPrincipal(formLogin.EmpleadoActual));
            }
        }
    }
}
