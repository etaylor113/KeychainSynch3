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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_Scan = new System.Windows.Forms.TabPage();
            this.tb_ScannedItems = new System.Windows.Forms.TextBox();
            this.scannedItemsLabel = new System.Windows.Forms.Label();
            this.btn_CreateOrder = new System.Windows.Forms.Button();
            this.btn_ReviewOrder = new System.Windows.Forms.Button();
            this.rtb_ScanActionMessages = new System.Windows.Forms.RichTextBox();
            this.scannerStatusLabel = new System.Windows.Forms.Label();
            this.tb_ScannerStatus = new System.Windows.Forms.TextBox();
            this.picb_ScanTab = new System.Windows.Forms.PictureBox();
            this.tab_Messages = new System.Windows.Forms.TabPage();
            this.btn_ClearMessages = new System.Windows.Forms.Button();
            this.messagesLabel = new System.Windows.Forms.Label();
            this.rtb_Messages = new System.Windows.Forms.RichTextBox();
            this.picb_Messages = new System.Windows.Forms.PictureBox();
            this.tab_Account = new System.Windows.Forms.TabPage();
            this.btn_SetActNum = new System.Windows.Forms.Button();
            this.picb_AccountTab = new System.Windows.Forms.PictureBox();
            this.enterActNumLabel = new System.Windows.Forms.Label();
            this.tb_Actnum = new System.Windows.Forms.TextBox();
            this.tab_Preferences = new System.Windows.Forms.TabPage();
            this.btn_PrefLine = new System.Windows.Forms.Button();
            this.radb_ScanUPC_OPC = new System.Windows.Forms.RadioButton();
            this.radb_ScanOPC = new System.Windows.Forms.RadioButton();
            this.radb_ScanUPC = new System.Windows.Forms.RadioButton();
            this.rtb_Preferences = new System.Windows.Forms.RichTextBox();
            this.ll_PrefMoreInfoLink = new System.Windows.Forms.LinkLabel();
            this.picb_PrefTab = new System.Windows.Forms.PictureBox();
            this.pref_progb = new System.Windows.Forms.ProgressBar();
            this.btn_ChangePref = new System.Windows.Forms.Button();
            this.prefWarningLabel = new System.Windows.Forms.Label();
            this.tab_Help = new System.Windows.Forms.TabPage();
            this.ll_SupportLink = new System.Windows.Forms.LinkLabel();
            this.picb_HelpTab = new System.Windows.Forms.PictureBox();
            this.contactNumLabel = new System.Windows.Forms.Label();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.blinkTimer = new System.Windows.Forms.Timer(this.components);
            this.checkMessagesTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tab_Scan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_ScanTab)).BeginInit();
            this.tab_Messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Messages)).BeginInit();
            this.tab_Account.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_AccountTab)).BeginInit();
            this.tab_Preferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_PrefTab)).BeginInit();
            this.tab_Help.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_HelpTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabControl.Controls.Add(this.tab_Scan);
            this.tabControl.Controls.Add(this.tab_Messages);
            this.tabControl.Controls.Add(this.tab_Account);
            this.tabControl.Controls.Add(this.tab_Preferences);
            this.tabControl.Controls.Add(this.tab_Help);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(620, 403);
            this.tabControl.TabIndex = 0;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            // 
            // tab_Scan
            // 
            this.tab_Scan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tab_Scan.Controls.Add(this.tb_ScannedItems);
            this.tab_Scan.Controls.Add(this.scannedItemsLabel);
            this.tab_Scan.Controls.Add(this.btn_CreateOrder);
            this.tab_Scan.Controls.Add(this.btn_ReviewOrder);
            this.tab_Scan.Controls.Add(this.rtb_ScanActionMessages);
            this.tab_Scan.Controls.Add(this.scannerStatusLabel);
            this.tab_Scan.Controls.Add(this.tb_ScannerStatus);
            this.tab_Scan.Controls.Add(this.picb_ScanTab);
            this.tab_Scan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Scan.Location = new System.Drawing.Point(4, 37);
            this.tab_Scan.Name = "tab_Scan";
            this.tab_Scan.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Scan.Size = new System.Drawing.Size(612, 362);
            this.tab_Scan.TabIndex = 0;
            this.tab_Scan.Text = "Scan";
            this.tab_Scan.Enter += new System.EventHandler(this.tab_Scan_Enter);
            this.tab_Scan.Leave += new System.EventHandler(this.tab_Scan_Leave);
            // 
            // tb_ScannedItems
            // 
            this.tb_ScannedItems.Location = new System.Drawing.Point(316, 199);
            this.tb_ScannedItems.Name = "tb_ScannedItems";
            this.tb_ScannedItems.ReadOnly = true;
            this.tb_ScannedItems.Size = new System.Drawing.Size(172, 31);
            this.tb_ScannedItems.TabIndex = 10;
            this.tb_ScannedItems.Text = "Not Connected";
            // 
            // scannedItemsLabel
            // 
            this.scannedItemsLabel.AutoSize = true;
            this.scannedItemsLabel.Location = new System.Drawing.Point(311, 171);
            this.scannedItemsLabel.Name = "scannedItemsLabel";
            this.scannedItemsLabel.Size = new System.Drawing.Size(160, 25);
            this.scannedItemsLabel.TabIndex = 9;
            this.scannedItemsLabel.Text = "Scanned Items:";
            // 
            // btn_CreateOrder
            // 
            this.btn_CreateOrder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_CreateOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CreateOrder.Location = new System.Drawing.Point(102, 298);
            this.btn_CreateOrder.Name = "btn_CreateOrder";
            this.btn_CreateOrder.Size = new System.Drawing.Size(171, 35);
            this.btn_CreateOrder.TabIndex = 8;
            this.btn_CreateOrder.Text = "Create Order";
            this.btn_CreateOrder.UseVisualStyleBackColor = false;
            this.btn_CreateOrder.Click += new System.EventHandler(this.btn_CreateOrder_Click);
            // 
            // btn_ReviewOrder
            // 
            this.btn_ReviewOrder.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ReviewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ReviewOrder.Location = new System.Drawing.Point(316, 298);
            this.btn_ReviewOrder.Name = "btn_ReviewOrder";
            this.btn_ReviewOrder.Size = new System.Drawing.Size(172, 35);
            this.btn_ReviewOrder.TabIndex = 7;
            this.btn_ReviewOrder.Text = "Review Orders";
            this.btn_ReviewOrder.UseVisualStyleBackColor = false;
            this.btn_ReviewOrder.Click += new System.EventHandler(this.btn_ReviewOrder_Click);
            // 
            // rtb_ScanActionMessages
            // 
            this.rtb_ScanActionMessages.Location = new System.Drawing.Point(102, 248);
            this.rtb_ScanActionMessages.Name = "rtb_ScanActionMessages";
            this.rtb_ScanActionMessages.ReadOnly = true;
            this.rtb_ScanActionMessages.Size = new System.Drawing.Size(386, 31);
            this.rtb_ScanActionMessages.TabIndex = 4;
            this.rtb_ScanActionMessages.Text = "";
            // 
            // scannerStatusLabel
            // 
            this.scannerStatusLabel.AutoSize = true;
            this.scannerStatusLabel.Location = new System.Drawing.Point(97, 171);
            this.scannerStatusLabel.Name = "scannerStatusLabel";
            this.scannerStatusLabel.Size = new System.Drawing.Size(165, 25);
            this.scannerStatusLabel.TabIndex = 2;
            this.scannerStatusLabel.Text = "Scanner Status:";
            // 
            // tb_ScannerStatus
            // 
            this.tb_ScannerStatus.Location = new System.Drawing.Point(102, 199);
            this.tb_ScannerStatus.Name = "tb_ScannerStatus";
            this.tb_ScannerStatus.ReadOnly = true;
            this.tb_ScannerStatus.Size = new System.Drawing.Size(171, 31);
            this.tb_ScannerStatus.TabIndex = 1;
            this.tb_ScannerStatus.Text = "Not Connected";
            // 
            // picb_ScanTab
            // 
            this.picb_ScanTab.Image = global::WVA_Scan.Properties.Resources.WVAScanLogo_Clear;
            this.picb_ScanTab.Location = new System.Drawing.Point(114, 3);
            this.picb_ScanTab.Name = "picb_ScanTab";
            this.picb_ScanTab.Size = new System.Drawing.Size(363, 120);
            this.picb_ScanTab.TabIndex = 0;
            this.picb_ScanTab.TabStop = false;
            // 
            // tab_Messages
            // 
            this.tab_Messages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tab_Messages.Controls.Add(this.btn_ClearMessages);
            this.tab_Messages.Controls.Add(this.messagesLabel);
            this.tab_Messages.Controls.Add(this.rtb_Messages);
            this.tab_Messages.Controls.Add(this.picb_Messages);
            this.tab_Messages.Location = new System.Drawing.Point(4, 37);
            this.tab_Messages.Name = "tab_Messages";
            this.tab_Messages.Size = new System.Drawing.Size(612, 362);
            this.tab_Messages.TabIndex = 4;
            this.tab_Messages.Text = "Messages";
            this.tab_Messages.Enter += new System.EventHandler(this.tab_Messages_Enter);
            // 
            // btn_ClearMessages
            // 
            this.btn_ClearMessages.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ClearMessages.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btn_ClearMessages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ClearMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ClearMessages.Location = new System.Drawing.Point(192, 326);
            this.btn_ClearMessages.Name = "btn_ClearMessages";
            this.btn_ClearMessages.Size = new System.Drawing.Size(234, 31);
            this.btn_ClearMessages.TabIndex = 9;
            this.btn_ClearMessages.Text = "Clear and go to Scan tab";
            this.btn_ClearMessages.UseVisualStyleBackColor = false;
            this.btn_ClearMessages.Click += new System.EventHandler(this.btn_ClearMessages_Click);
            // 
            // messagesLabel
            // 
            this.messagesLabel.AutoSize = true;
            this.messagesLabel.Location = new System.Drawing.Point(109, 128);
            this.messagesLabel.Name = "messagesLabel";
            this.messagesLabel.Size = new System.Drawing.Size(394, 25);
            this.messagesLabel.TabIndex = 5;
            this.messagesLabel.Text = "Any messages you get will appear here:";
            // 
            // rtb_Messages
            // 
            this.rtb_Messages.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rtb_Messages.Location = new System.Drawing.Point(114, 156);
            this.rtb_Messages.Name = "rtb_Messages";
            this.rtb_Messages.ReadOnly = true;
            this.rtb_Messages.Size = new System.Drawing.Size(380, 166);
            this.rtb_Messages.TabIndex = 4;
            this.rtb_Messages.Text = "";
            // 
            // picb_Messages
            // 
            this.picb_Messages.Image = global::WVA_Scan.Properties.Resources.WVAScanLogo_Clear;
            this.picb_Messages.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picb_Messages.Location = new System.Drawing.Point(114, 3);
            this.picb_Messages.Name = "picb_Messages";
            this.picb_Messages.Size = new System.Drawing.Size(380, 122);
            this.picb_Messages.TabIndex = 3;
            this.picb_Messages.TabStop = false;
            // 
            // tab_Account
            // 
            this.tab_Account.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tab_Account.Controls.Add(this.btn_SetActNum);
            this.tab_Account.Controls.Add(this.picb_AccountTab);
            this.tab_Account.Controls.Add(this.enterActNumLabel);
            this.tab_Account.Controls.Add(this.tb_Actnum);
            this.tab_Account.Location = new System.Drawing.Point(4, 37);
            this.tab_Account.Name = "tab_Account";
            this.tab_Account.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Account.Size = new System.Drawing.Size(612, 362);
            this.tab_Account.TabIndex = 1;
            this.tab_Account.Text = "Account";
            this.tab_Account.Enter += new System.EventHandler(this.resetAccountTab);
            // 
            // btn_SetActNum
            // 
            this.btn_SetActNum.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_SetActNum.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btn_SetActNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetActNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SetActNum.Location = new System.Drawing.Point(255, 235);
            this.btn_SetActNum.Name = "btn_SetActNum";
            this.btn_SetActNum.Size = new System.Drawing.Size(103, 40);
            this.btn_SetActNum.TabIndex = 8;
            this.btn_SetActNum.Text = "Set";
            this.btn_SetActNum.UseVisualStyleBackColor = false;
            this.btn_SetActNum.Click += new System.EventHandler(this.btn_SetActNum_Click);
            // 
            // picb_AccountTab
            // 
            this.picb_AccountTab.Image = global::WVA_Scan.Properties.Resources.WVAScanLogo_Clear;
            this.picb_AccountTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picb_AccountTab.Location = new System.Drawing.Point(114, 3);
            this.picb_AccountTab.Name = "picb_AccountTab";
            this.picb_AccountTab.Size = new System.Drawing.Size(380, 122);
            this.picb_AccountTab.TabIndex = 2;
            this.picb_AccountTab.TabStop = false;
            // 
            // enterActNumLabel
            // 
            this.enterActNumLabel.AutoSize = true;
            this.enterActNumLabel.Location = new System.Drawing.Point(187, 170);
            this.enterActNumLabel.Name = "enterActNumLabel";
            this.enterActNumLabel.Size = new System.Drawing.Size(234, 25);
            this.enterActNumLabel.TabIndex = 1;
            this.enterActNumLabel.Text = "Enter Account Number:";
            // 
            // tb_Actnum
            // 
            this.tb_Actnum.Location = new System.Drawing.Point(192, 198);
            this.tb_Actnum.Name = "tb_Actnum";
            this.tb_Actnum.Size = new System.Drawing.Size(229, 31);
            this.tb_Actnum.TabIndex = 0;
            // 
            // tab_Preferences
            // 
            this.tab_Preferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tab_Preferences.Controls.Add(this.btn_PrefLine);
            this.tab_Preferences.Controls.Add(this.radb_ScanUPC_OPC);
            this.tab_Preferences.Controls.Add(this.radb_ScanOPC);
            this.tab_Preferences.Controls.Add(this.radb_ScanUPC);
            this.tab_Preferences.Controls.Add(this.rtb_Preferences);
            this.tab_Preferences.Controls.Add(this.ll_PrefMoreInfoLink);
            this.tab_Preferences.Controls.Add(this.picb_PrefTab);
            this.tab_Preferences.Controls.Add(this.pref_progb);
            this.tab_Preferences.Controls.Add(this.btn_ChangePref);
            this.tab_Preferences.Controls.Add(this.prefWarningLabel);
            this.tab_Preferences.Location = new System.Drawing.Point(4, 37);
            this.tab_Preferences.Name = "tab_Preferences";
            this.tab_Preferences.Size = new System.Drawing.Size(612, 362);
            this.tab_Preferences.TabIndex = 2;
            this.tab_Preferences.Text = "Preferences";
            this.tab_Preferences.Enter += new System.EventHandler(this.tab_Preferences_Enter);
            // 
            // btn_PrefLine
            // 
            this.btn_PrefLine.BackColor = System.Drawing.Color.DimGray;
            this.btn_PrefLine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PrefLine.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_PrefLine.Location = new System.Drawing.Point(333, 144);
            this.btn_PrefLine.Name = "btn_PrefLine";
            this.btn_PrefLine.Size = new System.Drawing.Size(2, 193);
            this.btn_PrefLine.TabIndex = 17;
            this.btn_PrefLine.UseVisualStyleBackColor = false;
            // 
            // radb_ScanUPC_OPC
            // 
            this.radb_ScanUPC_OPC.AutoSize = true;
            this.radb_ScanUPC_OPC.Location = new System.Drawing.Point(374, 242);
            this.radb_ScanUPC_OPC.Name = "radb_ScanUPC_OPC";
            this.radb_ScanUPC_OPC.Size = new System.Drawing.Size(222, 29);
            this.radb_ScanUPC_OPC.TabIndex = 16;
            this.radb_ScanUPC_OPC.TabStop = true;
            this.radb_ScanUPC_OPC.Text = "Scan UPC and OPC";
            this.radb_ScanUPC_OPC.UseVisualStyleBackColor = true;
            // 
            // radb_ScanOPC
            // 
            this.radb_ScanOPC.AutoSize = true;
            this.radb_ScanOPC.Location = new System.Drawing.Point(374, 207);
            this.radb_ScanOPC.Name = "radb_ScanOPC";
            this.radb_ScanOPC.Size = new System.Drawing.Size(176, 29);
            this.radb_ScanOPC.TabIndex = 15;
            this.radb_ScanOPC.TabStop = true;
            this.radb_ScanOPC.Text = "Scan OPC only";
            this.radb_ScanOPC.UseVisualStyleBackColor = true;
            // 
            // radb_ScanUPC
            // 
            this.radb_ScanUPC.AutoSize = true;
            this.radb_ScanUPC.Location = new System.Drawing.Point(374, 172);
            this.radb_ScanUPC.Name = "radb_ScanUPC";
            this.radb_ScanUPC.Size = new System.Drawing.Size(175, 29);
            this.radb_ScanUPC.TabIndex = 14;
            this.radb_ScanUPC.TabStop = true;
            this.radb_ScanUPC.Text = "Scan UPC only";
            this.radb_ScanUPC.UseVisualStyleBackColor = true;
            // 
            // rtb_Preferences
            // 
            this.rtb_Preferences.Location = new System.Drawing.Point(41, 195);
            this.rtb_Preferences.Name = "rtb_Preferences";
            this.rtb_Preferences.ReadOnly = true;
            this.rtb_Preferences.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtb_Preferences.Size = new System.Drawing.Size(248, 106);
            this.rtb_Preferences.TabIndex = 13;
            this.rtb_Preferences.Text = "";
            // 
            // ll_PrefMoreInfoLink
            // 
            this.ll_PrefMoreInfoLink.AutoSize = true;
            this.ll_PrefMoreInfoLink.Location = new System.Drawing.Point(503, 333);
            this.ll_PrefMoreInfoLink.Name = "ll_PrefMoreInfoLink";
            this.ll_PrefMoreInfoLink.Size = new System.Drawing.Size(102, 25);
            this.ll_PrefMoreInfoLink.TabIndex = 12;
            this.ll_PrefMoreInfoLink.TabStop = true;
            this.ll_PrefMoreInfoLink.Text = "More Info";
            this.ll_PrefMoreInfoLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_PrefMoreInfoLink_LinkClicked);
            // 
            // picb_PrefTab
            // 
            this.picb_PrefTab.Image = global::WVA_Scan.Properties.Resources.WVAScanLogo_Clear;
            this.picb_PrefTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picb_PrefTab.Location = new System.Drawing.Point(114, 3);
            this.picb_PrefTab.Name = "picb_PrefTab";
            this.picb_PrefTab.Size = new System.Drawing.Size(380, 122);
            this.picb_PrefTab.TabIndex = 11;
            this.picb_PrefTab.TabStop = false;
            // 
            // pref_progb
            // 
            this.pref_progb.Location = new System.Drawing.Point(41, 307);
            this.pref_progb.Maximum = 50;
            this.pref_progb.Name = "pref_progb";
            this.pref_progb.Size = new System.Drawing.Size(248, 30);
            this.pref_progb.TabIndex = 10;
            // 
            // btn_ChangePref
            // 
            this.btn_ChangePref.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ChangePref.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateGray;
            this.btn_ChangePref.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChangePref.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ChangePref.Location = new System.Drawing.Point(397, 278);
            this.btn_ChangePref.Name = "btn_ChangePref";
            this.btn_ChangePref.Size = new System.Drawing.Size(135, 40);
            this.btn_ChangePref.TabIndex = 7;
            this.btn_ChangePref.Text = "Go";
            this.btn_ChangePref.UseVisualStyleBackColor = false;
            this.btn_ChangePref.Click += new System.EventHandler(this.btn_ChangePref_Click);
            // 
            // prefWarningLabel
            // 
            this.prefWarningLabel.AutoSize = true;
            this.prefWarningLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prefWarningLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.prefWarningLabel.Location = new System.Drawing.Point(35, 144);
            this.prefWarningLabel.Name = "prefWarningLabel";
            this.prefWarningLabel.Size = new System.Drawing.Size(254, 48);
            this.prefWarningLabel.TabIndex = 0;
            this.prefWarningLabel.Text = "Be sure device is connected\r\n while changing preferences!\r\n";
            this.prefWarningLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tab_Help
            // 
            this.tab_Help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(126)))), ((int)(((byte)(195)))));
            this.tab_Help.Controls.Add(this.ll_SupportLink);
            this.tab_Help.Controls.Add(this.picb_HelpTab);
            this.tab_Help.Controls.Add(this.contactNumLabel);
            this.tab_Help.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.tab_Help.Location = new System.Drawing.Point(4, 37);
            this.tab_Help.Name = "tab_Help";
            this.tab_Help.Size = new System.Drawing.Size(612, 362);
            this.tab_Help.TabIndex = 3;
            this.tab_Help.Text = "Help";
            // 
            // ll_SupportLink
            // 
            this.ll_SupportLink.AutoSize = true;
            this.ll_SupportLink.Location = new System.Drawing.Point(198, 227);
            this.ll_SupportLink.Name = "ll_SupportLink";
            this.ll_SupportLink.Size = new System.Drawing.Size(194, 25);
            this.ll_SupportLink.TabIndex = 2;
            this.ll_SupportLink.TabStop = true;
            this.ll_SupportLink.Text = "support.wisvis.com";
            this.ll_SupportLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_SupportLink_LinkClicked);
            // 
            // picb_HelpTab
            // 
            this.picb_HelpTab.Image = global::WVA_Scan.Properties.Resources.WVAScanLogo_Clear;
            this.picb_HelpTab.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.picb_HelpTab.Location = new System.Drawing.Point(114, 3);
            this.picb_HelpTab.Name = "picb_HelpTab";
            this.picb_HelpTab.Size = new System.Drawing.Size(380, 122);
            this.picb_HelpTab.TabIndex = 1;
            this.picb_HelpTab.TabStop = false;
            // 
            // contactNumLabel
            // 
            this.contactNumLabel.AutoSize = true;
            this.contactNumLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.contactNumLabel.Location = new System.Drawing.Point(68, 167);
            this.contactNumLabel.Name = "contactNumLabel";
            this.contactNumLabel.Size = new System.Drawing.Size(488, 50);
            this.contactNumLabel.TabIndex = 0;
            this.contactNumLabel.Text = "For questions and concerns, please contact\r\nWVA Scanner Support at 800-747-9000 E" +
    "xt: 8191";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // blinkTimer
            // 
            this.blinkTimer.Interval = 1000;
            this.blinkTimer.Tick += new System.EventHandler(this.blinkTimer_Tick);
            // 
            // checkMessagesTimer
            // 
            this.checkMessagesTimer.Interval = 250;
            this.checkMessagesTimer.Tick += new System.EventHandler(this.checkMessagesTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(621, 406);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "WVA Scan";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tab_Scan.ResumeLayout(false);
            this.tab_Scan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_ScanTab)).EndInit();
            this.tab_Messages.ResumeLayout(false);
            this.tab_Messages.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_Messages)).EndInit();
            this.tab_Account.ResumeLayout(false);
            this.tab_Account.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_AccountTab)).EndInit();
            this.tab_Preferences.ResumeLayout(false);
            this.tab_Preferences.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_PrefTab)).EndInit();
            this.tab_Help.ResumeLayout(false);
            this.tab_Help.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb_HelpTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_Scan;
        private System.Windows.Forms.TabPage tab_Account;
        private System.Windows.Forms.TabPage tab_Preferences;
        private System.Windows.Forms.Label prefWarningLabel;
        private System.Windows.Forms.TabPage tab_Help;
        private System.Windows.Forms.PictureBox picb_HelpTab;
        private System.Windows.Forms.Label contactNumLabel;
        private System.Windows.Forms.PictureBox picb_ScanTab;
        private System.Windows.Forms.RichTextBox rtb_ScanActionMessages;
        private System.Windows.Forms.Label scannerStatusLabel;
        public System.Windows.Forms.TextBox tb_ScannerStatus;
        private System.Windows.Forms.Button btn_ReviewOrder;
        private System.Windows.Forms.PictureBox picb_AccountTab;
        private System.Windows.Forms.Label enterActNumLabel;
        private System.Windows.Forms.PictureBox picb_PrefTab;
        private System.Windows.Forms.ProgressBar pref_progb;
        private System.Windows.Forms.Button btn_ChangePref;
        private System.Windows.Forms.Button btn_SetActNum;
        private System.Windows.Forms.TabPage tab_Messages;
        private System.Windows.Forms.Label messagesLabel;
        private System.Windows.Forms.PictureBox picb_Messages;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.Timer blinkTimer;
        private System.Windows.Forms.Timer checkMessagesTimer;
        private System.Windows.Forms.LinkLabel ll_PrefMoreInfoLink;
        private System.Windows.Forms.RadioButton radb_ScanUPC_OPC;
        private System.Windows.Forms.RadioButton radb_ScanOPC;
        private System.Windows.Forms.RadioButton radb_ScanUPC;
        private System.Windows.Forms.Button btn_PrefLine;
        private System.Windows.Forms.LinkLabel ll_SupportLink;
        private System.Windows.Forms.Button btn_CreateOrder;
        public System.Windows.Forms.TextBox tb_ScannedItems;
        private System.Windows.Forms.Label scannedItemsLabel;
        private System.Windows.Forms.Button btn_ClearMessages;
        public System.Windows.Forms.RichTextBox rtb_Preferences;
        public RichTextBox rtb_Messages;
        public TextBox tb_Actnum;
    }
}

