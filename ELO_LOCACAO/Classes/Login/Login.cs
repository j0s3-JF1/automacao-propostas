using ELO_LOCACAO.Conn;
using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Paginas;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Classes.Login
{
    internal class Login
    {
        public bool Entrar(string user, string senha, Form destino)
        {
            string status = "";

            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT ACESSO, NOME FROM USUARIOS WHERE USUARIO = @usuario AND SENHA = @senha";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@senha", senha);
            var reader = comando.ExecuteReader();

            if (reader.Read() == true)
            {
                MessageBox.Show($"Seja Bem-Vindo(a) {reader[1].ToString()}", "Bem-Vindo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                status = reader[0].ToString();

                //Passa o status
                if (destino is FormInicio formularioDestino)
                {
                    formularioDestino.StatusValue = status;
                    formularioDestino.Usuario = reader[1].ToString();
                }

                destino.Show();
                return true;
            }
            else
            {
                MessageBox.Show("Usuario ou senha inválidos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                senha = string.Empty;
            }

            Conexao.Close();
            return false;
        }
    }
}
