namespace GestionSalud.Presentacion
{
    partial class FormMenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuMantenimiento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEquipos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAsignacion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAsignarEnseres = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuIncidencias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRegistrarIncidencia = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptCentros = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptFechas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptTop3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptEspacio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptBuscar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCerrarSesion = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelBienvenida = new System.Windows.Forms.Panel();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.usuarioNuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelBienvenida.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(180)))));
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMantenimiento,
            this.mnuAsignacion,
            this.mnuIncidencias,
            this.mnuReportes,
            this.mnuSistema});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(891, 36);
            this.menuStrip1.TabIndex = 2;
            // 
            // mnuMantenimiento
            // 
            this.mnuMantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEquipos,
            this.usuarioNuevoToolStripMenuItem});
            this.mnuMantenimiento.ForeColor = System.Drawing.Color.White;
            this.mnuMantenimiento.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.mnuMantenimiento.Name = "mnuMantenimiento";
            this.mnuMantenimiento.Size = new System.Drawing.Size(124, 24);
            this.mnuMantenimiento.Text = "Mantenimiento";
            // 
            // mnuEquipos
            // 
            this.mnuEquipos.Name = "mnuEquipos";
            this.mnuEquipos.Size = new System.Drawing.Size(225, 26);
            this.mnuEquipos.Text = "Equipos (Inventario)";
            this.mnuEquipos.Click += new System.EventHandler(this.mnuEquipos_Click);
            // 
            // mnuAsignacion
            // 
            this.mnuAsignacion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAsignarEnseres});
            this.mnuAsignacion.ForeColor = System.Drawing.Color.White;
            this.mnuAsignacion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.mnuAsignacion.Name = "mnuAsignacion";
            this.mnuAsignacion.Size = new System.Drawing.Size(96, 24);
            this.mnuAsignacion.Text = "Asignación";
            // 
            // mnuAsignarEnseres
            // 
            this.mnuAsignarEnseres.Name = "mnuAsignarEnseres";
            this.mnuAsignarEnseres.Size = new System.Drawing.Size(262, 26);
            this.mnuAsignarEnseres.Text = "Asignar Enseres a Espacio";
            this.mnuAsignarEnseres.Click += new System.EventHandler(this.mnuAsignarEnseres_Click);
            // 
            // mnuIncidencias
            // 
            this.mnuIncidencias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRegistrarIncidencia});
            this.mnuIncidencias.ForeColor = System.Drawing.Color.White;
            this.mnuIncidencias.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.mnuIncidencias.Name = "mnuIncidencias";
            this.mnuIncidencias.Size = new System.Drawing.Size(96, 24);
            this.mnuIncidencias.Text = "Incidencias";
            // 
            // mnuRegistrarIncidencia
            // 
            this.mnuRegistrarIncidencia.Name = "mnuRegistrarIncidencia";
            this.mnuRegistrarIncidencia.Size = new System.Drawing.Size(337, 26);
            this.mnuRegistrarIncidencia.Text = "Registrar Incidencia / Mantenimiento";
            this.mnuRegistrarIncidencia.Click += new System.EventHandler(this.mnuRegistrarIncidencia_Click);
            // 
            // mnuReportes
            // 
            this.mnuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRptCentros,
            this.mnuRptFechas,
            this.mnuRptTop3,
            this.mnuRptEspacio,
            this.mnuRptBuscar});
            this.mnuReportes.ForeColor = System.Drawing.Color.White;
            this.mnuReportes.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.mnuReportes.Name = "mnuReportes";
            this.mnuReportes.Size = new System.Drawing.Size(82, 24);
            this.mnuReportes.Text = "Reportes";
            // 
            // mnuRptCentros
            // 
            this.mnuRptCentros.Name = "mnuRptCentros";
            this.mnuRptCentros.Size = new System.Drawing.Size(332, 26);
            this.mnuRptCentros.Text = "Espacios por Centro";
            this.mnuRptCentros.Click += new System.EventHandler(this.mnuRptCentros_Click);
            // 
            // mnuRptFechas
            // 
            this.mnuRptFechas.Name = "mnuRptFechas";
            this.mnuRptFechas.Size = new System.Drawing.Size(332, 26);
            this.mnuRptFechas.Text = "Incidencias por Fechas";
            this.mnuRptFechas.Click += new System.EventHandler(this.mnuRptFechas_Click);
            // 
            // mnuRptTop3
            // 
            this.mnuRptTop3.Name = "mnuRptTop3";
            this.mnuRptTop3.Size = new System.Drawing.Size(332, 26);
            this.mnuRptTop3.Text = "Top 3 Consultorios Mejor Equipados";
            this.mnuRptTop3.Click += new System.EventHandler(this.mnuRptTop3_Click);
            // 
            // mnuRptEspacio
            // 
            this.mnuRptEspacio.Name = "mnuRptEspacio";
            this.mnuRptEspacio.Size = new System.Drawing.Size(332, 26);
            this.mnuRptEspacio.Text = "Equipos por Espacio";
            this.mnuRptEspacio.Click += new System.EventHandler(this.mnuRptEspacio_Click);
            // 
            // mnuRptBuscar
            // 
            this.mnuRptBuscar.Name = "mnuRptBuscar";
            this.mnuRptBuscar.Size = new System.Drawing.Size(332, 26);
            this.mnuRptBuscar.Text = "Buscar Equipo";
            this.mnuRptBuscar.Click += new System.EventHandler(this.mnuRptBuscar_Click);
            // 
            // mnuSistema
            // 
            this.mnuSistema.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCerrarSesion});
            this.mnuSistema.ForeColor = System.Drawing.Color.White;
            this.mnuSistema.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.mnuSistema.Name = "mnuSistema";
            this.mnuSistema.Size = new System.Drawing.Size(75, 24);
            this.mnuSistema.Text = "Sistema";
            // 
            // mnuCerrarSesion
            // 
            this.mnuCerrarSesion.Name = "mnuCerrarSesion";
            this.mnuCerrarSesion.Size = new System.Drawing.Size(228, 26);
            this.mnuCerrarSesion.Text = "Cerrar Sesión";
            this.mnuCerrarSesion.Click += new System.EventHandler(this.mnuCerrarSesion_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(891, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(0, 16);
            // 
            // panelBienvenida
            // 
            this.panelBienvenida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelBienvenida.Controls.Add(this.lblBienvenida);
            this.panelBienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBienvenida.Location = new System.Drawing.Point(0, 28);
            this.panelBienvenida.Name = "panelBienvenida";
            this.panelBienvenida.Size = new System.Drawing.Size(891, 462);
            this.panelBienvenida.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblBienvenida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(160)))));
            this.lblBienvenida.Location = new System.Drawing.Point(0, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(891, 462);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Sistema de Gestión de Salud Municipal\r\nSeleccione una opción del menú superior";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBienvenida.Click += new System.EventHandler(this.lblBienvenida_Click);
            // 
            // usuarioNuevoToolStripMenuItem
            // 
            this.usuarioNuevoToolStripMenuItem.Name = "usuarioNuevoToolStripMenuItem";
            this.usuarioNuevoToolStripMenuItem.Size = new System.Drawing.Size(225, 26);
            this.usuarioNuevoToolStripMenuItem.Text = "Usuario Nuevo";
            this.usuarioNuevoToolStripMenuItem.Click += new System.EventHandler(this.usuarioNuevoToolStripMenuItem_Click);
            // 
            // FormMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 512);
            this.Controls.Add(this.panelBienvenida);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Text = "Gestión de Salud Municipal";
            this.Load += new System.EventHandler(this.FormMenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelBienvenida.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip           menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem   mnuMantenimiento;
        private System.Windows.Forms.ToolStripMenuItem   mnuEquipos;
        private System.Windows.Forms.ToolStripMenuItem   mnuAsignacion;
        private System.Windows.Forms.ToolStripMenuItem   mnuAsignarEnseres;
        private System.Windows.Forms.ToolStripMenuItem   mnuIncidencias;
        private System.Windows.Forms.ToolStripMenuItem   mnuRegistrarIncidencia;
        private System.Windows.Forms.ToolStripMenuItem   mnuReportes;
        private System.Windows.Forms.ToolStripMenuItem   mnuRptCentros;
        private System.Windows.Forms.ToolStripMenuItem   mnuRptFechas;
        private System.Windows.Forms.ToolStripMenuItem   mnuRptTop3;
        private System.Windows.Forms.ToolStripMenuItem   mnuRptEspacio;
        private System.Windows.Forms.ToolStripMenuItem   mnuRptBuscar;
        private System.Windows.Forms.ToolStripMenuItem   mnuSistema;
        private System.Windows.Forms.ToolStripMenuItem   mnuCerrarSesion;
        private System.Windows.Forms.StatusStrip         statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuario;
        private System.Windows.Forms.Panel               panelBienvenida;
        private System.Windows.Forms.Label               lblBienvenida;
        private System.Windows.Forms.ToolStripMenuItem usuarioNuevoToolStripMenuItem;
    }
}
