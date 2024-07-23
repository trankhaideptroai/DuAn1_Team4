using BUS;
using DevExpress.XtraEditors;
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
    public partial class List : DevExpress.XtraEditors.XtraForm
    {
        #region source

        NhapKho_BUS sp3 = new NhapKho_BUS();
        public List()
        {
            InitializeComponent();
        }

        private void dtg_SPNKh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void List_Load(object sender, EventArgs e)
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

        private void xemDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Update upd = new Update();
            upd.Show();
            this.Hide();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
            this.Hide();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void mToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}