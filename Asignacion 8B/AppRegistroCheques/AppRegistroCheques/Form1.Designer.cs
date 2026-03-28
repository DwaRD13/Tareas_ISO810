namespace AppRegistroCheques
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
            label1 = new Label();
            txtCheque = new TextBox();
            txtConcepto = new TextBox();
            label2 = new Label();
            txtCedula = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dtpFecha = new DateTimePicker();
            txtMontoNum = new TextBox();
            label5 = new Label();
            txtMontoLetra = new TextBox();
            label6 = new Label();
            txtFactura = new TextBox();
            label7 = new Label();
            btnGuardar = new Button();
            btnVerFactura = new Button();
            dgvDatabase = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDatabase).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(27, 35);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "No. Cheque";
            label1.Click += label1_Click;
            // 
            // txtCheque
            // 
            txtCheque.Location = new Point(27, 63);
            txtCheque.Name = "txtCheque";
            txtCheque.Size = new Size(113, 23);
            txtCheque.TabIndex = 1;
            // 
            // txtConcepto
            // 
            txtConcepto.Location = new Point(27, 148);
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Size = new Size(113, 23);
            txtConcepto.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(27, 112);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 2;
            label2.Text = "Concepto de Pago";
            // 
            // txtCedula
            // 
            txtCedula.Location = new Point(27, 234);
            txtCedula.Name = "txtCedula";
            txtCedula.Size = new Size(113, 23);
            txtCedula.TabIndex = 5;
            txtCedula.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(27, 198);
            label3.Name = "label3";
            label3.Size = new Size(84, 15);
            label3.TabIndex = 4;
            label3.Text = "Cédula Cliente";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(27, 285);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 6;
            label4.Text = "Fecha";
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(27, 319);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(135, 23);
            dtpFecha.TabIndex = 7;
            // 
            // txtMontoNum
            // 
            txtMontoNum.Location = new Point(183, 63);
            txtMontoNum.Name = "txtMontoNum";
            txtMontoNum.Size = new Size(113, 23);
            txtMontoNum.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Location = new Point(183, 27);
            label5.Name = "label5";
            label5.Size = new Size(90, 15);
            label5.TabIndex = 8;
            label5.Text = "Monto Número";
            // 
            // txtMontoLetra
            // 
            txtMontoLetra.Location = new Point(183, 148);
            txtMontoLetra.Name = "txtMontoLetra";
            txtMontoLetra.Size = new Size(113, 23);
            txtMontoLetra.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Location = new Point(183, 112);
            label6.Name = "label6";
            label6.Size = new Size(72, 15);
            label6.TabIndex = 10;
            label6.Text = "Monto Letra";
            // 
            // txtFactura
            // 
            txtFactura.Location = new Point(183, 234);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(113, 23);
            txtFactura.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Location = new Point(183, 198);
            label7.Name = "label7";
            label7.Size = new Size(46, 15);
            label7.TabIndex = 12;
            label7.Text = "Factura";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.ActiveCaption;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(183, 319);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(113, 51);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnVerFactura
            // 
            btnVerFactura.BackColor = SystemColors.ActiveCaption;
            btnVerFactura.FlatStyle = FlatStyle.Flat;
            btnVerFactura.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVerFactura.Location = new Point(314, 319);
            btnVerFactura.Name = "btnVerFactura";
            btnVerFactura.Size = new Size(113, 51);
            btnVerFactura.TabIndex = 15;
            btnVerFactura.Text = "Ver Factura";
            btnVerFactura.UseVisualStyleBackColor = false;
            btnVerFactura.Click += btnVerFactura_Click;
            // 
            // dgvDatabase
            // 
            dgvDatabase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatabase.Location = new Point(27, 424);
            dgvDatabase.Name = "dgvDatabase";
            dgvDatabase.Size = new Size(400, 255);
            dgvDatabase.TabIndex = 16;
            dgvDatabase.CellContentClick += dgvDatabase_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(689, 720);
            Controls.Add(dgvDatabase);
            Controls.Add(btnVerFactura);
            Controls.Add(btnGuardar);
            Controls.Add(txtFactura);
            Controls.Add(label7);
            Controls.Add(txtMontoLetra);
            Controls.Add(label6);
            Controls.Add(txtMontoNum);
            Controls.Add(label5);
            Controls.Add(dtpFecha);
            Controls.Add(label4);
            Controls.Add(txtCedula);
            Controls.Add(label3);
            Controls.Add(txtConcepto);
            Controls.Add(label2);
            Controls.Add(txtCheque);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatabase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtCheque;
        private TextBox txtConcepto;
        private Label label2;
        private TextBox txtCedula;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpFecha;
        private TextBox txtMontoNum;
        private Label label5;
        private TextBox txtMontoLetra;
        private Label label6;
        private TextBox txtFactura;
        private Label label7;
        private Button btnGuardar;
        private Button btnVerFactura;
        private DataGridView dgvDatabase;
    }
}
