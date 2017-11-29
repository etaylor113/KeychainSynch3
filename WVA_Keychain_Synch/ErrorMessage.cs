using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Csp2dotnet
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

            var pos1 = label2.Location;
            pos1 = backdrop.PointToClient(pos1);
            label2.Parent = backdrop;
            label2.Location = pos1;
            label2.BackColor = Color.Transparent;
        }
    }
}
