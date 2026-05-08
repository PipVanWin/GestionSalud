namespace GestionSalud.Presentacion
{
    partial class FormMantenimientoEquipo
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
            this.dgvEquipos = new System.Windows.Forms.DataGridView();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblSerie = new System.Windows.Forms.Label();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpBuscar = new System.Windows.Forms.GroupBox();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.grpBuscar.SuspendLayout();
            this.SuspendLayout();

            this.grpBuscar.Text = "Búsqueda rápida";
            this.grpBuscar.Location = new System.Drawing.Point(12, 10);
            this.grpBuscar.Size = new System.Drawing.Size(500, 48);

            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBuscar.Location = new System.Drawing.Point(10, 15);
            this.txtBuscar.Size = new System.Drawing.Size(360, 22);

            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(380, 13);
            this.btnBuscar.Size = new System.Drawing.Size(100, 26);
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);

            this.grpBuscar.Controls.Add(this.txtBuscar);
            this.grpBuscar.Controls.Add(this.btnBuscar);

            this.dgvEquipos.AllowUserToAddRows = false;
            this.dgvEquipos.AllowUserToDeleteRows = false;
            this.dgvEquipos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEquipos.BackgroundColor = System.Drawing.Color.White;
            this.dgvEquipos.Location = new System.Drawing.Point(12, 65);
            this.dgvEquipos.MultiSelect = false;
            this.dgvEquipos.ReadOnly = true;
            this.dgvEquipos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipos.Size = new System.Drawing.Size(500, 375);
            this.dgvEquipos.SelectionChanged += new System.EventHandler(this.dgvEquipos_SelectionChanged);
            this.dgvEquipos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipos_CellClick); // FIX

            this.grpDatos.Location = new System.Drawing.Point(525, 10);
            this.grpDatos.Size = new System.Drawing.Size(350, 430);
            this.grpDatos.Text = "Datos del Equipo";

            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(10, 22);
            this.lblCodigo.Text = "Código Municipal *";

            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCodigo.Location = new System.Drawing.Point(10, 42);
            this.txtCodigo.Size = new System.Drawing.Size(320, 22);

            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(10, 77);
            this.lblSerie.Text = "Número de Serie *";

            this.txtSerie.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSerie.Location = new System.Drawing.Point(10, 97);
            this.txtSerie.Size = new System.Drawing.Size(320, 22);

            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(10, 132);
            this.lblMarca.Text = "Marca";

            this.txtMarca.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMarca.Location = new System.Drawing.Point(10, 152);
            this.txtMarca.Size = new System.Drawing.Size(320, 22);

            this.lblModelo.AutoSize = true;
            this.lblModelo.Location = new System.Drawing.Point(10, 187);
            this.lblModelo.Text = "Modelo";

            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtModelo.Location = new System.Drawing.Point(10, 207);
            this.txtModelo.Size = new System.Drawing.Size(320, 22);

            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(10, 242);
            this.lblDescripcion.Text = "Descripción Técnica";

            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescripcion.Location = new System.Drawing.Point(10, 262);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Size = new System.Drawing.Size(320, 50);

            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(10, 325);
            this.lblEstado.Text = "Estado";

            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboEstado.Location = new System.Drawing.Point(10, 345);
            this.cboEstado.Size = new System.Drawing.Size(320, 22);

            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(10, 390);
            this.btnGuardar.Size = new System.Drawing.Size(95, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(180, 40, 40);
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(115, 390);
            this.btnEliminar.Size = new System.Drawing.Size(95, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.BackColor = System.Drawing.Color.Gray;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(220, 390);
            this.btnLimpiar.Size = new System.Drawing.Size(95, 30);
            this.btnLimpiar.Text = "Nuevo";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.grpDatos.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblCodigo,      this.txtCodigo,
                this.lblSerie,       this.txtSerie,
                this.lblMarca,       this.txtMarca,
                this.lblModelo,      this.txtModelo,
                this.lblDescripcion, this.txtDescripcion,
                this.lblEstado,      this.cboEstado,
                this.btnGuardar,     this.btnEliminar, this.btnLimpiar });

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(890, 455);
            this.Controls.Add(this.grpBuscar);
            this.Controls.Add(this.dgvEquipos);
            this.Controls.Add(this.grpDatos);
            this.Name = "FormMantenimientoEquipo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Equipos — Inventario";
            this.Load += new System.EventHandler(this.FormMantenimientoEquipo_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipos)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEquipos;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.GroupBox grpBuscar;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.TextBox txtSerie;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
    }
}