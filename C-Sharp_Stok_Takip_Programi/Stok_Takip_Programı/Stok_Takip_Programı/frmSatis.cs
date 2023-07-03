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
    public partial class frmSatis : Form
    {
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();
        private void SepetListele()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select *from sepet", bgl.baglanti());
            dataAdapter.Fill(dataSet, "sepet");
            dataGridView1.DataSource = dataSet.Tables["sepet"];
            dataGridView1.Columns[0].Visible = false;//bu komut ile datagridview deki ilk data görünmez olur
            dataGridView1.Columns[1].Visible = false;//bu komut ile datagridview deki ilk data görünmez olur
            dataGridView1.Columns[2].Visible = false;//bu komut ile datagridview deki ilk data görünmez olur

            bgl.baglanti().Close();

        }
        public frmSatis()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMusteriEkle ekle = new frmMusteriEkle();
            ekle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmMusteriListeleme listeleme = new frmMusteriListeleme();
            listeleme.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmUrunEkle ekle = new frmUrunEkle();
            ekle.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmKategori kategori = new frmKategori();
            kategori.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMarka marka = new frmMarka();
            marka.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmUrunListeleme urunListeleme = new frmUrunListeleme();
            urunListeleme.ShowDialog();
        }
        private void hesapla()
        {
            try
            {
                SqlCommand komut = new SqlCommand("select sum(toplamfiyat) from sepet", bgl.baglanti());
                lblGenelToplam.Text = komut.ExecuteScalar() + " TL";
                bgl.baglanti().Close();
            }
            catch (Exception)
            {
                ;
            }
            finally { bgl.baglanti().Close(); }
        }
        private void frmSatis_Load(object sender, EventArgs e)
        {
            SepetListele();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            if (txtTc.Text == "")
            {
                txtAdSoyad.Text = txtTelefon.Text = "";
            }

            SqlCommand komut = new SqlCommand("select *from musteri where tc like '" + txtTc.Text + "' ", bgl.baglanti());
            //komut.Parameters.AddWithValue("@tc", txtTc.Text);
            SqlDataReader dataReader = komut.ExecuteReader();
            while (dataReader.Read())
            {
                txtAdSoyad.Text = dataReader["adsoyad"].ToString();
                txtTelefon.Text = dataReader["telefon"].ToString();
            }
            bgl.baglanti().Close();
        }

        private void txtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            Temizle();
            string[] text;
            text = txtBarkodNo.Text.Split('x');
            if (text.Length > 1)
            {
                txtMiktari.Text = text[0];
                txtBarkodNo.Text = string.Empty;
            }



            SqlCommand komut = new SqlCommand("select * from urun where barkodno like '"
                + txtBarkodNo.Text + "'", bgl.baglanti());
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtUrunAdi.Text = read["urunadi"].ToString();
                txtSatisFiyati.Text = read["satisfiyati"].ToString();

            }
            bgl.baglanti().Close();
        }

        private void Temizle()
        {
            if (txtBarkodNo.Text == string.Empty)
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox && item != txtMiktari)
                    {
                        item.Text = "";
                    }
                }
            }
        }
        bool durum;
        private void BarkodKontrol()
        {
            durum = true;

            SqlCommand komut = new SqlCommand("select *from sepet", bgl.baglanti());
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                if (txtBarkodNo.Text == reader["barkodno"].ToString())
                {
                    durum = false;
                }
            }
            bgl.baglanti().Close();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                BarkodKontrol();
                if (durum == true)
                {

                    SqlCommand komut = new SqlCommand("insert into sepet(tc,adsoyad,telefon,barkodno,urunadi,miktari," +
                        "satisfiyati,toplamfiyat,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari," +
                        "@satisfiyati,@toplamfiyat,@tarih)", bgl.baglanti());
                    komut.Parameters.AddWithValue("@tc", txtTc.Text);
                    komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                    komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                    komut.Parameters.AddWithValue("@barkodno", txtBarkodNo.Text);
                    komut.Parameters.AddWithValue("@urunadi", txtUrunAdi.Text);
                    komut.Parameters.AddWithValue("@miktari", int.Parse(txtMiktari.Text));
                    komut.Parameters.AddWithValue("@satisfiyati", double.Parse(txtSatisFiyati.Text));
                    komut.Parameters.AddWithValue("@toplamfiyat", double.Parse(txtToplamFiyat.Text));
                    komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }
                else
                {
                    SqlCommand komut2 = new SqlCommand("update sepet set miktari=miktari+'" + int.Parse(txtMiktari.Text) + "' " +
                        "where barkodno=@p2", bgl.baglanti());
                    // komut2.Parameters.AddWithValue("@p1", int.Parse(txtMiktari.Text));
                    komut2.Parameters.AddWithValue("@p2", txtBarkodNo.Text);
                    komut2.ExecuteNonQuery();
                    SqlCommand komut3 = new SqlCommand("update sepet set toplamfiyat=miktari*satisfiyati where barkodno" +
                        "=@p3", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p3", txtBarkodNo.Text);
                    komut3.ExecuteNonQuery();
                    bgl.baglanti().Close();
                }

                txtMiktari.Text = "1";
                dataSet.Tables["sepet"].Clear();
                SepetListele();
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox && item != txtMiktari)
                    {
                        item.Text = "";
                    }
                }
                hesapla();
            }
            catch
            {
                bgl.baglanti().Close();
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox && item != txtMiktari)
                    {
                        item.Text = "";
                    }
                }
                MessageBox.Show("tekrar dene");
            }
        }

        private void txtMiktari_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktari.Text) *
                    double.Parse(txtSatisFiyati.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void txtSatisFiyati_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtToplamFiyat.Text = (double.Parse(txtMiktari.Text) *
                    double.Parse(txtSatisFiyati.Text)).ToString();
            }
            catch (Exception)
            {
                ;
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {

                SqlCommand komut = new SqlCommand("delete from sepet where barkodno=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("ürün sepetten çıkarıldı");
                //dataSet.Tables.Clear();           
                dataSet.Tables["sepet"].Clear();
                SepetListele();
                hesapla();
            }
            catch
            {
                bgl.baglanti().Close();
                MessageBox.Show("tekrar dene");
            }
        }

        private void btnSatisIptal_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from sepet", bgl.baglanti());
            //komut.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("ürünler sepetten çıkarıldı");
            //dataSet.Tables.Clear();
            dataSet.Tables["sepet"].Clear();
            SepetListele();
            hesapla();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmSatisListesi listesi = new frmSatisListesi();
            listesi.ShowDialog();
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                SqlCommand komut = new SqlCommand("insert into satis(tc,adsoyad,telefon,barkodno,urunadi,miktari," +
                    "satisfiyati,toplamfiyat,tarih) values(@tc,@adsoyad,@telefon,@barkodno,@urunadi,@miktari," +
                    "@satisfiyati,@toplamfiyat,@tarih)", bgl.baglanti());
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                komut.Parameters.AddWithValue("@urunadi", dataGridView1.Rows[i].Cells["urunadi"].Value.ToString());
                komut.Parameters.AddWithValue("@miktari", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut.Parameters.AddWithValue("@satisfiyati", double.Parse(dataGridView1.Rows[i].Cells["satisfiyati"].Value.ToString()));
                komut.Parameters.AddWithValue("@toplamfiyat", double.Parse(dataGridView1.Rows[i].Cells["toplamfiyat"].Value.ToString()));
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                SqlCommand komut2 = new SqlCommand("Update Urun set Miktari=Miktari-@p1 where BarkodNo=@p2", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", int.Parse(dataGridView1.Rows[i].Cells["miktari"].Value.ToString()));
                komut2.Parameters.AddWithValue("@p2", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();

            }

            SqlCommand komut3 = new SqlCommand("delete from sepet", bgl.baglanti());
            //komut.Parameters.AddWithValue("@p1", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            dataSet.Tables["sepet"].Clear();
            SepetListele();
            hesapla();
            MessageBox.Show("satış yapıldı");
        }
    }
}
