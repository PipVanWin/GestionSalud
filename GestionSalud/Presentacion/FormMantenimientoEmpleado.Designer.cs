namespace GestionSalud.Presentacion
{
    partial class FormMantenimientoEmpleado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cboRol = new System.Windows.Forms.ComboBox();
            this.lblCentro = new System.Windows.Forms.Label();
            this.cboCentro = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.grpDatos.SuspendLayout();
            this.SuspendLayout();

            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.MultiSelect = false;
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 12);
            this.dgvEmpleados.Size = new System.Drawing.Size(490, 460);
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvEmpleados_SelectionChanged);

            this.grpDatos.Text = "Datos del Empleado / Usuario";
            this.grpDatos.Location = new System.Drawing.Point(516, 12);
            this.grpDatos.Size = new System.Drawing.Size(348, 420);

            this.lblNombre.Text = "Nombre *";
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(10, 22);
            this.txtNombre.Location = new System.Drawing.Point(10, 40);
            this.txtNombre.Size = new System.Drawing.Size(318, 23);
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblApellido.Text = "Apellido *";
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(10, 78);
            this.txtApellido.Location = new System.Drawing.Point(10, 96);
            this.txtApellido.Size = new System.Drawing.Size(318, 23);
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblCorreo.Text = "Correo electronico *";
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Location = new System.Drawing.Point(10, 134);
            this.txtCorreo.Location = new System.Drawing.Point(10, 152);
            this.txtCorreo.Size = new System.Drawing.Size(318, 23);
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblClave.Text = "Contrasena  (vacio = no cambiar en edicion)";
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(10, 190);
            this.txtClave.Location = new System.Drawing.Point(10, 208);
            this.txtClave.Size = new System.Drawing.Size(318, 23);
            this.txtClave.PasswordChar = '*';
            this.txtClave.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblRol.Text = "Rol del sistema";
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(10, 246);
            this.cboRol.Location = new System.Drawing.Point(10, 264);
            this.cboRol.Size = new System.Drawing.Size(318, 23);
            this.cboRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRol.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.lblCentro.Text = "Centro de Salud";
            this.lblCentro.AutoSize = true;
            this.lblCentro.Location = new System.Drawing.Point(10, 302);
            this.cboCentro.Location = new System.Drawing.Point(10, 320);
            this.cboCentro.Size = new System.Drawing.Size(318, 23);
            this.cboCentro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCentro.Font = new System.Drawing.Font("Segoe UI", 9.5F);

            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Location = new System.Drawing.Point(10, 362);
            this.btnGuardar.Size = new System.Drawing.Size(92, 34);
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(34, 139, 34);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Location = new System.Drawing.Point(112, 362);
            this.btnEliminar.Size = new System.Drawing.Size(92, 34);
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(180, 40, 40);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);

            this.btnLimpiar.Text = "Nuevo";
            this.btnLimpiar.Location = new System.Drawing.Point(214, 362);
            this.btnLimpiar.Size = new System.Drawing.Size(92, 34);
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(90, 90, 90);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);

            this.grpDatos.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblNombre,   this.txtNombre,
                this.lblApellido, this.txtApellido,
                this.lblCorreo,   this.txtCorreo,
                this.lblClave,    this.txtClave,
                this.lblRol,      this.cboRol,
                this.lblCentro,   this.cboCentro,
                this.btnGuardar,  this.btnEliminar, this.btnLimpiar });

            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(876, 484);
            this.Controls.Add(this.dgvEmpleados);
            this.Controls.Add(this.grpDatos);
            this.MinimumSize = new System.Drawing.Size(892, 523);
            this.Name = "FormMantenimientoEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mantenimiento de Empleados - Usuarios del Sistema";
            this.Load += new System.EventHandler(this.FormMantenimientoEmpleado_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cboRol;
        private System.Windows.Forms.Label lblCentro;
        private System.Windows.Forms.ComboBox cboCentro;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}