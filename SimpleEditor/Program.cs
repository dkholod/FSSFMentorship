namespace SimpleEditor
{
    using System;
    using System.Windows.Forms;

    using SimpleEditor.Services;

    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(new FragileStorageService()));
        }
    }
}