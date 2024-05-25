using System;
using System.Windows.Forms;

namespace GettingUpTool.Forms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            while (GameFinder.IsGameRunning())
            {
                DialogResult res = MessageBox.Show("Game is already running!\r\nClose game and press OK to continue.", "MEGU Launcher", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (res != DialogResult.OK)
                {
                    Application.Exit();
                    return;
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Launcher());
        }
    }
}
