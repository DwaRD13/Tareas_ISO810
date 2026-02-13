using System.Xml.Serialization;

namespace MadereraMadeco_PushApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvMovimientos.Columns.Add("cuenta", "Cuenta Contable");
            dgvMovimientos.Columns.Add("monto", "Monto");

            // Columna desplegable para DB o CR
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "Tipo";
            combo.Name = "tipo";
            combo.Items.AddRange("DB", "CR");
            dgvMovimientos.Columns.Add(combo);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                var asiento = new AsientoActivoFijo
                {
                    IdTransaccion = txtIdTransaccion.Text,
                    NumeroAsiento = txtNumeroAsiento.Text,
                    DescripcionAsiento = txtDescripcion.Text,
                    FechaAsiento = dtpFecha.Value
                };

                foreach (DataGridViewRow row in dgvMovimientos.Rows)
                {
                    if (row.IsNewRow) continue;
                    asiento.Movimientos.Add(new Movimiento
                    {
                        CuentaContable = row.Cells["cuenta"].Value?.ToString(),
                        Monto = Convert.ToDecimal(row.Cells["monto"].Value),
                        Tipo = row.Cells["tipo"].Value?.ToString()
                    });
                }

                SaveFileDialog sfd = new SaveFileDialog { Filter = "XML Files|*.xml", FileName = "AsientoActivoFijo.xml" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AsientoActivoFijo));
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))
                    {
                        serializer.Serialize(sw, asiento);
                    }
                    MessageBox.Show("¡XML de Maderera Madeco generado!", "Éxito");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}