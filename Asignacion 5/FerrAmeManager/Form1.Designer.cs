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
            panel1 = new Panel();
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
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cBTipoEmpleado);
            panel1.Controls.Add(btnRegistrarEmpleado);
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
            panel1.Location = new Point(39, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 438);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // cBTipoEmpleado
            // 
            cBTipoEmpleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cBTipoEmpleado.FormattingEnabled = true;
            cBTipoEmpleado.Items.AddRange(new object[] { "Fijos", "Temporales", "Contratistas independientes" });
            cBTipoEmpleado.Location = new Point(110, 272);
            cBTipoEmpleado.Name = "cBTipoEmpleado";
            cBTipoEmpleado.Size = new Size(121, 23);
            cBTipoEmpleado.TabIndex = 25;
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
            txtBoxCargoNuevoEmpleado.MaxLength = 40;
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
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(84, 50);
            label2.Name = "label2";
            label2.Size = new Size(205, 30);
            label2.TabIndex = 26;
            label2.Text = "Ferreteria Americana";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(474, 500);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "FerrAme Manager";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
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
        private Label label2;
    }
}