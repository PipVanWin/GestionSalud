using System;
using System.Windows.Forms;
using GestionSalud.Datos;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    public partial class FormMantenimientoEmpleado : Form
    {
        private SeguridadService _seguridad;
        private int _idSeleccionado = 0;

        public FormMantenimientoEmpleado()
        {
            InitializeComponent();

            if (!System.ComponentModel.LicenseManager.UsageMode
                .Equals(System.ComponentModel.LicenseUsageMode.Designtime))
            {
                _seguridad = new SeguridadService();
            }
        }

        private void FormMantenimientoEmpleado_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode
                == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            CargarRoles();
            CargarCentros();
            RefrescarGrilla();
        }

        private void RefrescarGrilla()
        {
            try
            {
                dgvEmpleados.DataSource = Conexion.EjecutarConsulta(@"
                    SELECT e.IdEmpleado, e.Nombre, e.Apellido,
                           e.CorreoElectronico, r.NombreRol,
                           e.IdRol,
                           ic.NombreCentro, e.IdCentro
                    FROM   Personal_Empleado       e
                    JOIN   Sistema_Rol             r  ON e.IdRol   = r.IdRol
                    JOIN   Infraestructura_Centro  ic ON e.IdCentro = ic.IdCentro
                    ORDER  BY e.Apellido, e.Nombre");

                if (dgvEmpleados.Columns.Contains("IdEmpleado"))
                    dgvEmpleados.Columns["IdEmpleado"].Visible = false;
                if (dgvEmpleados.Columns.Contains("IdRol"))
                    dgvEmpleados.Columns["IdRol"].Visible = false;
                if (dgvEmpleados.Columns.Contains("IdCentro"))
                    dgvEmpleados.Columns["IdCentro"].Visible = false;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void CargarRoles()
        {
            try
            {
                var dt = Conexion.EjecutarConsulta(
                    "SELECT IdRol, NombreRol FROM Sistema_Rol ORDER BY NombreRol");
                cboRol.DataSource = dt;
                cboRol.DisplayMember = "NombreRol";
                cboRol.ValueMember = "IdRol";
                cboRol.SelectedIndex = 0;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void CargarCentros()
        {
            try
            {
                var dt = Conexion.EjecutarConsulta(
                    "SELECT IdCentro, NombreCentro FROM Infraestructura_Centro ORDER BY NombreCentro");
                cboCentro.DataSource = dt;
                cboCentro.DisplayMember = "NombreCentro";
                cboCentro.ValueMember = "IdCentro";
                cboCentro.SelectedIndex = 0;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count == 0) return;

            var fila = dgvEmpleados.SelectedRows[0];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdEmpleado"].Value);
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtApellido.Text = fila.Cells["Apellido"].Value?.ToString();
            txtCorreo.Text = fila.Cells["CorreoElectronico"].Value?.ToString();
            txtClave.Text = "";   // nunca mostrar la clave almacenada
            cboRol.SelectedValue = Convert.ToInt32(fila.Cells["IdRol"].Value);
            cboCentro.SelectedValue = Convert.ToInt32(fila.Cells["IdCentro"].Value);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                if (_idSeleccionado == 0)
                {
                    // INSERT
                    int nuevoId = Convert.ToInt32(Conexion.EjecutarEscalar(
                        "SELECT ISNULL(MAX(IdEmpleado),0)+1 FROM Personal_Empleado"));

                    Conexion.EjecutarComando(@"
                        INSERT INTO Personal_Empleado
                               (IdEmpleado, Nombre, Apellido,
                                CorreoElectronico, Contrasena, IdRol, IdCentro)
                        VALUES (@id, @nom, @ape, @correo, @clave, @rol, @centro)",
                        cmd =>
                        {
                            cmd.Parameters.AddWithValue("@id", nuevoId);
                            cmd.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@ape", txtApellido.Text.Trim());
                            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                            cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                            cmd.Parameters.AddWithValue("@rol", (int)cboRol.SelectedValue);
                            cmd.Parameters.AddWithValue("@centro", (int)cboCentro.SelectedValue);
                        });

                    MessageBox.Show("Empleado registrado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // UPDATE (solo actualiza clave si se escribió algo)
                    string sqlUpdate = string.IsNullOrWhiteSpace(txtClave.Text)
                        ? @"UPDATE Personal_Empleado
                            SET Nombre=@nom, Apellido=@ape,
                                CorreoElectronico=@correo, IdRol=@rol, IdCentro=@centro
                            WHERE IdEmpleado=@id"
                        : @"UPDATE Personal_Empleado
                            SET Nombre=@nom, Apellido=@ape, CorreoElectronico=@correo,
                                Contrasena=@clave, IdRol=@rol, IdCentro=@centro
                            WHERE IdEmpleado=@id";

                    Conexion.EjecutarComando(sqlUpdate, cmd =>
                    {
                        cmd.Parameters.AddWithValue("@id", _idSeleccionado);
                        cmd.Parameters.AddWithValue("@nom", txtNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@ape", txtApellido.Text.Trim());
                        cmd.Parameters.AddWithValue("@correo", txtCorreo.Text.Trim());
                        cmd.Parameters.AddWithValue("@clave", txtClave.Text.Trim());
                        cmd.Parameters.AddWithValue("@rol", (int)cboRol.SelectedValue);
                        cmd.Parameters.AddWithValue("@centro", (int)cboCentro.SelectedValue);
                    });

                    MessageBox.Show("Empleado actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LimpiarFormulario();
                RefrescarGrilla();
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un empleado de la lista primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Eliminar el empleado seleccionado?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                Conexion.EjecutarComando(
                    "DELETE FROM Personal_Empleado WHERE IdEmpleado = @id",
                    cmd => cmd.Parameters.AddWithValue("@id", _idSeleccionado));

                MessageBox.Show("Empleado eliminado.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
                RefrescarGrilla();
            }
            catch (Exception ex)
            {
                MostrarError("No se pudo eliminar. El empleado puede tener incidencias registradas.\n" + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void LimpiarFormulario()
        {
            _idSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtClave.Clear();
            if (cboRol.Items.Count > 0) cboRol.SelectedIndex = 0;
            if (cboCentro.Items.Count > 0) cboCentro.SelectedIndex = 0;
            dgvEmpleados.ClearSelection();
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Nombre, apellido y correo son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (_idSeleccionado == 0 && string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña para el nuevo empleado.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private static void MostrarError(string mensaje) =>
            MessageBox.Show($"Error: {mensaje}", "Error del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}