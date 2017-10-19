using System.Drawing;

namespace Csp2dotnet
{
    partial class ErrorMessage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backdrop = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.backdrop)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(50, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "There was an error sending \nyour data.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label2.Location = new System.Drawing.Point(50, 220);
            this.label2.Name = "label1";
            this.label2.Size = new System.Drawing.Size(428, 44);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please contact WVA scanner \nsupport if the problem persists.";
            // 
            // backdrop
            // 
            this.backdrop.Image = Image.FromFile(@"C:\Users\Taylo\Desktop\Csp2.net.Test\res\WVA.jpg");
            this.backdrop.Location = new System.Drawing.Point(-450, -335);
            this.backdrop.Name = "backdrop";
            this.backdrop.Size = new System.Drawing.Size(1500, 1500);
            this.backdrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backdrop.TabIndex = 3;
            this.backdrop.TabStop = false;
            // 
            // Error Message Form
            // 
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backdrop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Error Message";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "WVA - Keychain Synch 3.0";
            ((System.ComponentModel.ISupportInitialize)(this.backdrop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox backdrop;
    }
}