namespace OEC222.AsyncWinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startBtn = new System.Windows.Forms.Button();
            this.lbl = new System.Windows.Forms.Label();
            this.txtBox = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.BackColor = System.Drawing.Color.Gold;
            this.startBtn.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startBtn.Location = new System.Drawing.Point(92, 45);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(161, 76);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = false;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(92, 150);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(38, 15);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "label1";
            // 
            // txtBox
            // 
            this.txtBox.Location = new System.Drawing.Point(95, 194);
            this.txtBox.Name = "txtBox";
            this.txtBox.Size = new System.Drawing.Size(158, 23);
            this.txtBox.TabIndex = 2;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(95, 268);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(158, 23);
            this.progressBar.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 450);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtBox);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startBtn;
        private Label lbl;
        private TextBox txtBox;
        private ProgressBar progressBar;
    }
}