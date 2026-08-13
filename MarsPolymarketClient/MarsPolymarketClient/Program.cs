using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;

namespace MarsPolymarketClient
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppSettings.LoadSettings();
            ApplicationConfiguration.Initialize();

            LoginForm form = new LoginForm();
            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            Application.Run(MainForm.GetInstance());
            AppSettings.SaveSettings();
        }
    }
}