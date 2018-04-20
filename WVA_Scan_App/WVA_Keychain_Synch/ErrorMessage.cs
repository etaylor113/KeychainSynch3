﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WVA_Scan
{
    public partial class ErrorMessage : Form
    {
        public ErrorMessage()
        {
            InitializeComponent();

            var pos = label1.Location;
            pos = backdrop.PointToClient(pos);
            label1.Parent = backdrop;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;
     
            this.label1.Text = "An error has occurred. Please call WVA Scanner Support if the problem persists.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
