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
    //Data Source=DESKTOP-NIJEM97\WINCC;Initial Catalog=Stok_Takip;Integrated Security=True
    public partial class frmMusteriEkle : Form
    {
        public frmMusteriEkle()
        {
            InitializeComponent();
        }
        SqlBaglantim bgl=new SqlBaglantim();
        private void frmMusteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into Musteri(Tc,AdSoyad,Telefon,Adres,Email) " +
                    "values(@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtTc.Text);
                komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p3", txtTelefon.Text);
                komut.Parameters.AddWithValue("@p4", txtAdres.Text);
                komut.Parameters.AddWithValue("@p5", txtEmail.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("müşteri kaydı eklendi");
                foreach (Control item in this.Controls)
                {
                    if (item is TextBox)
                        item.Text = "";
                }
            }
            catch 
            {
                MessageBox.Show("bir hata oluştu");
            }
        }
    }
}
