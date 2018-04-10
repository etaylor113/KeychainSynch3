using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WVA_Scan
{
    public partial class MessageForm : Form
    {
        public static string Response { get; set; }

        public MessageForm()
        {
            InitializeComponent();

            label1.Text = Response;

            var pos = label1.Location;
            pos = backdrop.PointToClient(pos);
            label1.Parent = backdrop;
            label1.Location = pos;
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
