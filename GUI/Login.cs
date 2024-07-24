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

namespace GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_taikhoan.Text = Properties.Settings.Default.Username;
            txt_matkhau.Text = Properties.Settings.Default.Password;
            txt_matkhau.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_taikhoan.Text != "" && txt_matkhau.Text != "")
            {
                if (CheckLogin(txt_taikhoan.Text, txt_matkhau.Text))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (chkGhiNho.Checked)
                    {
                        Properties.Settings.Default.Username = txt_taikhoan.Text;
                        Properties.Settings.Default.Password = txt_matkhau.Text; 
                        Properties.Settings.Default.Save();
                    }

                    Main h = new Main();
                    h.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Clear the text boxes on login failure
                    txt_taikhoan.Clear();
                    txt_matkhau.Clear();
                    Properties.Settings.Default.Username = txt_taikhoan.Text;
                    Properties.Settings.Default.Password = txt_matkhau.Text;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void guna2Button2_Click(object sender, EventArgs e)
        {
            QuenMK quenMK = new QuenMK();
            Login login = new Login();
            quenMK.Show();
            this.Hide();
        }

        private void chkGhiNho_CheckedChanged(object sender, EventArgs e)
        {
            if (txt_taikhoan.Text != "" && txt_matkhau.Text != "")

            {
                if (chkGhiNho.Checked == true)
                {
                    string users = txt_taikhoan.Text;
                    string pwd = txt_matkhau.Text;
                    Properties.Settings.Default.Username = users;
                    Properties.Settings.Default.Password = pwd; 
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public bool CheckLogin(string email, string password)
        {
            string query = "SELECT COUNT(*) FROM NhanVien WHERE Email = @Email AND MatKhau = @MatKhau";
            using (SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-3OM6LVM;Initial Catalog=database_duan1;Integrated Security=True"))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@MatKhau", password);

                connection.Open();
                int result = (int)command.ExecuteScalar();
                return result > 0;
            }
        }

        private void txt_matkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
        }
    }
}    
