using System;
using System.Data;
using System.Windows.Forms;
using GestionSalud.Modelos;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    /// <summary>
    /// Registro de incidencias y mantenimientos de equipos.
    /// Accesible para el rol Jefe de Enfermeras (y superiores).
    ///
    /// Controles que debes crear en el diseñador:
    ///   txtBuscarEquipo  — TextBox  (código o serie del equipo)
    ///   btnBuscarEquipo  — Button   ("Buscar equipo")
    ///   dgvEquipo        — DataGridView (muestra el equipo encontrado)
    ///   cboTipoAccion    — ComboBox  (Mantenimiento / Reparación / Calibración)
    ///   txtDescripcion   — TextBox   (Multiline = true, descripción del problema)
    ///   lblEmpleado      — Label     (muestra quién está registrando)
    ///   btnRegistrar     — Button    ("Registrar incidencia")
    ///   btnLimpiar       — Button    ("Limpiar")
    ///   dgvHistorial     — DataGridView (historial reciente de incidencias)
    /// </summary>
    public partial class FormIncidencia : Form
    {
        private readonly InventarioService _inventario = new InventarioService();
        private readonly ReporteService    _reportes   = new ReporteService();
        private readonly Empleado          _empleado;
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

        // ── Buscar equipo por código o serie ────────────────────────────
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
                var dt = _reportes.BuscarEquipo(txtBuscarEquipo.Text.Trim());
                dgvEquipo.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontró ningún equipo con ese código o serie.",
                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _idInventarioSeleccionado = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Al seleccionar equipo en la grilla ──────────────────────────
        private void dgvEquipo_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEquipo.SelectedRows.Count == 0) return;

            // Guardamos el ID para usarlo al registrar
            // (necesita que IdInventario esté visible o al menos presente en DataSource)
            var fila = dgvEquipo.SelectedRows[0];
            if (fila.Cells["IdInventario"] != null)
                _idInventarioSeleccionado = Convert.ToInt32(fila.Cells["IdInventario"].Value);
        }

        // ── Registrar incidencia ────────────────────────────────────────
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
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

        // ── Historial reciente (último mes) ─────────────────────────────
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
            dgvEquipo.DataSource = null;
            cboTipoAccion.SelectedIndex = 0;
            _idInventarioSeleccionado = 0;
        }
    }
}
