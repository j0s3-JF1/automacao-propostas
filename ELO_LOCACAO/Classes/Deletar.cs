using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using ELO_LOCACAO.Paginas;

namespace ELO_LOCACAO.Classes
{
    internal class Deletar
    {
        public void DeletarEquip(ComboBox numserie)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();
            var query = @"DELETE FROM EQUIPAMENTO WHERE NUMSERIE = @numserie";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@numserie", numserie.Text);
            comando.ExecuteNonQuery();

            numserie.Text = string.Empty;

            MessageBox.Show("Equipamento apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void DeletarCaracteristica(ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM CARACTERISTICA WHERE NUMSERIE = @numserie";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@numserie", comboBox.Text);
            comando.ExecuteNonQuery();

            Conexao.Close();

        }

        public void DeletarIO(ComboBox id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            if (MessageBox.Show("Deseja Excluir este Adicional?", "Aviso",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var query = @"DELETE FROM PLACA_IO WHERE ID = @id";
                var comando = new MySqlCommand(query, Conexao);
                comando.Parameters.AddWithValue("@id", id.Text);
                comando.ExecuteNonQuery();

                MessageBox.Show("Placa I/O apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                new FormDelIO().Refresh();

                id.Text = string.Empty;
            }

            Conexao.Close();
        }

        public void DeletarEncoder(ComboBox id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            if (MessageBox.Show("Deseja Excluir este Adicional?", "Aviso",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var query = @"DELETE FROM PLACA_ENCODER WHERE ID = @id";
                var comando = new MySqlCommand(query, Conexao);
                comando.Parameters.AddWithValue("@id", id.Text);
                comando.ExecuteNonQuery();

                MessageBox.Show("Placa de Encoder apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                new FormDelEncoder().Refresh();

                id.Text = string.Empty;
            }

            Conexao.Close();
        }

        public void DeletarComunicacao(ComboBox id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            if (MessageBox.Show("Deseja Excluir este Adicional?", "Aviso",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var query = @"DELETE FROM PLACA_COMUNICACAO WHERE ID = @id";
                var comando = new MySqlCommand(query, Conexao);
                comando.Parameters.AddWithValue("@id", id.Text);
                comando.ExecuteNonQuery();

                MessageBox.Show("Placa de Comunicação apagado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                new FormDelComunicacao().Refresh();

                id.Text = string.Empty;
            }

            Conexao.Close();
        }
    }
}
