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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stok_Takip_Programı
{
    public partial class frmUrunEkle : Form
    {

        public frmUrunEkle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        bool durum;
        private void BarkodNoKontrol()
        {
            durum = true;
            SqlCommand komut = new SqlCommand("select *from Urun", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                if (txtBarkodNo.Text == oku["BarkodNo"].ToString() || txtBarkodNo.Text == "")
                {
                    durum = false;
                }
            }
            bgl.baglanti().Close();
        }
        private void frmUrunEkle_Load(object sender, EventArgs e)
        {
            KategoriGetir();
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;//önemli
            cmbMarka.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarka_.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void KategoriGetir()
        {
            SqlCommand komut2 = new SqlCommand("select *from KategoriBilgileri", bgl.baglanti());
            SqlDataReader reader = komut2.ExecuteReader();
            while (reader.Read())
            {
                cmbKategori.Items.Add(reader["Kategori"].ToString());
            }
            bgl.baglanti().Close();
        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMarka.Items.Clear();
            cmbMarka.Text = "";

            SqlCommand komut2 = new SqlCommand("select *from MarkaBilgileri where Kategori=" +
                " '" + cmbKategori.SelectedItem + "'", bgl.baglanti());
            SqlDataReader reader = komut2.ExecuteReader();
            while (reader.Read())
            {
                cmbMarka.Items.Add(reader["Marka"].ToString());
            }
            bgl.baglanti().Close();
        }

        private void btnYeniEkle_Click(object sender, EventArgs e)
        {
            try
            {
                BarkodNoKontrol();
                if (durum == true)
                {
                    SqlCommand komut = new SqlCommand("insert into urun(BarkodNo,Kategori,Marka,Urunadi,Miktari" +
                        ",AlisFiyati,SatisFiyati,Tarih) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p1", txtBarkodNo.Text);
                    komut.Parameters.AddWithValue("@p2", cmbKategori.Text);
                    komut.Parameters.AddWithValue("@p3", cmbMarka.Text);
                    komut.Parameters.AddWithValue("@p4", txtUrunAdi.Text);
                    komut.Parameters.AddWithValue("@p5", int.Parse(txtmiktari.Text));
                    komut.Parameters.AddWithValue("@p6", double.Parse(txtAlisFiyati.Text));
                    komut.Parameters.AddWithValue("@p7", double.Parse(txtSatisFiyati.Text));
                    komut.Parameters.AddWithValue("@p8", DateTime.Now.ToString());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Ürün eklendi");
                    cmbMarka.Items.Clear();

                    foreach (Control item in groupBox1.Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = "";
                        }
                        if (item is ComboBox)
                        {
                            item.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("böyle bir barkod no var", "uyarı");
                }
            }
            catch (Exception)
            {
                bgl.baglanti().Close();

            }


        }

        private void txtBarkodNo__TextChanged(object sender, EventArgs e)
        {
            if (txtBarkodNo_.Text == "")
            {
                cmbMarka_.Text = string.Empty;
                lblMiktar.Text = "";
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
           
            SqlCommand komut = new SqlCommand("select *from Urun where BarkodNo like (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtBarkodNo_.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtKategori_.Text = oku["Kategori"].ToString();
                cmbMarka_.Text = oku["Marka"].ToString();
                txtUrunadi_.Text = oku["UrunAdi"].ToString();
                lblMiktar.Text = oku["Miktari"].ToString();
                txtAlisFiyati_.Text = oku["AlisFiyati"].ToString();
                txtSatisFiyati_.Text = oku["SatisFiyati"].ToString();


            }
            bgl.baglanti().Close();
        }

        private void btnVarOlanaEkle_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("Update Urun set Miktari=Miktari+@p1 where BarkodNo=@p2", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", int.Parse(txtMiktari_.Text));
                komut.Parameters.AddWithValue("@p2", txtBarkodNo_.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                cmbMarka.Text = "";
                MessageBox.Show("var olan ürüne ekleme yapıldı.");
            }
            catch (Exception)
            {
                bgl.baglanti().Close();
                MessageBox.Show("tekrar dene");

            }

        }
    }
}
