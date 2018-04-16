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
            this.ListTitles = new System.Windows.Forms.ListBox();
            this.StartPoint = new System.Windows.Forms.Label();
            this.EndPoint = new System.Windows.Forms.Label();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.ButtonAbort = new System.Windows.Forms.Button();
            this.NumericStart = new System.Windows.Forms.NumericUpDown();
            this.NumericEnd = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumericStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEnd)).BeginInit();
            this.SuspendLayout();
            // 
            // ListTitles
            // 
            this.ListTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListTitles.FormattingEnabled = true;
            this.ListTitles.Location = new System.Drawing.Point(15, 11);
            this.ListTitles.Name = "ListTitles";
            this.ListTitles.Size = new System.Drawing.Size(402, 381);
            this.ListTitles.TabIndex = 0;
            // 
            // StartPoint
            // 
            this.StartPoint.AutoSize = true;
            this.StartPoint.Location = new System.Drawing.Point(420, 7);
            this.StartPoint.Name = "StartPoint";
            this.StartPoint.Size = new System.Drawing.Size(56, 13);
            this.StartPoint.TabIndex = 1;
            this.StartPoint.Text = "Start Point";
            // 
            // EndPoint
            // 
            this.EndPoint.AutoSize = true;
            this.EndPoint.Location = new System.Drawing.Point(423, 46);
            this.EndPoint.Name = "EndPoint";
            this.EndPoint.Size = new System.Drawing.Size(53, 13);
            this.EndPoint.TabIndex = 2;
            this.EndPoint.Text = "End Point";
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(423, 99);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(120, 23);
            this.ButtonStart.TabIndex = 5;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // ButtonAbort
            // 
            this.ButtonAbort.Location = new System.Drawing.Point(423, 139);
            this.ButtonAbort.Name = "ButtonAbort";
            this.ButtonAbort.Size = new System.Drawing.Size(120, 23);
            this.ButtonAbort.TabIndex = 6;
            this.ButtonAbort.Text = "Abort";
            this.ButtonAbort.UseVisualStyleBackColor = true;
            this.ButtonAbort.Click += new System.EventHandler(this.ButtonAbort_Click);
            // 
            // NumericStart
            // 
            this.NumericStart.Location = new System.Drawing.Point(423, 23);
            this.NumericStart.Name = "NumericStart";
            this.NumericStart.Size = new System.Drawing.Size(120, 20);
            this.NumericStart.TabIndex = 7;
            this.NumericStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NumericEnd
            // 
            this.NumericEnd.Location = new System.Drawing.Point(423, 62);
            this.NumericEnd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericEnd.Name = "NumericEnd";
            this.NumericEnd.Size = new System.Drawing.Size(120, 20);
            this.NumericEnd.TabIndex = 8;
            this.NumericEnd.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 404);
            this.Controls.Add(this.NumericEnd);
            this.Controls.Add(this.NumericStart);
            this.Controls.Add(this.ButtonAbort);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.EndPoint);
            this.Controls.Add(this.StartPoint);
            this.Controls.Add(this.ListTitles);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.NumericStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericEnd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListTitles;
        private System.Windows.Forms.Label StartPoint;
        private System.Windows.Forms.Label EndPoint;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Button ButtonAbort;
        private System.Windows.Forms.NumericUpDown NumericStart;
        private System.Windows.Forms.NumericUpDown NumericEnd;
    }
}

