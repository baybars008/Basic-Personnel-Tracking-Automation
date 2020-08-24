using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace personel_takip_sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\bin\Debug\personel.accdb
        //veri tabani dosya yolu ve proveider nesne belirleme
        OleDbConnection baglantı = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\personel.accdb");
        //OleDbConnection baglantı = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=.\personel.accdb");
        //formlar arası kullanılacak olan deüişkenlerim
        public static string tcno, adi, soyadi, yetki;

        //bu formda geçerli olacak olan değişkenler
        int hak = 3;bool durum = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if(hak!=0)
            {
                baglantı.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from kullanicilar", baglantı);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                while(kayitokuma.Read())
                {
                    if(radioButton1.Checked==true)
                    {
                        
                        if(kayitokuma["kullaniciadi"].ToString()==textBox1.Text && kayitokuma["parola"].ToString()==textBox2.Text && kayitokuma["yetki"].ToString()=="Yönetici")
                        {
                            durum = true;
                            tcno = kayitokuma.GetValue(0).ToString();
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                            this.Hide();
                            Form2 frm2 = new Form2();
                            frm2.Show();
                            break; //while dögüsü sürekli çalışmasın diye bu komutla döngüden çıkılır.
                        }
                    }

                    if (radioButton2.Checked == true)
                    {
                        if (kayitokuma["kullaniciadi"].ToString() == textBox1.Text && kayitokuma["parola"].ToString() == textBox2.Text && kayitokuma["yetki"].ToString() == "Kullanıcı")
                        {
                            durum = true;
                            tcno = kayitokuma.GetValue(0).ToString();
                            adi = kayitokuma.GetValue(1).ToString();
                            soyadi = kayitokuma.GetValue(2).ToString();
                            yetki = kayitokuma.GetValue(3).ToString();
                            this.Hide();
                            Form3 frm3 = new Form3();
                            frm3.Show();
                            break; //while dögüsü sürekli çalışmasın diye bu komutla döngüden çıkılır.
                        }
                    }
                }
                if (durum == false)
                    hak--;
                baglantı.Close();
            }
            label5.Text = Convert.ToString(hak);
            if(hak==0)
            {
                button1.Enabled = false;
                MessageBox.Show("Giriş Hakkı Kalmadı", "Baybars Personel Takip Sistemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Kullanıcı Girişi";
            this.AcceptButton = button1;this.CancelButton = button2; //buton1 = enter yani giriş , buton2 esc yani çıkış
            label5.Text = Convert.ToString(hak);
            radioButton1.Checked = true;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label111_Click(object sender, EventArgs e)
        {

        }

        private void dsadsasa_Click(object sender, EventArgs e)
        {
                    }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
