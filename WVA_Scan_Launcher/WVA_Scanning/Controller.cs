using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WVA_Scan_Main
{
    class Controller
    {
        public Controller()
        {
            Run();
        }

        public void Run()
        {
            try
            {
                if (App.DoesExist())
                {
                    if (API.NeedsUpdate())
                    {
                        API.GetUpdate();
                        App.LaunchWVA_Scan();
                    }
                }
                else
                {
                    API.GetUpdate();
                    App.Install();
                    App.LaunchWVA_Scan();
                }
            }
            catch (Exception error)
            {
                Error.PrintError(error.ToString());
            }
        }
    }
}
