using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Programı
{
    public partial class frmMarka : Form
    {
        public frmMarka()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        bool durum;
        private void MarkaKontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("select *from MarkaBilgileri", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (comboBox1.Text == oku["Kategori"].ToString() && textBox1.Text == oku[1].ToString()
                    || textBox1.Text == "" || comboBox1.Text == "")
                {
                    durum = false;
                }
            }
            bgl.baglanti().Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MarkaKontrol();
                if (durum == true)
                {
                    SqlCommand komut = new SqlCommand("insert into MarkaBilgileri(Kategori,Marka) values" +
                        "('" + comboBox1.Text + "','" + textBox1.Text + "')"
                        , bgl.baglanti());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    textBox1.Text = "";
                    comboBox1.Text = "";
                    MessageBox.Show("marka eklendi");
                }
                else
                {
                    MessageBox.Show("Böyle bir marka var", "Uyarı");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("bir hata oluştu");
            }
          

        }


        private void frmMarka_Load(object sender, EventArgs e)
        {
            KategoriGetir();
        }

        private void KategoriGetir()
        {
            SqlCommand komut2 = new SqlCommand("select *from KategoriBilgileri", bgl.baglanti());
            SqlDataReader reader = komut2.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Kategori"].ToString());
            }
            bgl.baglanti().Close();
        }
    }
}
