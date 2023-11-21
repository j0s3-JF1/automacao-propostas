using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;

namespace ELO_LOCACAO.Classes
{
    internal class Editar
    {
        public void Equipamento(string numserie, string fabricante, string modelo, string chooper, string status, string localizacao, string cadastrado, int tensaomin, int tensaomax, float corrente, float potencia)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE EQUIPAMENTO SET FABRICANTE = @fabricante, MODELO = @modelo, 
                        TENSAOMIN = @tensaomin, TENSAOMAX = @tensaomax, CORRENTE = @corrente, 
                        POTENCIA = @potencia, CHOOPER = @chooper, STATUS = @status, 
                        LOCALIZACAO = @localizacao, CADASTRADO = @cadastrado WHERE NUMSERIE = @numserie";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@numserie", numserie);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@tensaomin", tensaomin);
            comando.Parameters.AddWithValue("@tensaomax", tensaomax);
            comando.Parameters.AddWithValue("@corrente", corrente);
            comando.Parameters.AddWithValue("@potencia", potencia);
            comando.Parameters.AddWithValue("@chooper", chooper);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@localizacao", localizacao);
            comando.Parameters.AddWithValue("@cadastrado", cadastrado);

            comando.ExecuteNonQuery();

            MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Caracteristica(
                int entradaD,
                int saidaD,
                int entradaA,
                int saidaA,
                string largura,
                string altura,
                string profundidade,
                string familia,
                string numserie
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE CARACTERISTICA SET DIGITAL_INPUT = @entradaD, DIGITAL_OUTPUT = @saidaD, 
                        ANALOG_INPUT = @entradaA, ANALOG_OUTPUT = @saidaA, LARGURA = @largura, 
                        ALTURA = @altura, PROFUNDIDADE = @profundidade, FAMILIA = @familia WHERE NUMSERIE = @numserie";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@entradaD", entradaD);
            comando.Parameters.AddWithValue("@saidaD", saidaD);
            comando.Parameters.AddWithValue("@entradaA", entradaA);
            comando.Parameters.AddWithValue("@saidaA", saidaA);
            comando.Parameters.AddWithValue("@largura", largura);
            comando.Parameters.AddWithValue("@altura", altura);
            comando.Parameters.AddWithValue("@profundidade", profundidade);
            comando.Parameters.AddWithValue("@familia", familia);
            comando.Parameters.AddWithValue("@numserie", numserie);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Placa_IO(int id, string fabricante, string modelo, string config, string status, int digital_input, int digital_output, int analog_input, int analog_output, string familia, string cadastrado)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE PLACA_IO SET FABRICANTE = @fabricante, MODELO = @modelo, 
                        DIGITAL_INPUT = @digital_input, DIGITAL_OUTPUT = @digital_output, 
                        ANALOG_INPUT = @analog_input, ANALOG_OUTPUT = @analog_output,  
                        CONFIG = @config, STATUS = @status, FAMILIA = @familia, CADASTRADO = @cadastrado WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@digital_input", digital_input);
            comando.Parameters.AddWithValue("@digital_output", digital_output);
            comando.Parameters.AddWithValue("@analog_input", analog_input);
            comando.Parameters.AddWithValue("@analog_output", analog_output);
            comando.Parameters.AddWithValue("@config", config);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@familia", familia);
            comando.Parameters.AddWithValue("@cadastrado", cadastrado);

            comando.ExecuteNonQuery();

            MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Placa_Comunicacao(int id, string fabricante, string modelo, string protocolo, string status, string familia, string cadastrado)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE PLACA_COMUNICACAO SET FABRICANTE = @fabricante, MODELO = @modelo, 
                        PROTOCOLO = @protocolo, STATUS = @status, FAMILIA = @familia, CADASTRADO = @cadastrado WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@protocolo", protocolo);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@familia", familia);
            comando.Parameters.AddWithValue("@cadastrado", cadastrado);

            comando.ExecuteNonQuery();

            MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Placa_Encoder(int id, string fabricante, string modelo, string tipo, string status, string familia, string cadastrado)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE PLACA_ENCODER SET FABRICANTE = @fabricante, MODELO = @modelo, TIPO = @tipo, 
                        STATUS = @status, FAMILIA = @familia, CADASTRADO = @cadastrado WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@familia", familia);
            comando.Parameters.AddWithValue("@cadastrado", cadastrado);

            MessageBox.Show("Dados alterados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
