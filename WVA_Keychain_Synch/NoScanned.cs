﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WVA_Keychain_Synch
{
    public partial class NoScanned : Form
    {
        public NoScanned()
        {
            InitializeComponent();

            this.label1.Text = Variables.NoScanned_Text;
        }
     
    }
}