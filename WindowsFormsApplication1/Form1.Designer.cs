namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.bitBox = new System.Windows.Forms.PictureBox();
            this.Score = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bitBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 32;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bitBox
            // 
            this.bitBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bitBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bitBox.Location = new System.Drawing.Point(0, 0);
            this.bitBox.Name = "bitBox";
            this.bitBox.Size = new System.Drawing.Size(1070, 861);
            this.bitBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bitBox.TabIndex = 0;
            this.bitBox.TabStop = false;
            this.bitBox.Click += new System.EventHandler(this.bitBox_Click);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Enabled = false;
            this.Score.Location = new System.Drawing.Point(1014, 8);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(16, 17);
            this.Score.TabIndex = 1;
            this.Score.Text = "0";
            this.Score.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 861);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.bitBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bitBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox bitBox;
        private System.Windows.Forms.Label Score;
    }
}

