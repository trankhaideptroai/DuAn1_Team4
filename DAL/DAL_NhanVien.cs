using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_NhanVien
    {
        public bool CheckLogin(string email, string password)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE Email = @Email AND MatKhau = @MatKhau";
            using (SqlConnection conn = DataProvider.connect())

            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@MatKhau", password);

                conn.Open();
                int result = (int)command.ExecuteScalar();
                return result > 0;
            }
        }
    }
}
