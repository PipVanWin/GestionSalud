namespace GestionSalud.Presentacion
{
    partial class FormHojaInventario
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
            this.lblTitulo   = new System.Windows.Forms.Label();
            this.lblFecha    = new System.Windows.Forms.Label();
            this.dgvHoja     = new System.Windows.Forms.DataGridView();
            this.lblFirma    = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrar   = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoja)).BeginInit();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(0, 80, 140);
            this.lblTitulo.Location  = new System.Drawing.Point(12, 12);
            this.lblTitulo.Size      = new System.Drawing.Size(760, 60);
            this.lblTitulo.Text      = "HOJA DE INVENTARIO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblFecha
            this.lblFecha.AutoSize  = true;
            this.lblFecha.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblFecha.ForeColor = System.Drawing.Color.Gray;
            this.lblFecha.Location  = new System.Drawing.Point(12, 78);
            this.lblFecha.Text      = "Fecha de generación: ...";

            // dgvHoja
            this.dgvHoja.AllowUserToAddRows    = false;
            this.dgvHoja.AllowUserToDeleteRows = false;
            this.dgvHoja.ReadOnly              = true;
            this.dgvHoja.AutoSizeColumnsMode   = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoja.Location              = new System.Drawing.Point(12, 100);
            this.dgvHoja.Size                  = new System.Drawing.Size(760, 310);
            this.dgvHoja.BackgroundColor        = System.Drawing.Color.White;

            // lblFirma
            this.lblFirma.AutoSize  = true;
            this.lblFirma.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFirma.Location  = new System.Drawing.Point(12, 422);
            this.lblFirma.Text      = "Firma del Responsable del Centro: _______________________________";

            // btnImprimir
            this.btnImprimir.Text      = "Imprimir";
            this.btnImprimir.Location  = new System.Drawing.Point(600, 418);
            this.btnImprimir.Size      = new System.Drawing.Size(90, 30);
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font      = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImprimir.Click    += new System.EventHandler(this.btnImprimir_Click);

            // btnCerrar
            this.btnCerrar.Text      = "Cerrar";
            this.btnCerrar.Location  = new System.Drawing.Point(698, 418);
            this.btnCerrar.Size      = new System.Drawing.Size(74, 30);
            this.btnCerrar.BackColor = System.Drawing.Color.Gray;
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Click    += new System.EventHandler(this.btnCerrar_Click);

            // FormHojaInventario
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(786, 460);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dgvHoja);
            this.Controls.Add(this.lblFirma);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrar);
            this.Name          = "FormHojaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Hoja de Inventario de Espacio Médico";
            this.Load         += new System.EventHandler(this.FormHojaInventario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label        lblTitulo;
        private System.Windows.Forms.Label        lblFecha;
        private System.Windows.Forms.DataGridView dgvHoja;
        private System.Windows.Forms.Label        lblFirma;
        private System.Windows.Forms.Button       btnImprimir;
        private System.Windows.Forms.Button       btnCerrar;
    }
}
