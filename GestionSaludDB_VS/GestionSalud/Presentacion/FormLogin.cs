using System;
using System.Windows.Forms;
using GestionSalud.Modelos;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    /// <summary>
    /// Pantalla de autenticación del sistema.
    ///
    /// Controles que debes crear en el diseñador (.Designer.cs):
    ///   txtCorreo   — TextBox
    ///   txtClave    — TextBox  (PasswordChar = '*')
    ///   btnIngresar — Button
    ///   chkMostrar  — CheckBox ("Mostrar contraseña")
    ///   lblError    — Label    (ForeColor = Red, Visible = false)
    ///   lblTitulo   — Label    (texto: "Sistema de Gestión de Salud Municipal")
    /// </summary>
    public partial class FormLogin : Form
    {
        private readonly SeguridadService _seguridad = new SeguridadService();

        /// <summary>Empleado autenticado; accesible desde Program.cs tras el login.</summary>
        public Empleado EmpleadoActual { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
            txtClave.PasswordChar = '*';
            lblError.Visible      = false;
            this.AcceptButton     = btnIngresar;   // Enter dispara el botón
        }

        // ── Botón Ingresar ──────────────────────────────────────────────
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;

            if (string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MostrarError("Ingrese correo y contraseña.");
                return;
            }

            try
            {
                var empleado = _seguridad.ValidarLogin(
                    txtCorreo.Text.Trim(),
                    txtClave.Text.Trim());

                if (empleado == null)
                {
                    MostrarError("Credenciales incorrectas. Intente de nuevo.");
                    txtClave.Clear();
                    txtClave.Focus();
                    return;
                }

                EmpleadoActual = empleado;
                DialogResult   = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MostrarError($"Error de conexión: {ex.Message}");
            }
        }

        // ── Mostrar / ocultar contraseña ────────────────────────────────
        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtClave.PasswordChar = chkMostrar.Checked ? '\0' : '*';
        }

        private void MostrarError(string mensaje)
        {
            lblError.Text    = mensaje;
            lblError.Visible = true;
        }
    }
}
