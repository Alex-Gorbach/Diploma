namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.NumericEnd = new System.Windows.Forms.NumericUpDown();
            this.NumericStart = new System.Windows.Forms.NumericUpDown();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.ListTitles = new System.Windows.Forms.ListBox();
            this.StartPointLabel = new System.Windows.Forms.Label();
            this.EndPointLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericStart)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(593, 406);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // NumericEnd
            // 
            this.NumericEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericEnd.Location = new System.Drawing.Point(429, 104);
            this.NumericEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericEnd.Name = "NumericEnd";
            this.NumericEnd.Size = new System.Drawing.Size(137, 29);
            this.NumericEnd.TabIndex = 15;
            this.NumericEnd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // NumericStart
            // 
            this.NumericStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericStart.Location = new System.Drawing.Point(429, 36);
            this.NumericStart.Name = "NumericStart";
            this.NumericStart.Size = new System.Drawing.Size(137, 29);
            this.NumericStart.TabIndex = 14;
            this.NumericStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(429, 224);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(137, 52);
            this.metroButton1.TabIndex = 19;
            this.metroButton1.Text = "Стоп";
            this.metroButton1.Click += new System.EventHandler(this.AbortButtonClick);
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(429, 150);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(137, 50);
            this.metroButton2.TabIndex = 18;
            this.metroButton2.Text = "Старт";
            this.metroButton2.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ListTitles
            // 
            this.ListTitles.FormattingEnabled = true;
            this.ListTitles.Location = new System.Drawing.Point(8, 7);
            this.ListTitles.Name = "ListTitles";
            this.ListTitles.Size = new System.Drawing.Size(418, 381);
            this.ListTitles.TabIndex = 20;
            // 
            // StartPointLabel
            // 
            this.StartPointLabel.AutoSize = true;
            this.StartPointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartPointLabel.Location = new System.Drawing.Point(428, 9);
            this.StartPointLabel.Name = "StartPointLabel";
            this.StartPointLabel.Size = new System.Drawing.Size(128, 24);
            this.StartPointLabel.TabIndex = 21;
            this.StartPointLabel.Text = "Точка старта";
            // 
            // EndPointLabel
            // 
            this.EndPointLabel.AutoSize = true;
            this.EndPointLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndPointLabel.Location = new System.Drawing.Point(428, 77);
            this.EndPointLabel.Name = "EndPointLabel";
            this.EndPointLabel.Size = new System.Drawing.Size(161, 24);
            this.EndPointLabel.TabIndex = 22;
            this.EndPointLabel.Text = "Точка остановки";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(593, 404);
            this.Controls.Add(this.EndPointLabel);
            this.Controls.Add(this.StartPointLabel);
            this.Controls.Add(this.ListTitles);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.NumericEnd);
            this.Controls.Add(this.NumericStart);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Parser";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericStart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown NumericEnd;
        private System.Windows.Forms.NumericUpDown NumericStart;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.ListBox ListTitles;
        private System.Windows.Forms.Label StartPointLabel;
        private System.Windows.Forms.Label EndPointLabel;
    }
}

