namespace FerrAmeManager
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
            button1 = new Button();
            btnActualizarTabla = new Button();
            panel1 = new Panel();
            label12 = new Label();
            label11 = new Label();
            cBTipoEmpleado = new ComboBox();
            btnRegistrarEmpleado = new Button();
            txtBoxCargoNuevoEmpleado = new TextBox();
            label10 = new Label();
            label9 = new Label();
            dTPNuevoEmpleado = new DateTimePicker();
            label8 = new Label();
            txtBoxSalarioNuevoEmpleado = new TextBox();
            label7 = new Label();
            txtBoxCedulaNuevoEmpleado = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label1 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            loadEmployees = new Button();
            textLabelRnc = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(549, 23);
            button1.Name = "button1";
            button1.Size = new Size(203, 23);
            button1.TabIndex = 0;
            button1.Text = "Generar Txt de los Datos de la DB";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnActualizarTabla
            // 
            btnActualizarTabla.Location = new Point(572, 86);
            btnActualizarTabla.Name = "btnActualizarTabla";
            btnActualizarTabla.Size = new Size(140, 26);
            btnActualizarTabla.TabIndex = 1;
            btnActualizarTabla.Text = "Guardar Cambios Tabla";
            btnActualizarTabla.UseVisualStyleBackColor = true;
            btnActualizarTabla.Click += btnActualizarTabla_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(cBTipoEmpleado);
            panel1.Controls.Add(btnRegistrarEmpleado);
            panel1.Controls.Add(btnActualizarTabla);
            panel1.Controls.Add(txtBoxCargoNuevoEmpleado);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(dTPNuevoEmpleado);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(txtBoxSalarioNuevoEmpleado);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtBoxCedulaNuevoEmpleado);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(loadEmployees);
            panel1.Controls.Add(textLabelRnc);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(39, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(733, 504);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.Location = new Point(14, 387);
            label12.Name = "label12";
            label12.Size = new Size(327, 20);
            label12.TabIndex = 27;
            label12.Text = "-----------------------------------------------------";
            label12.Click += label12_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(14, 446);
            label11.Name = "label11";
            label11.Size = new Size(105, 15);
            label11.TabIndex = 26;
            label11.Text = "Ruta seleccionada:";
            // 
            // cBTipoEmpleado
            // 
            cBTipoEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cBTipoEmpleado.FormattingEnabled = true;
            cBTipoEmpleado.Items.AddRange(new object[] { "Fijos", "Temporales", "Contratstas independientes" });
            cBTipoEmpleado.Location = new Point(110, 272);
            cBTipoEmpleado.Name = "cBTipoEmpleado";
            cBTipoEmpleado.Size = new Size(121, 23);
            cBTipoEmpleado.TabIndex = 25;
            cBTipoEmpleado.SelectedIndexChanged += comboBox1_SelectedIndexChanged_1;
            // 
            // btnRegistrarEmpleado
            // 
            btnRegistrarEmpleado.Location = new Point(21, 349);
            btnRegistrarEmpleado.Name = "btnRegistrarEmpleado";
            btnRegistrarEmpleado.Size = new Size(75, 23);
            btnRegistrarEmpleado.TabIndex = 24;
            btnRegistrarEmpleado.Text = "Registrar";
            btnRegistrarEmpleado.UseVisualStyleBackColor = true;
            btnRegistrarEmpleado.Click += btnGuardar_Click;
            // 
            // txtBoxCargoNuevoEmpleado
            // 
            txtBoxCargoNuevoEmpleado.Location = new Point(66, 307);
            txtBoxCargoNuevoEmpleado.MaxLength = 9;
            txtBoxCargoNuevoEmpleado.Multiline = true;
            txtBoxCargoNuevoEmpleado.Name = "txtBoxCargoNuevoEmpleado";
            txtBoxCargoNuevoEmpleado.Size = new Size(143, 20);
            txtBoxCargoNuevoEmpleado.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(21, 310);
            label10.Name = "label10";
            label10.Size = new Size(39, 15);
            label10.TabIndex = 22;
            label10.Text = "Cargo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(19, 274);
            label9.Name = "label9";
            label9.Size = new Size(86, 15);
            label9.TabIndex = 20;
            label9.Text = "Tipo empleado";
            // 
            // dTPNuevoEmpleado
            // 
            dTPNuevoEmpleado.CustomFormat = "";
            dTPNuevoEmpleado.Format = DateTimePickerFormat.Custom;
            dTPNuevoEmpleado.Location = new Point(110, 231);
            dTPNuevoEmpleado.Name = "dTPNuevoEmpleado";
            dTPNuevoEmpleado.Size = new Size(127, 23);
            dTPNuevoEmpleado.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 234);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 18;
            label8.Text = "Fecha Ingreso";
            // 
            // txtBoxSalarioNuevoEmpleado
            // 
            txtBoxSalarioNuevoEmpleado.Location = new Point(69, 192);
            txtBoxSalarioNuevoEmpleado.MaxLength = 9;
            txtBoxSalarioNuevoEmpleado.Multiline = true;
            txtBoxSalarioNuevoEmpleado.Name = "txtBoxSalarioNuevoEmpleado";
            txtBoxSalarioNuevoEmpleado.Size = new Size(143, 20);
            txtBoxSalarioNuevoEmpleado.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 195);
            label7.Name = "label7";
            label7.Size = new Size(42, 15);
            label7.TabIndex = 16;
            label7.Text = "Salario";
            label7.Click += label7_Click;
            // 
            // txtBoxCedulaNuevoEmpleado
            // 
            txtBoxCedulaNuevoEmpleado.Location = new Point(69, 155);
            txtBoxCedulaNuevoEmpleado.MaxLength = 11;
            txtBoxCedulaNuevoEmpleado.Multiline = true;
            txtBoxCedulaNuevoEmpleado.Name = "txtBoxCedulaNuevoEmpleado";
            txtBoxCedulaNuevoEmpleado.Size = new Size(143, 20);
            txtBoxCedulaNuevoEmpleado.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 158);
            label6.Name = "label6";
            label6.Size = new Size(44, 15);
            label6.TabIndex = 14;
            label6.Text = "Cédula";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(151, 115);
            label5.Name = "label5";
            label5.Size = new Size(195, 20);
            label5.TabIndex = 13;
            label5.Text = "-------------------------------";
            label5.Click += label5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 115);
            label1.Name = "label1";
            label1.Size = new Size(140, 20);
            label1.TabIndex = 12;
            label1.Text = "Registrar Empleado";
            label1.Click += label1_Click_1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MMMM yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(117, 53);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(127, 23);
            dateTimePicker1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 59);
            label4.Name = "label4";
            label4.Size = new Size(97, 15);
            label4.TabIndex = 9;
            label4.Text = "Periodo Nominal";
            // 
            // loadEmployees
            // 
            loadEmployees.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadEmployees.Location = new Point(390, 16);
            loadEmployees.Name = "loadEmployees";
            loadEmployees.Size = new Size(134, 21);
            loadEmployees.TabIndex = 4;
            loadEmployees.Text = "Cargar Colaboradores";
            loadEmployees.UseVisualStyleBackColor = true;
            loadEmployees.Click += button4_Click_1;
            // 
            // textLabelRnc
            // 
            textLabelRnc.Location = new Point(201, 17);
            textLabelRnc.MaxLength = 9;
            textLabelRnc.Multiline = true;
            textLabelRnc.Name = "textLabelRnc";
            textLabelRnc.Size = new Size(183, 20);
            textLabelRnc.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 19);
            label3.Name = "label3";
            label3.Size = new Size(181, 15);
            label3.TabIndex = 6;
            label3.Text = "RNC de su empresa (sin guiones)";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(366, 97);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 5;
            label2.Text = "Colaboradores registrados:";
            label2.Click += label2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(11, 464);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(694, 33);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(366, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(346, 326);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // button3
            // 
            button3.Location = new Point(39, 23);
            button3.Name = "button3";
            button3.Size = new Size(178, 23);
            button3.TabIndex = 3;
            button3.Text = "Ruta para guardar el archivo";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 568);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button btnActualizarTabla;
        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button3;
        private TextBox textBox2;
        private Label label2;
        private Label label3;
        private TextBox textLabelRnc;
        private Button loadEmployees;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private Label label5;
        private Label label6;
        private TextBox txtBoxSalarioNuevoEmpleado;
        private Label label7;
        private TextBox txtBoxCedulaNuevoEmpleado;
        private Label label8;
        private Label label9;
        private DateTimePicker dTPNuevoEmpleado;
        private Button btnRegistrarEmpleado;
        private Label label10;
        private ComboBox cBTipoEmpleado;
        private TextBox txtBoxCargoNuevoEmpleado;
        private Label label12;
        private Label label11;
    }
}
