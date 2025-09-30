using System.Diagnostics;

namespace akaryakıt_sistemi_projesi
{
    public partial class Form1 : Form
    {
        double D_benzin95 = 0, D_benzin97 = 0, D_mazot = 0, D_lpg = 0; // Depo miktarları
        double F_benzin95 = 0, F_benzin97 = 0, F_mazot = 0, F_lpg = 0; // Fiyatlar
        double E_benzin95 = 0, E_benzin97 = 0, E_mazot = 0, E_lpg = 0; // eklenen miktarlar
        double S_benzin95 = 0, S_benzin97 = 0, S_mazot = 0, S_lpg = 0; // satılan miktarlar
        string[] depo_bilgileri; // Depo bilgilerini tutan dizi
        string[] fiyat_bilgileri; // Fiyat bilgilerini tutan dizi

        public void txt_depo_oku()
        {
            depo_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            D_benzin95 = Convert.ToDouble(depo_bilgileri[0]);//alınan depo bilgisini 0. indise atıyoruz
            D_benzin97 = Convert.ToDouble(depo_bilgileri[1]);
            D_mazot = Convert.ToDouble(depo_bilgileri[2]);
            D_lpg = Convert.ToDouble(depo_bilgileri[3]);
        }

        public void depo_yaz()
        {
            label5.Text = D_benzin95.ToString("N");// yukarıda atadığımız depo bilgilerini label'lara yazıyoruz
            label6.Text = D_benzin97.ToString("N");
            label7.Text = D_mazot.ToString("N");
            label8.Text = D_lpg.ToString("N");
        }
        public void txt_fiyat_oku()
        {
            fiyat_bilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\fiyat.txt");
            F_benzin95 = Convert.ToDouble(fiyat_bilgileri[0]);
            F_benzin97 = Convert.ToDouble(fiyat_bilgileri[1]);
            F_mazot = Convert.ToDouble(fiyat_bilgileri[2]);
            F_lpg = Convert.ToDouble(fiyat_bilgileri[3]);
        }
        public void fiyat_yaz()
        {
            label13.Text = F_benzin95.ToString("N");// "N" formatı sayıyı sayı olarak gösterir
            label14.Text = F_benzin97.ToString("N");
            label15.Text = F_mazot.ToString("N");
            label16.Text = F_lpg.ToString("N");
        }

        public void progressbar_guncelle()
        {
            progressBar1.Value = Convert.ToInt16(D_benzin95);
            progressBar2.Value = Convert.ToInt16(D_benzin97);
            progressBar3.Value = Convert.ToInt16(D_mazot);
            progressBar4.Value = Convert.ToInt16(D_lpg);
        }

