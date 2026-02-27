namespace FacturacionFarmCarol
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            imageList1 = new ImageList(components);
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            lb_montoCantidadProductos = new Label();
            lb_montoDescuentoSeguro = new Label();
            lb_montoItbis = new Label();
            lb_montoSubtotal = new Label();
            lb_montoMontoTotal = new Label();
            panel3 = new Panel();
            btn_registrarFactura = new Button();
            txtBox_ncf = new TextBox();
            lb_ncf = new Label();
            cb_formaPago = new ComboBox();
            lb_formaPago = new Label();
            txtBox_sucursal = new TextBox();
            lb_sucursal = new Label();
            txtBox_nombreVendedor = new TextBox();
            lb_nombreVendedor = new Label();
            txtbox_seguroMedico = new TextBox();
            lb_ArsNombre = new Label();
            btn_calcularMonto = new Button();
            txtbox_subtotal = new TextBox();
            lb_subtotal = new Label();
            txtbox_productos = new TextBox();
            lb_productos = new Label();
            txtbox_carolealID = new TextBox();
            lb_carolealId = new Label();
            txtbox_idCliente = new TextBox();
            lb_clienteID = new Label();
            panel2 = new Panel();
            tituloApp = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(138, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(227, 99);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(635, 710);
            panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lb_montoCantidadProductos);
            groupBox1.Controls.Add(lb_montoDescuentoSeguro);
            groupBox1.Controls.Add(lb_montoItbis);
            groupBox1.Controls.Add(lb_montoSubtotal);
            groupBox1.Controls.Add(lb_montoMontoTotal);
            groupBox1.Location = new Point(394, 187);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(225, 479);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Monto descompuesto";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // lb_montoCantidadProductos
            // 
            lb_montoCantidadProductos.AutoSize = true;
            lb_montoCantidadProductos.Location = new Point(3, 161);
            lb_montoCantidadProductos.Name = "lb_montoCantidadProductos";
            lb_montoCantidadProductos.Size = new Size(115, 15);
            lb_montoCantidadProductos.TabIndex = 4;
            lb_montoCantidadProductos.Text = "Cantidad Productos:";
            lb_montoCantidadProductos.Click += label6_Click;
            // 
            // lb_montoDescuentoSeguro
            // 
            lb_montoDescuentoSeguro.AutoSize = true;
            lb_montoDescuentoSeguro.Location = new Point(15, 92);
            lb_montoDescuentoSeguro.Name = "lb_montoDescuentoSeguro";
            lb_montoDescuentoSeguro.Size = new Size(106, 15);
            lb_montoDescuentoSeguro.TabIndex = 3;
            lb_montoDescuentoSeguro.Text = "Descuento Seguro:";
            // 
            // lb_montoItbis
            // 
            lb_montoItbis.AutoSize = true;
            lb_montoItbis.Location = new Point(87, 68);
            lb_montoItbis.Name = "lb_montoItbis";
            lb_montoItbis.Size = new Size(38, 15);
            lb_montoItbis.TabIndex = 2;
            lb_montoItbis.Text = "ITBIS: ";
            // 
            // lb_montoSubtotal
            // 
            lb_montoSubtotal.AutoSize = true;
            lb_montoSubtotal.Location = new Point(60, 43);
            lb_montoSubtotal.Name = "lb_montoSubtotal";
            lb_montoSubtotal.Size = new Size(65, 15);
            lb_montoSubtotal.TabIndex = 1;
            lb_montoSubtotal.Text = "SUBTOTAL: ";
            lb_montoSubtotal.Click += label3_Click_3;
            // 
            // lb_montoMontoTotal
            // 
            lb_montoMontoTotal.AutoSize = true;
            lb_montoMontoTotal.Location = new Point(44, 136);
            lb_montoMontoTotal.Name = "lb_montoMontoTotal";
            lb_montoMontoTotal.Size = new Size(77, 15);
            lb_montoMontoTotal.TabIndex = 0;
            lb_montoMontoTotal.Text = "Monto Total: ";
            lb_montoMontoTotal.Click += label2_Click_5;
            // 
            // panel3
            // 
            panel3.Controls.Add(btn_registrarFactura);
            panel3.Controls.Add(txtBox_ncf);
            panel3.Controls.Add(lb_ncf);
            panel3.Controls.Add(cb_formaPago);
            panel3.Controls.Add(lb_formaPago);
            panel3.Controls.Add(txtBox_sucursal);
            panel3.Controls.Add(lb_sucursal);
            panel3.Controls.Add(txtBox_nombreVendedor);
            panel3.Controls.Add(lb_nombreVendedor);
            panel3.Controls.Add(txtbox_seguroMedico);
            panel3.Controls.Add(lb_ArsNombre);
            panel3.Controls.Add(btn_calcularMonto);
            panel3.Controls.Add(txtbox_subtotal);
            panel3.Controls.Add(lb_subtotal);
            panel3.Controls.Add(txtbox_productos);
            panel3.Controls.Add(lb_productos);
            panel3.Controls.Add(txtbox_carolealID);
            panel3.Controls.Add(lb_carolealId);
            panel3.Controls.Add(txtbox_idCliente);
            panel3.Controls.Add(lb_clienteID);
            panel3.Location = new Point(14, 187);
            panel3.Name = "panel3";
            panel3.Size = new Size(374, 494);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // btn_registrarFactura
            // 
            btn_registrarFactura.BackColor = SystemColors.Highlight;
            btn_registrarFactura.ForeColor = Color.Black;
            btn_registrarFactura.Location = new Point(157, 432);
            btn_registrarFactura.Name = "btn_registrarFactura";
            btn_registrarFactura.Size = new Size(137, 40);
            btn_registrarFactura.TabIndex = 19;
            btn_registrarFactura.Text = "Registrar Factura";
            btn_registrarFactura.UseVisualStyleBackColor = false;
            // 
            // txtBox_ncf
            // 
            txtBox_ncf.Location = new Point(96, 325);
            txtBox_ncf.Name = "txtBox_ncf";
            txtBox_ncf.Size = new Size(182, 23);
            txtBox_ncf.TabIndex = 18;
            // 
            // lb_ncf
            // 
            lb_ncf.AutoSize = true;
            lb_ncf.Location = new Point(53, 328);
            lb_ncf.Name = "lb_ncf";
            lb_ncf.Size = new Size(30, 15);
            lb_ncf.TabIndex = 17;
            lb_ncf.Text = "NCF";
            // 
            // cb_formaPago
            // 
            cb_formaPago.FormattingEnabled = true;
            cb_formaPago.Items.AddRange(new object[] { "Crédito", "Contado" });
            cb_formaPago.Location = new Point(96, 286);
            cb_formaPago.Name = "cb_formaPago";
            cb_formaPago.Size = new Size(182, 23);
            cb_formaPago.TabIndex = 16;
            cb_formaPago.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // lb_formaPago
            // 
            lb_formaPago.AutoSize = true;
            lb_formaPago.Location = new Point(19, 289);
            lb_formaPago.Name = "lb_formaPago";
            lb_formaPago.Size = new Size(71, 15);
            lb_formaPago.TabIndex = 15;
            lb_formaPago.Text = "Forma Pago";
            // 
            // txtBox_sucursal
            // 
            txtBox_sucursal.Location = new Point(96, 393);
            txtBox_sucursal.Name = "txtBox_sucursal";
            txtBox_sucursal.Size = new Size(182, 23);
            txtBox_sucursal.TabIndex = 14;
            txtBox_sucursal.TextChanged += textBox2_TextChanged_1;
            // 
            // lb_sucursal
            // 
            lb_sucursal.AutoSize = true;
            lb_sucursal.Location = new Point(32, 396);
            lb_sucursal.Name = "lb_sucursal";
            lb_sucursal.Size = new Size(51, 15);
            lb_sucursal.TabIndex = 13;
            lb_sucursal.Text = "Sucursal";
            // 
            // txtBox_nombreVendedor
            // 
            txtBox_nombreVendedor.Location = new Point(96, 361);
            txtBox_nombreVendedor.Name = "txtBox_nombreVendedor";
            txtBox_nombreVendedor.Size = new Size(182, 23);
            txtBox_nombreVendedor.TabIndex = 12;
            txtBox_nombreVendedor.TextChanged += textBox1_TextChanged_3;
            // 
            // lb_nombreVendedor
            // 
            lb_nombreVendedor.AutoSize = true;
            lb_nombreVendedor.Location = new Point(13, 364);
            lb_nombreVendedor.Name = "lb_nombreVendedor";
            lb_nombreVendedor.Size = new Size(77, 15);
            lb_nombreVendedor.TabIndex = 11;
            lb_nombreVendedor.Text = "Atendido por";
            // 
            // txtbox_seguroMedico
            // 
            txtbox_seguroMedico.Location = new Point(96, 209);
            txtbox_seguroMedico.Name = "txtbox_seguroMedico";
            txtbox_seguroMedico.Size = new Size(182, 23);
            txtbox_seguroMedico.TabIndex = 10;
            txtbox_seguroMedico.TextChanged += textBox1_TextChanged_2;
            // 
            // lb_ArsNombre
            // 
            lb_ArsNombre.AutoSize = true;
            lb_ArsNombre.Location = new Point(3, 212);
            lb_ArsNombre.Name = "lb_ArsNombre";
            lb_ArsNombre.Size = new Size(87, 15);
            lb_ArsNombre.TabIndex = 9;
            lb_ArsNombre.Text = "Seguro Medico";
            // 
            // btn_calcularMonto
            // 
            btn_calcularMonto.Location = new Point(280, 243);
            btn_calcularMonto.Name = "btn_calcularMonto";
            btn_calcularMonto.Size = new Size(76, 23);
            btn_calcularMonto.TabIndex = 8;
            btn_calcularMonto.Text = "Calcular";
            btn_calcularMonto.UseVisualStyleBackColor = true;
            // 
            // txtbox_subtotal
            // 
            txtbox_subtotal.Location = new Point(96, 244);
            txtbox_subtotal.Name = "txtbox_subtotal";
            txtbox_subtotal.Size = new Size(182, 23);
            txtbox_subtotal.TabIndex = 7;
            txtbox_subtotal.TextChanged += textBox1_TextChanged_1;
            // 
            // lb_subtotal
            // 
            lb_subtotal.AutoSize = true;
            lb_subtotal.Location = new Point(39, 247);
            lb_subtotal.Name = "lb_subtotal";
            lb_subtotal.Size = new Size(51, 15);
            lb_subtotal.TabIndex = 6;
            lb_subtotal.Text = "Subtotal";
            // 
            // txtbox_productos
            // 
            txtbox_productos.Location = new Point(96, 106);
            txtbox_productos.Multiline = true;
            txtbox_productos.Name = "txtbox_productos";
            txtbox_productos.Size = new Size(182, 92);
            txtbox_productos.TabIndex = 5;
            txtbox_productos.TextChanged += textBox2_TextChanged;
            // 
            // lb_productos
            // 
            lb_productos.AutoSize = true;
            lb_productos.Location = new Point(29, 106);
            lb_productos.Name = "lb_productos";
            lb_productos.Size = new Size(61, 15);
            lb_productos.TabIndex = 4;
            lb_productos.Text = "Productos";
            // 
            // txtbox_carolealID
            // 
            txtbox_carolealID.Location = new Point(96, 61);
            txtbox_carolealID.Name = "txtbox_carolealID";
            txtbox_carolealID.Size = new Size(182, 23);
            txtbox_carolealID.TabIndex = 3;
            // 
            // lb_carolealId
            // 
            lb_carolealId.AutoSize = true;
            lb_carolealId.Location = new Point(26, 64);
            lb_carolealId.Name = "lb_carolealId";
            lb_carolealId.Size = new Size(64, 15);
            lb_carolealId.TabIndex = 2;
            lb_carolealId.Text = "Caroleal ID";
            // 
            // txtbox_idCliente
            // 
            txtbox_idCliente.Location = new Point(96, 18);
            txtbox_idCliente.Name = "txtbox_idCliente";
            txtbox_idCliente.Size = new Size(182, 23);
            txtbox_idCliente.TabIndex = 1;
            // 
            // lb_clienteID
            // 
            lb_clienteID.AutoSize = true;
            lb_clienteID.Location = new Point(32, 21);
            lb_clienteID.Name = "lb_clienteID";
            lb_clienteID.Size = new Size(58, 15);
            lb_clienteID.TabIndex = 0;
            lb_clienteID.Text = "ID Cliente";
            lb_clienteID.Click += label2_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(tituloApp);
            panel2.Controls.Add(pictureBox1);
            panel2.Location = new Point(76, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(487, 142);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // tituloApp
            // 
            tituloApp.AutoSize = true;
            tituloApp.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tituloApp.Location = new Point(191, 109);
            tituloApp.Name = "tituloApp";
            tituloApp.Size = new Size(115, 25);
            tituloApp.TabIndex = 1;
            tituloApp.Text = "Facturación";
            tituloApp.Click += label1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(659, 734);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ImageList imageList1;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Panel panel2;
        private Label tituloApp;
        private Panel panel3;
        private Label lb_clienteID;
        private TextBox txtbox_carolealID;
        private Label lb_carolealId;
        private TextBox txtbox_idCliente;
        private GroupBox groupBox1;
        private TextBox txtbox_productos;
        private Label lb_productos;
        private TextBox txtbox_subtotal;
        private Label lb_subtotal;
        private TextBox txtbox_seguroMedico;
        private Label lb_ArsNombre;
        private Button btn_calcularMonto;
        private TextBox txtBox_nombreVendedor;
        private Label lb_nombreVendedor;
        private TextBox txtBox_sucursal;
        private Label lb_sucursal;
        private ComboBox cb_formaPago;
        private Label lb_formaPago;
        private TextBox txtBox_ncf;
        private Label lb_ncf;
        private Button btn_registrarFactura;
        private Label lb_montoMontoTotal;
        private Label lb_montoSubtotal;
        private Label lb_montoCantidadProductos;
        private Label lb_montoDescuentoSeguro;
        private Label lb_montoItbis;
    }
}
