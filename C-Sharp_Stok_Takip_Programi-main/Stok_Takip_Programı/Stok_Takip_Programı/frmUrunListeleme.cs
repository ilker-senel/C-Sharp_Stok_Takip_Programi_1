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
    public partial class frmUrunListeleme : Form
    {
        public frmUrunListeleme()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();
        private void frmUrunListeleme_Load(object sender, EventArgs e)
        {
            UrunListele();
            KategoriGetir();
            cmbKategori.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMarka.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void UrunListele()
        {

            // dataSet.Tables["urun"].Clear();
            dataSet.Tables.Clear();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Urun order by barkodno", bgl.baglanti());
            dataAdapter.Fill(dataSet, "urun");
            dataGridView1.DataSource = dataSet.Tables["urun"];
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UrunBilgisiGetir();

        }

        private void UrunBilgisiGetir()
        {
            txtBarkodNo_.Text = dataGridView1.CurrentRow.Cells["BarkodNo"].Value.ToString();
            txtKategori_.Text = dataGridView1.CurrentRow.Cells["Kategori"].Value.ToString();
            txtMarka_.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
            txtUrunadi_.Text = dataGridView1.CurrentRow.Cells["UrunAdi"].Value.ToString();
            txtAlisFiyati_.Text = dataGridView1.CurrentRow.Cells["AlisFiyati"].Value.ToString();
            txtSatisFiyati_.Text = dataGridView1.CurrentRow.Cells["SatisFiyati"].Value.ToString();
            txtMiktari_.Text = dataGridView1.CurrentRow.Cells["miktari"].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Urun set urunadi=@p1,miktari=@p2,alisfiyati=@p3,satisfiyati=@p4" +
                " where barkodno=@p0", bgl.baglanti());
                komut.Parameters.AddWithValue("@p0", txtBarkodNo_.Text);
                komut.Parameters.AddWithValue("@p1", txtUrunadi_.Text);
                komut.Parameters.AddWithValue("@p2", int.Parse(txtMiktari_.Text));
                komut.Parameters.AddWithValue("@p3", double.Parse(txtAlisFiyati_.Text));
                komut.Parameters.AddWithValue("@p4", double.Parse(txtSatisFiyati_.Text));
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                UrunListele();
                MessageBox.Show("güncelleme yapıldı");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("güncelleme işlemi yapılamadı");
            }
            
        }

        private void btnMarkaGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBarkodNo_.Text != "")
                {
                    SqlCommand komut = new SqlCommand("update Urun set kategori=@p1,marka=@p2 where barkodno=@p0", bgl.baglanti());
                    komut.Parameters.AddWithValue("@p0", txtBarkodNo_.Text);
                    komut.Parameters.AddWithValue("@p1", cmbKategori.Text);
                    komut.Parameters.AddWithValue("@p2", cmbMarka.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    UrunListele();
                    //UrunBilgisiGetir(); farklı bir şey yapmak lazım.
                    //güncellendikten sonra 
                    MessageBox.Show("güncelleme yapıldı");

                }
                else
                {
                    MessageBox.Show("barkod no yazılı değil");
                }
                foreach (Control item in this.Controls)
                {
                    if (item is ComboBox)
                    {
                        item.Text = "";
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("güncelleme işlemi yapılamadı");
            }
          

        }
        private void KategoriGetir()
        {

            SqlCommand komut = new SqlCommand("select *from KategoriBilgileri", bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                cmbKategori.Items.Add(oku[0].ToString());
            }
            bgl.baglanti().Close();

        }

        private void cmbKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            //kategoriye göre Marka ekleme komutları
            cmbMarka.Items.Clear();
            cmbMarka.Text = ""; //önceki kategoriye ait markalar siliniyor

            SqlCommand komut2 = new SqlCommand("select *from MarkaBilgileri where Kategori=" +
                " '" + cmbKategori.SelectedItem + "'", bgl.baglanti());
            SqlDataReader reader = komut2.ExecuteReader();
            while (reader.Read())
            {
                cmbMarka.Items.Add(reader["Marka"].ToString());
            }
            bgl.baglanti().Close();

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Urun where barkodno=@barkodno", bgl.baglanti());
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            UrunListele();
            MessageBox.Show("kayıt silindi");

        }

        private void txtBarkodNoAra_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();            
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from urun where barkodno" +
                " like '%" + txtBarkodNoAra.Text + "%'", bgl.baglanti());
            dataAdapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bgl.baglanti().Close();
        }

       
    }
}
