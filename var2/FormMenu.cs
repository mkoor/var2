using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace var2
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            if (FormAuthorization.users.type == "manager") { buttonManager.Enabled = false; }
            labelHello.Text = "Здравствуйте, " + FormAuthorization.users.login + " " + FormAuthorization.users.type;
        }

        private void buttonManager_Click(object sender, EventArgs e)
        {
            FormManagers man = new FormManagers();
            man.Show();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            FormAuthorization auto = new FormAuthorization();
            auto.Show();
            this.Hide();
        }
    }
}
