using System;
using System.Data;
using System.Windows.Forms;
using GestionSalud.Modelos;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    public partial class FormIncidencia : Form
    {
        private readonly InventarioService _inventario = new InventarioService();
        private readonly ReporteService _reportes = new ReporteService();
        private readonly Empleado _empleado;
        private int _idInventarioSeleccionado = 0;

        public FormIncidencia(Empleado empleado)
        {
            InitializeComponent();
            _empleado = empleado;
        }

        private void FormIncidencia_Load(object sender, EventArgs e)
        {
            lblEmpleado.Text = $"Registrando como: {_empleado.NombreCompleto}";
            CargarTiposAccion();
            CargarHistorialReciente();
        }

        private void CargarTiposAccion()
        {
            cboTipoAccion.Items.Clear();
            cboTipoAccion.Items.AddRange(new[]
                { "Mantenimiento", "Reparación", "Calibración", "Revisión" });
            cboTipoAccion.SelectedIndex = 0;
        }

        // Buscar equipo por código o serie
        private void btnBuscarEquipo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscarEquipo.Text))
            {
                MessageBox.Show("Ingrese el código municipal o número de serie.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Resetear selección antes de cargar nuevos datos
                _idInventarioSeleccionado = 0;

                var dt = _reportes.BuscarEquipo(txtBuscarEquipo.Text.Trim());

                // FIX: desuscribir el evento antes de asignar DataSource para evitar
                //      que SelectionChanged se dispare con datos a medio cargar
                dgvEquipo.SelectionChanged -= dgvEquipo_SelectionChanged;
                dgvEquipo.DataSource = dt;

                // Ocultar la columna IdInventario (necesaria para leer el ID pero
                // no debe mostrarse al usuario)
                if (dgvEquipo.Columns.Contains("IdInventario"))
                    dgvEquipo.Columns["IdInventario"].Visible = false;

                // Volver a suscribir
                dgvEquipo.SelectionChanged += dgvEquipo_SelectionChanged;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún equipo con ese código o serie.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _idInventarioSeleccionado = 0;
                }
                else if (dt.Rows.Count == 1)
                {
                    // Si solo hay un resultado, seleccionarlo automáticamente
                    dgvEquipo.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Al seleccionar equipo en la grilla
        private void dgvEquipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEquipo.SelectedRows.Count == 0)
            {
                _idInventarioSeleccionado = 0;
                return;
            }

            var fila = dgvEquipo.SelectedRows[0];

            // FIX: leer IdInventario de forma robusta verificando el valor, no solo la columna
            try
            {
                object val = fila.Cells["IdInventario"].Value;
                if (val != null && val != DBNull.Value)
                    _idInventarioSeleccionado = Convert.ToInt32(val);
                else
                    _idInventarioSeleccionado = 0;
            }
            catch
            {
                _idInventarioSeleccionado = 0;
            }
        }

        // Registrar incidencia
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // FIX: Si hay filas pero el ID es 0, intentar leerlo de la fila seleccionada
            if (_idInventarioSeleccionado == 0 && dgvEquipo.SelectedRows.Count > 0)
            {
                dgvEquipo_SelectionChanged(null, EventArgs.Empty);
            }

            if (_idInventarioSeleccionado == 0)
            {
                MessageBox.Show("Primero busque y seleccione el equipo afectado.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Ingrese la descripción del problema o acción.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _inventario.RegistrarIncidencia(
                    _idInventarioSeleccionado,
                    _empleado.IdEmpleado,
                    txtDescripcion.Text.Trim(),
                    cboTipoAccion.Text);

                MessageBox.Show("Incidencia registrada correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                Limpiar();
                CargarHistorialReciente();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Historial reciente (último mes)
        private void CargarHistorialReciente()
        {
            try
            {
                var dt = _reportes.IncidenciasPorFechas(
                    DateTime.Now.AddMonths(-1), DateTime.Now);
                dgvHistorial.DataSource = dt;
            }
            catch { /* no bloquear si falla el historial */ }
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => Limpiar();

        private void Limpiar()
        {
            txtBuscarEquipo.Clear();
            txtDescripcion.Clear();

            // Desuscribir para evitar disparo al limpiar
            dgvEquipo.SelectionChanged -= dgvEquipo_SelectionChanged;
            dgvEquipo.DataSource = null;
            dgvEquipo.SelectionChanged += dgvEquipo_SelectionChanged;

            cboTipoAccion.SelectedIndex = 0;
            _idInventarioSeleccionado = 0;
        }
    }
}