using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WpfApplication1
{
    class dbconnection
    {

        //string server = "localhost";
        //string userName = "root";
        //string password = "root";
        //string database = "hospital";

        public MySqlConnection conn = new MySqlConnection("server=localhost;uid=root;pwd=root;database=hospital");


    }
}
