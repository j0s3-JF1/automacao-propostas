using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELO_LOCACAO.Conn;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace ELO_LOCACAO.Classes
{
    internal class Cadastrar
    {
        /*
            Cadastro Equipamento
         */
        public void Equipamento(string numserie, string fabricante, string modelo, string chooper, string status, string localizacao, string cadastrado,int tensaomin, int tensaomax, float corrente, float potencia)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO 
                        EQUIPAMENTO( NUMSERIE, FABRICANTE, MODELO, TENSAOMIN, TENSAOMAX, CORRENTE, POTENCIA, CHOOPER, STATUS, LOCALIZACAO, CADASTRADO) 
                        VALUE ( @numserie, @fabricante, @modelo, @tensaomin, @tensaomax, @corrente, @potencia, @chooper, @status, @localizacao, @cadastrado )";
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

            MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Caracteristica(
                string entradaD,
                string saidaD,
                string entradaA,
                string saidaA,
                string largura,
                string altura,
                string profundidade,
                string numserie,
                string familia
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO CARACTERISTICA(DIGITAL_INPUT, DIGITAL_OUTPUT, ANALOG_INPUT, ANALOG_OUTPUT, LARGURA, ALTURA, PROFUNDIDADE, FAMILIA, NUMSERIE)
                        VALUE(@entradaD, @saidaD, @entradaA, @saidaA, @largura, @altura, @profundidade, @familia, @numserie)";
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

        public void Placa_IO( string fabricante, string modelo, string config, string status, int digital_input, int digital_output, int analog_input, int analog_output, string familia, string cadastrado)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO PLACA_IO( FABRICANTE, MODELO, DIGITAL_INPUT, DIGITAL_OUTPUT, ANALOG_INPUT, ANALOG_OUTPUT,CONFIG, STATUS, FAMILIA, CADASTRADO)
                        VALUES(@fabricante, @modelo, @digital_input, @digital_output, @analog_input, @analog_output, @config, @status, @familia, @cadastrado)";
            var comando = new MySqlCommand(query, Conexao);

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

            MessageBox.Show("Cadastro efetuado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Placa_Comunicacao( string fabricante, string modelo, string protocolo, string status, string familia, string cadastrado)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO PLACA_COMUNICACAO( FABRICANTE, MODELO, PROTOCOLO, STATUS, FAMILIA, CADASTRADO )
                        VALUES( @fabricante, @modelo, @protocolo, @status, @familia, @cadastrado)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@protocolo", protocolo);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@familia", familia);
            comando.Parameters.AddWithValue("@cadastrado", cadastrado);

            comando.ExecuteNonQuery();

            MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Conexao.Close();
        }

        public void Placa_Encoder(string fabricante, string modelo, string tipo, string status, string familia, string cadastrado)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO PLACA_ENCODER(FABRICANTE, MODELO, TIPO, STATUS, FAMILIA, CADASTRADO)
                        VALUES(@fabricante, @modelo, @tipo, @status, @familia, @cadastrado)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@modelo", modelo);
            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@status", status);
            comando.Parameters.AddWithValue("@familia", familia);
            comando.Parameters.AddWithValue("@cadastrado", cadastrado);

            MessageBox.Show("cadastro efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
