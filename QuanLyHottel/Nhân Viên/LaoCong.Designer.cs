namespace QuanLyHottel
{
    partial class LaoCong
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dateTimePickerLC = new System.Windows.Forms.DateTimePicker();
            this.buttonKT = new System.Windows.Forms.Button();
            this.buttonBD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(54, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(360, 110);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick_1);
            // 
            // dateTimePickerLC
            // 
            this.dateTimePickerLC.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerLC.Location = new System.Drawing.Point(88, 30);
            this.dateTimePickerLC.Name = "dateTimePickerLC";
            this.dateTimePickerLC.Size = new System.Drawing.Size(291, 20);
            this.dateTimePickerLC.TabIndex = 9;
            this.dateTimePickerLC.ValueChanged += new System.EventHandler(this.DateTimePickerLC_ValueChanged_1);
            // 
            // buttonKT
            // 
            this.buttonKT.BackColor = System.Drawing.Color.Red;
            this.buttonKT.Location = new System.Drawing.Point(304, 76);
            this.buttonKT.Name = "buttonKT";
            this.buttonKT.Size = new System.Drawing.Size(75, 37);
            this.buttonKT.TabIndex = 8;
            this.buttonKT.Text = "End";
            this.buttonKT.UseVisualStyleBackColor = false;
            this.buttonKT.Click += new System.EventHandler(this.ButtonKT_Click_1);
            // 
            // buttonBD
            // 
            this.buttonBD.BackColor = System.Drawing.Color.SpringGreen;
            this.buttonBD.Location = new System.Drawing.Point(88, 76);
            this.buttonBD.Name = "buttonBD";
            this.buttonBD.Size = new System.Drawing.Size(83, 37);
            this.buttonBD.TabIndex = 7;
            this.buttonBD.Text = "Star";
            this.buttonBD.UseVisualStyleBackColor = false;
            this.buttonBD.Click += new System.EventHandler(this.ButtonBD_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "TimeWork";
            // 
            // LaoCong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(477, 294);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dateTimePickerLC);
            this.Controls.Add(this.buttonKT);
            this.Controls.Add(this.buttonBD);
            this.Name = "LaoCong";
            this.Text = "LaoCong";
            this.Load += new System.EventHandler(this.LaoCong_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker dateTimePickerLC;
        private System.Windows.Forms.Button buttonKT;
        private System.Windows.Forms.Button buttonBD;
        private System.Windows.Forms.Label label1;
    }
}