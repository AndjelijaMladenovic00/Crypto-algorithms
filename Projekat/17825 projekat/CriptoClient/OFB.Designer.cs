
namespace CriptoClient
{
    partial class OFB
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
            this.ofbLabel = new System.Windows.Forms.Label();
            this.selectLabel = new System.Windows.Forms.Label();
            this.fileTbx = new System.Windows.Forms.TextBox();
            this.fileBtn = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.actionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ofbLabel
            // 
            this.ofbLabel.AutoSize = true;
            this.ofbLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ofbLabel.Location = new System.Drawing.Point(351, 32);
            this.ofbLabel.Name = "ofbLabel";
            this.ofbLabel.Size = new System.Drawing.Size(87, 39);
            this.ofbLabel.TabIndex = 0;
            this.ofbLabel.Text = "OFB";
            // 
            // selectLabel
            // 
            this.selectLabel.AutoSize = true;
            this.selectLabel.Location = new System.Drawing.Point(90, 155);
            this.selectLabel.Name = "selectLabel";
            this.selectLabel.Size = new System.Drawing.Size(73, 17);
            this.selectLabel.TabIndex = 1;
            this.selectLabel.Text = "Select file:";
            // 
            // fileTbx
            // 
            this.fileTbx.Enabled = false;
            this.fileTbx.Location = new System.Drawing.Point(210, 152);
            this.fileTbx.Name = "fileTbx";
            this.fileTbx.Size = new System.Drawing.Size(387, 22);
            this.fileTbx.TabIndex = 2;
            // 
            // fileBtn
            // 
            this.fileBtn.Location = new System.Drawing.Point(614, 152);
            this.fileBtn.Name = "fileBtn";
            this.fileBtn.Size = new System.Drawing.Size(174, 23);
            this.fileBtn.TabIndex = 3;
            this.fileBtn.Text = "Select from file system...";
            this.fileBtn.UseVisualStyleBackColor = true;
            this.fileBtn.Click += new System.EventHandler(this.fileBtn_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.Filter = "Image file|*.bmp";
            this.fileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.fileDialog_FileOk);
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(337, 262);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(126, 23);
            this.actionButton.TabIndex = 4;
            this.actionButton.Text = "button1";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // OFB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.fileBtn);
            this.Controls.Add(this.fileTbx);
            this.Controls.Add(this.selectLabel);
            this.Controls.Add(this.ofbLabel);
            this.Name = "OFB";
            this.Text = "OFB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ofbLabel;
        private System.Windows.Forms.Label selectLabel;
        private System.Windows.Forms.TextBox fileTbx;
        private System.Windows.Forms.Button fileBtn;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Button actionButton;
    }
}