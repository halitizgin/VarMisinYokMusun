using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VarMisinYokMusun
{
    public partial class Hile : Form
    {
        public Hile()
        {
            InitializeComponent();
        }

        private void Hile_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            this.Location = new Point(form2.Location.X + this.Size.Width, form2.Location.Y);
            Color sari = ColorTranslator.FromHtml("#FFE400");
            for (int i = 0; i < form2.groupBox1.Controls.Count; i++)
            {
                Button button = (Button)groupBox1.Controls[i];
                button.FlatStyle = FlatStyle.Flat;
                int tag = Convert.ToInt32(form2.groupBox1.Controls[i].Tag.ToString().Replace(".", "").Replace(" ", "").Replace("₺", ""));
                if (tag < 1000)
                {
                    button.BackColor = Color.Blue;
                }
                else if (tag >= 1000 && tag <= 50000)
                {
                    button.BackColor = sari;
                }
                else if (tag >= 75000 && tag < 1000000)
                {
                    button.BackColor = Color.Red;
                }
                else if (tag == 1000000)
                {
                    button.BackColor = Color.Black;
                }
                groupBox1.Controls[i].Tag = form2.groupBox1.Controls[i].Tag;
            }
        }

        private void Button_tiklanma(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void butonlaruzerinegelindiginde(object sender, EventArgs e)
        {
            
        }

        private void butonlaruzerindenayrildiginda(object sender, EventArgs e)
        {
            
        }

        private void uzerinegelindiginde(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = true;
            Button tiklanan = (Button)sender;
            toolStripStatusLabel1.Text = tiklanan.Text + " nolu kutunun içindeki miktar: " + tiklanan.Tag;
        }

        private void uzerindenayrildiginda(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Visible = false;
            toolStripStatusLabel1.Text = "0 nolu kutunun içindeki miktar: 0 ₺";
        }
    }
}
