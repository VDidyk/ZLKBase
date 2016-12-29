using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace ZLKB
{
    class DataBaseWorker
    {
         public MySqlConnection con = new MySqlConnection();
         public DataBaseWorker()
        {
            string myConnectionString = "server=zlkmagaz.mysql.ukraine.com.ua;uid=zlkmagaz_zlkbase;pwd=zz2j45bq;database=zlkmagaz_zlkbase;";
            con.ConnectionString = myConnectionString;
            con.Open();
        }      
        
    }
}
