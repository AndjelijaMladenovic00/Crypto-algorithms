
namespace CriptoClient
{
    partial class SHA_1
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
            this.SHAFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.sha1Label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.fileTbx = new System.Windows.Forms.TextBox();
            this.selectButton = new System.Windows.Forms.Button();
            this.hashButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.hashTbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SHAFileDialog
            // 
            this.SHAFileDialog.FileName = "openFileDialog1";
            this.SHAFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SHAFileDialog_FileOk);
            // 
            // sha1Label
            // 
            this.sha1Label.AutoSize = true;
            this.sha1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha1Label.Location = new System.Drawing.Point(379, 29);
            this.sha1Label.Name = "sha1Label";
            this.sha1Label.Size = new System.Drawing.Size(118, 39);
            this.sha1Label.TabIndex = 0;
            this.sha1Label.Text = "SHA-1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select file:";
            // 
            // fileTbx
            // 
            this.fileTbx.Enabled = false;
            this.fileTbx.Location = new System.Drawing.Point(162, 143);
            this.fileTbx.Name = "fileTbx";
            this.fileTbx.Size = new System.Drawing.Size(437, 22);
            this.fileTbx.TabIndex = 2;
            // 
            // selectButton
            // 
            this.selectButton.Location = new System.Drawing.Point(626, 142);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(190, 23);
            this.selectButton.TabIndex = 3;
            this.selectButton.Text = "Select from file system...";
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // hashButton
            // 
            this.hashButton.Location = new System.Drawing.Point(354, 235);
            this.hashButton.Name = "hashButton";
            this.hashButton.Size = new System.Drawing.Size(143, 23);
            this.hashButton.TabIndex = 4;
            this.hashButton.Text = "Calculate hash";
            this.hashButton.UseVisualStyleBackColor = true;
            this.hashButton.Click += new System.EventHandler(this.hashButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Result:";
            // 
            // hashTbx
            // 
            this.hashTbx.Location = new System.Drawing.Point(250, 319);
            this.hashTbx.Name = "hashTbx";
            this.hashTbx.Size = new System.Drawing.Size(322, 22);
            this.hashTbx.TabIndex = 6;
            // 
            // SHA_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 437);
            this.Controls.Add(this.hashTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hashButton);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.fileTbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sha1Label);
            this.Name = "SHA_1";
            this.Text = "SHA_1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog SHAFileDialog;
        private System.Windows.Forms.Label sha1Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileTbx;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Button hashButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hashTbx;
    }
}