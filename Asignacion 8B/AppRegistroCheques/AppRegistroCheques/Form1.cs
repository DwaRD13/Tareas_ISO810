using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AppRegistroCheques
{
    public partial class Form1 : Form
    {
        private readonly Color primaryColor = Color.FromArgb(0, 122, 204);
        private readonly Color successColor = Color.FromArgb(40, 167, 69);
        private readonly Color darkHeaderColor = Color.FromArgb(45, 45, 48);
        private readonly Color backgroundColor = Color.FromArgb(240, 242, 245);
        private readonly Font mainFont = new Font("Segoe UI", 10f, FontStyle.Regular);
        private readonly Font headerFont = new Font("Segoe UI", 14f, FontStyle.Bold);

        private readonly string rutaArchivoDatos = Path.Combine(Application.StartupPath, "cheques_db.txt");

        public Form1()
        {
            InitializeComponent();
            this.Text = "Sistema de Registro de Cheques";
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dgvDatabase.Columns.Count == 0)
            {
                dgvDatabase.Columns.Add("ColCheque", "No. Cheque");
                dgvDatabase.Columns.Add("ColConcepto", "Concepto");
                dgvDatabase.Columns.Add("ColCedula", "Cédula");
                dgvDatabase.Columns.Add("ColFecha", "Fecha");
                dgvDatabase.Columns.Add("ColMontoNum", "Monto ($)");
                dgvDatabase.Columns.Add("ColMontoLetra", "Monto Letras");
                dgvDatabase.Columns.Add("ColFactura", "Factura");
            }

            CargarDatosGuardados();
            AplicarDisenoProfesionalAvanzado();
        }

        private void GuardarDatosEnArchivo()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(rutaArchivoDatos, false))
                {
                    foreach (DataGridViewRow fila in dgvDatabase.Rows)
                    {
                        if (!fila.IsNewRow)
                        {
                            string linea = $"{fila.Cells["ColCheque"].Value}|{fila.Cells["ColConcepto"].Value}|{fila.Cells["ColCedula"].Value}|{fila.Cells["ColFecha"].Value}|{fila.Cells["ColMontoNum"].Value}|{fila.Cells["ColMontoLetra"].Value}|{fila.Cells["ColFactura"].Value}";
                            sw.WriteLine(linea);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en el archivo físico: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosGuardados()
        {
            try
            {
                if (File.Exists(rutaArchivoDatos))
                {
                    string[] lineas = File.ReadAllLines(rutaArchivoDatos);

                    foreach (string linea in lineas)
                    {
                        string[] datos = linea.Split('|');

                        if (datos.Length == 7)
                        {
                            dgvDatabase.Rows.Add(datos[0], datos[1], datos[2], datos[3], datos[4], datos[5], datos[6]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos guardados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarDisenoProfesionalAvanzado()
        {
            this.BackColor = backgroundColor;
            this.Font = mainFont;
            this.ForeColor = Color.FromArgb(64, 64, 64);

            int maxBottom = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl != dgvDatabase)
                {
                    ctrl.Top += 70;
                    if (ctrl.Bottom > maxBottom)
                    {
                        maxBottom = ctrl.Bottom;
                    }
                }
            }

            btnGuardar.BringToFront();
            btnVerFactura.BringToFront();

            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = darkHeaderColor,
                Padding = new Padding(20, 0, 0, 0)
            };

            Label titleLabel = new Label
            {
                Text = "Registro de Cheques",
                Font = headerFont,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(20, 15)
            };
            headerPanel.Controls.Add(titleLabel);
            this.Controls.Add(headerPanel);

            EstilarBoton(btnGuardar, successColor);
            EstilarBoton(btnVerFactura, primaryColor);

            dgvDatabase.BackgroundColor = Color.White;
            dgvDatabase.BorderStyle = BorderStyle.None;
            dgvDatabase.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvDatabase.GridColor = Color.FromArgb(224, 224, 224);
            dgvDatabase.RowHeadersVisible = false;
            dgvDatabase.AllowUserToAddRows = false;
            dgvDatabase.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatabase.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvDatabase.DefaultCellStyle.BackColor = Color.White;
            dgvDatabase.DefaultCellStyle.ForeColor = Color.Black;
            dgvDatabase.DefaultCellStyle.SelectionBackColor = Color.FromArgb(232, 240, 254);
            dgvDatabase.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvDatabase.DefaultCellStyle.Padding = new Padding(8);
            dgvDatabase.RowTemplate.Height = 40;
            dgvDatabase.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dgvDatabase.EnableHeadersVisualStyles = false;
            dgvDatabase.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvDatabase.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvDatabase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDatabase.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            dgvDatabase.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDatabase.ColumnHeadersHeight = 45;

            dgvDatabase.Location = new Point(20, maxBottom + 20);
            int altoDgv = this.ClientSize.Height - dgvDatabase.Location.Y - 20;

            if (altoDgv < 150)
            {
                this.ClientSize = new Size(this.ClientSize.Width, dgvDatabase.Location.Y + 170);
                altoDgv = 150;
            }

            dgvDatabase.Size = new Size(this.ClientSize.Width - 40, altoDgv);
            dgvDatabase.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void EstilarBoton(Button btn, Color color)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.Size = new Size(120, 40);

            btn.MouseEnter += (s, e) => btn.BackColor = ControlPaint.Light(color, 0.1f);
            btn.MouseLeave += (s, e) => btn.BackColor = color;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cheque = txtCheque.Text.Trim();
            string concepto = txtConcepto.Text.Trim();
            string cedula = txtCedula.Text.Trim();
            string fecha = dtpFecha.Value.ToShortDateString();
            string montoNum = txtMontoNum.Text.Trim();
            string montoLetra = txtMontoLetra.Text.Trim();
            string factura = txtFactura.Text.Trim();

            if (string.IsNullOrWhiteSpace(cheque) || string.IsNullOrWhiteSpace(concepto) ||
                string.IsNullOrWhiteSpace(cedula) || string.IsNullOrWhiteSpace(montoNum) ||
                string.IsNullOrWhiteSpace(montoLetra) || string.IsNullOrWhiteSpace(factura))
            {
                MessageBox.Show("Todos los campos son obligatorios. Por favor, complete la información.", "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvDatabase.Rows.Add(cheque, concepto, cedula, fecha, montoNum, montoLetra, factura);
            GuardarDatosEnArchivo();

            MessageBox.Show("Cheque registrado y guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtCheque.Clear();
            txtConcepto.Clear();
            txtCedula.Clear();
            dtpFecha.Value = DateTime.Now;
            txtMontoNum.Clear();
            txtMontoLetra.Clear();
            txtFactura.Clear();
            txtCheque.Focus();
        }

        private void btnVerFactura_Click(object sender, EventArgs e)
        {
            string cedulaBuscada = txtCedula.Text.Trim();

            if (string.IsNullOrEmpty(cedulaBuscada))
            {
                MessageBox.Show("Ingrese la cédula del cliente a buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cheque = "", concepto = "", cedula = "", fecha = "", montoNum = "", montoLetra = "", factura = "";
            bool encontrado = false;

            foreach (DataGridViewRow fila in dgvDatabase.Rows)
            {
                if (fila.IsNewRow) continue;

                if (fila.Cells["ColCedula"].Value != null && fila.Cells["ColCedula"].Value.ToString() == cedulaBuscada)
                {
                    cheque = fila.Cells["ColCheque"].Value.ToString();
                    concepto = fila.Cells["ColConcepto"].Value.ToString();
                    cedula = fila.Cells["ColCedula"].Value.ToString();
                    fecha = fila.Cells["ColFecha"].Value.ToString();
                    montoNum = fila.Cells["ColMontoNum"].Value.ToString();
                    montoLetra = fila.Cells["ColMontoLetra"].Value.ToString();
                    factura = fila.Cells["ColFactura"].Value.ToString();

                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                MessageBox.Show("No se encontró ningún registro con esa cédula en la tabla.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string rutaAppB = @"C:\Users\Carlos\Desktop\Api_Course\AppConsultaFactura\AppConsultaFactura\bin\Debug\net8.0-windows\AppConsultaFactura.exe";

                string argumentos = $"\"{cheque}\" \"{concepto}\" \"{cedula}\" \"{fecha}\" \"{montoNum}\" \"{montoLetra}\" \"{factura}\"";
                Process.Start(rutaAppB, argumentos);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir aplicación B: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox3_TextChanged(object sender, EventArgs e) { }
        private void dgvDatabase_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}