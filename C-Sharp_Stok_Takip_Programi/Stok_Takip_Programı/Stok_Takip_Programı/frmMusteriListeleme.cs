using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stok_Takip_Programı
{
    public partial class frmMusteriListeleme : Form
    {
        public frmMusteriListeleme()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();
        DataSet dataSet = new DataSet();
        private void frmMusteriListeleme_Load(object sender, EventArgs e)
        {
            Kayit_Goster();

        }

        private void Kayit_Goster()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select *from Musteri", bgl.baglanti());
            dataAdapter.Fill(dataSet, "Musteri");
            dataGridView1.DataSource = dataSet.Tables["Musteri"];
            bgl.baglanti().Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Musteri set AdSoyad=@p2,Telefon=@p3,Adres=@p4" +
                ",Email=@p5 where Tc=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtTc.Text);
                komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p4", txtAdres.Text);
                komut.Parameters.AddWithValue("@p5", txtEmail.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();

                dataSet.Tables["Musteri"].Clear();
                Kayit_Goster();

                MessageBox.Show("müşteri kaydı güncellendi");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                        item.Text = "";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("bir hata oluştu");
            }
            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Musteri where Tc='" + dataGridView1.CurrentRow
                .Cells[0].Value.ToString() + "'", bgl.baglanti());
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            dataSet.Tables.Clear();
            Kayit_Goster();
            MessageBox.Show("kayıt silindi");
        }

        private void txtTcArama_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("select *from musteri where Tc like '%" + txtTcArama.Text + "%'",
                bgl.baglanti());
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            bgl.baglanti().Close();
        }   
    }
}
