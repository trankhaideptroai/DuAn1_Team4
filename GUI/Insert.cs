using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace GUI.Nhập_kho
{
    public partial class Insert : Form, IInsert
    {
        #region source

        NhapKho_DTO sp = new NhapKho_DTO();
        NhapKho_BUS sp3 = new NhapKho_BUS();
        public Insert()
        {
            InitializeComponent();
        }

        #region load

        public void open()
        {
            txt_ten.Enabled = true;
            txt_soluong.Enabled = true;
            txt_ncc.Enabled = true;
            dTP_ngnh.Enabled = true;
            txt_email.Enabled = true;
        }

        public void locked()
        {
            txt_maloai.Enabled = false;
            txt_ten.Enabled = false;
            txt_soluong.Enabled = false;
            txt_ncc.Enabled = false;
            txt_email.Enabled = false;
            dTP_ngnh.Enabled = false;
            dTP_hsd.Enabled = false;
        }

        public  void cleartext()
        {
            txt_email.Clear();
            txt_ten.Clear();
            txt_soluong.Clear();
            txt_ncc.Clear();
            txt_email.Clear();
            dTP_ngnh.Value = DateTime.Now;
            dTP_hsd.Value = DateTime.Now;
        }

        #endregion

        #region check
        public bool checkinput()
        {
            return checkten() && checksoluong() && checkncc();
        }

        public bool checkten()
        {
            if(string.IsNullOrEmpty(txt_ten.Text))
            {
                MessageBox.Show("Chưa nhập tên sản phẩm", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ten.Focus();
                return false;
            }
            return true;
        }

        public bool checksoluong()
        {
            if (string.IsNullOrEmpty(txt_soluong.Text))
            {
                MessageBox.Show("Chưa nhập số lượng sản phẩm", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_soluong.Focus();
                return false;
            }
            return true;
        }

        public bool checkncc()
        {
            if (string.IsNullOrEmpty(txt_ncc.Text))
            {
                MessageBox.Show("Chưa nhập đơn vị cung cấp", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ncc.Focus();
                return false;
            }
            return true;
        }

        public void checkngnh()
        {
            MessageBox.Show("Ngày nhập là" + dTP_ngnh.Value, " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        #endregion

        #region Even

        public void inputvalues()
        {
            sp.ML = txt_maloai.Text;
            sp.Ten = txt_ten.Text;
            sp.SL = Convert.ToInt32(txt_soluong.Text);
            sp.NCC = txt_ncc.Text;
            sp.NgNH = dTP_ngnh.Value.ToString("yyyy-MM-dd");
            sp.HSD = dTP_hsd.Value.ToString("yyyy-MM-dd");
            sp.Email = txt_email.Text;
        }

        public void luu()
        {
            try
            {
                if (sp3.Insert(sp))
                {
                    MessageBox.Show("Bạn Đã Lưu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartext();
                    locked();
                }
                else
                    MessageBox.Show("Bạn Đã Lưu Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex + ""," ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pas()
        {
            cleartext();
        }

        #endregion

        #region Main
        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Insert_Load(object sender, EventArgs e)
        {
            locked();   
            btn_add.Focus();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            open();
            cleartext();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            inputvalues();
            checkinput();
            luu();
            cleartext();
            locked();
        }

        private void btn_pas_Click(object sender, EventArgs e)
        {
            pas();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
            this.Hide();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update upd = new Update();
            upd.Show();
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search sea = new Search();
            sea.Show();
            this.Hide();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xemDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List l = new List();
            l.Show();
            this.Hide();
        }

        #endregion

        #endregion
    }
}