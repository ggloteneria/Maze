using System;
using System.Windows.Forms;
// ReSharper disable LocalizableElement

namespace Labirint {
    public partial class LoginForm: Form {
        public GameForm GameForm { get; set; }

        public LoginForm() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string name = tbName.Text;
            string password = tbPassword.Text;

            if (isAdmin(name, password)) {
                GameForm = new GameForm();
                GameForm.IsUser = false;
                GameForm.Text = "Лабиринт - Администратор";
                Close();
            } else if (isPlayer(name, password)) {
                GameForm = new GameForm();
                GameForm.IsUser = true;
                GameForm.Text = "Лабиринт";
                Close();
            }
        }

        private bool isAdmin(string name, string password) {
            return name.Equals("1") && password.Equals("1");
        }
        private bool isPlayer(string name, string password) {
            return name.Equals("2") && password.Equals("2");
        }
    }
}