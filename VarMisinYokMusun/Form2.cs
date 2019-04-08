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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string gIslem = "Kutu seç";
        public string sonPara = "";
        public int sonNumara = 0;
        public bool kendiKutum = false;

        public ArrayList kalanKutular = new ArrayList();

        private void kalanKutuYenile()
        {
            for (int i = 0; i < 26; i++)
            {
                kalanKutular.Add(groupBox1.Controls[i].Tag.ToString());
            }
        }

        public void ikiKutu()
        {
            if (kendiKutum == true)
            {
                Form3 form3 = new Form3();
                form3.label2.Text = "Kendi kutunuzun içindeki miktar:";
                form3.ShowDialog();
                sonPara = benimKutum.Tag.ToString();
            }
        }
    
        private void yukle()
        {
            birLira.Image = Resource1.birtl;
            ikiLira.Image = Resource1.ikitl;
            besLira.Image = Resource1.bestl;
            onLira.Image = Resource1.ontl;
            yirmiBesLira.Image = Resource1.yirmibestl;
            elliLira.Image = Resource1.ellitl;
            yetmisBesLira.Image = Resource1.yemisbestl;
            yuzLira.Image = Resource1.yuztl;
            ikiYuzLira.Image = Resource1.ikiyuztl;
            ucYuzLira.Image = Resource1.ucyuztl;
            dortYuzLira.Image = Resource1.dortyuztl;
            besYuzLira.Image = Resource1.besyuztl;
            yediYuzElliLira.Image = Resource1.yediyuzellitl;
            binLira.Image = Resource1.bintl;
            besBinLira.Image = Resource1.besbintl;
            onBinLira.Image = Resource1.onbintl;
            yirmiBesBinLira.Image = Resource1.yirmibesbin;
            elliBinLira.Image = Resource1.ellibin;
            yetmisBesBinLira.Image = Resource1.yetmisbesbin;
            yuzBinLira.Image = Resource1.yuzbintl;
            ikiYuzBinLira.Image = Resource1.ikiyuzbintl;
            ucYuzBinLira.Image = Resource1.ucyuzbintl;
            dortYuzBinLira.Image = Resource1.dortyuzbintl;
            besYuzBinLira.Image = Resource1.besyuzbintl;
            yediYuzElliBinLira.Image = Resource1.yediyuzellibintl;
            birMilyonLira.Image = Resource1.birmilyontl;
        }
        ArrayList paralar = new ArrayList();
        Random rast = new Random();

        private void tekYerlestir(Button button)
        {
            int sayi = rast.Next(0, paralar.Count);
            button.Tag = paralar[sayi];
            paralar.RemoveAt(sayi);
        }

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

        private void defaYerlestir(int defa)
        {
            for (int i = 0; i < defa; i++)
            {
                yerlestir();
            }
        }

        private void yerlestir()
        {
            paraYenile();
            tekYerlestir(button1);
            tekYerlestir(button2);
            tekYerlestir(button3);
            tekYerlestir(button4);
            tekYerlestir(button5);
            tekYerlestir(button6);
            tekYerlestir(button7);
            tekYerlestir(button8);
            tekYerlestir(button9);
            tekYerlestir(button10);
            tekYerlestir(button11);
            tekYerlestir(button12);
            tekYerlestir(button13);
            tekYerlestir(button14);
            tekYerlestir(button15);
            tekYerlestir(button16);
            tekYerlestir(button17);
            tekYerlestir(button18);
            tekYerlestir(button19);
            tekYerlestir(button20);
            tekYerlestir(button21);
            tekYerlestir(button22);
            tekYerlestir(button23);
            tekYerlestir(button24);
            tekYerlestir(button25);
            button26.Tag = paralar[0];
            paralar.RemoveAt(0);
        }

        public void tebrikler()
        {
            label3.Text = "Kazandığınız Miktar: " + kazanilanMiktar;
            label3.Visible = true;
            MessageBox.Show("Tebrikler.\nKazandığınız miktar: " + kazanilanMiktar, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ayarSifirla()
        {
            Ayar.Default.dusukTeklif = 3;
            Ayar.Default.devamEtseydin = false;
            Ayar.Default.Save();
        }

        private void hileKontrol()
        {
            menuStrip1.Items[1].Visible = Ayar.Default.hile;
        }

        public void OyunBitti()
        {
            Son son = new Son();
            son.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            yukle();
            defaYerlestir(5);
            kalanKutuYenile();
            ayarSifirla();
            hileKontrol();
        }

        public int teklifeKalan = 5;
        public string kazanilanMiktar = "0";

        public void paraGotur(string para)
        {
            para = para.Replace(" ", "");
            para = para.Replace(".", "");
            para = para.Replace("₺", "");
            if (para == birLira.Tag.ToString())
                birLira.Image = Resource1.mavibos;
            else if (para == ikiLira.Tag.ToString())
                ikiLira.Image = Resource1.mavibos;
            else if (para == besLira.Tag.ToString())
                besLira.Image = Resource1.mavibos;
            else if (para == onLira.Tag.ToString())
                onLira.Image = Resource1.mavibos;
            else if (para == yirmiBesLira.Tag.ToString())
                yirmiBesLira.Image = Resource1.mavibos;
            else if (para == elliLira.Tag.ToString())
                elliLira.Image = Resource1.mavibos;
            else if (para == yetmisBesLira.Tag.ToString())
                yetmisBesLira.Image = Resource1.mavibos;
            else if (para == yuzLira.Tag.ToString())
                yuzLira.Image = Resource1.mavibos;
            else if (para == ikiYuzLira.Tag.ToString())
                ikiYuzLira.Image = Resource1.mavibos;
            else if (para == ucYuzLira.Tag.ToString())
                ucYuzLira.Image = Resource1.mavibos;
            else if (para == dortYuzLira.Tag.ToString())
                dortYuzLira.Image = Resource1.mavibos;
            else if (para == besYuzLira.Tag.ToString())
                besYuzLira.Image = Resource1.mavibos;
            else if (para == yediYuzElliLira.Tag.ToString())
                yediYuzElliLira.Image = Resource1.mavibos;
            else if (para == binLira.Tag.ToString())
                binLira.Image = Resource1.saribos;
            else if (para == besBinLira.Tag.ToString())
                besBinLira.Image = Resource1.saribos;
            else if (para == onBinLira.Tag.ToString())
                onBinLira.Image = Resource1.saribos;
            else if (para == yirmiBesBinLira.Tag.ToString())
                yirmiBesBinLira.Image = Resource1.saribos;
            else if (para == elliBinLira.Tag.ToString())
                elliBinLira.Image = Resource1.saribos;
            else if (para == yetmisBesBinLira.Tag.ToString())
                yetmisBesBinLira.Image = Resource1.kirmizibos;
            else if (para == yuzBinLira.Tag.ToString())
                yuzBinLira.Image = Resource1.kirmizibos;
            else if (para == ikiYuzBinLira.Tag.ToString())
                ikiYuzBinLira.Image = Resource1.kirmizibos;
            else if (para == ucYuzBinLira.Tag.ToString())
                ucYuzBinLira.Image = Resource1.kirmizibos;
            else if (para == dortYuzBinLira.Tag.ToString())
                dortYuzBinLira.Image = Resource1.kirmizibos;
            else if (para == besYuzBinLira.Tag.ToString())
                besYuzBinLira.Image = Resource1.kirmizibos;
            else if (para == yediYuzElliBinLira.Tag.ToString())
                yediYuzElliBinLira.Image = Resource1.kirmizibos;
            else if (para == birMilyonLira.Tag.ToString())
                birMilyonLira.Image = Resource1.kirmizibos;
        }

        private string fix(string veri)
        {
            return veri.Replace(".", "").Replace(" ", "").Replace("₺", "");
        }

        private void kutu_tiklanma(object sender, EventArgs e)
        {
            if (gIslem == "Kutu seç")
            {
                Button tiklanan = (Button)sender;
                tiklanan.Visible = false;
                label1.Visible = false;
                benimKutum.Text = tiklanan.Text;
                benimKutum.Tag = tiklanan.Tag;
                gIslem = "Kutu aç";
                toolStripStatusLabel1.Text = "Açılacak kutuyu seçin...";
                toolStripStatusLabel2.Text = "Teklife " + teklifeKalan + " adet kutu kaldı...";
            }
            else if (gIslem == "Kutu aç")
            {
                Button tiklanan = (Button)sender;
                tiklanan.Enabled = false;
                string para = tiklanan.Tag.ToString();
                sonPara = para;
                sonNumara = Convert.ToInt32(tiklanan.Text);
                Form3 form3 = new Form3();
                form3.ShowDialog();
                kalanKutular.Remove(tiklanan.Tag.ToString());
                teklifeKalan--;
                if (teklifeKalan == 0)
                {
                    if (kalanKutular.Count == 21 || kalanKutular.Count == 18 || kalanKutular.Count == 15 || kalanKutular.Count == 12 || kalanKutular.Count == 9)
                    {
                        teklifeKalan = 3;
                    }
                    else if (kalanKutular.Count <= 6 && kalanKutular.Count >= 2)
                    {
                        teklifeKalan = 1;
                    }
                    toolStripStatusLabel1.Text = "Teklifi bekleyin...";
                    toolStripStatusLabel2.Text = "Teklife " + teklifeKalan + " adet kutu kaldı...";
                    Form4 form4 = new Form4();
                    form4.ShowDialog();
                }
                else
                {
                    toolStripStatusLabel1.Text = "Açılacak kutuyu seçin...";
                    toolStripStatusLabel2.Text = "Teklife " + teklifeKalan + " adet kutu kaldı...";
                }
            }
        }

        public void hileSistemBilgi()
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void hileSistemineGeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Ayar.Default.hile == true)
            {
                string sifre = Microsoft.VisualBasic.Interaction.InputBox("Hile sistemine erişebilmek için şifreyi giriniz:", "Şifre", "");
                if (sifre.Trim() == Ayar.Default.hilesifre.Trim())
                {
                    MessageBox.Show("Şifre doğru.\nHile sisteminin açılması için Tamam'a basın.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hile hile = new Hile();
                    hile.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonYenile()
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                groupBox1.Controls[i].Enabled = true;
                groupBox1.Controls[i].Visible = true;
            }
            benimKutum.Tag = null;
            benimKutum.Text = "?";
            label3.Visible = false;
            label4.Visible = false;
        }

        private void yeniOyunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Dispose();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
