namespace GestionSalud.Presentacion
{
    partial class FormLogin
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
            this.lblTitulo    = new System.Windows.Forms.Label();
            this.lblCorreo    = new System.Windows.Forms.Label();
            this.lblClave     = new System.Windows.Forms.Label();
            this.txtCorreo    = new System.Windows.Forms.TextBox();
            this.txtClave     = new System.Windows.Forms.TextBox();
            this.chkMostrar   = new System.Windows.Forms.CheckBox();
            this.btnIngresar  = new System.Windows.Forms.Button();
            this.lblError     = new System.Windows.Forms.Label();
            this.panelTop     = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.panelTop.Controls.Add(this.lblTitulo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Size = new System.Drawing.Size(420, 70);

            // lblTitulo
            this.lblTitulo.Font      = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Text      = "Sistema de Gestión de Salud Municipal";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitulo.Dock      = System.Windows.Forms.DockStyle.Fill;

            // lblCorreo
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblCorreo.Location = new System.Drawing.Point(50, 100);
            this.lblCorreo.Text     = "Correo electrónico:";

            // txtCorreo
            this.txtCorreo.Font     = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCorreo.Location = new System.Drawing.Point(50, 122);
            this.txtCorreo.Size     = new System.Drawing.Size(320, 26);
            this.txtCorreo.TabIndex = 0;

            // lblClave
            this.lblClave.AutoSize = true;
            this.lblClave.Font     = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblClave.Location = new System.Drawing.Point(50, 162);
            this.lblClave.Text     = "Contraseña:";

            // txtClave
            this.txtClave.Font         = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClave.Location     = new System.Drawing.Point(50, 184);
            this.txtClave.Size         = new System.Drawing.Size(320, 26);
            this.txtClave.PasswordChar = '*';
            this.txtClave.TabIndex     = 1;

            // chkMostrar
            this.chkMostrar.AutoSize = true;
            this.chkMostrar.Font     = new System.Drawing.Font("Segoe UI", 9F);
            this.chkMostrar.Location = new System.Drawing.Point(50, 218);
            this.chkMostrar.Text     = "Mostrar contraseña";
            this.chkMostrar.TabIndex = 2;
            this.chkMostrar.CheckedChanged += new System.EventHandler(this.chkMostrar_CheckedChanged);

            // btnIngresar
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(0, 120, 180);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font      = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.Location  = new System.Drawing.Point(50, 248);
            this.btnIngresar.Size      = new System.Drawing.Size(320, 36);
            this.btnIngresar.Text      = "Ingresar";
            this.btnIngresar.TabIndex  = 3;
            this.btnIngresar.Click    += new System.EventHandler(this.btnIngresar_Click);

            // lblError
            this.lblError.AutoSize  = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Font      = new System.Drawing.Font("Segoe UI", 9F);
            this.lblError.Location  = new System.Drawing.Point(50, 294);
            this.lblError.Text      = "";
            this.lblError.Visible   = false;

            // FormLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor           = System.Drawing.Color.White;
            this.ClientSize          = new System.Drawing.Size(420, 330);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.lblCorreo);
            this.Controls.Add(this.txtCorreo);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.chkMostrar);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.lblError);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox     = false;
            this.MinimizeBox     = false;
            this.Name            = "FormLogin";
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Iniciar Sesión — Gestión de Salud";
            this.panelTop.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel     panelTop;
        private System.Windows.Forms.Label     lblTitulo;
        private System.Windows.Forms.Label     lblCorreo;
        private System.Windows.Forms.Label     lblClave;
        private System.Windows.Forms.TextBox   txtCorreo;
        private System.Windows.Forms.TextBox   txtClave;
        private System.Windows.Forms.CheckBox  chkMostrar;
        private System.Windows.Forms.Button    btnIngresar;
        private System.Windows.Forms.Label     lblError;
    }
}
