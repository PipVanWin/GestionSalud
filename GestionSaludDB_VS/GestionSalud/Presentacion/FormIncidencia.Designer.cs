namespace GestionSalud.Presentacion
{
    partial class FormIncidencia
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
            this.grpBusqueda     = new System.Windows.Forms.GroupBox();
            this.txtBuscarEquipo = new System.Windows.Forms.TextBox();
            this.btnBuscarEquipo = new System.Windows.Forms.Button();
            this.dgvEquipo       = new System.Windows.Forms.DataGridView();
            this.grpRegistro     = new System.Windows.Forms.GroupBox();
            this.lblTipoAccion   = new System.Windows.Forms.Label();
            this.cboTipoAccion   = new System.Windows.Forms.ComboBox();
            this.lblDescripcion  = new System.Windows.Forms.Label();
            this.txtDescripcion  = new System.Windows.Forms.TextBox();
            this.lblEmpleado     = new System.Windows.Forms.Label();
            this.btnRegistrar    = new System.Windows.Forms.Button();
            this.btnLimpiar      = new System.Windows.Forms.Button();
            this.lblHistorial    = new System.Windows.Forms.Label();
            this.dgvHistorial    = new System.Windows.Forms.DataGridView();
            this.grpBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).BeginInit();
            this.grpRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();

            // grpBusqueda
            this.grpBusqueda.Text     = "Buscar equipo afectado";
            this.grpBusqueda.Location = new System.Drawing.Point(12, 10);
            this.grpBusqueda.Size     = new System.Drawing.Size(560, 170);
            this.grpBusqueda.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtBuscarEquipo, this.btnBuscarEquipo, this.dgvEquipo });

            this.txtBuscarEquipo.Location    = new System.Drawing.Point(10, 28);
            this.txtBuscarEquipo.Size        = new System.Drawing.Size(360, 22);
            this.txtBuscarEquipo.Font        = new System.Drawing.Font("Segoe UI", 9.5F);

            this.btnBuscarEquipo.Text      = "Buscar";
            this.btnBuscarEquipo.Location  = new System.Drawing.Point(382, 26);
            this.btnBuscarEquipo.Size      = new System.Drawing.Size(100, 26);
            this.btnBuscarEquipo.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.btnBuscarEquipo.ForeColor = System.Drawing.Color.White;
            this.btnBuscarEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEquipo.Click    += new System.EventHandler(this.btnBuscarEquipo_Click);

            this.dgvEquipo.AllowUserToAddRows    = false;
            this.dgvEquipo.AllowUserToDeleteRows = false;
            this.dgvEquipo.ReadOnly              = true;
            this.dgvEquipo.SelectionMode         = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipo.MultiSelect           = false;
            this.dgvEquipo.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipo.Location              = new System.Drawing.Point(10, 60);
            this.dgvEquipo.Size                  = new System.Drawing.Size(535, 100);
            this.dgvEquipo.BackgroundColor        = System.Drawing.Color.White;
            this.dgvEquipo.SelectionChanged      += new System.EventHandler(this.dgvEquipo_SelectionChanged);

            // grpRegistro
            this.grpRegistro.Text     = "Datos de la incidencia";
            this.grpRegistro.Location = new System.Drawing.Point(590, 10);
            this.grpRegistro.Size     = new System.Drawing.Size(300, 360);
            this.grpRegistro.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEmpleado, this.lblTipoAccion, this.cboTipoAccion,
                this.lblDescripcion, this.txtDescripcion,
                this.btnRegistrar, this.btnLimpiar });

            this.lblEmpleado.AutoSize  = true;
            this.lblEmpleado.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEmpleado.ForeColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.lblEmpleado.Location  = new System.Drawing.Point(10, 28);
            this.lblEmpleado.Text      = "Registrando como: ...";

            this.lblTipoAccion.Text     = "Tipo de acción:";
            this.lblTipoAccion.AutoSize = true;
            this.lblTipoAccion.Location = new System.Drawing.Point(10, 58);

            this.cboTipoAccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoAccion.Location      = new System.Drawing.Point(10, 78);
            this.cboTipoAccion.Size          = new System.Drawing.Size(270, 22);
            this.cboTipoAccion.Font          = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblDescripcion.Text     = "Descripción del problema / acción *:";
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(10, 115);

            this.txtDescripcion.Location  = new System.Drawing.Point(10, 135);
            this.txtDescripcion.Size      = new System.Drawing.Size(270, 120);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Font      = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            this.btnRegistrar.Text      = "Registrar Incidencia";
            this.btnRegistrar.Location  = new System.Drawing.Point(10, 270);
            this.btnRegistrar.Size      = new System.Drawing.Size(270, 36);
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrar.Click    += new System.EventHandler(this.btnRegistrar_Click);

            this.btnLimpiar.Text      = "Limpiar";
            this.btnLimpiar.Location  = new System.Drawing.Point(10, 315);
            this.btnLimpiar.Size      = new System.Drawing.Size(270, 28);
            this.btnLimpiar.BackColor = System.Drawing.Color.Gray;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Click    += new System.EventHandler(this.btnLimpiar_Click);

            // lblHistorial
            this.lblHistorial.AutoSize  = true;
            this.lblHistorial.Font      = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHistorial.Location  = new System.Drawing.Point(12, 192);
            this.lblHistorial.Text      = "Historial de incidencias (último mes):";

            // dgvHistorial
            this.dgvHistorial.AllowUserToAddRows    = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.ReadOnly              = true;
            this.dgvHistorial.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.Location              = new System.Drawing.Point(12, 215);
            this.dgvHistorial.Size                  = new System.Drawing.Size(560, 210);
            this.dgvHistorial.BackgroundColor        = System.Drawing.Color.White;

            // FormIncidencia
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(908, 438);
            this.Controls.Add(this.grpBusqueda);
            this.Controls.Add(this.grpRegistro);
            this.Controls.Add(this.lblHistorial);
            this.Controls.Add(this.dgvHistorial);
            this.Name          = "FormIncidencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Registro de Incidencias y Mantenimientos";
            this.Load         += new System.EventHandler(this.FormIncidencia_Load);
            this.grpBusqueda.ResumeLayout(false);
            this.grpBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipo)).EndInit();
            this.grpRegistro.ResumeLayout(false);
            this.grpRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox     grpBusqueda;
        private System.Windows.Forms.TextBox      txtBuscarEquipo;
        private System.Windows.Forms.Button       btnBuscarEquipo;
        private System.Windows.Forms.DataGridView dgvEquipo;
        private System.Windows.Forms.GroupBox     grpRegistro;
        private System.Windows.Forms.Label        lblEmpleado;
        private System.Windows.Forms.Label        lblTipoAccion;
        private System.Windows.Forms.ComboBox     cboTipoAccion;
        private System.Windows.Forms.Label        lblDescripcion;
        private System.Windows.Forms.TextBox      txtDescripcion;
        private System.Windows.Forms.Button       btnRegistrar;
        private System.Windows.Forms.Button       btnLimpiar;
        private System.Windows.Forms.Label        lblHistorial;
        private System.Windows.Forms.DataGridView dgvHistorial;
    }
}
