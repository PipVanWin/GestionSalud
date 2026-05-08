namespace GestionSalud.Presentacion
{
    partial class FormAsignacionEnseres
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
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.lblCentro = new System.Windows.Forms.Label();
            this.cboCentro = new System.Windows.Forms.ComboBox();
            this.lblEspacio = new System.Windows.Forms.Label();
            this.cboEspacio = new System.Windows.Forms.ComboBox();
            this.lblEquiposAsign = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnHojaInventario = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.grpFiltro.SuspendLayout();
            this.grpAcciones.SuspendLayout();
            this.SuspendLayout();

            this.grpFiltro.Text = "Seleccionar destino";
            this.grpFiltro.Location = new System.Drawing.Point(12, 10);
            this.grpFiltro.Size = new System.Drawing.Size(860, 80);

            this.lblCentro.Text = "Centro de Salud:";
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(10, 30);

            this.cboCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCentro.Location = new System.Drawing.Point(115, 27);
            this.cboCentro.Size = new System.Drawing.Size(220, 22);
            this.cboCentro.SelectedIndexChanged += new System.EventHandler(this.cboCentro_SelectedIndexChanged);

            this.lblEspacio.Text = "Espacio Médico:";
            this.lblEspacio.AutoSize = true;
            this.lblEspacio.Location = new System.Drawing.Point(355, 30);

            this.cboEspacio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEspacio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEspacio.Location = new System.Drawing.Point(460, 27);
            this.cboEspacio.Size = new System.Drawing.Size(220, 22);

            this.lblEquiposAsign.AutoSize = true;
            this.lblEquiposAsign.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEquiposAsign.ForeColor = System.Drawing.Color.FromArgb(0, 100, 160);
            this.lblEquiposAsign.Location = new System.Drawing.Point(700, 30);
            this.lblEquiposAsign.Text = "";

            this.grpFiltro.Controls.Add(this.lblCentro);
            this.grpFiltro.Controls.Add(this.cboCentro);
            this.grpFiltro.Controls.Add(this.lblEspacio);
            this.grpFiltro.Controls.Add(this.cboEspacio);
            this.grpFiltro.Controls.Add(this.lblEquiposAsign);

            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(12, 98);
            this.lblInfo.Text = "Equipos disponibles (sin asignar) — Ctrl+clic para selección múltiple:";

            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.Location = new System.Drawing.Point(12, 118);
            this.dgvEquipos.MultiSelect = true;
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(680, 330);

            this.grpAcciones.Text = "Acciones";
            this.grpAcciones.Location = new System.Drawing.Point(710, 118);
            this.grpAcciones.Size = new System.Drawing.Size(165, 180);

            this.btnAsignar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Location = new System.Drawing.Point(10, 30);
            this.btnAsignar.Size = new System.Drawing.Size(145, 36);
            this.btnAsignar.Text = "Asignar al Espacio";
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);

            this.btnHojaInventario.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.btnHojaInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHojaInventario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHojaInventario.ForeColor = System.Drawing.Color.White;
            this.btnHojaInventario.Location = new System.Drawing.Point(10, 80);
            this.btnHojaInventario.Size = new System.Drawing.Size(145, 36);
            this.btnHojaInventario.Text = "Hoja de Inventario";
            this.btnHojaInventario.Click += new System.EventHandler(this.btnHojaInventario_Click);

            this.btnRefrescar.BackColor = System.Drawing.Color.Gray;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Location = new System.Drawing.Point(10, 130);
            this.btnRefrescar.Size = new System.Drawing.Size(145, 30);
            this.btnRefrescar.Text = "Refrescar lista";
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);

            this.grpAcciones.Controls.Add(this.btnAsignar);
            this.grpAcciones.Controls.Add(this.btnHojaInventario);
            this.grpAcciones.Controls.Add(this.btnRefrescar);

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 465);
            this.Controls.Add(this.grpFiltro);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.dgvEquipos);
            this.Controls.Add(this.grpAcciones);
            this.Name = "FormAsignacionEnseres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asignación de Enseres a Espacios Médicos";
            this.Load += new System.EventHandler(this.FormAsignacionEnseres_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            this.grpAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.ComboBox cboCentro;
        private System.Windows.Forms.Label lblEspacio;
        private System.Windows.Forms.ComboBox cboEspacio;
        private System.Windows.Forms.Label lblEquiposAsign;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnHojaInventario;
        private System.Windows.Forms.Button btnRefrescar;
    }
}