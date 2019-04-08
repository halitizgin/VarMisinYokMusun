using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VarMisinYokMusun
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text.Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            form2.OyunBitti();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            if (Ayar.Default.bilgi == false)
            {
                textBox1.Text = Ayar.Default.hilesifre.Trim();
                Ayar.Default.bilgi = true;
                Ayar.Default.Save();
            }
            else
            {
                this.Hide();
            }
        }
    }
}
