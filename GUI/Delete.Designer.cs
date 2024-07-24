namespace GUI.Nhập_kho
{
    partial class Delete
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.mStr = new System.Windows.Forms.MenuStrip();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtg_SPNKh = new System.Windows.Forms.DataGridView();
            this.txt_maloai = new System.Windows.Forms.TextBox();
            this.btn_pas = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.mStr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SPNKh)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(316, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 37);
            this.label1.TabIndex = 26;
            this.label1.Text = "XÓA SẢN PHẨM";
            // 
            // mStr
            // 
            this.mStr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mStr.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mStr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItem});
            this.mStr.Location = new System.Drawing.Point(0, 459);
            this.mStr.Name = "mStr";
            this.mStr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mStr.Size = new System.Drawing.Size(937, 28);
            this.mStr.TabIndex = 24;
            this.mStr.Text = "menuStrip1";
            // 
            // mToolStripMenuItem
            // 
            this.mToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.tìmKiếmToolStripMenuItem,
            this.xemDanhSáchToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.sửaToolStripMenuItem});
            this.mToolStripMenuItem.Image = global::GUI.Properties.Resources.Menu;
            this.mToolStripMenuItem.Name = "mToolStripMenuItem";
            this.mToolStripMenuItem.Size = new System.Drawing.Size(34, 24);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            this.tìmKiếmToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmToolStripMenuItem_Click);
            // 
            // xemDanhSáchToolStripMenuItem
            // 
            this.xemDanhSáchToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemDanhSáchToolStripMenuItem.Name = "xemDanhSáchToolStripMenuItem";
            this.xemDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xemDanhSáchToolStripMenuItem.Text = "Xem danh sách";
            this.xemDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xóaToolStripMenuItem.Text = "Sửa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sửaToolStripMenuItem.Text = "Thêm";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // dtg_SPNKh
            // 
            this.dtg_SPNKh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SPNKh.Location = new System.Drawing.Point(12, 50);
            this.dtg_SPNKh.Name = "dtg_SPNKh";
            this.dtg_SPNKh.RowHeadersWidth = 51;
            this.dtg_SPNKh.RowTemplate.Height = 24;
            this.dtg_SPNKh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtg_SPNKh.Size = new System.Drawing.Size(690, 406);
            this.dtg_SPNKh.TabIndex = 27;
            this.dtg_SPNKh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_SPNKh_CellContentClick);
            // 
            // txt_maloai
            // 
            this.txt_maloai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_maloai.Location = new System.Drawing.Point(708, 50);
            this.txt_maloai.Name = "txt_maloai";
            this.txt_maloai.Size = new System.Drawing.Size(217, 23);
            this.txt_maloai.TabIndex = 29;
            // 
            // btn_pas
            // 
            this.btn_pas.BackgroundImage = global::GUI.Properties.Resources.Reload;
            this.btn_pas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pas.Location = new System.Drawing.Point(825, 79);
            this.btn_pas.Name = "btn_pas";
            this.btn_pas.Size = new System.Drawing.Size(100, 52);
            this.btn_pas.TabIndex = 28;
            this.btn_pas.UseVisualStyleBackColor = true;
            this.btn_pas.Click += new System.EventHandler(this.btn_pas_Click);
            // 
            // btn_del
            // 
            this.btn_del.BackgroundImage = global::GUI.Properties.Resources.Xóa;
            this.btn_del.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del.Location = new System.Drawing.Point(708, 79);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(111, 52);
            this.btn_del.TabIndex = 25;
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // Delete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 487);
            this.Controls.Add(this.txt_maloai);
            this.Controls.Add(this.btn_pas);
            this.Controls.Add(this.dtg_SPNKh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.mStr);
            this.Name = "Delete";
            this.Text = "Delete";
            this.Load += new System.EventHandler(this.Delete_Load);
            this.mStr.ResumeLayout(false);
            this.mStr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SPNKh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.MenuStrip mStr;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.DataGridView dtg_SPNKh;
        private System.Windows.Forms.Button btn_pas;
        private System.Windows.Forms.TextBox txt_maloai;
    }
}