using System;
using System.Drawing;
using System.Windows.Forms;

namespace WVA_Scan
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
            this.warningLabel = new System.Windows.Forms.Label();
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
            AccountTextBox = new System.Windows.Forms.TextBox();
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
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 320);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.warningLabel);
            this.tabPage1.Controls.Add(this.logoTab1);
            this.tabPage1.Controls.Add(this.labelStatusHead);
            this.tabPage1.Controls.Add(this.labelBarcodes);
            this.tabPage1.Controls.Add(this.labelNumBarcodes);
            this.tabPage1.Controls.Add(this.labelConnected);
            this.tabPage1.Controls.Add(this.labelMain);
            this.tabPage1.Controls.Add(this.sendData);
            this.tabPage1.Controls.Add(this.labelMainDividerLine);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(458, 272);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " Scan  ";
            // 
            // warningLabel
            // 
            this.warningLabel.AutoSize = true;
            this.warningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLabel.Location = new System.Drawing.Point(10, 250);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(420, 26);
            this.warningLabel.TabIndex = 9;
            this.warningLabel.Text = "Do not unplug scanner while downloading!";
            // 
            // logoTab1
            // 
            this.logoTab1.Image = ((System.Drawing.Image)(resources.GetObject("logoTab1.Image")));
            this.logoTab1.Location = new System.Drawing.Point(-11, -189);
            this.logoTab1.Name = "logoTab1";
            this.logoTab1.Size = new System.Drawing.Size(700, 700);
            this.logoTab1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoTab1.TabIndex = 3;
            this.logoTab1.TabStop = false;
            // 
            // labelStatusHead
            // 
            this.labelStatusHead.AutoSize = true;
            this.labelStatusHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatusHead.Location = new System.Drawing.Point(16, 50);
            this.labelStatusHead.Name = "labelStatusHead";
            this.labelStatusHead.Size = new System.Drawing.Size(65, 24);
            this.labelStatusHead.TabIndex = 4;
            this.labelStatusHead.Text = "Status:";
            // 
            // labelBarcodes
            // 
            this.labelBarcodes.AutoSize = true;
            this.labelBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBarcodes.Location = new System.Drawing.Point(16, 119);
            this.labelBarcodes.Name = "labelBarcodes";
            this.labelBarcodes.Size = new System.Drawing.Size(176, 24);
            this.labelBarcodes.TabIndex = 5;
            this.labelBarcodes.Text = "Scanned Barcodes:";
            // 
            // labelNumBarcodes
            // 
            this.labelNumBarcodes.BackColor = System.Drawing.Color.White;
            this.labelNumBarcodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumBarcodes.Location = new System.Drawing.Point(16, 148);
            this.labelNumBarcodes.Name = "labelNumBarcodes";
            this.labelNumBarcodes.Size = new System.Drawing.Size(213, 27);
            this.labelNumBarcodes.TabIndex = 6;
            this.labelNumBarcodes.Text = "Not Connected";
            // 
            // labelConnected
            // 
            this.labelConnected.BackColor = System.Drawing.Color.White;
            this.labelConnected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelConnected.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConnected.Location = new System.Drawing.Point(16, 80);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(213, 27);
            this.labelConnected.TabIndex = 7;
            this.labelConnected.Text = "Not Connected";
            // 
            // labelMain
            // 
            this.labelMain.AutoSize = true;
            this.labelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMain.Location = new System.Drawing.Point(5, 10);
            this.labelMain.Name = "labelMain";
            this.labelMain.Size = new System.Drawing.Size(452, 22);
            this.labelMain.TabIndex = 8;
            this.labelMain.Text = "Be sure device is connected before sending data.";
            // 
            // sendData
            // 
            this.sendData.BackColor = System.Drawing.Color.White;
            this.sendData.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.sendData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sendData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendData.Location = new System.Drawing.Point(16, 199);
            this.sendData.Name = "sendData";
            this.sendData.Size = new System.Drawing.Size(213, 35);
            this.sendData.TabIndex = 1;
            this.sendData.Text = "Download Scanner";
            this.sendData.UseVisualStyleBackColor = false;
            this.sendData.Click += new System.EventHandler(this.SendData_Click);
            // 
            // labelMainDividerLine
            // 
            this.labelMainDividerLine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelMainDividerLine.Location = new System.Drawing.Point(0, 45);
            this.labelMainDividerLine.Name = "labelMainDividerLine";
            this.labelMainDividerLine.Size = new System.Drawing.Size(460, 2);
            this.labelMainDividerLine.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.setActPB);
            this.tabPage2.Controls.Add(this.button5);
            this.tabPage2.Controls.Add(this.AccountLabel);
            this.tabPage2.Controls.Add(AccountTextBox);
            this.tabPage2.Controls.Add(this.LLViewCart);
            this.tabPage2.Controls.Add(this.logoTab2);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(458, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = " My Account ";
            this.tabPage2.Enter += new System.EventHandler(this.resetProgressBar);
            // 
            // setActPB
            // 
            this.setActPB.Location = new System.Drawing.Point(11, 98);
            this.setActPB.Margin = new System.Windows.Forms.Padding(2);
            this.setActPB.Name = "setActPB";
            this.setActPB.Size = new System.Drawing.Size(208, 25);
            this.setActPB.TabIndex = 5;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(11, 140);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "SetAccountNumberBtn";
            this.button5.Size = new System.Drawing.Size(207, 32);
            this.button5.TabIndex = 2;
            this.button5.Text = "Set Account Number";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.SetAccountNumberBtn);
            // 
            // AccountLabel
            // 
            this.AccountLabel.AutoSize = true;
            this.AccountLabel.Location = new System.Drawing.Point(-7, 114);
            this.AccountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AccountLabel.Name = "AccountLabel";
            this.AccountLabel.Size = new System.Drawing.Size(204, 24);
            this.AccountLabel.TabIndex = 0;
            this.AccountLabel.Text = "Enter Account Number";
            // 
            // AccountTextBox
            // 
            AccountTextBox.Location = new System.Drawing.Point(11, 51);
            AccountTextBox.Margin = new System.Windows.Forms.Padding(2);
            AccountTextBox.Name = "AccountTextBox";
            AccountTextBox.Size = new System.Drawing.Size(209, 29);
            AccountTextBox.TabIndex = 1;
            // 
            // LLViewCart
            // 
            this.LLViewCart.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LLViewCart.LinkColor = System.Drawing.Color.Black;
            this.LLViewCart.Location = new System.Drawing.Point(16, 222);
            this.LLViewCart.Name = "LLViewCart";
            this.LLViewCart.Size = new System.Drawing.Size(218, 27);
            this.LLViewCart.TabIndex = 3;
            this.LLViewCart.TabStop = true;
            this.LLViewCart.Text = "Review My Order";
            this.LLViewCart.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LLViewCart_LinkClicked);
            // 
            // logoTab2
            // 
            this.logoTab2.Image = ((System.Drawing.Image)(resources.GetObject("logoTab2.Image")));
            this.logoTab2.Location = new System.Drawing.Point(-11, -189);
            this.logoTab2.Name = "logoTab2";
            this.logoTab2.Size = new System.Drawing.Size(700, 700);
            this.logoTab2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoTab2.TabIndex = 6;
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
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(458, 272);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = " Preferences ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(123, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 40);
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
            this.button3.Location = new System.Drawing.Point(123, 120);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(200, 40);
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
            this.button4.Location = new System.Drawing.Point(123, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(200, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "Scan UPC and OPC";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PrefPB
            // 
            this.PrefPB.Location = new System.Drawing.Point(73, 230);
            this.PrefPB.Maximum = 50;
            this.PrefPB.Name = "PrefPB";
            this.PrefPB.Size = new System.Drawing.Size(300, 30);
            this.PrefPB.TabIndex = 4;
            // 
            // labelPrefHead
            // 
            this.labelPrefHead.AutoSize = true;
            this.labelPrefHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrefHead.Location = new System.Drawing.Point(98, 7);
            this.labelPrefHead.Name = "labelPrefHead";
            this.labelPrefHead.Size = new System.Drawing.Size(261, 50);
            this.labelPrefHead.TabIndex = 0;
            this.labelPrefHead.Text = "Be sure device is connected \r\nwhile changing preferences!";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.White;
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage4.Controls.Add(this.labelContactNum);
            this.tabPage4.Controls.Add(this.backdrop);
            this.tabPage4.Location = new System.Drawing.Point(4, 44);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(458, 272);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = " Help ";
            // 
            // labelContactNum
            // 
            this.labelContactNum.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelContactNum.Location = new System.Drawing.Point(32, 38);
            this.labelContactNum.Name = "labelContactNum";
            this.labelContactNum.Size = new System.Drawing.Size(382, 79);
            this.labelContactNum.TabIndex = 2;
            this.labelContactNum.Text = "For questions or concerns, please contact WVA Scanner Support at 800.747.9000 x81" +
    "91.";
            // 
            // backdrop
            // 
            this.backdrop.Image = ((System.Drawing.Image)(resources.GetObject("backdrop.Image")));
            this.backdrop.Location = new System.Drawing.Point(-170, -175);
            this.backdrop.Name = "backdrop";
            this.backdrop.Size = new System.Drawing.Size(800, 800);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(466, 320);
            this.Controls.Add(this.tabControl1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::WVA_Scan_App.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::WVA_Scan_App.Properties.Settings.Default.Location;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WVA Scan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
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
        private Button button5;
        private PictureBox backdrop;
        private PictureBox logoTab1;
        private LinkLabel LLViewCart;
        private Label warningLabel;
        public static TextBox AccountTextBox;
        public ProgressBar setActPB;
    }      
}

