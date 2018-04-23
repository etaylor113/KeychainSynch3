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

            var pos = label1.Location;
            pos = background.PointToClient(pos);
            label1.Parent = background;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;

            this.label1.Text = "You must enter your WVA account number first. Please go to 'My Account' tab to submit it."; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
