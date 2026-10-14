using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ödev1
{
    public partial class Form1 : Form
    {
        List<string> secilmeSirasi = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            foreach (string item in secilmeSirasi)
            {
                listBox3.Items.Add(item);
            }
        }
    

        

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Seçimi kaldırılanları takip listesinden çıkar
            for (int i = secilmeSirasi.Count - 1; i >= 0; i--)
            {
                if (!listBox2.SelectedItems.Contains(secilmeSirasi[i]))
                {
                    secilmeSirasi.RemoveAt(i);
                }
            }

            // 2. Yeni seçilenleri takip listesinin sonuna ekle (seçilme sırasını korur)
            foreach (var item in listBox2.SelectedItems)
            {
                string secilenMetin = item.ToString();
                if (!secilmeSirasi.Contains(secilenMetin))
                {
                    secilmeSirasi.Add(secilenMetin);
                }
            }

            // Sol taraftaki ListBox'a (listBox1) anında yazdır
            listBox1.Items.Clear();
            foreach (string item in secilmeSirasi)
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
