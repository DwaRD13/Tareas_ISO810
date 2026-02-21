using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FerrAmeManager
{
    public partial class Form1 : Form
    {
        private int idEmpresaActual = -1;

        // 1. CAMBIO DE RUTA: Apuntamos al puerto de tu servidor Node.js (ej. 3000)
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:3000/") };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        
       
        // Evento del botón "Registrar"
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cBTipoEmpleado.Text))
            {
                MessageBox.Show("Seleccione un tipo de empleado.");
                return;
            }

            string cedula = txtBoxCedulaNuevoEmpleado.Text.Trim();
            string cargo = txtBoxCargoNuevoEmpleado.Text.Trim();
            decimal salario = 0;


            if (!decimal.TryParse(txtBoxSalarioNuevoEmpleado.Text, out salario) || salario <= 0)
            {
                MessageBox.Show("El salario debe ser un número mayor a 0.");
                return;
            }

            // 3. CAMBIO DE ESTRUCTURA: Node.js espera propiedades específicas y un arreglo
            var nuevoEmpleado = new
            {
                cedula = cedula,
                cargo = cargo,
                salario = salario,
                fechaIngreso = dTPNuevoEmpleado.Value.Date
            };

            var payload = new[] { nuevoEmpleado };

            try
            {
                var response = await client.PostAsJsonAsync("api/empleados/guardar-empleados", payload);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Empleado registrado correctamente.");

                    // Limpiar campos
                    txtBoxCedulaNuevoEmpleado.Clear();
                    txtBoxCargoNuevoEmpleado.Clear();
                    txtBoxSalarioNuevoEmpleado.Clear();
                    dTPNuevoEmpleado.Value = DateTime.Now;
                    cBTipoEmpleado.SelectedIndex = -1;
                }
                else
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error de la API al guardar: {errorMsg}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de red conectando con la API: " + ex.Message);
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
    }

    // Clase auxiliar para recibir los datos desde Node.js y pintarlos en el DataGridView
    public class EmpleadoTssDto
    {
        public string cedula { get; set; }
        public string cargo { get; set; }
        public decimal sueldo { get; set; }
        public decimal descuento_seguro { get; set; }
        public decimal sueldo_neto { get; set; }
        public DateTime fecha_ingreso { get; set; }
    }
}