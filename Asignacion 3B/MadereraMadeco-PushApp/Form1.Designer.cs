namespace MadereraMadeco_PushApp
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

        private void InitializeComponent()
        {
            Titulo = new Label();
            panel1 = new Panel();
            lblId = new Label();
            txtIdTransaccion = new TextBox();
            lblNumAsiento = new Label();
            txtNumeroAsiento = new TextBox();
            lblFecha = new Label();
            dtpFecha = new DateTimePicker();
            lblDesc = new Label();
            txtDescripcion = new TextBox();
            dgvMovimientos = new DataGridView();
            btnExportar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).BeginInit();
            SuspendLayout();
            // 
            // Titulo
            // 
            Titulo.AutoSize = true;
            Titulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            Titulo.Location = new Point(250, 15);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(312, 30);
            Titulo.TabIndex = 1;
            Titulo.Text = "Maderera Madeco - Asientos";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lblId);
            panel1.Controls.Add(txtIdTransaccion);
            panel1.Controls.Add(lblNumAsiento);
            panel1.Controls.Add(txtNumeroAsiento);
            panel1.Controls.Add(lblFecha);
            panel1.Controls.Add(dtpFecha);
            panel1.Controls.Add(lblDesc);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(dgvMovimientos);
            panel1.Controls.Add(btnExportar);
            panel1.Location = new Point(12, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 378);
            panel1.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.Location = new Point(20, 20);
            lblId.Name = "lblId";
            lblId.Size = new Size(100, 23);
            lblId.TabIndex = 0;
            lblId.Text = "ID Transacción:";
            // 
            // txtIdTransaccion
            // 
            txtIdTransaccion.Location = new Point(120, 17);
            txtIdTransaccion.Name = "txtIdTransaccion";
            txtIdTransaccion.Size = new Size(150, 23);
            txtIdTransaccion.TabIndex = 1;
            // 
            // lblNumAsiento
            // 
            lblNumAsiento.Location = new Point(20, 50);
            lblNumAsiento.Name = "lblNumAsiento";
            lblNumAsiento.Size = new Size(100, 23);
            lblNumAsiento.TabIndex = 2;
            lblNumAsiento.Text = "No. Asiento:";
            // 
            // txtNumeroAsiento
            // 
            txtNumeroAsiento.Location = new Point(120, 47);
            txtNumeroAsiento.Name = "txtNumeroAsiento";
            txtNumeroAsiento.Size = new Size(150, 23);
            txtNumeroAsiento.TabIndex = 3;
            // 
            // lblFecha
            // 
            lblFecha.Location = new Point(301, 20);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(53, 23);
            lblFecha.TabIndex = 4;
            lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(360, 17);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(200, 23);
            dtpFecha.TabIndex = 5;
            // 
            // lblDesc
            // 
            lblDesc.Location = new Point(20, 80);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(100, 23);
            lblDesc.TabIndex = 6;
            lblDesc.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 77);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(620, 23);
            txtDescripcion.TabIndex = 7;
            // 
            // dgvMovimientos
            // 
            dgvMovimientos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMovimientos.Location = new Point(20, 120);
            dgvMovimientos.Name = "dgvMovimientos";
            dgvMovimientos.Size = new Size(720, 180);
            dgvMovimientos.TabIndex = 8;
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.ForestGreen;
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(620, 320);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(120, 40);
            btnExportar.TabIndex = 9;
            btnExportar.Text = "Exportar XML";
            btnExportar.UseVisualStyleBackColor = false;
            btnExportar.Click += btnExportar_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(Titulo);
            Name = "Form1";
            Text = "Maderera Madeco PushApp";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMovimientos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label Titulo;
        private Panel panel1;
        private Label lblId, lblNumAsiento, lblFecha, lblDesc;
        private TextBox txtIdTransaccion, txtNumeroAsiento, txtDescripcion;
        private DateTimePicker dtpFecha;
        private DataGridView dgvMovimientos;
        private Button btnExportar;
    }
}