using System;
using System.Windows.Forms;
using CryptoMarketViewer.Forms;

namespace CryptoMarketViewer
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}