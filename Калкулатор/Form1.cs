using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace Калкулатор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NumberFormatInfo info = new CultureInfo("en-US").NumberFormat;
        int brOperacii;
        bool saveko = false;
        Decimal vrednost;
        String operacija;
        bool sis = false;
        private void button(object sender, EventArgs e)
        {
            if(sis || textBox1.Text == "0")
            {
                textBox1.Clear();
            }
            Button b = (Button)sender;
            textBox1.Text += b.Text;
            sis = false;
            saveko = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            brOperacii++;

            if(brOperacii > 1)
            {
                switch(operacija)
                {
                    case "+":
                        Math.Round(vrednost += Decimal.Parse(textBox1.Text, info), 2);
                        break;
                    case "-":
                        Math.Round(vrednost -= Decimal.Parse(textBox1.Text, info), 2);
                        break;
                    case "*":
                        Math.Round(vrednost *= Decimal.Parse(textBox1.Text, info), 2);
                        break;
                    case "/":
                        Math.Round(vrednost /= Decimal.Parse(textBox1.Text, info), 2);
                        break;
                }
            }
            else
            {
                vrednost = Math.Round(Decimal.Parse(textBox1.Text, info), 2);
            }
            operacija = b.Text;
            label1.Text = vrednost + " " + operacija;
            sis = true;
            saveko = false;
        }

        private void ednakvo_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            switch (operacija)
            {
                case "+":
                    textBox1.Text = ( Math.Round(vrednost += Decimal.Parse(textBox1.Text, info), 2)).ToString();
                    break;
                case "-":
                    textBox1.Text = ( Math.Round(vrednost -= Decimal.Parse(textBox1.Text, info), 2)).ToString();
                    break;
                case "*":
                    textBox1.Text = ( Math.Round(vrednost *= Decimal.Parse(textBox1.Text, info), 2)).ToString();
                    break;
                case "/":
                    textBox1.Text =  ( Math.Round(vrednost / Decimal.Parse(textBox1.Text, info), 2)).ToString();
                    break;
            }
            vrednost = 0;
            brOperacii = 0;
            sis = true;
            saveko = true;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
            vrednost = 0;
            brOperacii = 0;
            sis = false;
        }

        private void зачувувањеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveko == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Text File|*.txt";
                save.Title = "Зачувај како";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(File.Create(save.FileName));
                    sw.WriteLine(textBox1.Text);
                    sw.Close();
                }
            }
            else
            {

                var x = MessageBox.Show("Грешка\n\r01x010589", "Грешка", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
}
