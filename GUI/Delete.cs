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
    public partial class Delete : DevExpress.XtraEditors.XtraForm, IDelete
    {
        #region source

        NhapKho_BUS sp3 = new NhapKho_BUS();
        NhapKho_DTO sp1 = new NhapKho_DTO();
        public Delete()
        {
            InitializeComponent();
        }

        #region check
        public void checkvalue()
        {

            if (string.IsNullOrEmpty(txt_maloai.Text) && dtg_SPNKh.SelectedRows.Count < 1)
            {
                MessageBox.Show("Bạn chưa chọn dòng nào", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtg_SPNKh.Focus();
            }
        }

        #endregion

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

        public void xoa()
        {
            sp1.ML = txt_maloai.Text;
            checkvalue();
            if (sp3.Delete(sp1.ML))
            {
                MessageBox.Show("Xóa thành công", " ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Thất bại", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void pas()
        {
            txt_maloai.Clear();
        }

        #endregion

        #region Main

        private void Delete_Load(object sender, EventArgs e)
        {
            txt_maloai.Enabled = false;
            loadlist();
        }

        private void dtg_SPNKh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_maloai.Text = dtg_SPNKh.CurrentRow.Cells["MALOAI"].Value.ToString();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_maloai.Text))
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để xóa", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                xoa();
                loadlist();
            }
        }

        private void btn_pas_Click(object sender, EventArgs e)
        {
            pas();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert ins = new Insert();
            ins.Show();
            this.Hide();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void xemDanhSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadList l = new LoadList();
            l.Show();
            this.Hide();
        }

        #endregion

        #endregion
    }
}