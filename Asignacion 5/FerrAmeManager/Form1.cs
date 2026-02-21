using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerrAmeManager
{
    public partial class Form1 : Form
    {

        private int idEmpresaActual = 1;

        private static readonly HttpClient _httpClient = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5000/")
        };

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarEmpleadosAsync();
        }

        private async void loadEmployees_Click(object sender, EventArgs e)
        {
            string rnc = textLabelRnc.Text.Trim();

            if (rnc.Length != 9 || !rnc.All(char.IsDigit))
            {
                MessageBox.Show("El RNC debe tener exactamente 9 dígitos numéricos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var empresas = await _httpClient.GetFromJsonAsync<List<EmpresaDto>>("api/empresas");
                var empresa = empresas?.FirstOrDefault(emp => emp.Rnc == rnc);

                if (empresa != null)
                {
                    idEmpresaActual = empresa.Id;
                    label2.Text = $"Colaboradores de: {empresa.Nombre}";
                    await CargarEmpleadosAsync();
                }
                else
                {
                    MessageBox.Show("La empresa con ese RNC no está registrada en el sistema.", "No encontrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    idEmpresaActual = -1;
                    label2.Text = "Empresa no encontrada";
                    dataGridView1.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al contactar con la API: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CARGAR EMPLEADOS ---
        private async Task CargarEmpleadosAsync()
        {
            if (idEmpresaActual == -1) return;

            try
            {
                var empleados = await _httpClient.GetFromJsonAsync<List<EmpleadoDto>>($"api/empleados?empresaId={idEmpresaActual}");
                dataGridView1.DataSource = new BindingList<EmpleadoDto>(empleados ?? new List<EmpleadoDto>());

                if (dataGridView1.Columns["Id"] != null) dataGridView1.Columns["Id"].Visible = false;
                if (dataGridView1.Columns["EmpresaId"] != null) dataGridView1.Columns["EmpresaId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        // --- REGISTRAR EMPLEADO ---
        private async void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            if (idEmpresaActual == -1)
            {
                MessageBox.Show("Debe buscar una empresa válida primero.");
                return;
            }

            if (string.IsNullOrEmpty(cBTipoEmpleado.Text))
            {
                MessageBox.Show("Seleccione un tipo de empleado.");
                return;
            }

            string cedula = txtBoxCedulaNuevoEmpleado.Text.Trim();
            string cargo = txtBoxCargoNuevoEmpleado.Text.Trim();
            decimal salario = 0;

            if (!ValidaCedula(cedula))
            {
                MessageBox.Show("La cédula no es válida.");
                return;
            }

            if (!decimal.TryParse(txtBoxSalarioNuevoEmpleado.Text, out salario) || salario <= 0)
            {
                MessageBox.Show("El salario debe ser un número mayor a 0.");
                return;
            }

            // DTO para la API en .NET
            var nuevoEmpleado = new CrearEmpleadoDto
            {
                Cedula = cedula,
                Salario = salario,
                FechaIngreso = dTPNuevoEmpleado.Value.ToString("ddMMyyyy"), // Formato que pide la API
                TipoEmpleado = cBTipoEmpleado.Text.Trim().Substring(0, 1),
                Cargo = cargo,
                EmpresaId = idEmpresaActual
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/empleados", nuevoEmpleado);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Empleado registrado correctamente.");

                    // Limpiar campos
                    txtBoxCedulaNuevoEmpleado.Clear();
                    txtBoxCargoNuevoEmpleado.Clear();
                    txtBoxSalarioNuevoEmpleado.Clear();
                    dTPNuevoEmpleado.Value = DateTime.Now;
                    cBTipoEmpleado.SelectedIndex = -1;

                    await CargarEmpleadosAsync(); // Recargar la tabla
                }
                else
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error de la API: {errorMsg}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectando con la API: " + ex.Message);
            }
        }

        public static bool ValidaCedula(string cedula)
        {
            if (string.IsNullOrEmpty(cedula)) return false;
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

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }

    public class EmpresaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Rnc { get; set; }
    }

    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public decimal Salario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string TipoEmpleado { get; set; }
        public string Cargo { get; set; }
        public int EmpresaId { get; set; }
    }

    public class CrearEmpleadoDto
    {
        public string Cedula { get; set; }
        public decimal Salario { get; set; }
        public string FechaIngreso { get; set; }
        public string TipoEmpleado { get; set; }
        public string Cargo { get; set; }
        public int EmpresaId { get; set; }
    }
}