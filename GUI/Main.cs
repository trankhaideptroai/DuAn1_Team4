using GUI;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.Design.WebControls;
using BUS;
using DAL;
using DTO;


namespace GUI
{
    public partial class Main : Form
    {
        public string email {  get; set; }
        NhapKho_BUS sp3 = new NhapKho_BUS();
        NhapKho_DTO sp1 = new NhapKho_DTO();    
        public Main(string Email)
        {
            InitializeComponent();
            tabPageToDisable = tab_control.TabPages["tabPage5"];
            this.email = Email;
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

        private void Main_Load(object sender, EventArgs e)
        {
            LoadfromThongKe();
            locked();
            loadlist();
            txt_find.Enabled = false;
        }

        #region ThongKe

        private void LoadfromThongKe()
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            // Tạo kết nối
            using (SqlConnection conn = DataProvider.connect())
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo đối tượng SqlCommand để gọi Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("thongke", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Tạo đối tượng SqlDataAdapter để lấy dữ liệu
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        // Tạo DataTable để lưu dữ liệu
                        DataTable dt = new DataTable();

                        // Đổ dữ liệu vào DataTable
                        da.Fill(dt);

                        // Gán DataTable làm nguồn dữ liệu cho DataGridView
                        dtgvThongKe.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ (nếu có)
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void btnXuatPDF_Click(object sender, EventArgs e)
        {
            // Tạo và cấu hình SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Lưu file PDF";
            saveFileDialog.FileName = "exported_data.pdf";

            // Hiển thị SaveFileDialog và kiểm tra nếu người dùng đã chọn file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn được người dùng chọn
                string pdfPath = saveFileDialog.FileName;

                // Tạo tài liệu PDF mới
                Document pdfDoc = new Document(PageSize.A4, 10, 10, 10, 10);

                try
                {
                    // Tạo writer để ghi tài liệu vào đường dẫn được chỉ định
                    PdfWriter.GetInstance(pdfDoc, new FileStream(pdfPath, FileMode.Create));

                    // Mở tài liệu để ghi
                    pdfDoc.Open();

                    // Tạo bảng với số cột tương tự như DataGridView
                    PdfPTable pdfTable = new PdfPTable(dtgvThongKe.Columns.Count);

                    // Đặt chiều rộng cho các cột
                    float[] widths = new float[dtgvThongKe.Columns.Count];
                    for (int i = 0; i < dtgvThongKe.Columns.Count; i++)
                    {
                        widths[i] = (float)dtgvThongKe.Columns[i].Width;
                    }
                    pdfTable.SetWidths(widths);

                    // Thêm tiêu đề từ DataGridView vào bảng PDF
                    foreach (DataGridViewColumn column in dtgvThongKe.Columns)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                        pdfTable.AddCell(cell);
                    }

                    // Thêm các dòng từ DataGridView vào bảng PDF
                    foreach (DataGridViewRow row in dtgvThongKe.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            pdfTable.AddCell(cell.Value?.ToString() ?? string.Empty);
                        }
                    }

                    // Thêm bảng vào tài liệu
                    pdfDoc.Add(pdfTable);

                    MessageBox.Show("Dữ liệu đã được xuất ra file PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra khi xuất file PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Đóng tài liệu
                    pdfDoc.Close();
                }
            }
        }

