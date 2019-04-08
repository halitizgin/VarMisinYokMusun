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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2.kazanilanMiktar != "0")
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
            }
            timer1.Start();
            islemYenile();
            sayiYenile();
        }

        int defa = 20;
        ArrayList miktarlar = new ArrayList();

        private string fix(string veri)
        {
            return veri.Replace(".", "").Replace(" ", "").Replace("₺", "");
        }

        ArrayList sayilar = new ArrayList();
        ArrayList islemler = new ArrayList();

        private void islemYenile()
        {
            islemler.Add("Ekle");
            islemler.Add("Sil");
            islemler.Add("Ekle");
            islemler.Add("Sil");
        }

        private void sayiYenile()
        {
            sayilar.Add(5);
            sayilar.Add(10);
            sayilar.Add(15);
            sayilar.Add(20);
            sayilar.Add(55);
            sayilar.Add(60);
            sayilar.Add(75);
            sayilar.Add(100);
            sayilar.Add(102);
            sayilar.Add(150);
            sayilar.Add(200);
            sayilar.Add(1000);
            sayilar.Add(1250);
            sayilar.Add(2000);
            sayilar.Add(10000);
            sayilar.Add(11000);
        }

        private int aritmetik(ArrayList veriler)
        {
            int toplam = 0;
            for (int i = 0; i < veriler.Count; i++)
            {
                toplam += Convert.ToInt32(veriler[i]);
            }
            int aritmetik = toplam / veriler.Count;
            return aritmetik;
        }

        private string parayaCevir(string para)
        {
            string basamak = String.Format("{0:N}", Convert.ToInt32(para));
            basamak = basamak.Replace(",00", "");
            basamak += " ₺";
            return basamak;
        }

        private int teklifDusur(int teklif)
        {
            
            if (teklif > 500000)
            {
                teklif -= 500000;
            }
            else if (teklif > 400000)
            {
                teklif -= 400000;
            }
            else if (teklif > 300000)
            {
                teklif -= 300000;
            }
            else if (teklif > 200000)
            {
                teklif -= 200000;
            }
            else if (teklif > 100000)
            {
                teklif -= 100000;
            }
            Random rast = new Random();
            if (teklif < 10000)
            {
                teklif += rast.Next(2000, 20000);
            }
            return teklif;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            Random rast = new Random();
            string kaba = rast.Next(0, 1000000).ToString();
            label2.Text = parayaCevir(kaba);
            if (defa == 0)
            {
                timer1.Stop();
                Form2 form2 = (Form2)Application.OpenForms["Form2"];
                for (int i = 0; i < form2.kalanKutular.Count; i++)
                {
                    miktarlar.Add(Convert.ToInt32(fix(form2.kalanKutular[i].ToString())));
                }
                miktarlar.Sort();
                int teklif = aritmetik(miktarlar);
                baslangic:
                string islem = islemler[rast.Next(0, islemler.Count)].ToString();
                int sayi = Convert.ToInt32(sayilar[rast.Next(0, sayilar.Count)]);
                if (teklif > sayi)
                {
                    if (islem == "Ekle")
                    {
                        teklif += sayi;
                    }
                    else if (islem == "Sil")
                    {
                        teklif -= sayi;
                    }
                }
                else
                {
                    goto baslangic;
                }
                if (Ayar.Default.dusukTeklif > 0)
                {
                    Ayar.Default.dusukTeklif--;
                    Ayar.Default.Save();
                    teklif = teklifDusur(teklif);
                }
                label2.Text = parayaCevir(teklif.ToString());
                button1.Enabled = true;
                button2.Enabled = true;
            }
            defa--;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2.kalanKutular.Count == 2)
            {
                form2.gIslem = "Kutu açma";
                form2.kendiKutum = true;
                form2.ikiKutu();
            }
            form2.toolStripStatusLabel1.Text = "Açılacak kutuyu seçin...";
            form2.toolStripStatusLabel2.Text = "Teklife " + form2.teklifeKalan + " adet kutu kaldı...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2.kalanKutular.Count == 2)
            {
                this.Hide();
                form2.gIslem = "Kutu açma";
                form2.kendiKutum = true;
                form2.ikiKutu();
                Ayar.Default.devamEtseydin = true;
                Ayar.Default.Save();
            }
            else if (!Ayar.Default.devamEtseydin == true)
            {
                form2.kazanilanMiktar = label2.Text;
                form2.label4.Visible = true;
                form2.label3.Text = "Kazandığınız Miktar: " + label2.Text + " ₺";
                this.Hide();
                form2.tebrikler();
            }
            form2.toolStripStatusLabel1.Text = "Açılacak kutuyu seçin...";
            form2.toolStripStatusLabel2.Text = "Teklife " + form2.teklifeKalan + " adet kutu kaldı...";
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (button1.Enabled == false)
            {
                e.Cancel = true;
            }
            else
            {
                Form2 form2 = (Form2)Application.OpenForms["Form2"];
                if (form2.kalanKutular.Count == 21 || form2.kalanKutular.Count == 18 || form2.kalanKutular.Count == 15 || form2.kalanKutular.Count == 12 || form2.kalanKutular.Count == 9)
                {
                    form2.teklifeKalan = 3;
                }
                else if (form2.kalanKutular.Count <= 6 && form2.kalanKutular.Count >= 2)
                {
                    form2.teklifeKalan = 1;
                }
                form2.toolStripStatusLabel2.Text = "Teklife " + form2.teklifeKalan + " adet kutu kaldı...";
                form2.toolStripStatusLabel1.Text = "Açılacak kutuyu seçin...";
                e.Cancel = false;
            }
        }

        private void Tamam(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form2 = (Form2)Application.OpenForms["Form2"];
            if (form2.kalanKutular.Count == 2)
            {
                form2.gIslem = "Kutu açma";
                form2.kendiKutum = true;
                form2.ikiKutu();
                Ayar.Default.devamEtseydin = true;
                Ayar.Default.Save();
            }
            form2.toolStripStatusLabel1.Text = "Açılacak kutuyu seçin...";
            form2.toolStripStatusLabel2.Text = "Teklife " + form2.teklifeKalan + " adet kutu kaldı...";
        }
    }
}
