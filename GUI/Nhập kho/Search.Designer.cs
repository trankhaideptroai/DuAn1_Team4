namespace GUI.Nhập_kho
{
    partial class Search
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
            this.txt_ten = new System.Windows.Forms.TextBox();
            this.dtg_SPNKh = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.mStr = new System.Windows.Forms.MenuStrip();
            this.btn_sear = new System.Windows.Forms.Button();
            this.btn_pas = new System.Windows.Forms.Button();
            this.btn_luu = new System.Windows.Forms.Button();
            this.mToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemDanhSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SPNKh)).BeginInit();
            this.mStr.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_ten
            // 
            this.txt_ten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ten.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ten.Location = new System.Drawing.Point(212, 516);
            this.txt_ten.Name = "txt_ten";
            this.txt_ten.Size = new System.Drawing.Size(267, 30);
            this.txt_ten.TabIndex = 35;
            this.txt_ten.Text = "Nhập tên sản phẩm";
            // 
            // dtg_SPNKh
            // 
            this.dtg_SPNKh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg_SPNKh.Location = new System.Drawing.Point(12, 45);
            this.dtg_SPNKh.Name = "dtg_SPNKh";
            this.dtg_SPNKh.RowHeadersWidth = 51;
            this.dtg_SPNKh.RowTemplate.Height = 24;
            this.dtg_SPNKh.Size = new System.Drawing.Size(917, 453);
            this.dtg_SPNKh.TabIndex = 33;
            this.dtg_SPNKh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtg_SPNKh_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(291, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 37);
            this.label1.TabIndex = 32;
            this.label1.Text = "TÌM KIẾM SẢN PHẨM";
            // 
            // mStr
            // 
            this.mStr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.mStr.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mStr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mToolStripMenuItem});
            this.mStr.Location = new System.Drawing.Point(0, 554);
            this.mStr.Name = "mStr";
            this.mStr.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.mStr.Size = new System.Drawing.Size(941, 30);
            this.mStr.TabIndex = 30;
            this.mStr.Text = "menuStrip1";
            // 
            // btn_sear
            // 
            this.btn_sear.BackgroundImage = global::GUI.Properties.Resources.Tìm;
            this.btn_sear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_sear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sear.Location = new System.Drawing.Point(485, 504);
            this.btn_sear.Name = "btn_sear";
            this.btn_sear.Size = new System.Drawing.Size(111, 52);
            this.btn_sear.TabIndex = 36;
            this.btn_sear.UseVisualStyleBackColor = true;
            this.btn_sear.Click += new System.EventHandler(this.btn_sear_Click);
            // 
            // btn_pas
            // 
            this.btn_pas.BackgroundImage = global::GUI.Properties.Resources.Reload;
            this.btn_pas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_pas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pas.Location = new System.Drawing.Point(602, 504);
            this.btn_pas.Name = "btn_pas";
            this.btn_pas.Size = new System.Drawing.Size(100, 52);
            this.btn_pas.TabIndex = 34;
            this.btn_pas.UseVisualStyleBackColor = true;
            this.btn_pas.Click += new System.EventHandler(this.btn_pas_Click);
            // 
            // btn_luu
            // 
            this.btn_luu.BackgroundImage = global::GUI.Properties.Resources.Lưu;
            this.btn_luu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_luu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_luu.Location = new System.Drawing.Point(708, 504);
            this.btn_luu.Name = "btn_luu";
            this.btn_luu.Size = new System.Drawing.Size(111, 52);
            this.btn_luu.TabIndex = 31;
            this.btn_luu.UseVisualStyleBackColor = true;
            this.btn_luu.Click += new System.EventHandler(this.btn_luu_Click);
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
            this.mToolStripMenuItem.Size = new System.Drawing.Size(34, 26);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.menuToolStripMenuItem.Text = "Menu";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.menuToolStripMenuItem_Click_1);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.tìmKiếmToolStripMenuItem.Text = "Xem danh sách";
            this.tìmKiếmToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmToolStripMenuItem_Click);
            // 
            // xemDanhSáchToolStripMenuItem
            // 
            this.xemDanhSáchToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xemDanhSáchToolStripMenuItem.Name = "xemDanhSáchToolStripMenuItem";
            this.xemDanhSáchToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xemDanhSáchToolStripMenuItem.Text = "Sửa";
            this.xemDanhSáchToolStripMenuItem.Click += new System.EventHandler(this.xemDanhSáchToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.xóaToolStripMenuItem.Text = "Xóa";
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
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 584);
            this.Controls.Add(this.btn_sear);
            this.Controls.Add(this.txt_ten);
            this.Controls.Add(this.btn_pas);
            this.Controls.Add(this.dtg_SPNKh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_luu);
            this.Controls.Add(this.mStr);
            this.Name = "Search";
            this.Text = "Find";
            this.Load += new System.EventHandler(this.Search_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg_SPNKh)).EndInit();
            this.mStr.ResumeLayout(false);
            this.mStr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_ten;
        private System.Windows.Forms.Button btn_pas;
        private System.Windows.Forms.DataGridView dtg_SPNKh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_luu;
        private System.Windows.Forms.MenuStrip mStr;
        private System.Windows.Forms.ToolStripMenuItem mToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemDanhSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.Button btn_sear;
    }
}