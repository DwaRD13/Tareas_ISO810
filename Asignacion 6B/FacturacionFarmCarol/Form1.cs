using Microsoft.Data.SqlClient;
using System.Data;

namespace FacturacionFarmCarol
{
    public partial class Form1 : Form
    {
        private decimal subtotalCalculado = 0;
        private decimal itbisCalculado = 0;
        private decimal descuentoCalculado = 0;
        private decimal totalCalculado = 0;
        private int cantidadProductosCalculada = 0;

        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=FarmaciaCarol;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            AplicarMejorasUI();
            btn_calcularMonto.Click += btn_calcularMonto_Click;
            btn_registrarFactura.Click += btn_registrarFactura_Click;
            btn_registrarPago.Click += btn_registrarPago_Click;
        }
        private void AplicarMejorasUI()
        {
            this.BackColor = Color.FromArgb(244, 246, 249); 
            panel2.BackColor = Color.White;
            panel3.BackColor = Color.White; 
            groupBox1.BackColor = Color.White; 

            btn_registrarFactura.BackColor = Color.FromArgb(0, 64, 128);
            btn_registrarFactura.ForeColor = Color.White;
            btn_registrarFactura.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_registrarFactura.FlatStyle = FlatStyle.Flat;
            btn_registrarFactura.Cursor = Cursors.Hand;

            btn_calcularMonto.BackColor = Color.FromArgb(255, 193, 7); 
            btn_calcularMonto.ForeColor = Color.Black;
            btn_calcularMonto.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_calcularMonto.FlatStyle = FlatStyle.Flat;
            btn_calcularMonto.Cursor = Cursors.Hand;


            cb_formaPago.DropDownStyle = ComboBoxStyle.DropDownList;

            txtBox_ncf.MaxLength = 11;
            txtBox_ncf.CharacterCasing = CharacterCasing.Upper;

            txtbox_productos.ScrollBars = ScrollBars.Vertical;

            txtbox_idCliente.KeyPress += SoloNumeros_KeyPress;
            txtbox_carolealID.KeyPress += SoloNumeros_KeyPress;
            txtbox_subtotal.KeyPress += Decimales_KeyPress;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void Decimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; 
            }

