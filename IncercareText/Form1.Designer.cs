namespace IncercareText
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
            this.storyTextbox = new System.Windows.Forms.RichTextBox();
            this.storyTitleLabel = new System.Windows.Forms.Label();
            this.advanceButton = new System.Windows.Forms.Button();
            this.rewindButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // storyTextbox
            // 
            this.storyTextbox.Font = new System.Drawing.Font("Microsoft Tai Le", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.storyTextbox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.storyTextbox.Location = new System.Drawing.Point(12, 40);
            this.storyTextbox.Name = "storyTextbox";
            this.storyTextbox.ReadOnly = true;
            this.storyTextbox.Size = new System.Drawing.Size(306, 360);
            this.storyTextbox.TabIndex = 2;
            this.storyTextbox.Text = "";
            // 
            // storyTitleLabel
            // 
            this.storyTitleLabel.AutoSize = true;
            this.storyTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.storyTitleLabel.Location = new System.Drawing.Point(12, 13);
            this.storyTitleLabel.Name = "storyTitleLabel";
            this.storyTitleLabel.Size = new System.Drawing.Size(228, 20);
            this.storyTitleLabel.TabIndex = 3;
            this.storyTitleLabel.Text = "Titlul poveștii (sau al capitolului)";
            // 
            // advanceButton
            // 
            this.advanceButton.Location = new System.Drawing.Point(204, 407);
            this.advanceButton.Name = "advanceButton";
            this.advanceButton.Size = new System.Drawing.Size(114, 23);
            this.advanceButton.TabIndex = 0;
            this.advanceButton.Text = "Avanseaza";
            this.advanceButton.UseVisualStyleBackColor = true;
            this.advanceButton.Click += new System.EventHandler(this.advanceButton_Click_1);
            // 
            // rewindButton
            // 
            this.rewindButton.Location = new System.Drawing.Point(12, 407);
            this.rewindButton.Name = "rewindButton";
            this.rewindButton.Size = new System.Drawing.Size(114, 23);
            this.rewindButton.TabIndex = 1;
            this.rewindButton.Text = "Inapoi";
            this.rewindButton.UseVisualStyleBackColor = true;
            this.rewindButton.Click += new System.EventHandler(this.rewindButton_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(330, 438);
            this.Controls.Add(this.rewindButton);
            this.Controls.Add(this.advanceButton);
            this.Controls.Add(this.storyTitleLabel);
            this.Controls.Add(this.storyTextbox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Titlul povestii";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox storyTextbox;
        private System.Windows.Forms.Label storyTitleLabel;
        private System.Windows.Forms.Button advanceButton;
        private System.Windows.Forms.Button rewindButton;
    }
}

