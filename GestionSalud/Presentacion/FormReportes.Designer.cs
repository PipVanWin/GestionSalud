namespace GestionSalud.Presentacion
{
    partial class FormReportes
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
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblBusqueda = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.cmbEspacios = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();

            // lblTituloReporte
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTituloReporte.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblTituloReporte.Location = new System.Drawing.Point(12, 10);
            this.lblTituloReporte.Size = new System.Drawing.Size(860, 32);
            this.lblTituloReporte.Text = "Reporte";
            this.lblTituloReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlFiltros
            this.pnlFiltros.Location = new System.Drawing.Point(12, 48);
            this.pnlFiltros.Size = new System.Drawing.Size(860, 45);
            this.pnlFiltros.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblDesde,    this.dtpDesde,
                this.lblHasta,    this.dtpHasta,
                this.lblBusqueda, this.txtBusqueda,
                this.cmbEspacios,
                this.btnGenerar,  this.btnExportar });

            // lblDesde
            this.lblDesde.Text = "Desde:";
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(0, 13);
            this.lblDesde.Visible = false;

            // dtpDesde
            this.dtpDesde.Location = new System.Drawing.Point(55, 8);
            this.dtpDesde.Size = new System.Drawing.Size(150, 22);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Visible = false;

            // lblHasta
            this.lblHasta.Text = "Hasta:";
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(215, 13);
            this.lblHasta.Visible = false;

            // dtpHasta
            this.dtpHasta.Location = new System.Drawing.Point(265, 8);
            this.dtpHasta.Size = new System.Drawing.Size(150, 22);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Visible = false;

            // lblBusqueda
            this.lblBusqueda.Text = "Valor:";
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Location = new System.Drawing.Point(0, 13);
            this.lblBusqueda.Visible = false;

            // txtBusqueda
            this.txtBusqueda.Location = new System.Drawing.Point(120, 8);
            this.txtBusqueda.Size = new System.Drawing.Size(300, 22);
            this.txtBusqueda.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBusqueda.Visible = false;

            // cmbEspacios
            this.cmbEspacios.Location = new System.Drawing.Point(120, 8);
            this.cmbEspacios.Size = new System.Drawing.Size(300, 22);
            this.cmbEspacios.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEspacios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspacios.Visible = false;

            // btnGenerar
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.Location = new System.Drawing.Point(440, 6);
            this.btnGenerar.Size = new System.Drawing.Size(140, 32);
            this.btnGenerar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnGenerar.ForeColor = System.Drawing.Color.White;
            this.btnGenerar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);

            // btnExportar
            this.btnExportar.Text = "Exportar CSV";
            this.btnExportar.Location = new System.Drawing.Point(592, 6);
            this.btnExportar.Size = new System.Drawing.Size(120, 32);
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);

            // dgvReporte
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.Location = new System.Drawing.Point(12, 100);
            this.dgvReporte.Size = new System.Drawing.Size(860, 360);
            this.dgvReporte.BackgroundColor = System.Drawing.Color.White;

            // FormReportes
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(886, 476);
            this.Controls.Add(this.lblTituloReporte);
            this.Controls.Add(this.pnlFiltros);
            this.Controls.Add(this.dgvReporte);
            this.Name = "FormReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes — Director Municipal";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox cmbEspacios;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.DataGridView dgvReporte;
    }
}