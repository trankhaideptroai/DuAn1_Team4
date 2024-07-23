using GUI.Nhập_kho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            
        }
        private void Thoat_click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Main_Click(object sender, EventArgs e)
        {
            tab_control.SelectTab(tabPage1);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Insert ins = new Insert();
            ins.Show();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Delete del = new Delete();
            del.Show();
        }

        private void btn_upd_Click(object sender, EventArgs e)
        {
            Update upd = new Update();
            upd.Show();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            Search sea = new Search();
            sea.Show();
        }
    }
}
