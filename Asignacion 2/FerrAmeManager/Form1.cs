using Microsoft.Data.SqlClient;
using System.Data.SqlClient;

namespace FerrAmeManager
{
    public partial class Form1 : Form
    {
        string selectedFilePath = "";
        string query = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Por favor, seleccione una ruta para guardar el archivo.");
                return;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.Title = "Seleccione la ruta para guardar el archivo";
            saveFileDialog.FileName = ".txt";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                textBox2.Text = "La ruta seleccionada es: " + filePath;
                selectedFilePath = filePath;
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String rnc = textLabelRnc.Text;

            if (rnc.Length != 9)
            {
                MessageBox.Show("El RNC debe tener 9 dígitos.");

            }

            for (int i = 0; i < rnc.Length; i++)
            {
                if (!char.IsDigit(rnc[i]))
                {
                    MessageBox.Show("El RNC solo debe contener números.");
                    break;
                }
            }

            query = "SELECT Nombre FROM Empresas WHERE RNC = @RNC";

        }

    }

}
