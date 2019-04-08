using System;
using System.Collections;
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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (Ayar.Default.hile == true && form2.kalanKutular.Count == 2 && Ayar.Default.bilgi == false)
            {
                form2.hileSistemBilgi();
            }
            else
            {
                if (oyunBitti)
                form2.OyunBitti();
            }
        }

        public ArrayList paralar = new ArrayList();

        private void paraYenile()
        {
            paralar.Add("1 ₺");
            paralar.Add("2 ₺");
            paralar.Add("5 ₺");
            paralar.Add("10 ₺");
            paralar.Add("25 ₺");
            paralar.Add("50 ₺");
            paralar.Add("75 ₺");
            paralar.Add("100 ₺");
            paralar.Add("200 ₺");
            paralar.Add("300 ₺");
            paralar.Add("400 ₺");
            paralar.Add("500 ₺");
            paralar.Add("750 ₺");
            paralar.Add("1.000 ₺");
            paralar.Add("5.000 ₺");
            paralar.Add("10.000 ₺");
            paralar.Add("25.000 ₺");
            paralar.Add("50.000 ₺");
            paralar.Add("75.000 ₺");
            paralar.Add("100.000 ₺");
            paralar.Add("200.000 ₺");
            paralar.Add("300.000 ₺");
            paralar.Add("400.000 ₺");
            paralar.Add("500.000 ₺");
            paralar.Add("750.000 ₺");
            paralar.Add("1.000.000 ₺");
        }

        bool oyunBitti = false;

        private void Form3_Load(object sender, EventArgs e)
        {
            paraYenile();
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            int numara = form2.sonNumara;
            if (form2.kendiKutum == false)
            {
                label2.Text = numara + " nolu kutunun içinde bulunan miktar:";
            }
            else if (form2.kendiKutum == true)
            {
                label2.Text = "Kendi kutunuzun içinde bulunan miktar:";
                form2.kazanilanMiktar = label1.Text;
            }
            else if (form2.label3.Visible == true)
            {
                label2.Text = "Devam etseydiniz kazanacağınız miktar:";
            }
            timer1.Start();
        }

        int defa = 15;
        string gPara = "";


        private void timer1_Tick(object sender, EventArgs e)
        {
            defa--;
            Random rast = new Random();
            int rSayi = rast.Next(0, paralar.Count);
            label1.Text = paralar[rSayi].ToString();
            if (defa == 0)
            {
                timer1.Stop();
                Form2 form2 = (Form2)Application.OpenForms["Form2"];
                gPara = form2.sonPara;
                
                button1.Enabled = true;
                if (form2.kendiKutum == true)
                {
                    label1.Text = form2.benimKutum.Tag.ToString();
                    if (form2.label3.Visible == false)
                    {
                        form2.label3.Text = "Kazandığınız Miktar: " + form2.benimKutum.Tag.ToString();
                        oyunBitti = true;
                        if (form2.benimKutum.Tag.ToString() == "1.000.000 ₺" && form2.kalanKutular.Count == 2)
                        {
                            if (Ayar.Default.hile == false)
                            {
                                Ayar.Default.hile = true;
                                Ayar.Default.Save();
                            }
                        }
                    }
                }
                else
                {
                    form2.paraGotur(gPara);
                    label1.Text = gPara;
                }            
            }
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1.Enabled == false)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
                Form2 form2 = (Form2)Application.OpenForms["Form2"];
                if (Ayar.Default.hile == true && form2.kalanKutular.Count == 2 && Ayar.Default.bilgi == false)
                {
                    form2.hileSistemBilgi();
                }
            }
        }
    }
}
