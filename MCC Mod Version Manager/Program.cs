using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

namespace MCC_Mod_Version_Manager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string home = Directory.GetCurrentDirectory()+"/";
            if (File.Exists(home + "../mcclauncher.exe"))
            {
                if (!Directory.Exists(home + "logs")) Directory.CreateDirectory(home + "logs");
                if (!Directory.Exists(home + "originals")) Directory.CreateDirectory(home + "originals");
                if (!Directory.Exists(home + "branches")) Directory.CreateDirectory(home + "branches");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new main());
            } else
            {
                MessageBox.Show("Executable should be placed in:\n'steamapps\\common\\Halo The Master Chief Collection\\Mod' subdirectory", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
