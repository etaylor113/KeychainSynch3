using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WVA_Scan
{
    class Launcher_Update
    {
        public static void Init()
        {
            if (Launcher_API.NeedsUpdate())
            {
                Launcher_Controls.Uninstall();
                Launcher_API.GetUpdate();
                Launcher_Controls.Install();
                Launcher_Controls.CloseApp();
            }
            else
                Launcher_Controls.CloseApp();
        }
    }
}
