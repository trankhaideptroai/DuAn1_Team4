using BUS;
using DevExpress.XtraEditors;
using DTO;
using GUI.Nhập_kho.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Nhập_kho
{
    public partial class Update : DevExpress.XtraEditors.XtraForm, IUpdate
    {
        #region source

        NhapKho_DTO sp1 = new NhapKho_DTO();   
        NhapKho_BUS sp3 = new NhapKho_BUS();

        public Update()
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

        public void cleartext()
        {
            txt_ten.Clear();
            txt_soluong.Clear();
            txt_ncc.Clear();
            txt_email.Clear();
            dTP_ngnh = null;
            dTP_hsd = null;
        }

        public void loadlist()
        {
            dtg_SPNKh.DataSource = sp3.Load();
            dtg_SPNKh.Columns[0].HeaderText = "IDNHAPKHO";
            dtg_SPNKh.Columns[1].HeaderText = "MALOAI";
            dtg_SPNKh.Columns[2].HeaderText = "TENSP";
            dtg_SPNKh.Columns[3].HeaderText = "SOLUONG";
            dtg_SPNKh.Columns[4].HeaderText = "NGAYNHAP";
            dtg_SPNKh.Columns[5].HeaderText = "NHACUNGCAP";
            dtg_SPNKh.Columns[6].HeaderText = "HSD";
            dtg_SPNKh.Columns[7].HeaderText = "IDNV";
        }

        public void showinf()
        {
            txt_maloai.Text = dtg_SPNKh.CurrentRow.Cells["MALOAI"].Value.ToString();
            txt_ten.Text = dtg_SPNKh.CurrentRow.Cells["TENSP"].Value.ToString();
            txt_soluong.Text = dtg_SPNKh.CurrentRow.Cells["SOLUONG"].Value.ToString();
            txt_ncc.Text = dtg_SPNKh.CurrentRow.Cells["NHACUNGCAP"].Value.ToString();
            string ngnhstr = dtg_SPNKh.CurrentRow.Cells["NGAYNHAP"].Value.ToString();
            DateTime ngnh;
            if(DateTime.TryParse(ngnhstr, out ngnh))
            {
                dTP_ngnh.Value = ngnh;
            }    
            else
            {
                MessageBox.Show("Error"," ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string hsdstr = dtg_SPNKh.CurrentRow.Cells["HSD"].Value.ToString();
            DateTime hsd;
            if(DateTime.TryParse(hsdstr, out hsd))
            {
                dTP_hsd.Value = hsd;
            }
            else
            {
                MessageBox.Show("Error", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region check

        public bool checkinput()
        {
            return checkten() && checksoluong() && checkncc() && checkngnh();
        }

        public bool checkten()
        {
            if (string.IsNullOrEmpty(txt_ten.Text))
            {
                MessageBox.Show("Bạn đã xóa tên sản phẩm", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_ten.Focus();
                return false;
            }
            return true;
        }

        public bool checksoluong()
        {
            if (!int.TryParse(txt_soluong.Text, out _))
            {
                MessageBox.Show("Bạn đã xóa số lượng sản phẩm", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public bool checkngnh()
        {
            if (dTP_ngnh == null)
            {
                MessageBox.Show("Chưa chọn ngày nhập hàng", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dTP_ngnh.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Even

        public void inputvalues()
        {
            sp1.ML = txt_maloai.Text;
            sp1.Ten = txt_ten.Text;
            sp1.SL = Convert.ToInt32(txt_soluong.Text);
            sp1.NCC = txt_ncc.Text;
            sp1.NgNH = dTP_ngnh.Value.ToString("yyyy-MM-dd");
            sp1.HSD = dTP_hsd.Value.ToString("yyyy-MM-dd");
            sp1.Email = txt_email.Text;
        }

        public void luu()
        {
            try
            {
                inputvalues();
                checkinput();
                if (sp3.Update(sp1))
                {
                    MessageBox.Show("Bạn Đã Sửa Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartext();
                    locked();
                    loadlist();
                }
                else
                    MessageBox.Show("Bạn Đã Sửa Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + "", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pas()
        {
            locked();
            cleartext();
            loadlist();
        }

        #endregion

        #region Main

        private void Update_Load(object sender, EventArgs e)
        {
            loadlist();
            locked();
        }

        private void btn_pas_Click(object sender, EventArgs e)
        {
            pas();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            luu();
            loadlist();
        }

        private void btn_upd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txt_ten.Text) || string.IsNullOrEmpty(txt_soluong.Text) || string.IsNullOrEmpty(txt_ncc.Text))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để thay đổi thông tin", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
            else
            {
                open();
            }
        }

        private void dtg_SPNKh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showinf();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert ins = new Insert();
            ins.Show();
            this.Hide();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
            this.Hide();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search sea = new Search();
            sea.Show();
            this.Hide();
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