using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class DataBaseConnect
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;username=root;password=1111;database=test0");

        public void OpenCon()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public void CloseCon()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }

        public MySqlConnection GetConnection()
        {
            return connection;
        }

    }
}
