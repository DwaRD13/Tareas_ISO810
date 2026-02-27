namespace FacturacionFarmCarol
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();

            // --- NUEVOS CONTROLES PARA PAGO ---
            this.groupBoxPago = new System.Windows.Forms.GroupBox();
            this.lb_pagoFacturaId = new System.Windows.Forms.Label();
            this.txtBox_pagoFacturaId = new System.Windows.Forms.TextBox();
            this.lb_pagoMonto = new System.Windows.Forms.Label();
            this.txtBox_pagoMonto = new System.Windows.Forms.TextBox();
            this.btn_registrarPago = new System.Windows.Forms.Button();
            // ----------------------------------

            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_montoCantidadProductos = new System.Windows.Forms.Label();
            this.lb_montoDescuentoSeguro = new System.Windows.Forms.Label();
            this.lb_montoItbis = new System.Windows.Forms.Label();
            this.lb_montoSubtotal = new System.Windows.Forms.Label();
            this.lb_montoMontoTotal = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_registrarFactura = new System.Windows.Forms.Button();
            this.txtBox_ncf = new System.Windows.Forms.TextBox();
            this.lb_ncf = new System.Windows.Forms.Label();
            this.cb_formaPago = new System.Windows.Forms.ComboBox();
            this.lb_formaPago = new System.Windows.Forms.Label();
            this.txtBox_sucursal = new System.Windows.Forms.TextBox();
            this.lb_sucursal = new System.Windows.Forms.Label();
            this.txtBox_nombreVendedor = new System.Windows.Forms.TextBox();
            this.lb_nombreVendedor = new System.Windows.Forms.Label();
            this.txtbox_seguroMedico = new System.Windows.Forms.TextBox();
            this.lb_ArsNombre = new System.Windows.Forms.Label();
            this.btn_calcularMonto = new System.Windows.Forms.Button();
            this.txtbox_subtotal = new System.Windows.Forms.TextBox();
            this.lb_subtotal = new System.Windows.Forms.Label();
            this.txtbox_productos = new System.Windows.Forms.TextBox();
            this.lb_productos = new System.Windows.Forms.Label();
            this.txtbox_carolealID = new System.Windows.Forms.TextBox();
            this.lb_carolealId = new System.Windows.Forms.Label();
            this.txtbox_idCliente = new System.Windows.Forms.TextBox();
            this.lb_clienteID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tituloApp = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxPago.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();

            // imageList1
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;

            // pictureBox1
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(138, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 99);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;

            // panel1
            this.panel1.Controls.Add(this.groupBoxPago); // Agregado el nuevo bloque
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 830); // Aumenté el tamaño
            this.panel1.TabIndex = 1;

            // --- SECCIÓN: NUEVO GROUPBOX PARA PAGOS ---
            this.groupBoxPago.Controls.Add(this.btn_registrarPago);
            this.groupBoxPago.Controls.Add(this.txtBox_pagoMonto);
            this.groupBoxPago.Controls.Add(this.lb_pagoMonto);
            this.groupBoxPago.Controls.Add(this.txtBox_pagoFacturaId);
            this.groupBoxPago.Controls.Add(this.lb_pagoFacturaId);
            this.groupBoxPago.Location = new System.Drawing.Point(14, 695);
            this.groupBoxPago.Name = "groupBoxPago";
            this.groupBoxPago.Size = new System.Drawing.Size(605, 100);
            this.groupBoxPago.TabIndex = 4;
            this.groupBoxPago.TabStop = false;
            this.groupBoxPago.Text = "Procesar Pago de Cuentas por Cobrar";

            this.lb_pagoFacturaId.AutoSize = true;
            this.lb_pagoFacturaId.Location = new System.Drawing.Point(20, 45);
            this.lb_pagoFacturaId.Name = "lb_pagoFacturaId";
            this.lb_pagoFacturaId.Size = new System.Drawing.Size(66, 15);
            this.lb_pagoFacturaId.Text = "ID Factura:";

            this.txtBox_pagoFacturaId.Location = new System.Drawing.Point(90, 42);
            this.txtBox_pagoFacturaId.Name = "txtBox_pagoFacturaId";
            this.txtBox_pagoFacturaId.Size = new System.Drawing.Size(100, 23);

            this.lb_pagoMonto.AutoSize = true;
            this.lb_pagoMonto.Location = new System.Drawing.Point(210, 45);
            this.lb_pagoMonto.Name = "lb_pagoMonto";
            this.lb_pagoMonto.Size = new System.Drawing.Size(89, 15);
            this.lb_pagoMonto.Text = "Monto a Pagar:";

            this.txtBox_pagoMonto.Location = new System.Drawing.Point(305, 42);
            this.txtBox_pagoMonto.Name = "txtBox_pagoMonto";
            this.txtBox_pagoMonto.Size = new System.Drawing.Size(120, 23);

            this.btn_registrarPago.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_registrarPago.ForeColor = System.Drawing.Color.White;
            this.btn_registrarPago.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_registrarPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registrarPago.Location = new System.Drawing.Point(445, 35);
            this.btn_registrarPago.Name = "btn_registrarPago";
            this.btn_registrarPago.Size = new System.Drawing.Size(140, 35);
            this.btn_registrarPago.Text = "Procesar Pago";
            this.btn_registrarPago.UseVisualStyleBackColor = false;
            // ------------------------------------------

            // groupBox1
            this.groupBox1.Controls.Add(this.lb_montoCantidadProductos);
            this.groupBox1.Controls.Add(this.lb_montoDescuentoSeguro);
            this.groupBox1.Controls.Add(this.lb_montoItbis);
            this.groupBox1.Controls.Add(this.lb_montoSubtotal);
            this.groupBox1.Controls.Add(this.lb_montoMontoTotal);
            this.groupBox1.Location = new System.Drawing.Point(394, 187);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 494);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monto descompuesto";

            // lb_montoCantidadProductos
            this.lb_montoCantidadProductos.AutoSize = true;
            this.lb_montoCantidadProductos.Location = new System.Drawing.Point(3, 161);
            this.lb_montoCantidadProductos.Name = "lb_montoCantidadProductos";
            this.lb_montoCantidadProductos.Size = new System.Drawing.Size(115, 15);
            this.lb_montoCantidadProductos.TabIndex = 4;
            this.lb_montoCantidadProductos.Text = "Cantidad Productos:";

            // lb_montoDescuentoSeguro
            this.lb_montoDescuentoSeguro.AutoSize = true;
            this.lb_montoDescuentoSeguro.Location = new System.Drawing.Point(15, 92);
            this.lb_montoDescuentoSeguro.Name = "lb_montoDescuentoSeguro";
            this.lb_montoDescuentoSeguro.Size = new System.Drawing.Size(106, 15);
            this.lb_montoDescuentoSeguro.TabIndex = 3;
            this.lb_montoDescuentoSeguro.Text = "Descuento Seguro:";

            // lb_montoItbis
            this.lb_montoItbis.AutoSize = true;
            this.lb_montoItbis.Location = new System.Drawing.Point(87, 68);
            this.lb_montoItbis.Name = "lb_montoItbis";
            this.lb_montoItbis.Size = new System.Drawing.Size(38, 15);
            this.lb_montoItbis.TabIndex = 2;
            this.lb_montoItbis.Text = "ITBIS: ";

            // lb_montoSubtotal
            this.lb_montoSubtotal.AutoSize = true;
            this.lb_montoSubtotal.Location = new System.Drawing.Point(60, 43);
            this.lb_montoSubtotal.Name = "lb_montoSubtotal";
            this.lb_montoSubtotal.Size = new System.Drawing.Size(65, 15);
            this.lb_montoSubtotal.TabIndex = 1;
            this.lb_montoSubtotal.Text = "SUBTOTAL: ";

            // lb_montoMontoTotal
            this.lb_montoMontoTotal.AutoSize = true;
            this.lb_montoMontoTotal.Location = new System.Drawing.Point(44, 136);
            this.lb_montoMontoTotal.Name = "lb_montoMontoTotal";
            this.lb_montoMontoTotal.Size = new System.Drawing.Size(77, 15);
            this.lb_montoMontoTotal.TabIndex = 0;
            this.lb_montoMontoTotal.Text = "Monto Total: ";

            // panel3
            this.panel3.Controls.Add(this.btn_registrarFactura);
            this.panel3.Controls.Add(this.txtBox_ncf);
            this.panel3.Controls.Add(this.lb_ncf);
            this.panel3.Controls.Add(this.cb_formaPago);
            this.panel3.Controls.Add(this.lb_formaPago);
            this.panel3.Controls.Add(this.txtBox_sucursal);
            this.panel3.Controls.Add(this.lb_sucursal);
            this.panel3.Controls.Add(this.txtBox_nombreVendedor);
            this.panel3.Controls.Add(this.lb_nombreVendedor);
            this.panel3.Controls.Add(this.txtbox_seguroMedico);
            this.panel3.Controls.Add(this.lb_ArsNombre);
            this.panel3.Controls.Add(this.btn_calcularMonto);
            this.panel3.Controls.Add(this.txtbox_subtotal);
            this.panel3.Controls.Add(this.lb_subtotal);
            this.panel3.Controls.Add(this.txtbox_productos);
            this.panel3.Controls.Add(this.lb_productos);
            this.panel3.Controls.Add(this.txtbox_carolealID);
            this.panel3.Controls.Add(this.lb_carolealId);
            this.panel3.Controls.Add(this.txtbox_idCliente);
            this.panel3.Controls.Add(this.lb_clienteID);
            this.panel3.Location = new System.Drawing.Point(14, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(374, 494);
            this.panel3.TabIndex = 2;

            // btn_registrarFactura
            this.btn_registrarFactura.BackColor = System.Drawing.SystemColors.Highlight;
            this.btn_registrarFactura.ForeColor = System.Drawing.Color.Black;
            this.btn_registrarFactura.Location = new System.Drawing.Point(157, 432);
            this.btn_registrarFactura.Name = "btn_registrarFactura";
            this.btn_registrarFactura.Size = new System.Drawing.Size(137, 40);
            this.btn_registrarFactura.TabIndex = 19;
            this.btn_registrarFactura.Text = "Registrar Factura";
            this.btn_registrarFactura.UseVisualStyleBackColor = false;

            // txtBox_ncf
            this.txtBox_ncf.Location = new System.Drawing.Point(96, 325);
            this.txtBox_ncf.Name = "txtBox_ncf";
            this.txtBox_ncf.Size = new System.Drawing.Size(182, 23);
            this.txtBox_ncf.TabIndex = 18;

            // lb_ncf
            this.lb_ncf.AutoSize = true;
            this.lb_ncf.Location = new System.Drawing.Point(53, 328);
            this.lb_ncf.Name = "lb_ncf";
            this.lb_ncf.Size = new System.Drawing.Size(30, 15);
            this.lb_ncf.TabIndex = 17;
            this.lb_ncf.Text = "NCF";

            // cb_formaPago
            this.cb_formaPago.FormattingEnabled = true;
            this.cb_formaPago.Items.AddRange(new object[] { "Crédito", "Contado" });
            this.cb_formaPago.Location = new System.Drawing.Point(96, 286);
            this.cb_formaPago.Name = "cb_formaPago";
            this.cb_formaPago.Size = new System.Drawing.Size(182, 23);
            this.cb_formaPago.TabIndex = 16;

            // lb_formaPago
            this.lb_formaPago.AutoSize = true;
            this.lb_formaPago.Location = new System.Drawing.Point(19, 289);
            this.lb_formaPago.Name = "lb_formaPago";
            this.lb_formaPago.Size = new System.Drawing.Size(71, 15);
            this.lb_formaPago.TabIndex = 15;
            this.lb_formaPago.Text = "Forma Pago";

            // txtBox_sucursal
            this.txtBox_sucursal.Location = new System.Drawing.Point(96, 393);
            this.txtBox_sucursal.Name = "txtBox_sucursal";
            this.txtBox_sucursal.Size = new System.Drawing.Size(182, 23);
            this.txtBox_sucursal.TabIndex = 14;

            // lb_sucursal
            this.lb_sucursal.AutoSize = true;
            this.lb_sucursal.Location = new System.Drawing.Point(32, 396);
            this.lb_sucursal.Name = "lb_sucursal";
            this.lb_sucursal.Size = new System.Drawing.Size(51, 15);
            this.lb_sucursal.TabIndex = 13;
            this.lb_sucursal.Text = "Sucursal";

            // txtBox_nombreVendedor
            this.txtBox_nombreVendedor.Location = new System.Drawing.Point(96, 361);
            this.txtBox_nombreVendedor.Name = "txtBox_nombreVendedor";
            this.txtBox_nombreVendedor.Size = new System.Drawing.Size(182, 23);
            this.txtBox_nombreVendedor.TabIndex = 12;

            // lb_nombreVendedor
            this.lb_nombreVendedor.AutoSize = true;
            this.lb_nombreVendedor.Location = new System.Drawing.Point(13, 364);
            this.lb_nombreVendedor.Name = "lb_nombreVendedor";
            this.lb_nombreVendedor.Size = new System.Drawing.Size(77, 15);
            this.lb_nombreVendedor.TabIndex = 11;
            this.lb_nombreVendedor.Text = "Atendido por";

            // txtbox_seguroMedico
            this.txtbox_seguroMedico.Location = new System.Drawing.Point(96, 209);
            this.txtbox_seguroMedico.Name = "txtbox_seguroMedico";
            this.txtbox_seguroMedico.Size = new System.Drawing.Size(182, 23);
            this.txtbox_seguroMedico.TabIndex = 10;

            // lb_ArsNombre
            this.lb_ArsNombre.AutoSize = true;
            this.lb_ArsNombre.Location = new System.Drawing.Point(3, 212);
            this.lb_ArsNombre.Name = "lb_ArsNombre";
            this.lb_ArsNombre.Size = new System.Drawing.Size(87, 15);
            this.lb_ArsNombre.TabIndex = 9;
            this.lb_ArsNombre.Text = "Seguro Medico";

            // btn_calcularMonto
            this.btn_calcularMonto.Location = new System.Drawing.Point(280, 243);
            this.btn_calcularMonto.Name = "btn_calcularMonto";
            this.btn_calcularMonto.Size = new System.Drawing.Size(76, 23);
            this.btn_calcularMonto.TabIndex = 8;
            this.btn_calcularMonto.Text = "Calcular";
            this.btn_calcularMonto.UseVisualStyleBackColor = true;

            // txtbox_subtotal
            this.txtbox_subtotal.Location = new System.Drawing.Point(96, 244);
            this.txtbox_subtotal.Name = "txtbox_subtotal";
            this.txtbox_subtotal.Size = new System.Drawing.Size(182, 23);
            this.txtbox_subtotal.TabIndex = 7;

            // lb_subtotal
            this.lb_subtotal.AutoSize = true;
            this.lb_subtotal.Location = new System.Drawing.Point(39, 247);
            this.lb_subtotal.Name = "lb_subtotal";
            this.lb_subtotal.Size = new System.Drawing.Size(51, 15);
            this.lb_subtotal.TabIndex = 6;
            this.lb_subtotal.Text = "Subtotal";

            // txtbox_productos
            this.txtbox_productos.Location = new System.Drawing.Point(96, 106);
            this.txtbox_productos.Multiline = true;
            this.txtbox_productos.Name = "txtbox_productos";
            this.txtbox_productos.Size = new System.Drawing.Size(182, 92);
            this.txtbox_productos.TabIndex = 5;

            // lb_productos
            this.lb_productos.AutoSize = true;
            this.lb_productos.Location = new System.Drawing.Point(29, 106);
            this.lb_productos.Name = "lb_productos";
            this.lb_productos.Size = new System.Drawing.Size(61, 15);
            this.lb_productos.TabIndex = 4;
            this.lb_productos.Text = "Productos";

            // txtbox_carolealID
            this.txtbox_carolealID.Location = new System.Drawing.Point(96, 61);
            this.txtbox_carolealID.Name = "txtbox_carolealID";
            this.txtbox_carolealID.Size = new System.Drawing.Size(182, 23);
            this.txtbox_carolealID.TabIndex = 3;

            // lb_carolealId
            this.lb_carolealId.AutoSize = true;
            this.lb_carolealId.Location = new System.Drawing.Point(26, 64);
            this.lb_carolealId.Name = "lb_carolealId";
            this.lb_carolealId.Size = new System.Drawing.Size(64, 15);
            this.lb_carolealId.TabIndex = 2;
            this.lb_carolealId.Text = "Caroleal ID";

            // txtbox_idCliente
            this.txtbox_idCliente.Location = new System.Drawing.Point(96, 18);
            this.txtbox_idCliente.Name = "txtbox_idCliente";
            this.txtbox_idCliente.Size = new System.Drawing.Size(182, 23);
            this.txtbox_idCliente.TabIndex = 1;

            // lb_clienteID
            this.lb_clienteID.AutoSize = true;
            this.lb_clienteID.Location = new System.Drawing.Point(32, 21);
            this.lb_clienteID.Name = "lb_clienteID";
            this.lb_clienteID.Size = new System.Drawing.Size(58, 15);
            this.lb_clienteID.TabIndex = 0;
            this.lb_clienteID.Text = "ID Cliente";

            // panel2
            this.panel2.Controls.Add(this.tituloApp);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(76, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(487, 142);
            this.panel2.TabIndex = 1;

            // tituloApp
            this.tituloApp.AutoSize = true;
            this.tituloApp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloApp.Location = new System.Drawing.Point(191, 109);
            this.tituloApp.Name = "tituloApp";
            this.tituloApp.Size = new System.Drawing.Size(115, 25);
            this.tituloApp.TabIndex = 1;
            this.tituloApp.Text = "Facturación";

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(659, 854); // Aumenté la altura de la ventana
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Formulario de Facturación y Pagos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxPago.ResumeLayout(false);
            this.groupBoxPago.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label tituloApp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lb_clienteID;
        private System.Windows.Forms.TextBox txtbox_carolealID;
        private System.Windows.Forms.Label lb_carolealId;
        private System.Windows.Forms.TextBox txtbox_idCliente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtbox_productos;
        private System.Windows.Forms.Label lb_productos;
        private System.Windows.Forms.TextBox txtbox_subtotal;
        private System.Windows.Forms.Label lb_subtotal;
        private System.Windows.Forms.TextBox txtbox_seguroMedico;
        private System.Windows.Forms.Label lb_ArsNombre;
        private System.Windows.Forms.Button btn_calcularMonto;
        private System.Windows.Forms.TextBox txtBox_nombreVendedor;
        private System.Windows.Forms.Label lb_nombreVendedor;
        private System.Windows.Forms.TextBox txtBox_sucursal;
        private System.Windows.Forms.Label lb_sucursal;
        private System.Windows.Forms.ComboBox cb_formaPago;
        private System.Windows.Forms.Label lb_formaPago;
        private System.Windows.Forms.TextBox txtBox_ncf;
        private System.Windows.Forms.Label lb_ncf;
        private System.Windows.Forms.Button btn_registrarFactura;
        private System.Windows.Forms.Label lb_montoMontoTotal;
        private System.Windows.Forms.Label lb_montoSubtotal;
        private System.Windows.Forms.Label lb_montoCantidadProductos;
        private System.Windows.Forms.Label lb_montoDescuentoSeguro;
        private System.Windows.Forms.Label lb_montoItbis;

        private System.Windows.Forms.GroupBox groupBoxPago;
        private System.Windows.Forms.Label lb_pagoFacturaId;
        private System.Windows.Forms.TextBox txtBox_pagoFacturaId;
        private System.Windows.Forms.Label lb_pagoMonto;
        private System.Windows.Forms.TextBox txtBox_pagoMonto;
        private System.Windows.Forms.Button btn_registrarPago;
    }
}