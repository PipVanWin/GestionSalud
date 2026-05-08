using System;
using System.Windows.Forms;
using GestionSalud.Modelos;

namespace GestionSalud.Presentacion
{
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

            // NUEVO: colorear el label según el rol
            lblUsuario.BackColor = ObtenerColorRol(_empleado.IdRol);
        }

        private System.Drawing.Color ObtenerColorRol(int idRol)
        {
            switch (idRol)
            {
                case 1: return System.Drawing.Color.FromArgb(0, 102, 51);    // Verde oscuro - Director Municipal
                case 2: return System.Drawing.Color.FromArgb(0, 70, 127);    // Azul oscuro  - Director Centro
                case 3: return System.Drawing.Color.FromArgb(153, 0, 0);     // Rojo oscuro  - Jefe Enfermeras
                case 4: return System.Drawing.Color.FromArgb(100, 60, 0);    // Café         - Digitador
                default: return System.Drawing.Color.Gray;
            }
        }

        // Control de acceso por rol
        private void AplicarPermisos(int idRol)
        {
            // Deshabilitar TODO por defecto (seguridad por denegación)
            mnuMantenimiento.Enabled = false;
            mnuEquipos.Enabled = false;
            usuarioNuevoToolStripMenuItem.Visible = false;   // solo Director Municipal
            mnuAsignacion.Enabled = false;
            mnuIncidencias.Enabled = false;
            mnuReportes.Enabled = false;

            switch (idRol)
            {
                // Rol 1: Director Municipal de Salud
                // Acceso completo: ve y usa todo el sistema
                case 1:
                    mnuMantenimiento.Enabled = true;
                    mnuEquipos.Enabled = true;
                    usuarioNuevoToolStripMenuItem.Visible = true;  // gestiona usuarios
                    mnuAsignacion.Enabled = true;
                    mnuIncidencias.Enabled = true;
                    mnuReportes.Enabled = true;
                    break;

                // Rol 2: Director del Centro
                // Mantenimiento de equipos + asignación de enseres a espacios
                case 2:
                    mnuMantenimiento.Enabled = true;
                    mnuEquipos.Enabled = true;
                    mnuAsignacion.Enabled = true;
                    // Sin acceso a: incidencias, reportes, usuarios
                    break;

                // Rol 3: Jefe de Enfermeras
                // Únicamente registra incidencias y mantenimientos de equipos
                case 3:
                    mnuIncidencias.Enabled = true;
                    // Sin acceso a: mantenimiento, asignación, reportes, usuarios
                    break;

                // Rol 4: Digitador
                // Solo ingresa información de inventario (equipos)
                case 4:
                    mnuMantenimiento.Enabled = true;
                    mnuEquipos.Enabled = true;
                    // Sin acceso a: asignación, incidencias, reportes, usuarios
                    break;
            }
        }

        // Mantenimiento

        private void mnuEquipos_Click(object sender, EventArgs e)
        {
            using (var form = new FormMantenimientoEquipo())
                form.ShowDialog();
        }

        private void usuarioNuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Solo llega aquí si el ítem es visible (Director Municipal)
            using (var form = new FormMantenimientoEmpleado())
                form.ShowDialog();
        }

        // Asignación

        private void mnuAsignarEnseres_Click(object sender, EventArgs e)
        {
            using (var form = new FormAsignacionEnseres(_empleado))
                form.ShowDialog();
        }

        // Incidencias

        private void mnuRegistrarIncidencia_Click(object sender, EventArgs e)
        {
            using (var form = new FormIncidencia(_empleado))
                form.ShowDialog();
        }

        // Reportes

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

        // Sistema

        private void mnuCerrarSesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // Eventos vacíos requeridos por el Designer (no eliminar)
        private void crearUsuarioNuevoToolStripMenuItem_Click(object sender, EventArgs e) { }
        private void lblBienvenida_Click(object sender, EventArgs e) { }
    }
}