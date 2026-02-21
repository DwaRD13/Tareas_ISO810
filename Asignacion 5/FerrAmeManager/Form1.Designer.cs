namespace FerrAmeManager
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
            panel1 = new System.Windows.Forms.Panel();
            cBTipoEmpleado = new System.Windows.Forms.ComboBox();
            btnRegistrarEmpleado = new System.Windows.Forms.Button();
            txtBoxCargoNuevoEmpleado = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            dTPNuevoEmpleado = new System.Windows.Forms.DateTimePicker();
            label8 = new System.Windows.Forms.Label();
            txtBoxSalarioNuevoEmpleado = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            txtBoxCedulaNuevoEmpleado = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            loadEmployees = new System.Windows.Forms.Button();
            textLabelRnc = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
            panel1.Controls.Add(loadEmployees);
            panel1.Controls.Add(textLabelRnc);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new System.Drawing.Point(39, 30);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(733, 490);
            panel1.TabIndex = 2;
            panel1.Paint += new System.Windows.Forms.PaintEventHandler(panel1_Paint);
            // 
            // cBTipoEmpleado
            // 
            cBTipoEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cBTipoEmpleado.FormattingEnabled = true;
            cBTipoEmpleado.Items.AddRange(new object[] {
            "Fijos",
            "Temporales",
            "Contratistas independientes"});
            cBTipoEmpleado.Location = new System.Drawing.Point(110, 272);
            cBTipoEmpleado.Name = "cBTipoEmpleado";
            cBTipoEmpleado.Size = new System.Drawing.Size(121, 23);
            cBTipoEmpleado.TabIndex = 25;
            // 
            // btnRegistrarEmpleado
            // 
            btnRegistrarEmpleado.Location = new System.Drawing.Point(21, 349);
            btnRegistrarEmpleado.Name = "btnRegistrarEmpleado";
            btnRegistrarEmpleado.Size = new System.Drawing.Size(75, 23);
            btnRegistrarEmpleado.TabIndex = 24;
            btnRegistrarEmpleado.Text = "Registrar";
            btnRegistrarEmpleado.UseVisualStyleBackColor = true;
            btnRegistrarEmpleado.Click += new System.EventHandler(btnRegistrarEmpleado_Click);
            // 
            // txtBoxCargoNuevoEmpleado
            // 
            txtBoxCargoNuevoEmpleado.Location = new System.Drawing.Point(66, 307);
            txtBoxCargoNuevoEmpleado.MaxLength = 40;
            txtBoxCargoNuevoEmpleado.Multiline = true;
            txtBoxCargoNuevoEmpleado.Name = "txtBoxCargoNuevoEmpleado";
            txtBoxCargoNuevoEmpleado.Size = new System.Drawing.Size(143, 20);
            txtBoxCargoNuevoEmpleado.TabIndex = 23;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(21, 310);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(39, 15);
            label10.TabIndex = 22;
            label10.Text = "Cargo";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(19, 274);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(86, 15);
            label9.TabIndex = 20;
            label9.Text = "Tipo empleado";
            // 
            // dTPNuevoEmpleado
            // 
            dTPNuevoEmpleado.CustomFormat = "";
            dTPNuevoEmpleado.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dTPNuevoEmpleado.Location = new System.Drawing.Point(110, 231);
            dTPNuevoEmpleado.Name = "dTPNuevoEmpleado";
            dTPNuevoEmpleado.Size = new System.Drawing.Size(127, 23);
            dTPNuevoEmpleado.TabIndex = 19;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(21, 234);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(80, 15);
            label8.TabIndex = 18;
            label8.Text = "Fecha Ingreso";
            // 
            // txtBoxSalarioNuevoEmpleado
            // 
            txtBoxSalarioNuevoEmpleado.Location = new System.Drawing.Point(69, 192);
            txtBoxSalarioNuevoEmpleado.MaxLength = 9;
            txtBoxSalarioNuevoEmpleado.Multiline = true;
            txtBoxSalarioNuevoEmpleado.Name = "txtBoxSalarioNuevoEmpleado";
            txtBoxSalarioNuevoEmpleado.Size = new System.Drawing.Size(143, 20);
            txtBoxSalarioNuevoEmpleado.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(21, 195);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(42, 15);
            label7.TabIndex = 16;
            label7.Text = "Salario";
            // 
            // txtBoxCedulaNuevoEmpleado
            // 
            txtBoxCedulaNuevoEmpleado.Location = new System.Drawing.Point(69, 155);
            txtBoxCedulaNuevoEmpleado.MaxLength = 11;
            txtBoxCedulaNuevoEmpleado.Multiline = true;
            txtBoxCedulaNuevoEmpleado.Name = "txtBoxCedulaNuevoEmpleado";
            txtBoxCedulaNuevoEmpleado.Size = new System.Drawing.Size(143, 20);
            txtBoxCedulaNuevoEmpleado.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(19, 158);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(44, 15);
            label6.TabIndex = 14;
            label6.Text = "Cédula";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label5.Location = new System.Drawing.Point(151, 115);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(195, 20);
            label5.TabIndex = 13;
            label5.Text = "-------------------------------";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(14, 115);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(140, 20);
            label1.TabIndex = 12;
            label1.Text = "Registrar Empleado";
            // 
            // loadEmployees
            // 
            loadEmployees.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            loadEmployees.Location = new System.Drawing.Point(390, 16);
            loadEmployees.Name = "loadEmployees";
            loadEmployees.Size = new System.Drawing.Size(134, 21);
            loadEmployees.TabIndex = 4;
            loadEmployees.Text = "Cargar Colaboradores";
            loadEmployees.UseVisualStyleBackColor = true;
            loadEmployees.Click += new System.EventHandler(loadEmployees_Click);
            // 
            // textLabelRnc
            // 
            textLabelRnc.Location = new System.Drawing.Point(201, 17);
            textLabelRnc.MaxLength = 9;
            textLabelRnc.Multiline = true;
            textLabelRnc.Name = "textLabelRnc";
            textLabelRnc.Size = new System.Drawing.Size(183, 20);
            textLabelRnc.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(14, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(181, 15);
            label3.TabIndex = 6;
            label3.Text = "RNC de su empresa (sin guiones)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(366, 97);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(148, 15);
            label2.TabIndex = 5;
            label2.Text = "Colaboradores de la Empresa:";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(366, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new System.Drawing.Size(346, 346);
            dataGridView1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 540);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "FerrAme Manager";
            Load += new System.EventHandler(Form1_Load);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cBTipoEmpleado;
        private System.Windows.Forms.Button btnRegistrarEmpleado;
        private System.Windows.Forms.TextBox txtBoxCargoNuevoEmpleado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dTPNuevoEmpleado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBoxSalarioNuevoEmpleado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBoxCedulaNuevoEmpleado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loadEmployees;
        private System.Windows.Forms.TextBox textLabelRnc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}