            TextBox textBox = sender as TextBox;
            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btn_calcularMonto_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtbox_subtotal.Text, out subtotalCalculado))
                {
                    MessageBox.Show("Por favor, ingrese un subtotal válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string[] productosArray = txtbox_productos.Text.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                cantidadProductosCalculada = productosArray.Length;

                itbisCalculado = subtotalCalculado * 0.18m;

                string nombreArs = txtbox_seguroMedico.Text.Trim();
                descuentoCalculado = 0;
                string mensajeSeguro = "";

                if (!string.IsNullOrEmpty(nombreArs))
                {
                    Random rnd = new Random();
                    int probabilidad = rnd.Next(1, 101);

                    if (probabilidad <= 20)
                    {
                        mensajeSeguro = "No aplica";
                    }
                    else
                    {
                        decimal porcentajeDescuento = (decimal)rnd.Next(10, 81) / 100m;
                        descuentoCalculado = subtotalCalculado * porcentajeDescuento;
                        mensajeSeguro = $"RD$ {descuentoCalculado:F2}";
                    }
                }
                else
                {
                    mensajeSeguro = "Sin cobertura ARS";
                }

                totalCalculado = (subtotalCalculado + itbisCalculado) - descuentoCalculado;
                if (totalCalculado < 0) totalCalculado = 0; 

                lb_montoSubtotal.Text = $"SUBTOTAL: RD$ {subtotalCalculado:F2}";
                lb_montoItbis.Text = $"ITBIS: RD$ {itbisCalculado:F2}";
                lb_montoDescuentoSeguro.Text = $"Descuento Seguro: {mensajeSeguro}";
                lb_montoMontoTotal.Text = $"Monto Total: RD$ {totalCalculado:F2}";
                lb_montoCantidadProductos.Text = $"Cantidad Productos: {cantidadProductosCalculada}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_registrarFactura_Click(object sender, EventArgs e)
        {
            if (totalCalculado == 0 && subtotalCalculado == 0)
            {
                MessageBox.Show("Por favor, calcule el monto antes de registrar la factura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO FACTURACION 
                                    (ClienteId, Caroleal, Productos, Subtotal, Itbis, DescuentoSeguro, MontoTotal, 
                                     CantidadProductos, NombreVendedor, FormaPago, NCF, ARSNombre, Sucursal) 
                                     VALUES 
                                    (@ClienteId, @Caroleal, @Productos, @Subtotal, @Itbis, @DescuentoSeguro, @MontoTotal, 
                                     @CantidadProductos, @NombreVendedor, @FormaPago, @NCF, @ARSNombre, @Sucursal)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", string.IsNullOrEmpty(txtbox_idCliente.Text) ? (object)DBNull.Value : Convert.ToInt32(txtbox_idCliente.Text));
                        cmd.Parameters.AddWithValue("@Caroleal", string.IsNullOrEmpty(txtbox_carolealID.Text) ? (object)DBNull.Value : Convert.ToInt32(txtbox_carolealID.Text));

                        cmd.Parameters.AddWithValue("@Productos", txtbox_productos.Text);
                        cmd.Parameters.AddWithValue("@Subtotal", subtotalCalculado);
                        cmd.Parameters.AddWithValue("@Itbis", itbisCalculado);
                        cmd.Parameters.AddWithValue("@DescuentoSeguro", descuentoCalculado);
                        cmd.Parameters.AddWithValue("@MontoTotal", totalCalculado);
                        cmd.Parameters.AddWithValue("@CantidadProductos", cantidadProductosCalculada);
                        cmd.Parameters.AddWithValue("@NombreVendedor", txtBox_nombreVendedor.Text);
                        cmd.Parameters.AddWithValue("@FormaPago", cb_formaPago.SelectedItem != null ? cb_formaPago.SelectedItem.ToString() : (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@NCF", txtBox_ncf.Text);
                        cmd.Parameters.AddWithValue("@ARSNombre", txtbox_seguroMedico.Text);
                        cmd.Parameters.AddWithValue("@Sucursal", txtBox_sucursal.Text);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Factura registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de Base de Datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_registrarPago_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtBox_pagoFacturaId.Text, out int idFactura))
            {
                MessageBox.Show("Por favor, ingrese un ID de factura válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtBox_pagoMonto.Text, out decimal montoAbonado) || montoAbonado <= 0)
            {
                MessageBox.Show("Por favor, ingrese un monto a pagar mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcesarPagoDeCuenta(idFactura, montoAbonado);

            txtBox_pagoFacturaId.Clear();
            txtBox_pagoMonto.Clear();
        }

        public void ProcesarPagoDeCuenta(int idFactura, decimal montoAbonado)
        {
            if (montoAbonado <= 0)
            {
                MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string insertPagoQuery = @"INSERT INTO dbo.Pago (FacturaId, Monto, FechaPago) 
                                       VALUES (@FacturaId, @Monto, GETDATE());
                                       SELECT SCOPE_IDENTITY();";

                    int nuevoPagoId = 0;
                    using (SqlCommand cmdPago = new SqlCommand(insertPagoQuery, conn))
                    {
                        cmdPago.Parameters.AddWithValue("@FacturaId", idFactura);
                        cmdPago.Parameters.AddWithValue("@Monto", montoAbonado);
                        nuevoPagoId = Convert.ToInt32(cmdPago.ExecuteScalar());
                    }
                    using (SqlCommand cmdSp = new SqlCommand("dbo.sp_CxC_AplicarPago", conn))
                    {
                        cmdSp.CommandType = CommandType.StoredProcedure;
                        cmdSp.Parameters.AddWithValue("@PagoId", nuevoPagoId);
                        cmdSp.ExecuteNonQuery();
                    }

                    MessageBox.Show("Pago registrado correctamente. El saldo en Cuentas por Cobrar se ha actualizado.", "Pago Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("Error de Base de Datos al procesar el pago: " + sqlEx.Message, "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtbox_idCliente.Clear();
            txtbox_carolealID.Clear();
            txtbox_productos.Clear();
            txtbox_subtotal.Clear();
            txtbox_seguroMedico.Clear();
            txtBox_nombreVendedor.Clear();
            txtBox_sucursal.Clear();
            txtBox_ncf.Clear();
            cb_formaPago.SelectedIndex = -1;

            lb_montoSubtotal.Text = "SUBTOTAL: ";
            lb_montoItbis.Text = "ITBIS: ";
            lb_montoDescuentoSeguro.Text = "Descuento Seguro: ";
            lb_montoMontoTotal.Text = "Monto Total: ";
            lb_montoCantidadProductos.Text = "Cantidad Productos: ";

            subtotalCalculado = 0; totalCalculado = 0; itbisCalculado = 0; descuentoCalculado = 0; cantidadProductosCalculada = 0;
        }

        private void panel2_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, PaintEventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged_1(object sender, EventArgs e) { }
        private void textBox1_TextChanged_2(object sender, EventArgs e) { }
        private void textBox1_TextChanged_3(object sender, EventArgs e) { }
        private void textBox2_TextChanged_1(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label2_Click_5(object sender, EventArgs e) { }
        private void label3_Click_3(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
    }
}