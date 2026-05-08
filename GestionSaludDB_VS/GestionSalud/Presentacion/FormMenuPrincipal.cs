using System;
using System.Windows.Forms;
using GestionSalud.Modelos;

namespace GestionSalud.Presentacion
{
    /// <summary>
    /// Menú principal. Habilita/deshabilita opciones según el rol del empleado.
    ///
    /// MenuStrip que debes crear en el diseñador:
    ///   mnuMantenimiento  → mnuEquipos, mnuEmpleados, mnuCentros
    ///   mnuAsignacion     → mnuAsignarEnseres
    ///   mnuIncidencias    → mnuRegistrarIncidencia
    ///   mnuReportes       → mnuRptCentros, mnuRptFechas, mnuRptTop3,
    ///                        mnuRptEspacio, mnuRptBuscar
    ///   mnuSistema        → mnuCerrarSesion
    ///
    /// StatusStrip:
    ///   lblUsuario — ToolStripStatusLabel
    ///
    /// Roles del enunciado:
    ///   1 = Director Municipal  → acceso total
    ///   2 = Director del Centro → mantenimiento + asignaciones
    ///   3 = Jefe de Enfermeras  → incidencias
    ///   4 = Digitador           → solo mantenimiento de inventario
    /// </summary>
    public partial class FormMenuPrincipal : Form
    {
        private readonly Empleado _empleado;

        public FormMenuPrincipal(Empleado empleado)
        {
            InitializeComponent();
            _empleado = empleado;
        }

        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"  Usuario: {_empleado.NombreCompleto}  |  Rol: {_empleado.NombreRol}";
            AplicarPermisos(_empleado.IdRol);
        }

        // ── Control de acceso por rol ───────────────────────────────────
        private void AplicarPermisos(int idRol)
        {
            // Deshabilitar todo por defecto
            mnuMantenimiento.Enabled = false;
            mnuAsignacion.Enabled    = false;
            mnuIncidencias.Enabled   = false;
            mnuReportes.Enabled      = false;

            switch (idRol)
            {
                case 1: // Director Municipal — ve todo
                    mnuMantenimiento.Enabled = true;
                    mnuAsignacion.Enabled    = true;
                    mnuIncidencias.Enabled   = true;
                    mnuReportes.Enabled      = true;
                    break;

                case 2: // Director del Centro
                    mnuMantenimiento.Enabled = true;
                    mnuAsignacion.Enabled    = true;
                    break;

                case 3: // Jefe de Enfermeras
                    mnuIncidencias.Enabled = true;
                    break;

                case 4: // Digitador — solo ingreso de datos
                    mnuMantenimiento.Enabled = true;
                    break;
            }
        }

        // ── Navegación ──────────────────────────────────────────────────

        private void mnuEquipos_Click(object sender, EventArgs e)
        {
            using (var form = new FormMantenimientoEquipo())
                form.ShowDialog();
        }

        private void mnuAsignarEnseres_Click(object sender, EventArgs e)
        {
            using (var form = new FormAsignacionEnseres(_empleado))
                form.ShowDialog();
        }

        private void mnuRegistrarIncidencia_Click(object sender, EventArgs e)
        {
            using (var form = new FormIncidencia(_empleado))
                form.ShowDialog();
        }

        private void mnuRptCentros_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportes(FormReportes.TipoReporte.EspaciosPorCentro))
                form.ShowDialog();
        }

        private void mnuRptFechas_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportes(FormReportes.TipoReporte.IncidenciasPorFechas))
                form.ShowDialog();
        }

        private void mnuRptTop3_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportes(FormReportes.TipoReporte.Top3Consultorios))
                form.ShowDialog();
        }

        private void mnuRptEspacio_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportes(FormReportes.TipoReporte.EquiposPorEspacio))
                form.ShowDialog();
        }

        private void mnuRptBuscar_Click(object sender, EventArgs e)
        {
            using (var form = new FormReportes(FormReportes.TipoReporte.BuscarEquipo))
                form.ShowDialog();
        }

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void crearUsuarioNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
