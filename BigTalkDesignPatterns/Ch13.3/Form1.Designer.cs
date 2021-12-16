
namespace Ch13._3
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBuildFat = new System.Windows.Forms.Button();
            this.btnBuildThin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuildFat
            // 
            this.btnBuildFat.Location = new System.Drawing.Point(12, 244);
            this.btnBuildFat.Name = "btnBuildFat";
            this.btnBuildFat.Size = new System.Drawing.Size(127, 29);
            this.btnBuildFat.TabIndex = 7;
            this.btnBuildFat.Text = "Fat";
            this.btnBuildFat.UseVisualStyleBackColor = true;
            this.btnBuildFat.Click += new System.EventHandler(this.btnBuildFat_Click);
            // 
            // btnBuildThin
            // 
            this.btnBuildThin.Location = new System.Drawing.Point(12, 209);
            this.btnBuildThin.Name = "btnBuildThin";
            this.btnBuildThin.Size = new System.Drawing.Size(127, 29);
            this.btnBuildThin.TabIndex = 6;
            this.btnBuildThin.Text = "Thin";
            this.btnBuildThin.UseVisualStyleBackColor = true;
            this.btnBuildThin.Click += new System.EventHandler(this.btnBuildThin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(127, 191);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 282);
            this.Controls.Add(this.btnBuildFat);
            this.Controls.Add(this.btnBuildThin);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuildFat;
        private System.Windows.Forms.Button btnBuildThin;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

