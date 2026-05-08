using System;
using System.Windows.Forms;
using GestionSalud.Modelos;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    public partial class FormMantenimientoEquipo : Form
    {
        private readonly InventarioService _inventario = new InventarioService();
        private readonly ReporteService _reportes = new ReporteService();
        private int _idSeleccionado = 0;   // 0 = modo insertar
        private bool _modoNuevo = false;   // TRUE mientras se ingresa un equipo nuevo

        public FormMantenimientoEquipo()
        {
            InitializeComponent();
        }

        private void FormMantenimientoEquipo_Load(object sender, EventArgs e)
        {
            CargarEstados();
            RefrescarGrilla();
            // Empezar en modo "nuevo" para que el primer uso sea insertar
            EntrarModoNuevo();
        }

        private void RefrescarGrilla()
        {
            try
            {
                dgvEquipos.DataSource = _inventario.ListarTodosLosEquipos();

                if (dgvEquipos.Columns.Contains("IdInventario"))
                    dgvEquipos.Columns["IdInventario"].Visible = false;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private void CargarEstados()
        {
            cboEstado.Items.Clear();
            cboEstado.Items.AddRange(new[]
                { "Activo", "En Calibración", "Dañado", "En Reparación" });
            cboEstado.SelectedIndex = 0;
        }

        // ── Selección en la grilla ──────────────────────────────────────
        // Solo carga datos cuando NO estamos en modo nuevo
        private void dgvEquipos_SelectionChanged(object sender, EventArgs e)
        {
            if (_modoNuevo) return;                          // ignorar clics cuando se está ingresando nuevo
            if (dgvEquipos.SelectedRows.Count == 0) return;

            var fila = dgvEquipos.SelectedRows[0];
            _idSeleccionado = Convert.ToInt32(fila.Cells["IdInventario"].Value);
            txtCodigo.Text = fila.Cells["CodigoMunicipal"].Value?.ToString();
            txtSerie.Text = fila.Cells["NumeroSerie"].Value?.ToString();
            txtMarca.Text = fila.Cells["Marca"].Value?.ToString();
            txtModelo.Text = fila.Cells["Modelo"].Value?.ToString();
            cboEstado.Text = fila.Cells["EstadoActual"].Value?.ToString();
            txtDescripcion.Text = "";  // la grilla no trae DescripcionTecnica

            // Indicar visualmente que se está editando
            ActualizarTituloModo();
        }

        // Botón Nuevo
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            EntrarModoNuevo();
        }

        private void EntrarModoNuevo()
        {
            _modoNuevo = true;          // bloquear SelectionChanged
            _idSeleccionado = 0;

            txtCodigo.Clear();
            txtSerie.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            txtDescripcion.Clear();
            cboEstado.SelectedIndex = 0;

            dgvEquipos.ClearSelection();

            ActualizarTituloModo();
            txtCodigo.Focus();
            // NOTA: _modoNuevo se mantiene en TRUE hasta que el usuario
            // haga clic en la grilla (ver dgvEquipos_Click abajo)
        }

        // Al hacer clic explícito en la grilla, salir del modo nuevo
        private void dgvEquipos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_modoNuevo && dgvEquipos.SelectedRows.Count > 0)
            {
                _modoNuevo = false;
                // Disparar carga manual porque SelectionChanged fue bloqueado
                dgvEquipos_SelectionChanged(sender, EventArgs.Empty);
            }
        }

        private void ActualizarTituloModo()
        {
            if (_idSeleccionado == 0)
                this.Text = "Mantenimiento de Equipos — NUEVO EQUIPO";
            else
                this.Text = $"Mantenimiento de Equipos — Editando ID {_idSeleccionado}";
        }

        // Guardar
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var equipo = new Equipo
                {
                    CodigoMunicipal = txtCodigo.Text.Trim(),
                    NumeroSerie = txtSerie.Text.Trim(),
                    Marca = txtMarca.Text.Trim(),
                    Modelo = txtModelo.Text.Trim(),
                    DescripcionTecnica = txtDescripcion.Text.Trim(),
                    EstadoActual = cboEstado.Text
                };

                if (_idSeleccionado == 0)
                {
                    // INSERT — siempre crea uno nuevo
                    equipo.IdInventario = _inventario.SiguienteIdEquipo();
                    _inventario.InsertarEquipo(equipo);
                    MessageBox.Show("Equipo registrado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // UPDATE — actualiza el seleccionado de la grilla
                    equipo.IdInventario = _idSeleccionado;
                    _inventario.ActualizarEquipo(equipo);
                    MessageBox.Show("Equipo actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                EntrarModoNuevo();
                RefrescarGrilla();
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un equipo de la lista primero.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Eliminar el equipo seleccionado?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                bool ok = _inventario.EliminarEquipo(_idSeleccionado);

                MessageBox.Show(
                    ok ? "Equipo eliminado correctamente."
                       : "No se puede eliminar: el equipo tiene incidencias registradas.",
                    ok ? "Éxito" : "Operación no permitida",
                    MessageBoxButtons.OK,
                    ok ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                EntrarModoNuevo();
                RefrescarGrilla();
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        // Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                RefrescarGrilla();
                return;
            }

            try
            {
                _modoNuevo = false; // permitir selección al buscar
                dgvEquipos.DataSource = _reportes.BuscarEquipo(txtBuscar.Text.Trim());

                if (dgvEquipos.Columns.Contains("IdInventario"))
                    dgvEquipos.Columns["IdInventario"].Visible = false;
            }
            catch (Exception ex) { MostrarError(ex.Message); }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtSerie.Text))
            {
                MessageBox.Show("Código municipal y número de serie son obligatorios.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private static void MostrarError(string mensaje) =>
            MessageBox.Show($"Error: {mensaje}", "Error del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}