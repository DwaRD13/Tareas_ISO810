using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;

namespace FerrAmeManager
{
    public partial class Form1 : Form
    {
        string selectedFilePath = "";
        string query = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Por favor, seleccione una ruta para guardar el archivo.");
                return;
            }

            if (string.IsNullOrEmpty(textLabelRnc.Text))
            {
                MessageBox.Show("Por favor, ingrese un RNC válido.");
                return;
            }

            if (dataGridView1.DataSource == null || dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay empleados en la tabla para generar el archivo. Por favor, realiza la carga primero.", "Tabla Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {

                int cantidadRegistros = 0;

                // Recorremos la grilla para sumar los salarios
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Salario"].Value != null)
                    {
                        decimal salarioFila;
                        if (decimal.TryParse(row.Cells["Salario"].Value.ToString(), out salarioFila))
                        {
                            cantidadRegistros++;
                        }
                    }
                }

                // Generar Archivo

                using (StreamWriter writer = new StreamWriter(selectedFilePath))
                {
                    string rncEmpresa = textLabelRnc.Text;
                    string fecha = DateTime.Now.ToString("ddMMyyyy");
                    string hora = DateTime.Now.ToString("HHmmss");
                    string fechaFormateada = dateTimePicker1.Value.ToString("yyyyMM");



                    string lineaEncabezado = $"E {rncEmpresa} {fecha} {fechaFormateada}";

                    writer.WriteLine(lineaEncabezado);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            // Obtenemos los valores de las celdas de manera segura
                            string cedula = row.Cells["Cedula"].Value?.ToString() ?? "";
                            string salario = row.Cells["Salario"].Value?.ToString() ?? "0.00";
                            string tipo = row.Cells["TipoEmpleado"].Value?.ToString() ?? "";
                            string cargo = row.Cells["Cargo"].Value?.ToString() ?? "";

                            string fechaIngreso = "";
                            var valorFecha = row.Cells["FechaIngreso"].Value;
                            if (DateTime.TryParse(valorFecha?.ToString(), out DateTime fechaDt))
                            {
                                fechaIngreso = fechaDt.ToString("ddMMyyyy");
                            }

                            string lineaDetalle = $"D {cedula} {salario} {fechaIngreso} {tipo} {cargo}";

                            writer.WriteLine(lineaDetalle);
                        }
                    }

                    String lineaSumario = $"S {cantidadRegistros}";  
                    writer.WriteLine(lineaSumario);
                }

                MessageBox.Show($"Archivo generado exitosamente en:\n{selectedFilePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al escribir el archivo: {ex.Message}", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Seleccione la ruta para guardar el archivo";
            saveFileDialog.FileName = ".txt";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                textBox2.Text = "La ruta seleccionada es: " + filePath;
                selectedFilePath = filePath;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string rnc = textLabelRnc.Text.Trim();

            // Validación del RNC
            if (rnc.Length != 9 || !rnc.All(char.IsDigit))
            {
                MessageBox.Show("El RNC debe tener exactamente 9 dígitos numéricos.");
                return; // Cortamos ejecución si no es válido
            }

            int empresaId = -1;
            string nombreEmpresa = "";

            string queryEmpresa = "SELECT Nombre, Id FROM Empresas WHERE RNC = @RNC";
            string queryEmpleados = "SELECT Cedula, Salario, FechaIngreso, TipoEmpleado, Cargo FROM Empleados WHERE EmpresaId = @EmpresaId";

            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Tss;Integrated Security=True"))
            {
                con.Open();

                // Buscar la Empresa
                using (SqlCommand cmd = new SqlCommand(queryEmpresa, con))
                {
                    cmd.Parameters.Add("@RNC", SqlDbType.VarChar, 9).Value = rnc;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombreEmpresa = reader.GetString(0);
                            empresaId = reader.GetInt32(1);

                            label2.Text = $"Colaboradores registrados de {nombreEmpresa}:";
                        }
                    }
                }

                if (empresaId != -1)
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(queryEmpleados, con))
                    {
                        adapter.SelectCommand.Parameters.Add("@EmpresaId", SqlDbType.Int).Value = empresaId;

                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        dataGridView1.DataSource = dt;

                        if (dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Esta empresa existe, pero aún no tiene empleados registrados.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró ninguna empresa con ese RNC.");
                    dataGridView1.DataSource = null;
                }
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}
