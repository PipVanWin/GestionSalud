using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace GestionSalud.Presentacion
{
    public partial class FormHojaInventario : Form
    {
        private readonly DataTable _datos;

        public FormHojaInventario(DataTable datos)
        {
            InitializeComponent();
            _datos = datos;
        }

        private void FormHojaInventario_Load(object sender, EventArgs e)
        {
            dgvHoja.DataSource = _datos;

            if (_datos.Rows.Count > 0)
            {
                lblTitulo.Text =
                    $"HOJA DE INVENTARIO\n" +
                    $"Centro de Salud: {_datos.Rows[0]["NombreCentro"]}\n" +
                    $"Espacio: {_datos.Rows[0]["NombreEspacio"]}";
            }

            lblFecha.Text  = $"Fecha de generación: {DateTime.Now:dd/MM/yyyy HH:mm}";
            lblFirma.Text  = "Firma del Responsable del Centro: _______________________________";
        }

        // Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var doc = new PrintDocument();
                doc.PrintPage += Doc_PrintPage;

                var dialogo = new PrintDialog { Document = doc };
                if (dialogo.ShowDialog() == DialogResult.OK)
                    doc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al imprimir: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            var g        = e.Graphics;
            var fNormal  = new Font("Arial", 9);
            var fBold    = new Font("Arial", 10, FontStyle.Bold);
            var fTitulo  = new Font("Arial", 13, FontStyle.Bold);
            var negro    = Brushes.Black;
            int margen   = 50;
            int y        = 40;

            // Encabezado
            g.DrawString("DIRECCIÓN DE SALUD MUNICIPAL", fTitulo, negro, 170, y);
            y += 22;
            g.DrawString("HOJA DE INVENTARIO DE ESPACIO MÉDICO", fBold, negro, 160, y);
            y += 30;

            if (_datos.Rows.Count > 0)
            {
                g.DrawString($"Centro:  {_datos.Rows[0]["NombreCentro"]}", fNormal, negro, margen, y);
                y += 16;
                g.DrawString($"Espacio: {_datos.Rows[0]["NombreEspacio"]}", fNormal, negro, margen, y);
                y += 16;
                g.DrawString($"Fecha:   {DateTime.Now:dd/MM/yyyy HH:mm}", fNormal, negro, margen, y);
                y += 25;
            }

            // Encabezados de tabla
            g.DrawString("Cód. Municipal", fBold, negro, margen,  y);
            g.DrawString("Nro. Serie",     fBold, negro, 160,     y);
            g.DrawString("Marca",          fBold, negro, 270,     y);
            g.DrawString("Modelo",         fBold, negro, 360,     y);
            g.DrawString("Estado",         fBold, negro, 470,     y);
            y += 16;
            g.DrawLine(Pens.Black, margen, y, 560, y);
            y += 6;

            // Filas
            foreach (DataRow fila in _datos.Rows)
            {
                g.DrawString(fila["CodigoMunicipal"].ToString(), fNormal, negro, margen, y);
                g.DrawString(fila["NumeroSerie"].ToString(),     fNormal, negro, 160,    y);
                g.DrawString(fila["Marca"].ToString(),           fNormal, negro, 270,    y);
                g.DrawString(fila["Modelo"].ToString(),          fNormal, negro, 360,    y);
                g.DrawString(fila["EstadoActual"].ToString(),    fNormal, negro, 470,    y);
                y += 17;
            }

            // Total
            y += 8;
            g.DrawLine(Pens.Black, margen, y, 560, y);
            y += 8;
            g.DrawString($"Total de equipos: {_datos.Rows.Count}", fBold, negro, margen, y);

            // Sección de firma
            y += 60;
            g.DrawLine(Pens.Black, margen, y, 280, y);
            y += 8;
            g.DrawString("Firma del Responsable del Centro", fNormal, negro, margen, y);
            y += 40;
            g.DrawLine(Pens.Black, 340, y - 32, 560, y - 32);
            g.DrawString("Sello del Centro de Salud", fNormal, negro, 340, y - 24);
        }

        private void btnCerrar_Click(object sender, EventArgs e) => Close();
    }
}
