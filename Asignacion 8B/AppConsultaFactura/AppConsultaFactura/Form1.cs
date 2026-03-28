using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace AppConsultaFactura
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Visor de Documentos Digitalizados";
            this.BackColor = Color.FromArgb(240, 242, 245);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length >= 8)
            {
                string numCheque = args[1];
                string concepto = args[2];
                string cedula = args[3];
                string fecha = args[4];
                string montoNum = args[5];
                string montoLetra = args[6];
                string factura = args[7];

                lblCedula.Text = $"Cédula del Cliente: {cedula}";

                try
                {
                    Bitmap facturaDibuja = GenerarFacturaDinamica(numCheque, concepto, cedula, fecha, montoNum, montoLetra, factura);
                    pictureBox1.Image = facturaDibuja;
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar la imagen: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("No se recibieron los parámetros necesarios para la generación.");
            }
        }

        private Bitmap GenerarFacturaDinamica(string numCheque, string concepto, string cedula, string fecha, string montoNum, string montoLetra, string factura)
        {
            Bitmap bmp = new Bitmap(800, 1100);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                g.Clear(Color.White);

                Color blueBrand = Color.FromArgb(0, 51, 102);
                Color graySoft = Color.FromArgb(245, 245, 245);
                Color grayText = Color.FromArgb(80, 80, 80);

                Font fontHeader = new Font("Segoe UI", 24, FontStyle.Bold);
                Font fontSection = new Font("Segoe UI", 12, FontStyle.Bold);
                Font fontData = new Font("Segoe UI", 11, FontStyle.Regular);
                Font fontLabel = new Font("Segoe UI", 10, FontStyle.Bold);
                Font fontAmount = new Font("Segoe UI", 16, FontStyle.Bold);

                g.FillRectangle(new SolidBrush(blueBrand), 0, 0, 800, 120);
                g.DrawString("COMPROBANTE DIGITAL", fontHeader, Brushes.White, 40, 40);

                g.FillEllipse(Brushes.White, 650, 30, 60, 60);
                g.DrawString("$", new Font("Arial", 30, FontStyle.Bold), new SolidBrush(blueBrand), 662, 35);

                g.DrawString("No. DOCUMENTO", fontLabel, Brushes.LightGray, 500, 30);
                g.DrawString(factura, fontData, Brushes.White, 500, 50);
                g.DrawString("FECHA", fontLabel, Brushes.LightGray, 500, 75);
                g.DrawString(fecha, fontData, Brushes.White, 500, 95);

                g.FillRectangle(new SolidBrush(graySoft), 40, 150, 720, 110);
                g.DrawRectangle(new Pen(Color.LightGray), 40, 150, 720, 110);

                g.DrawString("DATOS DEL BENEFICIARIO", fontSection, new SolidBrush(blueBrand), 60, 165);
                g.DrawString("ID / CÉDULA:", fontLabel, new SolidBrush(grayText), 60, 195);
                g.DrawString(cedula, fontData, Brushes.Black, 180, 195);
                g.DrawString("REFERENCIA:", fontLabel, new SolidBrush(grayText), 60, 220);
                g.DrawString(factura, fontData, Brushes.Black, 180, 220);

                int tableY = 300;
                g.DrawString("DETALLES DE LA TRANSACCIÓN", fontSection, new SolidBrush(blueBrand), 40, tableY);

                g.FillRectangle(new SolidBrush(blueBrand), 40, tableY + 30, 720, 40);
                g.DrawString("DESCRIPCIÓN DEL CONCEPTO", fontLabel, Brushes.White, 55, tableY + 42);
                g.DrawString("VALOR", fontLabel, Brushes.White, 650, tableY + 42);

                int rowY = tableY + 70;

                g.FillRectangle(new SolidBrush(Color.White), 40, rowY, 720, 45);
                g.DrawString("Pago mediante Cheque No.", fontData, Brushes.Black, 55, rowY + 12);
                g.DrawString(numCheque, fontLabel, Brushes.Black, 280, rowY + 12);
                g.DrawLine(new Pen(Color.LightGray), 40, rowY + 45, 760, rowY + 45);

                rowY += 45;
                g.FillRectangle(new SolidBrush(Color.FromArgb(252, 252, 252)), 40, rowY, 720, 45);
                g.DrawString("Concepto de Pago:", fontData, Brushes.Black, 55, rowY + 12);
                g.DrawString(concepto, fontData, Brushes.Black, 200, rowY + 12);
                g.DrawLine(new Pen(Color.LightGray), 40, rowY + 45, 760, rowY + 45);

                rowY += 45;
                g.FillRectangle(new SolidBrush(Color.White), 40, rowY, 720, 60);
                g.DrawString("Suma de:", fontData, Brushes.Black, 55, rowY + 15);
                Rectangle rectLetras = new Rectangle(140, rowY + 15, 600, 40);
                g.DrawString(montoLetra.ToUpper(), new Font("Segoe UI", 9, FontStyle.Italic), Brushes.Black, rectLetras);

                int totalY = rowY + 100;
                g.FillRectangle(new SolidBrush(blueBrand), 450, totalY, 310, 60);
                g.DrawString("TOTAL RD$", fontLabel, Brushes.White, 470, totalY + 20);
                g.DrawString(montoNum, fontAmount, Brushes.White, 580, totalY + 15);

                GraphicsState state = g.Save();
                g.TranslateTransform(150, 750);
                g.RotateTransform(-25);

                using (Pen stampPen = new Pen(Color.FromArgb(80, Color.ForestGreen), 5))
                {
                    g.DrawRectangle(stampPen, -120, -40, 240, 80);
                    g.DrawString("DIGITALIZADO", new Font("Impact", 24), new SolidBrush(Color.FromArgb(80, Color.ForestGreen)), -105, -30);
                }
                g.Restore(state);

                g.DrawString("Este documento es una copia fiel del registro electrónico original.", new Font("Segoe UI", 8), Brushes.Gray, 40, 1030);
                g.DrawString("Generado por el Sistema de Integración de Aplicaciones Propietarias v2.0", new Font("Segoe UI", 8), Brushes.Gray, 40, 1045);

                g.DrawLine(new Pen(blueBrand, 4), 40, 1070, 760, 1070);
            }

            return bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}