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
            button2 = new Button();
            panel1 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            loadEmployees = new Button();
            textLabelRnc = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            textBox1 = new TextBox();
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
            // button2
            // 
            button2.Location = new Point(364, 23);
            button2.Name = "button2";
            button2.Size = new Size(150, 23);
            button2.TabIndex = 1;
            button2.Text = "Guardar Datos en la BD";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(loadEmployees);
            panel1.Controls.Add(textLabelRnc);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(textBox1);
            panel1.Location = new Point(39, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(733, 504);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
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
            loadEmployees.Click += button4_Click;
            // 
            // textLabelRnc
            // 
            textLabelRnc.Location = new Point(201, 19);
            textLabelRnc.MaxLength = 9;
            textLabelRnc.Multiline = true;
            textLabelRnc.Name = "textLabelRnc";
            textLabelRnc.Size = new Size(183, 17);
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
            label2.Location = new Point(352, 97);
            label2.Name = "label2";
            label2.Size = new Size(148, 15);
            label2.TabIndex = 5;
            label2.Text = "Colaboradores registrados:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 97);
            label1.Name = "label1";
            label1.Size = new Size(215, 15);
            label1.TabIndex = 4;
            label1.Text = "Ingrese los datos de sus colaboradores: ";
            label1.Click += label1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 455);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(694, 33);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(352, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(356, 331);
            dataGridView1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(14, 115);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(315, 331);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
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
            Controls.Add(button2);
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
        private Button button2;
        private Panel panel1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button button3;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textLabelRnc;
        private Button loadEmployees;
        private Label label4;
        private DateTimePicker dateTimePicker1;
    }
}
