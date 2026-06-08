using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
    public static class TextBoxHelper
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        public static void SetPlaceholder(TextBox textBox, string placeholderText)
        {
            SendMessage(textBox.Handle, EM_SETCUEBANNER, 0, placeholderText);
        }
    }

    public partial class FormReportes : Form
    {
        public enum TipoReporte
        {
            EspaciosPorCentro,
            IncidenciasPorFechas,
            Top3Consultorios,
            EquiposPorEspacio,
            BuscarEquipo
        }

        private readonly ReporteService _reportes = new ReporteService();
        private readonly TipoReporte _tipo;

        public FormReportes(TipoReporte tipo)
        {
            InitializeComponent();
            _tipo = tipo;
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            ConfigurarVista();
        }

        private void ConfigurarVista()
        {
            lblDesde.Visible = false;
            dtpDesde.Visible = false;
            lblHasta.Visible = false;
            dtpHasta.Visible = false;
            lblBusqueda.Visible = false;
            txtBusqueda.Visible = false;
            cmbEspacios.Visible = false;

            switch (_tipo)
            {
                case TipoReporte.EspaciosPorCentro:
                    lblTituloReporte.Text = "Reporte — Espacios por Centro de Salud";
                    break;

                case TipoReporte.IncidenciasPorFechas:
                    lblTituloReporte.Text = "Reporte — Incidencias y Mantenimientos por Fechas";
                    lblDesde.Visible = true;
                    dtpDesde.Visible = true;
                    lblHasta.Visible = true;
                    dtpHasta.Visible = true;
                    dtpDesde.Value = DateTime.Now.AddMonths(-1);
                    dtpHasta.Value = DateTime.Now;
                    break;

                case TipoReporte.Top3Consultorios:
                    lblTituloReporte.Text = "Reporte — Top 3 Consultorios Mejor Equipados por Centro";
                    break;

                case TipoReporte.EquiposPorEspacio:
                    lblTituloReporte.Text = "Reporte — Equipos Detallados de un Espacio";
                    lblBusqueda.Text = "Seleccione Espacio:";
                    lblBusqueda.Visible = true;
                    cmbEspacios.Visible = true;
                    CargarComboEspacios();
                    break;

                case TipoReporte.BuscarEquipo:
                    lblTituloReporte.Text = "Reporte — Buscar Equipo por Código o Serie";
                    lblBusqueda.Text = "Código / N° Serie:";
                    lblBusqueda.Visible = true;
                    txtBusqueda.Visible = true;
                    txtBusqueda.Clear();
                    TextBoxHelper.SetPlaceholder(txtBusqueda, "Ej: MUN-001 o SN789123");
                    break;
            }
        }

        private void CargarComboEspacios()
        {
            try
            {
                cmbEspacios.DataSource = null;
                System.Data.DataTable dt = _reportes.ObtenerEspaciosCombo();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbEspacios.ValueMember = "Id";
                    cmbEspacios.DisplayMember = "Nombre";
                    cmbEspacios.DataSource = dt;
                    cmbEspacios.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el catálogo de espacios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_tipo)
                {
                    case TipoReporte.EspaciosPorCentro:
                        dgvReporte.DataSource = _reportes.EspaciosPorCentro();
                        break;

                    case TipoReporte.IncidenciasPorFechas:
                        if (dtpDesde.Value.Date > dtpHasta.Value.Date)
                        {
                            MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dgvReporte.DataSource = _reportes.IncidenciasPorFechas(
                            dtpDesde.Value, dtpHasta.Value);
                        break;

                    case TipoReporte.Top3Consultorios:
                        dgvReporte.DataSource = _reportes.Top3ConsultoriosMejorEquipados();
                        break;

                    case TipoReporte.EquiposPorEspacio:

                        if (cmbEspacios.SelectedValue == null)
                        {
                            MessageBox.Show("Por favor seleccione un espacio de la lista.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        int idEspacio = Convert.ToInt32(cmbEspacios.SelectedValue);
                        dgvReporte.DataSource = _reportes.EquiposPorEspacio(idEspacio);
                        break;

                    case TipoReporte.BuscarEquipo:
                        if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
                        {
                            MessageBox.Show("Ingrese un código municipal o número de serie para buscar.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dgvReporte.DataSource = _reportes.BuscarEquipo(txtBusqueda.Text.Trim());
                        break;
                }

                int filas = dgvReporte.Rows.Count;
                MessageBox.Show(
                    filas > 0
                        ? $"Se encontraron {filas} registro(s)."
                        : "El reporte no devolvió resultados para los filtros aplicados.",
                    "Reporte generado",
                    MessageBoxButtons.OK,
                    filas > 0 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar reporte: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvReporte.Rows.Count == 0)
            {
                MessageBox.Show("Primero genere el reporte.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dialogo = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                FileName = $"Reporte_{_tipo}_{DateTime.Now:yyyyMMdd}"
            })
            {
                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var writer = new System.IO.StreamWriter(
                        dialogo.FileName, false, System.Text.Encoding.UTF8))
                    {
                        var encabezados = new System.Collections.Generic.List<string>();
                        foreach (DataGridViewColumn col in dgvReporte.Columns)
                            encabezados.Add($"\"{col.HeaderText}\"");
                        writer.WriteLine(string.Join(",", encabezados));

                        foreach (DataGridViewRow fila in dgvReporte.Rows)
                        {
                            var celdas = new System.Collections.Generic.List<string>();
                            foreach (DataGridViewCell celda in fila.Cells)
                                celdas.Add($"\"{celda.Value}\"");
                            writer.WriteLine(string.Join(",", celdas));
                        }
                    }
                    MessageBox.Show("Archivo exportado exitosamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}