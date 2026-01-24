using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;

namespace FerrAmeManager
{
    public partial class Form1 : Form
    {
        private int idEmpresaActual = -1;

        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Tss;Integrated Security=True";
        string selectedFilePath = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES ---
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
                MessageBox.Show("No hay empleados para exportar.", "Tabla Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int cantidadRegistros = 0;

                using (StreamWriter writer = new StreamWriter(selectedFilePath, false, new UTF8Encoding(false)))
                {
                    string rncRaw = textLabelRnc.Text.Trim();
                    string rncFijo = rncRaw.Length > 11 ? rncRaw.Substring(0, 11) : rncRaw.PadLeft(11, '0');

                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    string periodo = dateTimePicker1.Value.ToString("yyyyMM");

                    writer.WriteLine($"E{rncFijo}{fecha}{periodo}");

                    // --- 2. DETALLES ---
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string cedRaw = row.Cells["Cedula"].Value?.ToString() ?? "";
                            string cedulaFija = cedRaw.Length > 11 ? cedRaw.Substring(0, 11) : cedRaw.PadLeft(11, '0');

                            decimal salVal = 0;
                            decimal.TryParse(row.Cells["Salario"].Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out salVal);
                            string salStr = salVal.ToString("F2", CultureInfo.InvariantCulture);
                            string salarioFijo = salStr.Length > 10 ? salStr.Substring(0, 10) : salStr.PadLeft(10, '0');

                            string fechaIngFija = "01/01/2000";
                            if (row.Cells["FechaIngreso"].Value != null &&
                                DateTime.TryParse(row.Cells["FechaIngreso"].Value.ToString(), out DateTime ft))
                            {
                                fechaIngFija = ft.ToString("dd/MM/yyyy");
                            }

                            string tipoRaw = row.Cells["TipoEmpleado"].Value?.ToString() ?? "F";
                            string tipoFijo = tipoRaw.Length > 0 ? tipoRaw.Substring(0, 1) : "F";

                            string cargoRaw = row.Cells["Cargo"].Value?.ToString() ?? "";
                            cargoRaw = cargoRaw.Replace("\r", "").Replace("\n", "").Trim();
                            string cargoFijo = cargoRaw.Length > 40 ? cargoRaw.Substring(0, 40) : cargoRaw.PadRight(40, ' ');

                            writer.WriteLine($"D{cedulaFija}{salarioFijo}{fechaIngFija}{tipoFijo}{cargoFijo}");

                            cantidadRegistros++;
                        }
                    }

                    // El sumario, según tu layout, debe incluir encabezado y sumario en el conteo total:
                    int totalRegistrosIncluyendoEYS = cantidadRegistros + 2;
                    string cantidadFija = totalRegistrosIncluyendoEYS.ToString().PadLeft(10, '0');
                    writer.WriteLine($"S{cantidadFija}");
                }

                MessageBox.Show($"Archivo generado exitosamente en:\n{selectedFilePath}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar archivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CargarEmpleados(SqlConnection con)
        {
            string queryEmpleados = "SELECT Id, Cedula, Salario, FechaIngreso, TipoEmpleado, Cargo FROM Empleados WHERE EmpresaId = @EmpresaId";

            using (SqlDataAdapter adapter = new SqlDataAdapter(queryEmpleados, con))
            {
                adapter.SelectCommand.Parameters.Add("@EmpresaId", SqlDbType.Int).Value = idEmpresaActual;
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;

                if (dataGridView1.Columns["Id"] != null) dataGridView1.Columns["Id"].Visible = false;
                if (dataGridView1.Columns["EmpresaId"] != null) dataGridView1.Columns["EmpresaId"].Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validar empresa seleccionada
            if (idEmpresaActual == -1)
            {
                MessageBox.Show("Primero debe buscar una empresa válida por RNC.");
                return;
            }

            if (string.IsNullOrEmpty(cBTipoEmpleado.Text))
            {
                MessageBox.Show("Seleccione un tipo de empleado.");
                return;
            }

            // 2. Obtener valores de los Inputs 
            string cedula = txtBoxCedulaNuevoEmpleado.Text.Trim();
            string cargo = txtBoxCargoNuevoEmpleado.Text.Trim();

            char tipo = cBTipoEmpleado.Text.Trim()[0];
            decimal salario = 0;



            // 3. Validaciones
            if (!ValidaCedula(cedula))
            {
                MessageBox.Show("La cédula no es válida (Verifique dígitos y formato).");
                return;
            }

            if (!decimal.TryParse(txtBoxSalarioNuevoEmpleado.Text, out salario) || salario <= 0)
            {
                MessageBox.Show("El salario debe ser un número mayor a 0.");
                return;
            }

            // 4. Insertar en Base de Datos
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string queryInsert = @"INSERT INTO Empleados (EmpresaId, Cedula, Salario, FechaIngreso, TipoEmpleado, Cargo) 
                                   VALUES (@EmpresaId, @Cedula, @Salario, @FechaIngreso, @Tipo, @Cargo)";

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@EmpresaId", idEmpresaActual);
                        cmd.Parameters.AddWithValue("@Cedula", cedula);
                        cmd.Parameters.AddWithValue("@Salario", salario);
                        cmd.Parameters.AddWithValue("@FechaIngreso", dTPNuevoEmpleado.Value.Date);
                        cmd.Parameters.AddWithValue("@Tipo", tipo);
                        cmd.Parameters.AddWithValue("@Cargo", cargo);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Empleado registrado correctamente.");

                            // Limpiando campos
                            txtBoxCedulaNuevoEmpleado.Clear();
                            txtBoxCargoNuevoEmpleado.Clear();
                            txtBoxSalarioNuevoEmpleado.Clear();
                            dTPNuevoEmpleado.Value = DateTime.Now;
                            cBTipoEmpleado.SelectedIndex = -1;

                            CargarEmpleados(con);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar: " + ex.Message);
                }
            }
        }

