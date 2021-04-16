using System;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;
using SurvivalRO_Launcher.Properties;
using System.Windows;
using System.Text;
using System.Drawing;
using System.Threading;
using SurvivalRO_Launcher;

namespace SurvivalRO_Launcher
{
    public partial class frmLogin : Form
    {
        int X = 0;
        int Y = 0;

        public frmLogin()
        {
            InitializeComponent();
            lblErrorMessage.Visible = false;
            panel1.MouseDown += new MouseEventHandler(panel1_MouseDown);
            panel1.MouseMove += new MouseEventHandler(panel1_MouseMove);

            if (!string.IsNullOrEmpty(Settings.Default.USERNAME))
            {
                txtUsername.Text = Settings.Default.USERNAME;
                checkbxShowPas.Checked = true;
            }
        }

        // Drag form
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            X = this.Left - MousePosition.X;
            Y = this.Top - MousePosition.Y;
        }

        // Drag form
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            this.Left = X + MousePosition.X;
            this.Top = Y + MousePosition.Y;
        }

        // Salvar credenciais? Checkbox
        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                //checkbxShowPas.Text = "Ativar";
                checkbxShowPas.ForeColor = Color.White;
            }
            else
            {
                //checkbxShowPas.Text = "Desativar";
                checkbxShowPas.ForeColor = Color.FromArgb(164, 165, 169);
            }
        }

        private void msgError(string msg)
        {
            lblErrorMessage.Text = "     " + msg;
            lblErrorMessage.Visible = true;
        }

        // Botão logar
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Length < 4 || txtUsername.Text.Length > 25)
            {
                msgError("O login deve conter entre 4 e 25 caracteres.");
                txtUsername.Text = "";
                txtPassword.Text = "";
                return;
            }

            if (txtPassword.Text.Length < 4 || txtPassword.Text.Length > 25)
            {
                msgError("A senha deve ter no mínimo 4 caracteres.");
                txtUsername.Text = "";
                txtPassword.Text = "";
                return;
            }

            string Username_Logado = txtUsername.Text;
            string Password_Logado = txtPassword.Text;

            // Salvar credenciais
            Settings.Default.USERNAME = checkbxShowPas.Checked ? txtUsername.Text : "";
            Settings.Default.Save();

            // Chama a dasboard se deu tudo certo com o login
            //dashboard db = new dashboard();
            var dashboard = new dashboard(Username_Logado, Password_Logado);
            dashboard.Show();
            this.Hide();
        }

        // Ao apertar "Enter" quando digitar a senha, abrir o .exe
        private void txtPassword_Enter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.PerformClick();
            }
        }

        // Botão close
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_MouseLeave(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        private void txtPassword_MouseLeave(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        public static implicit operator Label(frmLogin v)
        {
            throw new NotImplementedException();
        }
    }
}
