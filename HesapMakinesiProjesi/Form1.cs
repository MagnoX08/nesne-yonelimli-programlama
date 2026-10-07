using System;
using System.Drawing;
using System.Windows.Forms;

namespace HesapMakinesiProjesi
{
    public partial class Form1 : Form
    {
        TextBox txtEkran;
        double mevcutDeger = 0;
        string aktifOperator = "";
        bool yeniGirdi = false;

        public Form1()
        {
            InitializeComponent();
            this.Controls.Clear();

            // Form Ayarları (Koyu Tema)
            this.Text = "Hesap Makinesi";
            this.Size = new Size(265, 360);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(32, 32, 32); // Antrasit Arka Plan

            // Ekran
            txtEkran = new TextBox();
            txtEkran.Font = new Font("Segoe UI", 24, FontStyle.Bold);
            txtEkran.Size = new Size(225, 50);
            txtEkran.Location = new Point(10, 15);
            txtEkran.ReadOnly = true;
            txtEkran.Text = "0";
            txtEkran.TextAlign = HorizontalAlignment.Right;
            txtEkran.BackColor = Color.FromArgb(32, 32, 32);
            txtEkran.ForeColor = Color.White;
            txtEkran.BorderStyle = BorderStyle.None; // Kenarlıkları yokederek modern görünüm sağla
            this.Controls.Add(txtEkran);

            // Buton Matrisi
            string[] tuslar = { "7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "C", "0", "=", "+" };
            int x = 10, y = 75;

            for (int i = 0; i < tuslar.Length; i++)
            {
                Button btn = new Button();
                btn.Text = tuslar[i];
                btn.Size = new Size(55, 55);
                btn.Location = new Point(x, y);
                btn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                btn.FlatStyle = FlatStyle.Flat; // İşletim sistemi 3D efektini kapat
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;

                // Tuş İşlevine Göre Renklendirme ve Olay Atama
                if ("+-*/".Contains(tuslar[i]))
                {
                    btn.BackColor = Color.FromArgb(255, 153, 0); // Turuncu Operatörler
                    btn.Click += Operator_Girdisi;
                }
                else if (tuslar[i] == "=")
                {
                    btn.BackColor = Color.FromArgb(46, 204, 113); // Yeşil Eşittir
                    btn.Click += Esittir_Click;
                }
                else if (tuslar[i] == "C")
                {
                    btn.BackColor = Color.FromArgb(231, 76, 60); // Kırmızı Temizle
                    btn.Click += Temizle_Click;
                }
                else
                {
                    btn.BackColor = Color.FromArgb(64, 64, 64); // Gri Rakamlar
                    btn.Click += Rakam_Girdisi;
                }

                this.Controls.Add(btn);

                // Matris Kaydırma İşlemi
                x += 60;
                if ((i + 1) % 4 == 0) { x = 10; y += 60; }
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void Rakam_Girdisi(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (txtEkran.Text == "0" || yeniGirdi) { txtEkran.Clear(); yeniGirdi = false; }
            txtEkran.Text += btn.Text;
        }

        private void Operator_Girdisi(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            mevcutDeger = double.Parse(txtEkran.Text);
            aktifOperator = btn.Text;
            yeniGirdi = true;
        }

        private void Esittir_Click(object sender, EventArgs e)
        {
            double ikinciDeger = double.Parse(txtEkran.Text);
            switch (aktifOperator)
            {
                case "+": txtEkran.Text = (mevcutDeger + ikinciDeger).ToString(); break;
                case "-": txtEkran.Text = (mevcutDeger - ikinciDeger).ToString(); break;
                case "*": txtEkran.Text = (mevcutDeger * ikinciDeger).ToString(); break;
                case "/": txtEkran.Text = ikinciDeger == 0 ? "Hata" : (mevcutDeger / ikinciDeger).ToString(); break;
            }
            mevcutDeger = double.Parse(txtEkran.Text);
            aktifOperator = "";
            yeniGirdi = true;
        }

        private void Temizle_Click(object sender, EventArgs e)
        {
            txtEkran.Text = "0";
            mevcutDeger = 0;
            aktifOperator = "";
            yeniGirdi = false;
        }
    }
}