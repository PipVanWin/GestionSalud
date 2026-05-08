using System;
using System.Windows.Forms;
using GestionSalud.Servicios;

namespace GestionSalud.Presentacion
{
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
        private readonly TipoReporte    _tipo;

        public FormReportes(TipoReporte tipo)
        {
            InitializeComponent();
            _tipo = tipo;
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            ConfigurarVista();
        }

        // Configurar título y filtros visibles según tipo
        private void ConfigurarVista()
        {
            // Ocultar todos los filtros por defecto
            dtpDesde.Visible         = false;
            dtpHasta.Visible         = false;
            txtCodigoEspacio.Visible = false;

            switch (_tipo)
            {
                case TipoReporte.EspaciosPorCentro:
                    lblTituloReporte.Text = "Reporte — Espacios por Centro de Salud";
                    break;

                case TipoReporte.IncidenciasPorFechas:
                    lblTituloReporte.Text = "Reporte — Incidencias y Mantenimientos por Fechas";
                    dtpDesde.Visible = true;
                    dtpHasta.Visible = true;
                    dtpDesde.Value   = DateTime.Now.AddMonths(-1);
                    dtpHasta.Value   = DateTime.Now;
                    break;

                case TipoReporte.Top3Consultorios:
                    lblTituloReporte.Text = "Reporte — Top 3 Consultorios Mejor Equipados por Centro";
                    break;

                case TipoReporte.EquiposPorEspacio:
                    lblTituloReporte.Text = "Reporte — Equipos Detallados de un Espacio";
                    txtCodigoEspacio.Visible = true;
                    break;

                case TipoReporte.BuscarEquipo:
                    lblTituloReporte.Text = "Reporte — Buscar Equipo por Código o Serie";
                    txtCodigoEspacio.Visible = true;
                    break;
            }
        }

        // Generar el reporte
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
                        dgvReporte.DataSource = _reportes.IncidenciasPorFechas(
                            dtpDesde.Value, dtpHasta.Value);
                        break;

                    case TipoReporte.Top3Consultorios:
                        dgvReporte.DataSource = _reportes.Top3ConsultoriosMejorEquipados();
                        break;

                    case TipoReporte.EquiposPorEspacio:
                        if (!int.TryParse(txtCodigoEspacio.Text.Trim(), out int idEspacio))
                        {
                            MessageBox.Show("Ingrese un ID de espacio válido (número).",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dgvReporte.DataSource = _reportes.EquiposPorEspacio(idEspacio);
                        break;

                    case TipoReporte.BuscarEquipo:
                        if (string.IsNullOrWhiteSpace(txtCodigoEspacio.Text))
                        {
                            MessageBox.Show("Ingrese un código o número de serie para buscar.",
                                "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        dgvReporte.DataSource = _reportes.BuscarEquipo(txtCodigoEspacio.Text);
                        break;
                }

                // Mostrar conteo de resultados
                int filas = dgvReporte.Rows.Count;
                MessageBox.Show(
                    filas > 0 ? $"Se encontraron {filas} registro(s)."
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

        // Exportar a CSV
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
                Filter   = "Archivo CSV (*.csv)|*.csv",
                FileName = $"Reporte_{_tipo}_{DateTime.Now:yyyyMMdd}"
            })
            {
                if (dialogo.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (var writer = new System.IO.StreamWriter(dialogo.FileName,
                        false, System.Text.Encoding.UTF8))
                    {
                        // Encabezados
                        var encabezados = new System.Collections.Generic.List<string>();
                        foreach (DataGridViewColumn col in dgvReporte.Columns)
                            encabezados.Add($"\"{col.HeaderText}\"");
                        writer.WriteLine(string.Join(",", encabezados));

                        // Filas
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
