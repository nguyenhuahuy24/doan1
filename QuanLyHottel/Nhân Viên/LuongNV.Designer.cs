namespace QuanLyHottel
{
    partial class LuongNV
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
            this.dataGridViewLuong = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewLuong
            // 
            this.dataGridViewLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLuong.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewLuong.Name = "dataGridViewLuong";
            this.dataGridViewLuong.Size = new System.Drawing.Size(325, 339);
            this.dataGridViewLuong.TabIndex = 0;
            // 
            // LuongNV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 363);
            this.Controls.Add(this.dataGridViewLuong);
            this.Name = "LuongNV";
            this.Text = "LuongNV";
            this.Load += new System.EventHandler(this.LuongNV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewLuong;
    }
}