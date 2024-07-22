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

using iTextSharp.text;
using iTextSharp.text.pdf;

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

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            // Chuỗi kết nối tới cơ sở dữ liệu
            string connectionString = @"server=DESKTOP-8GQF8UM; database=sssj999; integrated security=true";

            // Tạo kết nối
            using (SqlConnection conn = new SqlConnection(connectionString))
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
    }
}