        public void numericupdown()
        {
            numericUpDown1.Maximum = decimal.Parse(D_benzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(D_benzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(D_mazot.ToString());
            numericUpDown4.Maximum = decimal.Parse(D_lpg.ToString());
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {


        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Akaryakıt istasyonu sistemi";
            progressBar1.Maximum = 1000;// Depo miktarlarını maximum 1000 olarak ayarlıyoruz
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            txt_depo_oku();
            depo_yaz();
            txt_fiyat_oku();
            fiyat_yaz();
            progressbar_guncelle();
            numericupdown();
            string[] yakit_türleri = { "Benzin 95", "Benzin 97", "Mazot", "LPG" };
            comboBox2.Items.AddRange(yakit_türleri);
            numericUpDown1.Enabled = false;//sayı arrtırma ve azaltma kutularını devre dışı bırakıyoruz
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;

            numericUpDown1.DecimalPlaces = 2;// Ondalık basamak sayısını 2 olarak ayarlıyoruz
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;

            numericUpDown1.Increment = 0.01M;// Artış miktarını 0.01 olarak ayarlıyoruz
            numericUpDown2.Increment = 0.01M;
            numericUpDown3.Increment = 0.01M;
            numericUpDown4.Increment = 0.01M;

            numericUpDown1.ReadOnly = true;//sayı arttırma ve azaltma yı sadece tıklayarak kullanalabilmesini sağlıyoruz
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                E_benzin95 = Convert.ToDouble(textBox1.Text);
                if (1000 < D_benzin95 + E_benzin95 || E_benzin95 < 0)
                {
                    textBox1.Text = "HATA!";
                }
                else
                {
                    depo_bilgileri[0] = Convert.ToString(E_benzin95 + D_benzin95);
                }
            }
            catch (Exception)
            {
                textBox1.Text = "HATA!";
            }
            try
            {
                E_benzin97 = Convert.ToDouble(textBox2.Text);
                if (1000 < D_benzin97 + E_benzin97 || E_benzin97 < 0)
                {
                    textBox2.Text = "HATA!";
                }
                else
                {
                    depo_bilgileri[1] = Convert.ToString(E_benzin97 + D_benzin97);
                }
            }
            catch (Exception)
            {
                textBox2.Text = "HATA!";
            }
            try
            {
                E_mazot = Convert.ToDouble(textBox3.Text);
                if (1000 < D_mazot + E_mazot || E_mazot < 0)
                {
                    textBox3.Text = "HATA!";
                }
                else
                {
                    depo_bilgileri[2] = Convert.ToString(E_mazot + D_mazot);
                }
            }
            catch (Exception)
            {
                textBox3.Text = "HATA!";
            }
            try
            {
                E_lpg = Convert.ToDouble(textBox4.Text);
                if (1000 < D_lpg + E_lpg || E_lpg < 0)
                {
                    textBox4.Text = "HATA!";
                }
                else
                {
                    depo_bilgileri[3] = Convert.ToString(E_lpg + D_lpg);
                }
            }
            catch (Exception)
            {
                textBox4.Text = "HATA!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depo_bilgileri);
            txt_depo_oku();
            depo_yaz();
            progressbar_guncelle();
            numericupdown();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                F_benzin95 = F_benzin95 + (F_benzin95 * Convert.ToDouble(textBox5.Text) / 100);
                fiyat_bilgileri[0] = Convert.ToString(F_benzin95);
            }
            catch (Exception)
            {
                textBox5.Text = "HATA!";
            }
            try
            {
                F_benzin97 = F_benzin97 + (F_benzin97 * Convert.ToDouble(textBox6.Text) / 100);
                fiyat_bilgileri[1] = Convert.ToString(F_benzin97);
            }
            catch (Exception)
            {
                textBox6.Text = "HATA!";
            }
            try
            {
                F_mazot = F_mazot + (F_mazot * Convert.ToDouble(textBox7.Text) / 100);
                fiyat_bilgileri[2] = Convert.ToString(F_mazot);
            }
            catch (Exception)
            {
                textBox7.Text = "HATA!";
            }
            try
            {
                F_lpg = F_lpg + (F_lpg * Convert.ToDouble(textBox8.Text) / 100);
                fiyat_bilgileri[3] = Convert.ToString(F_lpg);
            }
            catch (Exception)
            {
                textBox8.Text = "HATA!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyat_bilgileri);
            txt_fiyat_oku();
            fiyat_yaz();

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Benzin 95")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else if (comboBox2.Text == "Benzin 97")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
            }
            else if (comboBox2.Text == "Mazot")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
            }
            else if (comboBox2.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            label25.Text = "0,00 ₺";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Benzin 95")
            {
                S_benzin95 = Convert.ToDouble(numericUpDown1.Value);
                label25.Text = (S_benzin95 * F_benzin95).ToString("N") + " ₺";// "N" formatı sayıyı sayı olarak gösterir
                D_benzin95 = D_benzin95 - S_benzin95;
                depo_bilgileri[0] = Convert.ToString(D_benzin95);
            }
            else if (comboBox2.Text == "Benzin 97")
            {
                S_benzin97 = Convert.ToDouble(numericUpDown2.Value);
                label25.Text = (S_benzin97 * F_benzin97).ToString("N") + " ₺";
                D_benzin97 = D_benzin97 - S_benzin97;
                depo_bilgileri[1] = Convert.ToString(D_benzin97);
            }
            else if (comboBox2.Text == "Mazot")
            {
                S_mazot = Convert.ToDouble(numericUpDown3.Value);
                label25.Text = (S_mazot * F_mazot).ToString("N") + " ₺";
                D_mazot = D_mazot - S_mazot;
                depo_bilgileri[2] = Convert.ToString(D_mazot);
            }
            else if (comboBox2.Text == "LPG")
            {
                S_lpg = Convert.ToDouble(numericUpDown4.Value);
                label25.Text = (S_lpg * F_lpg).ToString("N") + " ₺";
                D_lpg = D_lpg - S_lpg;
                depo_bilgileri[3] = Convert.ToString(D_lpg);
            }
            numericUpDown1.Value=0;
            numericUpDown2.Value=0;
            numericUpDown3.Value=0;
            numericUpDown4.Value=0;
            depo_yaz();

        }
    }
}

