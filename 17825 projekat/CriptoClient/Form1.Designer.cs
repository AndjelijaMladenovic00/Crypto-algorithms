
namespace CriptoClient
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
            this.title = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.algorithmLabel = new System.Windows.Forms.Label();
            this.actionBox = new System.Windows.Forms.ComboBox();
            this.algorithmBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.sha1Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Snow;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.SystemColors.ControlText;
            this.title.Location = new System.Drawing.Point(350, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(283, 39);
            this.title.TabIndex = 0;
            this.title.Text = "Protect your data!";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionLabel.Location = new System.Drawing.Point(92, 140);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(187, 25);
            this.actionLabel.TabIndex = 1;
            this.actionLabel.Text = "Choose your action:";
            // 
            // algorithmLabel
            // 
            this.algorithmLabel.AutoSize = true;
            this.algorithmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmLabel.Location = new System.Drawing.Point(65, 193);
            this.algorithmLabel.Name = "algorithmLabel";
            this.algorithmLabel.Size = new System.Drawing.Size(214, 25);
            this.algorithmLabel.TabIndex = 2;
            this.algorithmLabel.Text = "Choose your algorithm:";
            // 
            // actionBox
            // 
            this.actionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.actionBox.FormattingEnabled = true;
            this.actionBox.Items.AddRange(new object[] {
            "Encryption",
            "Decryption"});
            this.actionBox.Location = new System.Drawing.Point(396, 137);
            this.actionBox.Name = "actionBox";
            this.actionBox.Size = new System.Drawing.Size(430, 33);
            this.actionBox.TabIndex = 3;
            this.actionBox.SelectedIndexChanged += new System.EventHandler(this.actionBox_SelectedIndexChanged);
            // 
            // algorithmBox
            // 
            this.algorithmBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.algorithmBox.FormattingEnabled = true;
            this.algorithmBox.Items.AddRange(new object[] {
            "One-time-pad",
            "Four-Square Cipher - parallel",
            "Four-Square Cipher",
            "XXTEA",
            "OFB"});
            this.algorithmBox.Location = new System.Drawing.Point(396, 190);
            this.algorithmBox.Name = "algorithmBox";
            this.algorithmBox.Size = new System.Drawing.Size(430, 33);
            this.algorithmBox.TabIndex = 4;
            this.algorithmBox.SelectedIndexChanged += new System.EventHandler(this.algorithmBox_SelectedIndexChanged);
            // 
            // okButton
            // 
            this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okButton.Location = new System.Drawing.Point(396, 305);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(127, 48);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // sha1Button
            // 
            this.sha1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sha1Button.Location = new System.Drawing.Point(396, 380);
            this.sha1Button.Name = "sha1Button";
            this.sha1Button.Size = new System.Drawing.Size(127, 49);
            this.sha1Button.TabIndex = 6;
            this.sha1Button.Text = "SHA-1";
            this.sha1Button.UseVisualStyleBackColor = true;
            this.sha1Button.Click += new System.EventHandler(this.sha1Button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 462);
            this.Controls.Add(this.sha1Button);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.algorithmBox);
            this.Controls.Add(this.actionBox);
            this.Controls.Add(this.algorithmLabel);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label algorithmLabel;
        private System.Windows.Forms.ComboBox actionBox;
        private System.Windows.Forms.ComboBox algorithmBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button sha1Button;
    }
}