        public static bool ValidaCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula)) return false;

            // Eliminar guiones si los tiene
            string cedulaLimpia = cedula.Replace("-", "").Trim();

            if (cedulaLimpia.Length != 11 || !cedulaLimpia.All(char.IsDigit)) return false;

            int suma = 0;
            int peso = 1;

            for (int i = 0; i < 10; i++)
            {
                int digito = int.Parse(cedulaLimpia[i].ToString());
                int calculo = digito * peso;

                if (calculo >= 10) calculo = (calculo / 10) + (calculo % 10);

                suma += calculo;
                peso = (peso == 1) ? 2 : 1;
            }

            int verificadorCalculado = (10 - (suma % 10)) % 10;
            int digitoVerificadorReal = int.Parse(cedulaLimpia[10].ToString());

            return verificadorCalculado == digitoVerificadorReal;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string rnc = textLabelRnc.Text.Trim();

            if (rnc.Length != 9 || !rnc.All(char.IsDigit))
            {
                MessageBox.Show("El RNC debe tener exactamente 9 dígitos numéricos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string queryEmpresa = "SELECT Id, Nombre FROM Empresas WHERE RNC = @RNC";

                    // Variable para controlar si encontramos o no la empresa
                    bool encontrada = false;

                    using (SqlCommand cmd = new SqlCommand(queryEmpresa, con))
                    {
                        cmd.Parameters.Add("@RNC", SqlDbType.VarChar, 9).Value = rnc;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                idEmpresaActual = reader.GetInt32(0);
                                string nombreEmpresa = reader.GetString(1);

                                label2.Text = $"Empresa: {nombreEmpresa}";
                                MessageBox.Show($"Empresa encontrada: {nombreEmpresa}. Puede registrar empleados.");
                                encontrada = true;
                            }
                        } // El Reader se cierra aquí automáticamente
                    }

                    if (encontrada)
                    {
                        CargarEmpleados(con);
                    }
                    else
                    {

                        DialogResult result = MessageBox.Show(
                            "El RNC no existe. ¿Desea registrar esta nueva empresa?",
                            "Empresa no encontrada",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string nombreNuevaEmpresa = ShowInputDialog("Ingrese el Nombre de la Empresa:", "Nueva Empresa");

                            if (!string.IsNullOrWhiteSpace(nombreNuevaEmpresa))
                            {
                                string queryInsert = "INSERT INTO Empresas (Nombre, RNC) VALUES (@Nombre, @RNC); SELECT CAST(scope_identity() AS int)";

                                using (SqlCommand cmdInsert = new SqlCommand(queryInsert, con))
                                {
                                    cmdInsert.Parameters.AddWithValue("@Nombre", nombreNuevaEmpresa);
                                    cmdInsert.Parameters.AddWithValue("@RNC", rnc);

                                    int newId = (int)cmdInsert.ExecuteScalar();

                                    idEmpresaActual = newId;
                                    label2.Text = $"Empresa: {nombreNuevaEmpresa}";

                                    dataGridView1.DataSource = null;

                                    MessageBox.Show("Empresa registrada exitosamente. Ahora puede agregar empleados.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Operación cancelada. Debe ingresar un nombre.");
                            }
                        }
                        else
                        {
                            idEmpresaActual = -1;
                            label2.Text = "Empresa no encontrada";
                            dataGridView1.DataSource = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

       
       
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarTabla_Click(object sender, EventArgs e)
        {
            GuardarCambiosDelGrid();
            MessageBox.Show("Datos de la tabla actualizados correctamente.");

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                CargarEmpleados(con);
            }
        }

        private void GuardarCambiosDelGrid()
        {
            if (dataGridView1.Rows.Count == 0) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        if (row.Cells["Id"].Value == null) continue;
                        int idEmpleado = Convert.ToInt32(row.Cells["Id"].Value);

                        string queryUpdate = @"UPDATE Empleados 
                                       SET Cedula = @Cedula, 
                                           Salario = @Salario, 
                                           TipoEmpleado = @Tipo, 
                                           Cargo = @Cargo,
                                           FechaIngreso = @FechaIngreso
                                       WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                        {
                            cmd.Parameters.AddWithValue("@Id", idEmpleado);

                            cmd.Parameters.AddWithValue("@Cedula", row.Cells["Cedula"].Value?.ToString() ?? "");

                            decimal salario = 0;

                            decimal.TryParse(row.Cells["Salario"].Value?.ToString(), out salario);
                            cmd.Parameters.AddWithValue("@Salario", salario);

                            DateTime fechaIng = DateTime.Now;
                            if (row.Cells["FechaIngreso"].Value != null)
                            {
                                DateTime.TryParse(row.Cells["FechaIngreso"].Value.ToString(), out fechaIng);
                            }
                            cmd.Parameters.AddWithValue("@FechaIngreso", fechaIng);

                            cmd.Parameters.AddWithValue("@Tipo", row.Cells["TipoEmpleado"].Value?.ToString() ?? "");
                            cmd.Parameters.AddWithValue("@Cargo", row.Cells["Cargo"].Value?.ToString() ?? "");

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar la tabla: " + ex.Message);
                }
            }
        }

        private static string ShowInputDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 400 };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 440 };
            Button confirmation = new Button() { Text = "Guardar", Left = 360, Width = 100, Top = 90, DialogResult = DialogResult.OK };

            // Para que al dar Enter se presione el botón
            prompt.AcceptButton = confirmation;

            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
    

}
