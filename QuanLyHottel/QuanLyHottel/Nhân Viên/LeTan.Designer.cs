namespace QuanLyHottel
{
    partial class LeTan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePickerLC = new System.Windows.Forms.DateTimePicker();
            this.buttonKT = new System.Windows.Forms.Button();
            this.buttonBD = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.quảnLíPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậnPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trảPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tinhTrạngPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(69, 169);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(370, 110);
            this.dataGridView1.TabIndex = 16;
            // 
            // dateTimePickerLC
            // 
            this.dateTimePickerLC.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerLC.Location = new System.Drawing.Point(115, 60);
            this.dateTimePickerLC.Name = "dateTimePickerLC";
            this.dateTimePickerLC.Size = new System.Drawing.Size(291, 20);
            this.dateTimePickerLC.TabIndex = 14;
            // 
            // buttonKT
            // 
            this.buttonKT.BackColor = System.Drawing.Color.Red;
            this.buttonKT.Location = new System.Drawing.Point(395, 102);
            this.buttonKT.Name = "buttonKT";
            this.buttonKT.Size = new System.Drawing.Size(75, 37);
            this.buttonKT.TabIndex = 13;
            this.buttonKT.Text = "End";
            this.buttonKT.UseVisualStyleBackColor = false;
            this.buttonKT.Click += new System.EventHandler(this.ButtonKT_Click);
            // 
            // buttonBD
            // 
            this.buttonBD.BackColor = System.Drawing.Color.SpringGreen;
            this.buttonBD.Location = new System.Drawing.Point(53, 102);
            this.buttonBD.Name = "buttonBD";
            this.buttonBD.Size = new System.Drawing.Size(75, 37);
            this.buttonBD.TabIndex = 12;
            this.buttonBD.Text = "Star";
            this.buttonBD.UseVisualStyleBackColor = false;
            this.buttonBD.Click += new System.EventHandler(this.ButtonBD_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quảnLíPhòngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // quảnLíPhòngToolStripMenuItem
            // 
            this.quảnLíPhòngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậnPhòngToolStripMenuItem,
            this.trảPhòngToolStripMenuItem,
            this.tinhTrạngPhòngToolStripMenuItem});
            this.quảnLíPhòngToolStripMenuItem.Name = "quảnLíPhòngToolStripMenuItem";
            this.quảnLíPhòngToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.quảnLíPhòngToolStripMenuItem.Text = "Quản Lí Phòng";
            // 
            // nhậnPhòngToolStripMenuItem
            // 
            this.nhậnPhòngToolStripMenuItem.Name = "nhậnPhòngToolStripMenuItem";
            this.nhậnPhòngToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.nhậnPhòngToolStripMenuItem.Text = "Đặt Phòng";
            this.nhậnPhòngToolStripMenuItem.Click += new System.EventHandler(this.NhậnPhòngToolStripMenuItem_Click);
            // 
            // trảPhòngToolStripMenuItem
            // 
            this.trảPhòngToolStripMenuItem.Name = "trảPhòngToolStripMenuItem";
            this.trảPhòngToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.trảPhòngToolStripMenuItem.Text = "Trả Phòng";
            this.trảPhòngToolStripMenuItem.Click += new System.EventHandler(this.TrảPhòngToolStripMenuItem_Click);
            // 
            // tinhTrạngPhòngToolStripMenuItem
            // 
            this.tinhTrạngPhòngToolStripMenuItem.Name = "tinhTrạngPhòngToolStripMenuItem";
            this.tinhTrạngPhòngToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.tinhTrạngPhòngToolStripMenuItem.Text = "Tinh Trạng Phòng";
            this.tinhTrạngPhòngToolStripMenuItem.Click += new System.EventHandler(this.TinhTrạngPhòngToolStripMenuItem_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(32, 305);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(449, 150);
            this.dataGridView2.TabIndex = 18;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "TimeWork";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "label2";
            // 
            // LeTan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(524, 493);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerLC);
            this.Controls.Add(this.buttonKT);
            this.Controls.Add(this.buttonBD);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LeTan";
            this.Text = "LeTan";
            this.Load += new System.EventHandler(this.LeTan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerLC;
        private System.Windows.Forms.Button buttonKT;
        private System.Windows.Forms.Button buttonBD;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem quảnLíPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậnPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trảPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tinhTrạngPhòngToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}