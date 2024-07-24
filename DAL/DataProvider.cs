using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        public static string connectionstr = @"Data Source=DESKTOP-4EF68B5\TUAN;Initial Catalog=database_duan1;Integrated Security=True";
        public DataTable ExcuteQuery(string querry)
        {
            DataTable data = new DataTable();
            using (SqlConnection connnection = new SqlConnection(connectionstr))
            {
                connnection.Open();
                SqlCommand command = new SqlCommand(querry, connnection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.Fill(data);
                connnection.Close();

            }
            return data;
        }

        public static SqlConnection connect()
        {
            return new SqlConnection(connectionstr);
        }
    }
}
