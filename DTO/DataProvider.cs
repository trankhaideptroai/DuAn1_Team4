using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    internal class DataProvider
    {
       private string connectionstr = @"Data Source=DESKTOP-3OM6LVM;Initial Catalog=DuAn1;User ID=sa;Trust Server Certificate=True";
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
    }
}
