using System;
using System.Windows.Forms;

namespace Practica_new
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // MainForm — это главная форма вашего приложения
        }
    }
}