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
    public partial class frmSatisListesi : Form
    {
        SqlBaglantim bgl = new SqlBaglantim();
        DataSet dataSet = new DataSet();
        public frmSatisListesi()
        {
            InitializeComponent();
        }

        private void frmSatisListesi_Load(object sender, EventArgs e)
        {
            SatisListele();
        }

        private void SatisListele()
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select *from satis", bgl.baglanti());
            dataAdapter.Fill(dataSet, "satis");
            dataGridView1.DataSource = dataSet.Tables["satis"];
            //dataGridView1.Columns[0].Visible = false;//bu komut ile datagridview deki ilk data görünmez olur
            //dataGridView1.Columns[1].Visible = false;//bu komut ile datagridview deki ilk data görünmez olur
            //dataGridView1.Columns[2].Visible = false;//bu komut ile datagridview deki ilk data görünmez olur

            bgl.baglanti().Close();
        }
    }
}
