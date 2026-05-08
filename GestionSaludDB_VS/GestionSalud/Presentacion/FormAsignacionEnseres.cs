using System;
using System.Data;
using System.Windows.Forms;
using GestionSalud.Modelos;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    /// <summary>
    /// Pantalla de asignación de equipos a espacios médicos.
    ///
    /// Controles que debes crear en el diseñador:
    ///   cboCentro          — ComboBox  (centros de salud)
    ///   cboEspacio         — ComboBox  (espacios filtrados por centro)
    ///   dgvEquipos         — DataGridView (equipos disponibles, MultiSelect = true)
    ///   lblEquiposAsign.   — Label  (muestra cuántos equipos tiene el espacio)
    ///   btnAsignar         — Button ("Asignar al espacio")
    ///   btnHojaInventario  — Button ("Generar hoja de inventario")
    ///   btnRefrescar       — Button ("Refrescar lista")
    /// </summary>
    public partial class FormAsignacionEnseres : Form
    {
        private readonly InventarioService _inventario = new InventarioService();
        private readonly Empleado          _empleado;

        public FormAsignacionEnseres(Empleado empleado)
        {
            InitializeComponent();
            _empleado = empleado;
        }

        private void FormAsignacionEnseres_Load(object sender, EventArgs e)
        {
            CargarCentros();
            RefrescarEquiposDisponibles();
        }

        // ── Cargar centros ──────────────────────────────────────────────
        private void CargarCentros()
        {
            try
            {
                var dt = _inventario.ListarCentros();
                cboCentro.DataSource    = dt;
                cboCentro.DisplayMember = "NombreCentro";
                cboCentro.ValueMember   = "IdCentro";
                cboCentro.SelectedIndex = -1;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Al cambiar centro → cargar sus espacios ─────────────────────
        private void cboCentro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCentro.SelectedValue == null) return;

            try
            {
                int idCentro = (int)cboCentro.SelectedValue;
                var dt = _inventario.ListarEspaciosPorCentro(idCentro);

                cboEspacio.DataSource    = dt;
                cboEspacio.DisplayMember = "NombreEspacio";
                cboEspacio.ValueMember   = "IdEspacio";
                cboEspacio.SelectedIndex = -1;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Equipos disponibles (sin asignar) ───────────────────────────
        private void RefrescarEquiposDisponibles()
        {
            try
            {
                dgvEquipos.DataSource = _inventario.ListarEquiposDisponibles();

                if (dgvEquipos.Columns.Contains("IdInventario"))
                    dgvEquipos.Columns["IdInventario"].Visible = false;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void btnRefrescar_Click(object sender, EventArgs e) =>
            RefrescarEquiposDisponibles();

        // ── Asignar equipos seleccionados al espacio ────────────────────
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            if (cboEspacio.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un centro y un espacio de destino.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvEquipos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione al menos un equipo de la lista.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspacio = (int)cboEspacio.SelectedValue;

            try
            {
                foreach (DataGridViewRow fila in dgvEquipos.SelectedRows)
                {
                    int idInventario = Convert.ToInt32(fila.Cells["IdInventario"].Value);
                    _inventario.AsignarEquipoAEspacio(idInventario, idEspacio);
                }

                MessageBox.Show(
                    $"{dgvEquipos.SelectedRows.Count} equipo(s) asignado(s) correctamente.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefrescarEquiposDisponibles();
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // ── Generar hoja de inventario ──────────────────────────────────
        private void btnHojaInventario_Click(object sender, EventArgs e)
        {
            if (cboEspacio.SelectedValue == null)
            {
                MessageBox.Show("Seleccione un espacio para generar su hoja.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEspacio = (int)cboEspacio.SelectedValue;

            try
            {
                var dt = _inventario.HojaInventarioPorEspacio(idEspacio);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("El espacio no tiene equipos asignados todavía.",
                        "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var formHoja = new FormHojaInventario(dt))
                    formHoja.ShowDialog();
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private static void MostrarError(string mensaje) =>
            MessageBox.Show($"Error: {mensaje}", "Error del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
