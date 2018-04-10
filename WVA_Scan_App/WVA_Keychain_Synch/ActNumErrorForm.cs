using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WVA_Scan
{
    public partial class ActNumErrorForm : Form
    {
        public ActNumErrorForm()
        {
            InitializeComponent();

            this.label1.Text = "You must enter your WVA account number first. Please go to My Account tab to submit it."; 
        }

        
    }
}
