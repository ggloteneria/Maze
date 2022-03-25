using System;
using System.Windows.Forms;

namespace Labirint
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameForm gameForm = null;
            var loginForm = new LoginForm();
            Application.Run(loginForm);
            gameForm = loginForm.GameForm;
            if (gameForm != null) {
                Application.Run(gameForm);
            }
        }
    }
}
