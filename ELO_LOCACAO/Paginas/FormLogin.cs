using ELO_LOCACAO.Classes.Login;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormLogin : Form
    {
        private bool fecharFormulario = false;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string user, senha;

            user = txt_user.Text;
            senha = txt_senha.Text;

            var destino = new FormInicio();
            var login = new Login();
            bool status = login.Entrar(user, senha, destino);

            if (status == true)
            {
                this.Hide();
            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (fecharFormulario)
                {
                    // Se a flag estiver definida, apenas feche o formulário
                    fecharFormulario = false; // Redefina a flag
                }
                else
                {
                    // Pergunte ao usuário se ele deseja realmente sair do aplicativo
                    DialogResult resultado = MessageBox.Show("Deseja realmente sair do aplicativo?", "Confirmação de Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                    {
                        // Se o usuário clicar em "Não", cancele o fechamento do formulário
                        e.Cancel = true;
                    }
                    else
                    {
                        // Se o usuário clicar em "Sim", encerre a aplicação
                        Application.Exit();
                    }
                }
            }
        }
    }
}
