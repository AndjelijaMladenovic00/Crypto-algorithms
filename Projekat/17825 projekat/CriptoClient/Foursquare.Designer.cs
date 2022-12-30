
namespace CriptoClient
{
    partial class Foursquare
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
            this.FourSquareLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InputBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultBox = new System.Windows.Forms.TextBox();
            this.actionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FourSquareLabel
            // 
            this.FourSquareLabel.AutoSize = true;
            this.FourSquareLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FourSquareLabel.Location = new System.Drawing.Point(231, 33);
            this.FourSquareLabel.Name = "FourSquareLabel";
            this.FourSquareLabel.Size = new System.Drawing.Size(318, 39);
            this.FourSquareLabel.TabIndex = 0;
            this.FourSquareLabel.Text = "Four-Square Cipher";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Your input:";
            // 
            // InputBox
            // 
            this.InputBox.Location = new System.Drawing.Point(183, 146);
            this.InputBox.Name = "InputBox";
            this.InputBox.Size = new System.Drawing.Size(506, 22);
            this.InputBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(125, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Result:";
            // 
            // ResultBox
            // 
            this.ResultBox.Location = new System.Drawing.Point(183, 196);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(506, 22);
            this.ResultBox.TabIndex = 5;
            // 
            // actionButton
            // 
            this.actionButton.Location = new System.Drawing.Point(343, 309);
            this.actionButton.Name = "actionButton";
            this.actionButton.Size = new System.Drawing.Size(99, 29);
            this.actionButton.TabIndex = 6;
            this.actionButton.Text = "button1";
            this.actionButton.UseVisualStyleBackColor = true;
            this.actionButton.Click += new System.EventHandler(this.actionButton_Click);
            // 
            // Foursquare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.actionButton);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InputBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FourSquareLabel);
            this.Name = "Foursquare";
            this.Text = "Foursquare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FourSquareLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ResultBox;
        private System.Windows.Forms.Button actionButton;
    }
}