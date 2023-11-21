using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Classes.Admin
{
    internal class Admin
    {
        public void Cadastro(string nome, string user, string senha, string acesso)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO USUARIOS(NOME,USUARIO, SENHA, ACESSO) VALUE (@nome, @usuario, @senha, @acesso)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@senha", senha);
            comando.Parameters.AddWithValue("@acesso", acesso);

            comando.ExecuteNonQuery();

            MessageBox.Show("Usuário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Consulta(DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM USUARIOS";
            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Nome";
            dataGridView.Columns[2].HeaderText = "Usuário";
            dataGridView.Columns[3].HeaderText = "Senha";
            dataGridView.Columns[4].HeaderText = "Acesso";

            MessageBox.Show("Usuário encontrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Alterar(string nome, string user, string senha, string acesso, int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE USUARIOS SET NOME = @nome, USUARIO = @usuario, SENHA = @senha, ACESSO = @acesso WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@usuario", user);
            comando.Parameters.AddWithValue("@senha", senha);
            comando.Parameters.AddWithValue("@acesso", acesso);
            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            MessageBox.Show("Usuário alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Deletar(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM USUARIOS WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            MessageBox.Show("Usuário deletado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void ConsultaID(TextBox nome, TextBox senha, TextBox usuario, ComboBox acesso, int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT NOME, USUARIO, SENHA, ACESSO FROM USUARIOS WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                nome.Text = reader[0].ToString();
                usuario.Text = reader[1].ToString();
                senha.Text = reader[2].ToString();
                acesso.Text = reader[3].ToString();

                MessageBox.Show("Usuário encontrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Conexao.Close();
        }

        public void ConsultaDel(TextBox nome, int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT NOME FROM USUARIOS WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                nome.Text = reader[0].ToString();

                MessageBox.Show("Usuário encontrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Conexao.Close();
        }
    }
}