        #endregion
        private TabPage tabPageToDisable;
        public void LimitAccess()
        {
            if (tab_control.TabPages.Contains(tabPageToDisable))
            {
                tab_control.TabPages.Remove(tabPageToDisable);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tab_control.SelectTab(tabPage1);
        }

        private void dtgvThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        #region Nhập kho

        #region LOClLShP

        void open()
        {
            txt_ten.Enabled = true;
            txt_soluong.Enabled = true;
            txt_ncc.Enabled = true;
        }

        void locked()
        {
            txt_maloai.Enabled = false;
            txt_ten.Enabled = false;
            txt_soluong.Enabled = false;
            txt_ncc.Enabled = false;
            txt_email.Enabled = false;
            dTP_ngnh.Enabled = false;
            dTP_hsd.Enabled = false;
        }

        void cleartext()
        {
            txt_maloai.Clear();
            txt_ten.Clear();
            txt_soluong.Clear();
            txt_ncc.Clear();
            txt_email.Clear();
        }

        void loadlist()
        {
            dtg_SPNKh.DataSource = sp3.Load();
            dtg_SPNKh.Columns[0].HeaderText = "MaLoai";
            dtg_SPNKh.Columns[1].HeaderText = "TenSP";
            dtg_SPNKh.Columns[2].HeaderText = "SoLuong";
            dtg_SPNKh.Columns[3].HeaderText = "NhaCungCap";
            dtg_SPNKh.Columns[4].HeaderText = "NgayNhap";
            dtg_SPNKh.Columns[5].HeaderText = "HSD";
            dtg_SPNKh.Columns[6].HeaderText = "MaNV";
        }

        void showinf()
        {
                txt_maloai.Text = dtg_SPNKh.CurrentRow.Cells["MaLoai"].Value.ToString();
                txt_ten.Text = dtg_SPNKh.CurrentRow.Cells["TenSP"].Value.ToString();
                txt_soluong.Text = dtg_SPNKh.CurrentRow.Cells["SoLuong"].Value.ToString();
                txt_ncc.Text = dtg_SPNKh.CurrentRow.Cells["NhaCungCap"].Value.ToString();
                string ngayNhapStr = dtg_SPNKh.CurrentRow.Cells["NgayNhap"].Value.ToString();
                DateTime ngayNhap;
                if (DateTime.TryParse(ngayNhapStr, out ngayNhap))
                {
                    dTP_ngnh.Value = ngayNhap;
                }
                else
                {
                    MessageBox.Show("Error", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string hsdStr = dtg_SPNKh.CurrentRow.Cells["HSD"].Value.ToString();
                DateTime hsd;
                if (DateTime.TryParse(hsdStr, out hsd))
                {
                    dTP_ngnh.Value = hsd;
                }
                else
                {
                    MessageBox.Show("Error", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        void pass()
        {
            if (btn_ad.Text == "Lưu")
            {
                cleartext();
                locked();
                btn_ad.Text = "Thêm";
            }
            else if (btn_upd.Text == "Lưu")
            {
                locked();
                cleartext();
                showinf();
                btn_upd.Text = "Sửa";
            }
            else if (btn_del.Text == "Xác nhận")
            {
                btn_del.Text = "Xóa";
            }
            else if (btn_find.Text == "Tìm")
            {
                txt_find.Clear();
                txt_find.Enabled = false;
                txt_find.Text = "Nhập tên sản phẩm";
                btn_find.Text = "Tìm kiếm";
            }
            else
            {
                loadlist();
            }
        }

        #endregion

        #region Check

        bool checkTen()
        {
            if (string.IsNullOrEmpty(txt_ten.Text))
            {
                MessageBox.Show("Thiếu tên Sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ten.Focus();
                return false;
            }
            return true;
        }

        bool checkNCC()
        {
            if (string.IsNullOrEmpty(txt_ncc.Text))
            {
                MessageBox.Show("Thiếu Nhà cung cấp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_ncc.Focus();
                return false;
            }
            return true;
        }

        /*
        bool checkngnh()
        {
            if (dTP_ngnh.Value < DateTime.Now)
            {
                MessageBox.Show("Kiểm tra lại ngày nhập hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dTP_ngnh.Focus();
                return false;
            }
            return true;
        }

        /*bool checkNGnh()
        {
            if (cb_ngnhap.Items.Count > 0)
            {
                MessageBox.Show("Chưa chọn ngày nhập", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cb_ngnhap.Focus();
                return false;
            }
            return true;
        }*/

        /*bool checkHSD()
        {
            if (string.IsNullOrEmpty(txt_hsd.Text))
            {
                MessageBox.Show("Thiếu Hạn Sử Dụng", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_hsd.Focus();
                return false;
            }
            return true;
        }
        */
        bool checkTim()
        {
            if (string.IsNullOrEmpty(txt_find.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã loại", " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_find.Focus();
                return false;
            }
            return true;
        }

        bool checkinput()
        {
            return checkTen() && checkNCC(); //&& checkHSD();
        }

        #endregion

        #region Even
        void inputvalues()
        {
            sp1.ML= txt_maloai.Text;
            sp1.Ten= txt_ten.Text;
            try
            {
                int parsedValue;
                if (int.TryParse(txt_soluong.Text, out parsedValue) && parsedValue > 0)
                {
                    sp1.SL = parsedValue;
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại số lượng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Chưa có số lượng nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sp1.NCC = txt_ncc.Text;
            sp1.NgNH= dTP_ngnh.Value;
            sp1.HSD = dTP_hsd.Value;
            sp1.Email = email;
        }

        void luu()
        {
            if (sp3.Insert(sp1))
            {
                MessageBox.Show("Bạn Đã Lưu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartext();
                locked();
                loadlist();
            }
            else
                MessageBox.Show("Bạn Đã Lưu Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void sua()
        {
            inputvalues();
            if (sp3.Update(sp1))
            {
                MessageBox.Show("Bạn Đã Lưu Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cleartext();
                loadlist();
            }
            else
                MessageBox.Show("Bạn Đã Lưu Thất Bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        void xoa()
        {
            if (string.IsNullOrEmpty(txt_maloai.Text))
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                sp1.ML= txt_maloai.Text;
                if (sp3.Delete(sp1.ML))
                {
                    MessageBox.Show("Xóa Thành Công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cleartext();
                    locked();
                    loadlist();
                }
                else
                {
                    MessageBox.Show("Thất Bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cleartext();
                    locked();
                }

            }
        }

        void tim()
        {
            sp1.Ten= txt_find.Text;
            DataTable danhsach = sp3.Find(sp1.Ten);
            if (danhsach.Rows.Count > 0)
            {
                dtg_SPNKh.DataSource = danhsach;
                showinf();
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_find.Text = null;
            txt_find.Enabled = false;
        }
        #endregion

        #region Main

        private void dtg_SPNKh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            showinf();
        }

        private void btn_ad_Click(object sender, EventArgs e)
        {
            if (btn_ad.Text == "Thêm")
            {
                MessageBox.Show("Vui lòng nhập thông tin Sản phẩm, nếu không chắc vui lòng bấm Bỏ qua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                open();
                cleartext();
                btn_ad.Text = "Lưu";
            }
            else
            {
                checkinput();
                inputvalues();
                luu();
                cleartext();
                loadlist();
                locked();
                btn_ad.Text = "Thêm";
            }

        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (btn_del.Text == "Xóa")
            {
                MessageBox.Show("Nếu chắc chắn hãy bấm nút Xác nhận hoặc bấm nút Bỏ qua", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_del.Text = "Xác nhận";
            }
            else
            {
                xoa();
                loadlist();
                btn_del.Text = "Xóa";
            }
        }

        private void btn_upd_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txt_maloai.Text))
            {
                if (btn_upd.Text == "Sửa")
                {
                    MessageBox.Show("Vui lòng nhập thông tin mới Sản phẩm, nếu không chắc vui lòng bấm Bỏ qua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    open();
                    txt_email.Enabled = false;
                    btn_upd.Text = "Lưu";
                }
                else
                {
                    sua();
                    cleartext();
                    locked();
                    loadlist();
                    btn_upd.Text = "Sửa";
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn sản phẩm để sửa", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btn_upd.Focus();
            }
        }

        private void btn_pas_Click(object sender, EventArgs e)
        {
            pass();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            if (btn_find.Text == "Tìm kiếm")
            {
                MessageBox.Show("Vui lòng nhập tên Sản phẩm, nếu không nhớ vui lòng bấm Bỏ qua", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_find.Enabled = true;
                txt_find.Text = null;
                txt_find.Focus();
                btn_find.Text = "Tìm";
            }
            else
            {
                tim();
                txt_find.Enabled = false;
                txt_find.Clear();
                txt_find.Text = "Nhập tên sản phâm";
                btn_find.Text = "Tìm kiếm";
            }
        }

        private void btn_M_Click(object sender, EventArgs e)
        {
            tab_control.SelectTab(tabPage1);
        }

        #endregion

        #region trash

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #endregion

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void tab_control_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void tab_control_ControlRemoved(object sender, ControlEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
    }
}