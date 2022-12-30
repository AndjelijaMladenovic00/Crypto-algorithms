
namespace CriptoClient
{
    partial class XXTEA
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inputTbx = new System.Windows.Forms.TextBox();
            this.resultTbx = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.actionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "XXTEA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Enter text here:";
            // 
            // inputTbx
            // 
            this.inputTbx.Location = new System.Drawing.Point(73, 127);
            this.inputTbx.Multiline = true;
            this.inputTbx.Name = "inputTbx";
            this.inputTbx.Size = new System.Drawing.Size(649, 198);
            this.inputTbx.TabIndex = 2;
            // 
            // resultTbx
            // 
            this.resultTbx.Location = new System.Drawing.Point(73, 461);
            this.resultTbx.Multiline = true;
            this.resultTbx.Name = "resultTbx";
            this.resultTbx.Size = new System.Drawing.Size(649, 198);
            this.resultTbx.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 441);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result";
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(356, 374);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(104, 31);
            this.actionButton.TabIndex = 6;
            this.actionButton.Text = "button2";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // XXTEA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 689);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resultTbx);
            this.Controls.Add(this.inputTbx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "XXTEA";
            this.Text = "XXTEA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox inputTbx;
        private System.Windows.Forms.TextBox resultTbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button actionButton;
    }
}