using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCT2
{
    public partial class MainForm : Form
    {
        private ImageProcessor imageProcessor;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btSubmitImage_Click(object sender, EventArgs e)
        {
            try
            {
                pbImage1.Image = null;
                pbImage2.Image = null;

                imageProcessor.threadCount = Convert.ToInt32(cbThreadsNumber.Text);
                imageProcessor.maskSize = Convert.ToInt32(cbMaskSize.Text);
                pbImage1.Image = new Bitmap(imageProcessor.ChooseFile());

                imageProcessor.ProcessImage();

                pbImage2.Image = imageProcessor.newImage;

                Score score = imageProcessor.WriteNewFile();

                ShowScore(score);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int threadCount = Environment.ProcessorCount;

            for (int i = 1; i <= threadCount; i++)
            {
                cbThreadsNumber.Items.Add(i.ToString());
            }

            cbThreadsNumber.Text = threadCount.ToString();
            cbThreadsNumber.DropDownStyle = ComboBoxStyle.DropDownList;

            imageProcessor = new ImageProcessor();
            imageProcessor.threadCount = threadCount;

            cbMaskSize.Items.Add("3");
            cbMaskSize.Items.Add("5");
            cbMaskSize.Items.Add("7");

            cbMaskSize.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaskSize.Text = "3";
        }

        private void ShowScore(Score score)
        {
            string time = "";
            time += "N°. Threads: " + imageProcessor.threadCount.ToString() + "\n";
            time += "Máscara: " + imageProcessor.maskSize.ToString() + "x" + imageProcessor.maskSize.ToString() + "\n";
            time += "Leitura do arquivo: " + score.readFile.ToString() + " ms" + "\n";
            time += "Processamento da imagem: " + score.threadTime + " ms" + "\n";
            time += "Escrita do arquivo: " + score.writeFile.ToString() + " ms";


            MessageBox.Show(time);
            MessageBox.Show("O novo arquivo está disponível em \n" + score.path);
        }
    }
}
