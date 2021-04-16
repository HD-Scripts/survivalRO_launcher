using SurvivalRO_Launcher;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SurvivalRO_Launcher
{
    public partial class dashboard : Form
    {

        public dashboard(string Username_Logado, string Password_Logado)
        {
            InitializeComponent();
            lblUsername_Logado.Text = Username_Logado;
            lblPassword_Logado.Text = Password_Logado;
        }

        private void msgUsername(string msg1)
        {
            lblUsername_Logado.Text = "Logado como: " + msg1;
            lblUsername_Logado.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        // Botão config
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botão Discord
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Botão fechar
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Logado como?
        private void dashboard_Load(object sender, EventArgs e)
        {
            msgUsername(lblUsername_Logado.Text);
        }

        // Botão deslogar
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            this.Close();
            frmLogin frmlogin = new frmLogin();
            frmlogin.Show();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
