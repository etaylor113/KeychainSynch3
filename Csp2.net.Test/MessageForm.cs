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
    public partial class MessageForm : Form
    {
        public static string Response { get; set; }

        public MessageForm()
        {
            InitializeComponent();

            label1.Text = Response;            
        }
    }
}
