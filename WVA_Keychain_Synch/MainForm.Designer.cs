using System;
using System.Drawing;
using System.Windows.Forms;

namespace WVA_Keychain_Synch
{
    partial class MainForm
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logoTab1 = new System.Windows.Forms.PictureBox();
            this.labelStatusHead = new System.Windows.Forms.Label();
            this.labelBarcodes = new System.Windows.Forms.Label();
            this.labelNumBarcodes = new System.Windows.Forms.Label();
            this.labelConnected = new System.Windows.Forms.Label();
            this.labelMain = new System.Windows.Forms.Label();
            this.sendData = new System.Windows.Forms.Button();
            this.labelMainDividerLine = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.setActPB = new System.Windows.Forms.ProgressBar();
            this.button5 = new System.Windows.Forms.Button();
            this.AccountLabel = new System.Windows.Forms.Label();
            this.AccountTextBox = new System.Windows.Forms.TextBox();
            this.LLViewCart = new System.Windows.Forms.LinkLabel();
            this.logoTab2 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.PrefPB = new System.Windows.Forms.ProgressBar();
            this.labelPrefHead = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.labelContactNum = new System.Windows.Forms.Label();
            this.backdrop = new System.Windows.Forms.PictureBox();
            this.labelComport = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelPrefs = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTab1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTab2)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backdrop)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("MS Reference Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(622, 394);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.logoTab1);
            this.tabPage1.Controls.Add(this.labelStatusHead);
            this.tabPage1.Controls.Add(this.labelBarcodes);
            this.tabPage1.Controls.Add(this.labelNumBarcodes);
            this.tabPage1.Controls.Add(this.labelConnected);
            this.tabPage1.Controls.Add(this.labelMain);
            this.tabPage1.Controls.Add(this.sendData);
            this.tabPage1.Controls.Add(this.labelMainDividerLine);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(614, 346);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " Scan  ";
            // 
            // logoTab1
            // 
            this.logoTab1.Image = ((System.Drawing.Image)(resources.GetObject("logoTab1.Image")));
            this.logoTab1.Location = new System.Drawing.Point(-15, -233);
            this.logoTab1.Margin = new System.Windows.Forms.Padding(4);
            this.logoTab1.Name = "logoTab1";
            this.logoTab1.Size = new System.Drawing.Size(933, 861);
            this.logoTab1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoTab1.TabIndex = 3;
            this.logoTab1.TabStop = false;
            // 
            // labelStatusHead
            // 
            this.labelStatusHead.AutoSize = true;
            this.labelStatusHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusHead.Location = new System.Drawing.Point(22, 67);
            this.labelStatusHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatusHead.Name = "labelStatusHead";
            this.labelStatusHead.Size = new System.Drawing.Size(85, 29);
            this.labelStatusHead.TabIndex = 4;
            this.labelStatusHead.Text = "Status:";
            // 
            // labelBarcodes
            // 
            this.labelBarcodes.AutoSize = true;
            this.labelBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodes.Location = new System.Drawing.Point(22, 153);
            this.labelBarcodes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBarcodes.Name = "labelBarcodes";
            this.labelBarcodes.Size = new System.Drawing.Size(223, 29);
            this.labelBarcodes.TabIndex = 5;
            this.labelBarcodes.Text = "Scanned Barcodes:";
            // 
            // labelNumBarcodes
            // 
            this.labelNumBarcodes.BackColor = System.Drawing.Color.White;
            this.labelNumBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumBarcodes.Location = new System.Drawing.Point(22, 187);
            this.labelNumBarcodes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumBarcodes.Name = "labelNumBarcodes";
            this.labelNumBarcodes.Size = new System.Drawing.Size(284, 33);
            this.labelNumBarcodes.TabIndex = 6;
            this.labelNumBarcodes.Text = "Not Connected";
            // 
            // labelConnected
            // 
            this.labelConnected.BackColor = System.Drawing.Color.White;
            this.labelConnected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnected.Location = new System.Drawing.Point(22, 103);
            this.labelConnected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(284, 33);
            this.labelConnected.TabIndex = 7;
            this.labelConnected.Text = "Not Connected";
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.Location = new System.Drawing.Point(7, 12);
            this.labelMain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(535, 26);
            this.labelMain.TabIndex = 8;
            this.labelMain.Text = "Be sure device is connected before sending data.";
            // 
            // sendData
            // 
            this.sendData.BackColor = System.Drawing.Color.White;
            this.sendData.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.sendData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendData.Location = new System.Drawing.Point(22, 250);
            this.sendData.Margin = new System.Windows.Forms.Padding(4);
            this.sendData.Name = "sendData";
            this.sendData.Size = new System.Drawing.Size(284, 43);
            this.sendData.TabIndex = 1;
            this.sendData.Text = "Download Scanner";
            this.sendData.UseVisualStyleBackColor = false;
            this.sendData.Click += new System.EventHandler(this.SendData_Click);
            // 
            // labelMainDividerLine
            // 
            this.labelMainDividerLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMainDividerLine.Location = new System.Drawing.Point(0, 55);
            this.labelMainDividerLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMainDividerLine.Name = "labelMainDividerLine";
            this.labelMainDividerLine.Size = new System.Drawing.Size(613, 3);
            this.labelMainDividerLine.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.setActPB);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.AccountLabel);
            this.tabPage2.Controls.Add(this.AccountTextBox);
            this.tabPage2.Controls.Add(this.LLViewCart);
            this.tabPage2.Controls.Add(this.logoTab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(614, 346);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " My Account ";
            this.tabPage2.Enter += new System.EventHandler(this.resetProgressBar);
            // 
            // setActPB
            // 
            this.setActPB.Location = new System.Drawing.Point(15, 121);
            this.setActPB.Name = "setActPB";
            this.setActPB.Size = new System.Drawing.Size(277, 31);
            this.setActPB.TabIndex = 7;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("MS Reference Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(15, 172);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(276, 40);
            this.button5.TabIndex = 6;
            this.button5.Text = "Set Account Number";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.SetAccountNumberBtn);
            // 
            // AccountLabel
            // 
            this.AccountLabel.AutoSize = true;
            this.AccountLabel.Location = new System.Drawing.Point(-9, 153);
            this.AccountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(283, 29);
            this.AccountLabel.TabIndex = 5;
            this.AccountLabel.Text = "Enter Account Number";
            // 
            // AccountTextBox
            // 
            this.AccountTextBox.Location = new System.Drawing.Point(15, 63);
            this.AccountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AccountTextBox.Name = "AccountTextBox";
            this.AccountTextBox.Size = new System.Drawing.Size(277, 36);
            this.AccountTextBox.TabIndex = 4;
            // 
            // LLViewCart
            // 
            this.LLViewCart.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLViewCart.LinkColor = System.Drawing.Color.Black;
            this.LLViewCart.Location = new System.Drawing.Point(22, 273);
            this.LLViewCart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LLViewCart.Name = "LLViewCart";
            this.LLViewCart.Size = new System.Drawing.Size(291, 33);
            this.LLViewCart.TabIndex = 0;
            this.LLViewCart.TabStop = true;
            this.LLViewCart.Text = "Review My Order";
            this.LLViewCart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLViewCart_LinkClicked);
            // 
            // logoTab2
            // 
            this.logoTab2.Image = ((System.Drawing.Image)(resources.GetObject("logoTab2.Image")));
            this.logoTab2.Location = new System.Drawing.Point(-15, -233);
            this.logoTab2.Margin = new System.Windows.Forms.Padding(4);
            this.logoTab2.Name = "logoTab2";
            this.logoTab2.Size = new System.Drawing.Size(933, 861);
            this.logoTab2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoTab2.TabIndex = 3;
            this.logoTab2.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.PrefPB);
            this.tabPage3.Controls.Add(this.labelPrefHead);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage3.Size = new System.Drawing.Size(614, 346);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " Preferences ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(164, 80);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(267, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "Scan UPC only";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(164, 148);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(267, 49);
            this.button3.TabIndex = 2;
            this.button3.Text = "Scan OPC only";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(164, 215);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(267, 49);
            this.button4.TabIndex = 3;
            this.button4.Text = "Scan UPC and OPC";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PrefPB
            // 
            this.PrefPB.Location = new System.Drawing.Point(97, 283);
            this.PrefPB.Margin = new System.Windows.Forms.Padding(4);
            this.PrefPB.Maximum = 50;
            this.PrefPB.Name = "PrefPB";
            this.PrefPB.Size = new System.Drawing.Size(400, 37);
            this.PrefPB.TabIndex = 4;
            // 
            // labelPrefHead
            // 
            this.labelPrefHead.AutoSize = true;
            this.labelPrefHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrefHead.Location = new System.Drawing.Point(130, 9);
            this.labelPrefHead.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPrefHead.Name = "labelPrefHead";
            this.labelPrefHead.Size = new System.Drawing.Size(338, 58);
            this.labelPrefHead.TabIndex = 0;
            this.labelPrefHead.Text = "Be sure device is connected \nwhile changing preferences!";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage4.Controls.Add(this.labelContactNum);
            this.tabPage4.Controls.Add(this.backdrop);
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage4.Size = new System.Drawing.Size(614, 346);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = " Help ";
            // 
            // labelContactNum
            // 
            this.labelContactNum.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactNum.Location = new System.Drawing.Point(42, 47);
            this.labelContactNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContactNum.Name = "labelContactNum";
            this.labelContactNum.Size = new System.Drawing.Size(560, 213);
            this.labelContactNum.TabIndex = 2;
            // 
            // backdrop
            // 
            this.backdrop.Image = ((System.Drawing.Image)(resources.GetObject("backdrop.Image")));
            this.backdrop.Location = new System.Drawing.Point(-227, -215);
            this.backdrop.Margin = new System.Windows.Forms.Padding(4);
            this.backdrop.Name = "backdrop";
            this.backdrop.Size = new System.Drawing.Size(1067, 985);
            this.backdrop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backdrop.TabIndex = 4;
            this.backdrop.TabStop = false;
            // 
            // labelComport
            // 
            this.labelComport.AutoSize = true;
            this.labelComport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelComport.Location = new System.Drawing.Point(92, 222);
            this.labelComport.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelComport.Name = "labelComport";
            this.labelComport.Size = new System.Drawing.Size(540, 39);
            this.labelComport.TabIndex = 5;
            this.labelComport.Text = "Connected to port: Not Connected";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // labelPrefs
            // 
            this.labelPrefs.Location = new System.Drawing.Point(0, 0);
            this.labelPrefs.Name = "labelPrefs";
            this.labelPrefs.Size = new System.Drawing.Size(100, 23);
            this.labelPrefs.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(622, 394);
            this.Controls.Add(this.tabControl1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::WVA_Keychain_Synch.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::WVA_Keychain_Synch.Properties.Settings.Default.Location;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WVA Scan";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTab1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoTab2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backdrop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion 
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelMain;
        private System.Windows.Forms.Label labelStatusHead;
        private System.Windows.Forms.Label labelConnected;
		private System.Windows.Forms.Label labelBarcodes;
        private System.Windows.Forms.Label labelNumBarcodes;
        private System.Windows.Forms.Label labelComport;
        private System.Windows.Forms.Label labelMainDividerLine;
        private System.Windows.Forms.Label labelPrefs;
        private System.Windows.Forms.Label labelPrefHead;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ProgressBar PrefPB;
        private System.Windows.Forms.Label labelContactNum;
        private System.Windows.Forms.PictureBox logoTab2;
        private System.Windows.Forms.Button sendData;
        private Label AccountLabel;
        private TextBox AccountTextBox;
        private Button button5;
        private PictureBox backdrop;
        private ProgressBar setActPB;
        private PictureBox logoTab1;
        private LinkLabel LLViewCart;
    }      
}

