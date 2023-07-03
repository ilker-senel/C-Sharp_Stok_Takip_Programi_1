using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stok_Takip_Programı
{
    public partial class frmKategori : Form
    {
        public frmKategori()
        {
            InitializeComponent();
        }

        SqlBaglantim bgl = new SqlBaglantim();
        bool durum;
        private void KategoriKontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("select *from KategoriBilgileri", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (textBox1.Text == oku[0].ToString() || textBox1.Text == "")
                {
                    durum = false;
                }
            }
            bgl.baglanti().Close();
        }
        private void frmKategori_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                KategoriKontrol();
                if (durum == true)
                {

                    SqlCommand komut = new SqlCommand("insert into KategoriBilgileri(Kategori) values('" + textBox1.Text + "')"
                        , bgl.baglanti());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("kategori eklendi");
                }
                else
                {
                    MessageBox.Show("böyle bir kategori var", "Uyarı");
                }
                textBox1.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("bir hata oluştu");
            }
           

        }
    }
}
