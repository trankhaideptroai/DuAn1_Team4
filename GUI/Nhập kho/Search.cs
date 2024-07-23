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
    public partial class Search : DevExpress.XtraEditors.XtraForm, ISearch
    {
        #region source

        NhapKho_DTO sp1 = new NhapKho_DTO();
        NhapKho_BUS sp3 = new NhapKho_BUS();

        public Search()
        {
            InitializeComponent();
        }

        #region even

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

        public void tim()
        {
            try
            {
                if (string.IsNullOrEmpty(txt_ten.Text))
                {
                    MessageBox.Show("Bạn chưa nhập tên sản phẩm", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_ten.Focus();
                }

                sp1.Ten = txt_ten.Text;
                DataTable ds = sp3.Find(sp1.Ten);
                if(ds.Rows.Count > 0)
                {
                    dtg_SPNKh.DataSource = ds;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void pas()
        {
            txt_ten.Clear();
            txt_ten.Enabled = false;
        }

        #endregion

        #region main

        private void btn_sear_Click(object sender, EventArgs e)
        {
            txt_ten.Enabled = true;
            txt_ten.Clear();
            txt_ten.Focus();
        }

        private void btn_pas_Click(object sender, EventArgs e)
        {
            pas();
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            tim();
            txt_ten.Enabled=false;
        }

        private void Search_Load(object sender, EventArgs e)
        {
            txt_ten.Enabled = false;
            loadlist();
        }

        private void menuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List list = new List();
            list.Show();
            this.Hide();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
            this.Hide();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert ins = new Insert();
            ins.Show();
            this.Hide();

        }

        private void xemDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update upd = new Update();
            upd.Show();
            this.Hide();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
            this.Hide();
        }

        private void dtg_SPNKh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        #endregion
    }
}