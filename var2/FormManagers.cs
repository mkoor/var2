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
    public partial class FormManagers : Form
    {
        public FormManagers()
        {
            InitializeComponent();
            ShowManagers();
            ShowUsers();
            comboBoxLogin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        void ShowManagers()
        {
            listViewManagers.Items.Clear();
            foreach(ManagerSet managerSet in Program.var.ManagerSet)
            {
                ListViewItem item = new ListViewItem(new string[]
                {
                    managerSet.Id.ToString(), managerSet.LastName + " " + managerSet.FirstName, managerSet.Telephone,
                    managerSet.Email, managerSet.Users.Login, managerSet.Type
                });
                item.Tag = managerSet;
                listViewManagers.Items.Add(item);
            }
            listViewManagers.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void ShowUsers()
        {
            comboBoxLogin.Items.Clear();
            foreach (Users users in Program.var.Users)
            {
                string[] item = { users.Id.ToString() + ". " + users.Login };
                comboBoxLogin.Items.Add(string.Join(" ", item));
            }
        }

        private void listViewManagers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewManagers.SelectedItems.Count == 1)
            {
                ManagerSet managerSet = listViewManagers.SelectedItems[0].Tag as ManagerSet;
                textBoxFirstName.Text = managerSet.FirstName;
                textBoxLastName.Text = managerSet.LastName;
                maskedTextBoxTelephone.Text = managerSet.Telephone;
                textBoxEmail.Text = managerSet.Email;
                comboBoxLogin.Text = managerSet.Users.Id.ToString() + ". "+ managerSet.Users.Login;
                textBoxType.Text = managerSet.Type;
            }
            else
            {
                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";
                maskedTextBoxTelephone.Text = "";
                textBoxEmail.Text = "";
                comboBoxLogin.Text = null;
                textBoxType.Text = "";
            }

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ManagerSet managerSet = new ManagerSet();

                if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || textBoxEmail.Text == "" || 
                    maskedTextBoxTelephone.MaskCompleted == false || textBoxType.Text == "" || comboBoxLogin.Text == "")
                {
                    throw new Exception ("Обязательные данные не введены!");
                }
                else
                {
                    managerSet.FirstName = textBoxFirstName.Text;
                    managerSet.LastName = textBoxLastName.Text;
                    managerSet.Email = textBoxEmail.Text;
                    managerSet.Telephone = maskedTextBoxTelephone.Text;
                    managerSet.IdUser = Convert.ToInt32(comboBoxLogin.SelectedItem.ToString().Split('.')[0]);
                    managerSet.Type = textBoxType.Text;
                }
                Program.var.ManagerSet.Add(managerSet);
                Program.var.SaveChanges();
                ShowManagers();

            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewManagers.SelectedItems.Count == 1)
                {
                    ManagerSet managerSet = listViewManagers.SelectedItems[0].Tag as ManagerSet;

                    if (textBoxFirstName.Text == "" || textBoxLastName.Text == "" || textBoxEmail.Text == "" ||
                        maskedTextBoxTelephone.MaskCompleted == false || textBoxType.Text == "" || comboBoxLogin.Text == "")
                    {
                        throw new Exception("Обязательные данные не введены!");
                    }
                    else
                    {
                        managerSet.FirstName = textBoxFirstName.Text;
                        managerSet.LastName = textBoxLastName.Text;
                        managerSet.Email = textBoxEmail.Text;
                        managerSet.Telephone = maskedTextBoxTelephone.Text;
                        managerSet.IdUser = Convert.ToInt32(comboBoxLogin.SelectedItem.ToString().Split('.')[0]);
                        managerSet.Type = textBoxType.Text;
                    }
                    Program.var.SaveChanges();
                    ShowManagers();
                }

            }
            catch (Exception ex) { MessageBox.Show("" + ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewManagers.SelectedItems.Count == 1)
                {
                    ManagerSet managerSet = listViewManagers.SelectedItems[0].Tag as ManagerSet;

                    Program.var.ManagerSet.Remove(managerSet);
                    Program.var.SaveChanges();
                    ShowManagers();
                }
                textBoxFirstName.Text = "";
                textBoxLastName.Text = "";
                textBoxEmail.Text = "";
                maskedTextBoxTelephone.Text = "";
                comboBoxLogin.Text = null;
                textBoxType.Text = "";

            }
            catch
            {
                MessageBox.Show("Данные нельзя удалить, так как они используются!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void maskedTextBoxTelephone_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }
    }
}
