using ELO_LOCACAO.Conn;
using ELO_LOCACAO.PopUp;
using K4os.Compression.LZ4.Streams.Abstractions;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Classes.Proposta
{
    internal class Recomenda
    {
        /*
            Recomendação Equipamento
         */

        public float[] DadosMotor(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = "SELECT TENSAO, CORRENTE, Potencia FROM DADOS_MOTOR WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                float[] valor = new float[3];

                valor[0] = float.Parse(reader[0].ToString());
                valor[1] = float.Parse(reader[1].ToString());
                valor[2] = float.Parse(reader[2].ToString());

                return valor;
            }

            Conexao.Close();

            return null;

        }

        public void Equipamento(int id, ComboBox comboBox, DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            string[] equipamento = new string[2];

            equipamento[0] = "";

            float[] motor = DadosMotor(id);

            if (motor == null)
            {
                Conexao.Close();
            }
            else
            {
                if (motor[0] < 200 || motor[0] > 240 && motor[0] < 380 || motor[0] > 500)
                {
                    MessageBox.Show("A Tensão do Motor Especificada pelo cliente, necessita de uma inspeção de um técnico, pois é uma condição especial", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Conexao.Close();
                }
                else
                {
                    var query = $@"SELECT MODELO, FABRICANTE, TENSAOMIN, TENSAOMAX, CORRENTE, POTENCIA, STATUS
                                FROM EQUIPAMENTO WHERE TENSAOMIN <= {motor[0]} AND TENSAOMAX >= {motor[0]} AND CORRENTE >= {motor[1]} AND CORRENTE <= {motor[1]} * 5 AND STATUS = 'Disponível' ";
                    var comando = new MySqlCommand(query, Conexao);

                    var data = new MySqlDataAdapter(query, Conexao);
                    var tabela = new DataSet();
                    data.Fill(tabela);
                    dataGridView.DataSource = tabela.Tables[0];

                    dataGridView.Columns[0].HeaderText = "Modelo";
                    dataGridView.Columns[1].HeaderText = "Fabricante";
                    dataGridView.Columns[2].HeaderText = "Tensão Miníma";
                    dataGridView.Columns[3].HeaderText = "Tensão Máxima";
                    dataGridView.Columns[4].HeaderText = "Corrente";
                    dataGridView.Columns[5].HeaderText = "Potência";
                    dataGridView.Columns[6].HeaderText = "Status";

                    Conexao.Close();
                    MessageBox.Show("Equipamento(s) recomendado(s) com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            Conexao.Close();
        }
        /*
            Informações do Equipamento
         */
        public string NumSerieEquipamento(ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            string numserie = "";

            var query = @"SELECT NUMSERIE FROM EQUIPAMENTO WHERE MODELO = @modelo";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@modelo", comboBox.Text);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                numserie = reader[0].ToString();
                return numserie;
            }

            Conexao.Close();
            return numserie;
        }

        public void InfoEquipamento(DataGridView dataGridView, ComboBox comboBox)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            string numserie = NumSerieEquipamento(comboBox);

            if (numserie == null || numserie == "")
            {
                Conexao.Close();
            }
            else
            {
                var query = $@"
                              SELECT
                              	    EQUIPAMENTO.FABRICANTE AS Fabricante,
                                    EQUIPAMENTO.MODELO AS Modelo,
                                    EQUIPAMENTO.TENSAOMIN AS TensaoMin,
                                    EQUIPAMENTO.TENSAOMAX AS TensaoMax,
                                    EQUIPAMENTO.CORRENTE AS Corrente,
                                    EQUIPAMENTO.POTENCIA AS Potencia,
                                    CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
                                    CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
                                    CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
                                    CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
                                    CARACTERISTICA.LARGURA AS Largura,
                                    CARACTERISTICA.ALTURA AS Altura,
                                    CARACTERISTICA.PROFUNDIDADE AS Profundidade
                              FROM
                              	    CARACTERISTICA
                              INNER JOIN
                              	    EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE
                              WHERE
                              	    EQUIPAMENTO.NUMSERIE = '{numserie}'";
                var comando = new MySqlCommand(query, Conexao);
                var data = new MySqlDataAdapter(query, Conexao);
                var tabela = new DataSet();
                data.Fill(tabela);
                dataGridView.DataSource = tabela.Tables[0];

                dataGridView.Columns[0].HeaderText = "Fabricante";
                dataGridView.Columns[1].HeaderText = "Modelo";
                dataGridView.Columns[2].HeaderText = "Tensão Miníma";
                dataGridView.Columns[3].HeaderText = "Tensão Máxima";
                dataGridView.Columns[4].HeaderText = "Corrente";
                dataGridView.Columns[5].HeaderText = "Potência";
                dataGridView.Columns[6].HeaderText = "Entrada Digital";
                dataGridView.Columns[7].HeaderText = "Saida Digital";
                dataGridView.Columns[8].HeaderText = "Entrada Analógica";
                dataGridView.Columns[9].HeaderText = "Saida Analógica";
                dataGridView.Columns[10].HeaderText = "Largura";
                dataGridView.Columns[11].HeaderText = "Altura";
                dataGridView.Columns[12].HeaderText = "Profundidade";

                var reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    MessageBox.Show($"Informações do equipamento {reader[1].ToString()} buscadas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Nenhuma Informação encontrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            Conexao.Close();
        }

        /*
            Recomenda Placa I/O
         */

        public int[] CheckIO(ComboBox id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            int[] IO = new int[4];

            IO[0] = 0;
            IO[1] = 0;
            IO[2] = 0;
            IO[3] = 0;

            var query = $@"
                SELECT
                    -- DADOS DO CLIENTE
                    DADOS_CLIENTE.NOME AS Cliente,
                    DADOS_CLIENTE.EMPRESA AS Empresa,
                    DADOS_CLIENTE.CNPJ AS Cnpj,
                    DADOS_CLIENTE.ENDERECO AS Endereco,
                    DADOS_CLIENTE.EMAIL AS Email,
                    DADOS_CLIENTE.TELEFONE AS Telefone,
                    DADOS_CLIENTE.FONE AS Fone,
                    -- DADOS DO MOTOR
                    DADOS_MOTOR.TENSAO AS Tensao,
                    DADOS_MOTOR.CORRENTE AS Corrente,
                    DADOS_MOTOR.POTENCIA AS Potencia,
                    DADOS_MOTOR.VELOCIDADE AS Velocidade,
                    DADOS_MOTOR.FATOR AS Fator,
                    -- DADOS DA REDE
                    DADOS_REDE.TENSAO AS Rede,
                    DADOS_REDE.FUSIVEIS AS Fusiveis,
                    DADOS_REDE.DISJUNTOR AS Disjuntor,
                    DADOS_REDE.FECHAMENTO AS Fechamento,
                    DADOS_REDE.CARACTERISTICA AS Caracteristica,
                    -- DADOS DA APLICACAO
                    DADOS_APLICACAO.TIPO AS Tipo,
                    DADOS_APLICACAO.ENTRADAS_DIGITAIS AS EntradaDigital,
                    DADOS_APLICACAO.SAIDAS_DIGITAIS AS SaidaDigital,
                    DADOS_APLICACAO.ENTRADAS_ANALOGICAS AS EntradaAnalog,
                    DADOS_APLICACAO.SAIDAS_ANALOGICAS AS SaidaAnalog,
                    DADOS_APLICACAO.PROTOCOLO AS Protocolo,
                    DADOS_APLICACAO.ENCODER AS Encoder,
                    DADOS_APLICACAO.AMBIENTE AS Ambiente,
                    -- DADOS ADICIONAIS
                    DADOS_ADICIONAIS.LARGURA AS Largura,
                    DADOS_ADICIONAIS.ALTURA AS Altura,
                    DADOS_ADICIONAIS.PROFUNDIDADE AS Profundidade,
                    DADOS_ADICIONAIS.DIAS AS Dias,
                    DADOS_ADICIONAIS.PROFISSIONAL AS Profissional,
                    DADOS_ADICIONAIS.SUPORTE AS Suporte
                FROM
                    PROPOSTA
                INNER JOIN
                    DADOS_CLIENTE ON PROPOSTA.ID_CLIENTE = DADOS_CLIENTE.ID
                INNER JOIN
                    DADOS_MOTOR ON PROPOSTA.ID_MOTOR = DADOS_MOTOR.ID
                INNER JOIN
                    DADOS_REDE ON PROPOSTA.ID_REDE = DADOS_REDE.ID
                INNER JOIN
                    DADOS_APLICACAO ON PROPOSTA.ID_APLICACAO = DADOS_APLICACAO.ID
                INNER JOIN
                    DADOS_ADICIONAIS ON PROPOSTA.ID_ADICIONAL = DADOS_ADICIONAIS.ID
                WHERE 
                	PROPOSTA.ID = {id.Text};
            ";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                IO[0] = int.Parse(reader[18].ToString());
                IO[1] = int.Parse(reader[19].ToString());
                IO[2] = int.Parse(reader[20].ToString());
                IO[3] = int.Parse(reader[21].ToString());

                return IO;
            }
            Conexao.Close();
            return IO;
        }

        public void EquipIO(ComboBox modelo, ComboBox id, Label obs1, Label count)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            int[] check = CheckIO(id);
            string numserie = NumSerieEquipamento(modelo);

            var query = $@"
                              SELECT
                              	    EQUIPAMENTO.FABRICANTE AS Fabricante,
                                    EQUIPAMENTO.MODELO AS Modelo,
                                    EQUIPAMENTO.TENSAOMIN AS TensaoMin,
                                    EQUIPAMENTO.TENSAOMAX AS TensaoMax,
                                    EQUIPAMENTO.CORRENTE AS Corrente,
                                    EQUIPAMENTO.POTENCIA AS Potencia,
                                    CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
                                    CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
                                    CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
                                    CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
                                    CARACTERISTICA.LARGURA AS Largura,
                                    CARACTERISTICA.ALTURA AS Altura,
                                    CARACTERISTICA.PROFUNDIDADE AS Profundidade,
                                    CARACTERISTICA.FAMILIA AS Familia
                              FROM
                              	    CARACTERISTICA
                              INNER JOIN
                              	    EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE
                              WHERE
                              	    EQUIPAMENTO.NUMSERIE = '{numserie}'";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                int[] equip = new int[4];
                equip[0] = int.Parse(reader[6].ToString());
                equip[1] = int.Parse(reader[7].ToString());
                equip[2] = int.Parse(reader[8].ToString());
                equip[3] = int.Parse(reader[9].ToString());

                if (check[0] > equip[0] || check[1] > equip[1] || check[2] > equip[2] || check[3] > equip[3])
                {
                    MessageBox.Show($"O Cliente Solicita:\nEntrada Digital: {check[0]}\nSaida Digital: {check[1]}\nEntrada Analógica: {check[2]}\nSaida Analógica: {check[3]}", 
                                    "I/O", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    if (MessageBox.Show("É necessário uma PLACA de I/O adicional! Deseja verificar se há placa(s) disponível(is)?",
                        "I/O", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FabricanteIO(modelo);
                        obs1.Text = "Conforme Check-List do cliente, é necessária uma Placa Adicional de I/O";
                        count.Text = "1";
                    }
                    else
                    {
                        obs1.Text = "";
                    }
                }
                else
                {
                    obs1.Text = "";
                }
            }

            Conexao.Close();
        }

        public void FabricanteIO(ComboBox modelo)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT
                        	EQUIPAMENTO.NUMSERIE AS NumSerie,
                        	EQUIPAMENTO.FABRICANTE AS Fabricante,
                        	EQUIPAMENTO.MODELO AS Modelo,
                        	EQUIPAMENTO.TENSAOMIN AS TensaoMin,
                        	EQUIPAMENTO.TENSAOMAX AS TensaoMax,
                        	EQUIPAMENTO.CORRENTE AS Corrente,
                        	EQUIPAMENTO.POTENCIA AS Potencia,
                        	EQUIPAMENTO.CHOOPER AS Chooper,
                        	EQUIPAMENTO.STATUS AS Status,
                        	EQUIPAMENTO.LOCALIZACAO AS Localizacao,
                        	EQUIPAMENTO.CADASTRADO AS Cadastrado,
                        	CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
                        	CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
                        	CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
                        	CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
                        	CARACTERISTICA.LARGURA AS Largura,
                        	CARACTERISTICA.ALTURA AS Altura,
                        	CARACTERISTICA.PROFUNDIDADE AS Profundidade,
                        	CARACTERISTICA.FAMILIA AS Familia
                        FROM
                            CARACTERISTICA
                        INNER JOIN
                            EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE
                        WHERE
                            EQUIPAMENTO.MODELO = @modelo";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@modelo", modelo.Text);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                string[] strings = new string[2];

                strings[0] = reader[1].ToString();
                strings[1] = reader[18].ToString();
                PlacaIO(strings[0], strings[1]);
            }

            Conexao.Close();

        }

        public void PlacaIO(string fabricante, string familia)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT MODELO, STATUS, FAMILIA FROM PLACA_IO WHERE FABRICANTE = @fabricante AND FAMILIA = @familia";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@familia", familia);
            var reader = comando.ExecuteReader();

            int i = 0;

            while (reader.Read())
            {
                string[] IO = new string[3];

                IO[0] = reader[0].ToString();
                IO[1] = reader[1].ToString();
                IO[2] = reader[2].ToString();

                if (IO[1] == "Fora de Estoque")
                {
                    MessageBox.Show($"Modelo: {IO[0]} \n Status: {IO[1]} \n Familia: {IO[2]}", "I/O");
                }
                else
                {
                    MessageBox.Show($"Modelo: {IO[0]} \n Status: {IO[1]} \n Familia: {IO[2]}", "I/O");
                }

                i++;
            }

            if (reader.Read() == false && i == 0)
            {
                MessageBox.Show($"Placa não dispónivel para a familia {familia}", "I/O", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Conexao.Close();
        }

        /*
            Recomendação de Placa de Comunicação
         */
        public void CheckComunicacao(ComboBox id, ComboBox modelo, Label obs2, Label count)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            string comunicacao = "";

            var query = $@"
                SELECT
                    -- DADOS DO CLIENTE
                    DADOS_CLIENTE.NOME AS Cliente,
                    DADOS_CLIENTE.EMPRESA AS Empresa,
                    DADOS_CLIENTE.CNPJ AS Cnpj,
                    DADOS_CLIENTE.ENDERECO AS Endereco,
                    DADOS_CLIENTE.EMAIL AS Email,
                    DADOS_CLIENTE.TELEFONE AS Telefone,
                    DADOS_CLIENTE.FONE AS Fone,
                    -- DADOS DO MOTOR
                    DADOS_MOTOR.TENSAO AS Tensao,
                    DADOS_MOTOR.CORRENTE AS Corrente,
                    DADOS_MOTOR.POTENCIA AS Potencia,
                    DADOS_MOTOR.VELOCIDADE AS Velocidade,
                    DADOS_MOTOR.FATOR AS Fator,
                    -- DADOS DA REDE
                    DADOS_REDE.TENSAO AS Rede,
                    DADOS_REDE.FUSIVEIS AS Fusiveis,
                    DADOS_REDE.DISJUNTOR AS Disjuntor,
                    DADOS_REDE.FECHAMENTO AS Fechamento,
                    DADOS_REDE.CARACTERISTICA AS Caracteristica,
                    -- DADOS DA APLICACAO
                    DADOS_APLICACAO.TIPO AS Tipo,
                    DADOS_APLICACAO.ENTRADAS_DIGITAIS AS EntradaDigital,
                    DADOS_APLICACAO.SAIDAS_DIGITAIS AS SaidaDigital,
                    DADOS_APLICACAO.ENTRADAS_ANALOGICAS AS EntradaAnalog,
                    DADOS_APLICACAO.SAIDAS_ANALOGICAS AS SaidaAnalog,
                    DADOS_APLICACAO.PROTOCOLO AS Protocolo,
                    DADOS_APLICACAO.ENCODER AS Encoder,
                    DADOS_APLICACAO.AMBIENTE AS Ambiente,
                    -- DADOS ADICIONAIS
                    DADOS_ADICIONAIS.LARGURA AS Largura,
                    DADOS_ADICIONAIS.ALTURA AS Altura,
                    DADOS_ADICIONAIS.PROFUNDIDADE AS Profundidade,
                    DADOS_ADICIONAIS.DIAS AS Dias,
                    DADOS_ADICIONAIS.PROFISSIONAL AS Profissional,
                    DADOS_ADICIONAIS.SUPORTE AS Suporte
                FROM
                    PROPOSTA
                INNER JOIN
                    DADOS_CLIENTE ON PROPOSTA.ID_CLIENTE = DADOS_CLIENTE.ID
                INNER JOIN
                    DADOS_MOTOR ON PROPOSTA.ID_MOTOR = DADOS_MOTOR.ID
                INNER JOIN
                    DADOS_REDE ON PROPOSTA.ID_REDE = DADOS_REDE.ID
                INNER JOIN
                    DADOS_APLICACAO ON PROPOSTA.ID_APLICACAO = DADOS_APLICACAO.ID
                INNER JOIN
                    DADOS_ADICIONAIS ON PROPOSTA.ID_ADICIONAL = DADOS_ADICIONAIS.ID
                WHERE 
                	PROPOSTA.ID = {id.Text};
            ";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                comunicacao = reader[22].ToString();

                if (comunicacao == "NÃO")
                {
                    obs2.Text = "";
                    Conexao.Close();
                }
                else
                {
                    MessageBox.Show($"Cliente solicita o seguinte protocolo: {comunicacao}", "Comunicação");

                    if (MessageBox.Show("É necessário uma Placa de comunicação adicional, Deseja consultar?",
                                        "Comunicação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FabricanteComm(modelo, comunicacao);
                        obs2.Text = "Conforme Check-List do cliente, é necessária uma Placa Adicional de Comunicação";
                        count.Text = "1";
                    }
                    else
                    {
                        obs2.Text = "";
                    }
                }
            }
            else
            {
                obs2.Text = "";
            }

            Conexao.Close();
        }

        public void FabricanteComm(ComboBox modelo, string comunicacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT
                        	EQUIPAMENTO.NUMSERIE AS NumSerie,
                        	EQUIPAMENTO.FABRICANTE AS Fabricante,
                        	EQUIPAMENTO.MODELO AS Modelo,
                        	EQUIPAMENTO.TENSAOMIN AS TensaoMin,
                        	EQUIPAMENTO.TENSAOMAX AS TensaoMax,
                        	EQUIPAMENTO.CORRENTE AS Corrente,
                        	EQUIPAMENTO.POTENCIA AS Potencia,
                        	EQUIPAMENTO.CHOOPER AS Chooper,
                        	EQUIPAMENTO.STATUS AS Status,
                        	EQUIPAMENTO.LOCALIZACAO AS Localizacao,
                        	EQUIPAMENTO.CADASTRADO AS Cadastrado,
                        	CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
                        	CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
                        	CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
                        	CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
                        	CARACTERISTICA.LARGURA AS Largura,
                        	CARACTERISTICA.ALTURA AS Altura,
                        	CARACTERISTICA.PROFUNDIDADE AS Profundidade,
                        	CARACTERISTICA.FAMILIA AS Familia
                        FROM
                            CARACTERISTICA
                        INNER JOIN
                            EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE
                        WHERE
                            EQUIPAMENTO.MODELO = @modelo";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@modelo", modelo.Text);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                string fabricante = reader[1].ToString();
                string familia = reader[18].ToString();

                PlacaComunicacao(fabricante, comunicacao, familia);
            }

            Conexao.Close();
        }

        public void PlacaComunicacao(string fabricante, string comm, string familia)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT MODELO, STATUS, FAMILIA FROM PLACA_COMUNICACAO WHERE PROTOCOLO = @protocolo AND FABRICANTE = @fabricante AND FAMILIA = @familia";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@protocolo", comm);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@familia", familia);
            var reader = comando.ExecuteReader();

            int i = 0;

            while (reader.Read())
            {
                string[] placa = new string[3];

                placa[0] = reader[0].ToString();
                placa[1] = reader[1].ToString();
                placa[2] = reader[2].ToString();

                if (placa[1] == "Fora de Estoque")
                {
                    MessageBox.Show($"Modelo: {placa[0]} | Status: {placa[1]} | Familia: {placa[2]}.", "Comunicação");
                }
                else
                {
                    MessageBox.Show($"Modelo: {placa[0]} \n Status: {placa[1]} \n Familia: {placa[2]}", "Comunicação");
                }

                i++;

            }

            if (reader.Read() == false && i == 0)
            {
                MessageBox.Show($"Placa não dispónivel para a familia {familia}", "Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Conexao.Close();
        }

        /*
            Recomendação de Encoder
         */
        public void CheckEncoder(ComboBox id, ComboBox modelo, Label obs3, Label count)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"
                SELECT
                    -- DADOS DO CLIENTE
                    DADOS_CLIENTE.NOME AS Cliente,
                    DADOS_CLIENTE.EMPRESA AS Empresa,
                    DADOS_CLIENTE.CNPJ AS Cnpj,
                    DADOS_CLIENTE.ENDERECO AS Endereco,
                    DADOS_CLIENTE.EMAIL AS Email,
                    DADOS_CLIENTE.TELEFONE AS Telefone,
                    DADOS_CLIENTE.FONE AS Fone,
                    -- DADOS DO MOTOR
                    DADOS_MOTOR.TENSAO AS Tensao,
                    DADOS_MOTOR.CORRENTE AS Corrente,
                    DADOS_MOTOR.POTENCIA AS Potencia,
                    DADOS_MOTOR.VELOCIDADE AS Velocidade,
                    DADOS_MOTOR.FATOR AS Fator,
                    -- DADOS DA REDE
                    DADOS_REDE.TENSAO AS Rede,
                    DADOS_REDE.FUSIVEIS AS Fusiveis,
                    DADOS_REDE.DISJUNTOR AS Disjuntor,
                    DADOS_REDE.FECHAMENTO AS Fechamento,
                    DADOS_REDE.CARACTERISTICA AS Caracteristica,
                    -- DADOS DA APLICACAO
                    DADOS_APLICACAO.TIPO AS Tipo,
                    DADOS_APLICACAO.ENTRADAS_DIGITAIS AS EntradaDigital,
                    DADOS_APLICACAO.SAIDAS_DIGITAIS AS SaidaDigital,
                    DADOS_APLICACAO.ENTRADAS_ANALOGICAS AS EntradaAnalog,
                    DADOS_APLICACAO.SAIDAS_ANALOGICAS AS SaidaAnalog,
                    DADOS_APLICACAO.PROTOCOLO AS Protocolo,
                    DADOS_APLICACAO.ENCODER AS Encoder,
                    DADOS_APLICACAO.AMBIENTE AS Ambiente,
                    -- DADOS ADICIONAIS
                    DADOS_ADICIONAIS.LARGURA AS Largura,
                    DADOS_ADICIONAIS.ALTURA AS Altura,
                    DADOS_ADICIONAIS.PROFUNDIDADE AS Profundidade,
                    DADOS_ADICIONAIS.DIAS AS Dias,
                    DADOS_ADICIONAIS.PROFISSIONAL AS Profissional,
                    DADOS_ADICIONAIS.SUPORTE AS Suporte
                FROM
                    PROPOSTA
                INNER JOIN
                    DADOS_CLIENTE ON PROPOSTA.ID_CLIENTE = DADOS_CLIENTE.ID
                INNER JOIN
                    DADOS_MOTOR ON PROPOSTA.ID_MOTOR = DADOS_MOTOR.ID
                INNER JOIN
                    DADOS_REDE ON PROPOSTA.ID_REDE = DADOS_REDE.ID
                INNER JOIN
                    DADOS_APLICACAO ON PROPOSTA.ID_APLICACAO = DADOS_APLICACAO.ID
                INNER JOIN
                    DADOS_ADICIONAIS ON PROPOSTA.ID_ADICIONAL = DADOS_ADICIONAIS.ID
                WHERE 
                	PROPOSTA.ID = {id.Text};
            ";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                string encoder = reader[23].ToString();
                if (encoder == "NÃO")
                {
                    obs3.Text = "";
                    Conexao.Close();
                }
                else
                {
                    MessageBox.Show("Cliente solicita Equipamento com adicional de Encoder", "Encoder");

                    if (MessageBox.Show("É necessário uma Placa de Encoder adicional, Deseja consultar?",
                                        "Encoder", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FabricanteEncoder(modelo, encoder);
                        obs3.Text = "Conforme Check-List do cliente, é necessária uma placa adicional de Encoder";
                        count.Text = "1";
                    }
                    else
                    {
                        obs3.Text = "";
                    }
                }
            }
            else
            {
                obs3.Text = "";
            }
            Conexao.Close();
        }

        public void FabricanteEncoder(ComboBox modelo, string comunicacao)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT
                        	EQUIPAMENTO.NUMSERIE AS NumSerie,
                        	EQUIPAMENTO.FABRICANTE AS Fabricante,
                        	EQUIPAMENTO.MODELO AS Modelo,
                        	EQUIPAMENTO.TENSAOMIN AS TensaoMin,
                        	EQUIPAMENTO.TENSAOMAX AS TensaoMax,
                        	EQUIPAMENTO.CORRENTE AS Corrente,
                        	EQUIPAMENTO.POTENCIA AS Potencia,
                        	EQUIPAMENTO.CHOOPER AS Chooper,
                        	EQUIPAMENTO.STATUS AS Status,
                        	EQUIPAMENTO.LOCALIZACAO AS Localizacao,
                        	EQUIPAMENTO.CADASTRADO AS Cadastrado,
                        	CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
                        	CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
                        	CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
                        	CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
                        	CARACTERISTICA.LARGURA AS Largura,
                        	CARACTERISTICA.ALTURA AS Altura,
                        	CARACTERISTICA.PROFUNDIDADE AS Profundidade,
                        	CARACTERISTICA.FAMILIA AS Familia
                        FROM
                            CARACTERISTICA
                        INNER JOIN
                            EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE
                        WHERE
                            EQUIPAMENTO.MODELO = @modelo";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@modelo", modelo.Text);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                string fabricante = reader[1].ToString();
                string familia = reader[18].ToString();

                PlacaEncoder(fabricante, comunicacao, familia);
            }

            Conexao.Close();
        }

        public void PlacaEncoder(string fabricante, string tipo, string familia)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT MODELO, STATUS, FAMILIA FROM PLACA_ENCODER WHERE TIPO = @encoder AND FABRICANTE = @fabricante AND FAMILIA = @familia";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@encoder", tipo);
            comando.Parameters.AddWithValue("@fabricante", fabricante);
            comando.Parameters.AddWithValue("@familia", familia);
            var reader = comando.ExecuteReader();

            int i = 0;
            string[] encoder = new string[3];

            while (reader.Read())
            {

                encoder[0] = reader[0].ToString();
                encoder[1] = reader[1].ToString();
                encoder[2] = reader[2].ToString();

                if (encoder[1] == "Fora de Estoque")
                {
                    MessageBox.Show($"Modelo: {encoder[0]} | Status: {encoder[1]} | Familia: {encoder[2]}.", "Encoder");
                }
                else
                {
                    MessageBox.Show($"Modelo: {encoder[0]} \n Status: {encoder[1]} \n Familia: {encoder[2]}", "Encoder");
                }

                i++;

            }

            if (reader.Read() == false && i == 0)
            {
                MessageBox.Show($"Placa não dispónivel para a familia {familia}", "Encoder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            Conexao.Close();
        }

        /*
            Recomendação por dimensão
         */
        public void CheckDimensao(ComboBox id, ComboBox modelo, Label obs4)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"
                SELECT
                    -- DADOS DO CLIENTE
                    DADOS_CLIENTE.NOME AS Cliente,
                    DADOS_CLIENTE.EMPRESA AS Empresa,
                    DADOS_CLIENTE.CNPJ AS Cnpj,
                    DADOS_CLIENTE.ENDERECO AS Endereco,
                    DADOS_CLIENTE.EMAIL AS Email,
                    DADOS_CLIENTE.TELEFONE AS Telefone,
                    DADOS_CLIENTE.FONE AS Fone,
                    -- DADOS DO MOTOR
                    DADOS_MOTOR.TENSAO AS Tensao,
                    DADOS_MOTOR.CORRENTE AS Corrente,
                    DADOS_MOTOR.POTENCIA AS Potencia,
                    DADOS_MOTOR.VELOCIDADE AS Velocidade,
                    DADOS_MOTOR.FATOR AS Fator,
                    -- DADOS DA REDE
                    DADOS_REDE.TENSAO AS Rede,
                    DADOS_REDE.FUSIVEIS AS Fusiveis,
                    DADOS_REDE.DISJUNTOR AS Disjuntor,
                    DADOS_REDE.FECHAMENTO AS Fechamento,
                    DADOS_REDE.CARACTERISTICA AS Caracteristica,
                    -- DADOS DA APLICACAO
                    DADOS_APLICACAO.TIPO AS Tipo,
                    DADOS_APLICACAO.ENTRADAS_DIGITAIS AS EntradaDigital,
                    DADOS_APLICACAO.SAIDAS_DIGITAIS AS SaidaDigital,
                    DADOS_APLICACAO.ENTRADAS_ANALOGICAS AS EntradaAnalog,
                    DADOS_APLICACAO.SAIDAS_ANALOGICAS AS SaidaAnalog,
                    DADOS_APLICACAO.PROTOCOLO AS Protocolo,
                    DADOS_APLICACAO.ENCODER AS Encoder,
                    DADOS_APLICACAO.AMBIENTE AS Ambiente,
                    -- DADOS ADICIONAIS
                    DADOS_ADICIONAIS.LARGURA AS Largura,
                    DADOS_ADICIONAIS.ALTURA AS Altura,
                    DADOS_ADICIONAIS.PROFUNDIDADE AS Profundidade,
                    DADOS_ADICIONAIS.DIAS AS Dias,
                    DADOS_ADICIONAIS.PROFISSIONAL AS Profissional,
                    DADOS_ADICIONAIS.SUPORTE AS Suporte
                FROM
                    PROPOSTA
                INNER JOIN
                    DADOS_CLIENTE ON PROPOSTA.ID_CLIENTE = DADOS_CLIENTE.ID
                INNER JOIN
                    DADOS_MOTOR ON PROPOSTA.ID_MOTOR = DADOS_MOTOR.ID
                INNER JOIN
                    DADOS_REDE ON PROPOSTA.ID_REDE = DADOS_REDE.ID
                INNER JOIN
                    DADOS_APLICACAO ON PROPOSTA.ID_APLICACAO = DADOS_APLICACAO.ID
                INNER JOIN
                    DADOS_ADICIONAIS ON PROPOSTA.ID_ADICIONAL = DADOS_ADICIONAIS.ID
                WHERE 
                	PROPOSTA.ID = {id.Text};
            ";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                string largura = reader[25].ToString();
                string altura = reader[26].ToString();
                string profundidade = reader[27].ToString();

                if (largura == "0" || altura == "0" || profundidade == "0")
                {
                    obs4.Text = "";
                }
                else
                {
                    MessageBox.Show("Cliente especificou dimensões!", "Dimensão");

                    if (MessageBox.Show("O Cliente tem Limitação de Espaço, Deseja consultar?",
                                        "Dimensão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FabricanteDimensao(modelo, largura, altura, profundidade, obs4);
                    }
                }
            }
            else
            {
                obs4.Text = "";
            }
            Conexao.Close();
        }

        public void FabricanteDimensao(ComboBox modelo, string largura, string altura, string profundidade, Label obs4)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            float[] dimensao = new float[3];
            float[] check = new float[3];

            check[0] = float.Parse(largura);
            check[1] = float.Parse(altura);
            check[2] = float.Parse(profundidade);

            var query = @"SELECT
                        	EQUIPAMENTO.NUMSERIE AS NumSerie,
                        	EQUIPAMENTO.FABRICANTE AS Fabricante,
                        	EQUIPAMENTO.MODELO AS Modelo,
                        	EQUIPAMENTO.TENSAOMIN AS TensaoMin,
                        	EQUIPAMENTO.TENSAOMAX AS TensaoMax,
                        	EQUIPAMENTO.CORRENTE AS Corrente,
                        	EQUIPAMENTO.POTENCIA AS Potencia,
                        	EQUIPAMENTO.CHOOPER AS Chooper,
                        	EQUIPAMENTO.STATUS AS Status,
                        	EQUIPAMENTO.LOCALIZACAO AS Localizacao,
                        	EQUIPAMENTO.CADASTRADO AS Cadastrado,
                        	CARACTERISTICA.DIGITAL_INPUT AS EntradaDigital,
                        	CARACTERISTICA.DIGITAL_OUTPUT AS SaidaDigital,
                        	CARACTERISTICA.ANALOG_INPUT AS EntradaAnalogica,
                        	CARACTERISTICA.ANALOG_OUTPUT AS SaidaAnalogica,
                        	CARACTERISTICA.LARGURA AS Largura,
                        	CARACTERISTICA.ALTURA AS Altura,
                        	CARACTERISTICA.PROFUNDIDADE AS Profundidade,
                        	CARACTERISTICA.FAMILIA AS Familia
                        FROM
                            CARACTERISTICA
                        INNER JOIN
                            EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE
                        WHERE
                            EQUIPAMENTO.MODELO = @modelo";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@modelo", modelo.Text);
            var reader = comando.ExecuteReader();

            while (reader.Read())
            {
                dimensao[0] = float.Parse(reader[15].ToString());
                dimensao[1] = float.Parse(reader[16].ToString());
                dimensao[2] = float.Parse(reader[17].ToString());

                if (check[0] == 0 || check[1] == 0 || check[2] == 0)
                {
                    MessageBox.Show($"O Equipamento: {modelo.Text} atende ao dimensionamento especificado!", "Dimensão");
                    obs4.Text = "";
                }
                else if (dimensao[0] == 0 || dimensao[1] == 0 || dimensao[2] == 0)
                {
                    MessageBox.Show($"O Equipamento: {modelo.Text} não possui dimensionamento cadastrado!", "Dimensão");
                    obs4.Text = "";
                }
                else
                {
                    if (check[0] < dimensao[0] || check[1] < dimensao[1] || check[2] < dimensao[2])
                    {
                        MessageBox.Show($"O Equipamento: {modelo.Text} atende ao dimensionamento especificado!", "Dimensão");
                        obs4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show($"O Equipamento: {modelo.Text} não atende ao dimensionamento especificado!", "Dimensão");

                        obs4.Text = $@"Conforme Check-List do Cliente, existe uma limitação de espaço de: 
Largura: {check[0]}mm | Altura: {check[1]}mm | Profundidade: {check[0]}mm (Espaço do Cliente)
Largura: {dimensao[0]}mm | Altura: {dimensao[1]}mm | Profundidade: {dimensao[2]}mm (Equipamento)";
                    }
                }
            }

            Conexao.Close();
        }
    }
}
