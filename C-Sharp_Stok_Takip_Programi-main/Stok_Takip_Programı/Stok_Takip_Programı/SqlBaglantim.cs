using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Stok_Takip_Programı
{
    internal class SqlBaglantim
    {
        public SqlConnection baglanti()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
