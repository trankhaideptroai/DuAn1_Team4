using BUS;
using DAL;
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
using System.Security.Cryptography;
using DevExpress.XtraBars.Navigation;


namespace GUI
{
    public partial class Login : Form
    {
        private MD5 _md5 = MD5.Create();
        public Login()
        {
            InitializeComponent();
            txt_taikhoan.Text = Properties.Settings.Default.Username;
            txt_matkhau.Text = Properties.Settings.Default.Password;
            txt_matkhau.UseSystemPasswordChar = true;
            
        }
        

        private void LoadRememberedLogin()
        {
            // Kiểm tra xem có lưu trữ thông tin đăng nhập hay không
            if (Properties.Settings.Default.RememberMe)
            {
                txt_taikhoan.Text = Properties.Settings.Default.Username;
                txt_matkhau.Text = Properties.Settings.Default.Password;
                chkGhiNho.Checked = true;
            }
            else
            {
                txt_taikhoan.Text = string.Empty;
                txt_matkhau.Text = string.Empty;
                chkGhiNho.Checked = false;
            }
        }
        BUS_NhanVien bUSNhanVien = new BUS_NhanVien();
        
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (txt_taikhoan.Text != "" && txt_matkhau.Text != "")
            {
                string encryptedPassword = bUSNhanVien.EncryptPassword(txt_matkhau.Text);
                if (bUSNhanVien.checklogin(txt_taikhoan.Text, encryptedPassword))
                {
                    MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Properties.Settings.Default.RememberMe = true;
                    if (chkGhiNho.Checked == true)
                    {
                        chkGhiNho_luu();
                    }

                    string email = txt_taikhoan.Text;
                    Main h = new Main(email);

                    string role = bUSNhanVien.GetUserRole(email);
                    if (role != "Manager")
                    {
                        h.LimitAccess();
                    }

                    h.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Sai email hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_taikhoan.Clear();
                    txt_matkhau.Clear();
                    Properties.Settings.Default.Reset();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ClearLoginFields()
        {
            txt_taikhoan.Clear();
            txt_matkhau.Clear();
            Properties.Settings.Default.Reset();
        }
       

        DAL_NhanVien dAL_NhanVien = new DAL_NhanVien();

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            QuenMK quenMK = new QuenMK();
            Login login = new Login();
            quenMK.Show();
            this.Hide();
        }
        private void chkGhiNho_luu()
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


        private void txt_matkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            LoadRememberedLogin();
        }
    }
}    
