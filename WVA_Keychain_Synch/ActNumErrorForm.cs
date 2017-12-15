using System;
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
    public partial class ActNumErrorForm : Form
    {
        public ActNumErrorForm()
        {
            InitializeComponent();

            var pos = label1.Location;
            pos = backdrop.PointToClient(pos);
            label1.Parent = backdrop;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            this.label1.Text = Variables.ANEF_Text; 
        }

        
    }
}
