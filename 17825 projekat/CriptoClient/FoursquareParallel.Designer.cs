
namespace CriptoClient
{
    partial class FoursquareParallel
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
            this.actionButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.fileLabel = new System.Windows.Forms.Label();
            this.fileTbx = new System.Windows.Forms.TextBox();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(303, 244);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(172, 33);
            this.actionButton.TabIndex = 9;
            this.actionButton.Text = "button1";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click_1);
            // 
            // fileButton
            // 
            this.fileButton.Location = new System.Drawing.Point(539, 152);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(183, 25);
            this.fileButton.TabIndex = 8;
            this.fileButton.Text = "Select from file system...";
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.fileButton_Click_1);
            // 
            // fileLabel
            // 
            this.fileLabel.AutoSize = true;
            this.fileLabel.Location = new System.Drawing.Point(75, 158);
            this.fileLabel.Name = "fileLabel";
            this.fileLabel.Size = new System.Drawing.Size(34, 17);
            this.fileLabel.TabIndex = 7;
            this.fileLabel.Text = "File:";
            // 
            // fileTbx
            // 
            this.fileTbx.Enabled = false;
            this.fileTbx.Location = new System.Drawing.Point(127, 155);
            this.fileTbx.Name = "fileTbx";
            this.fileTbx.Size = new System.Drawing.Size(348, 22);
            this.fileTbx.TabIndex = 6;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(201, 73);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(391, 39);
            this.TitleLabel.TabIndex = 5;
            this.TitleLabel.Text = "Four-Square parallelised";
            // 
            // FileDialog
            // 
            this.FileDialog.FileName = "FileDialog";
            this.FileDialog.Filter = "Text files(*.txt)|*.txt";
            this.FileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialog_FileOk);
            // 
            // FoursquareParallel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 330);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.fileLabel);
            this.Controls.Add(this.fileTbx);
            this.Controls.Add(this.TitleLabel);
            this.Name = "FoursquareParallel";
            this.Text = "Four-Square parallelised";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button actionButton;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Label fileLabel;
        private System.Windows.Forms.TextBox fileTbx;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.OpenFileDialog FileDialog;
    }
}