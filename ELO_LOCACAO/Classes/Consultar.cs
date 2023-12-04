using System.Data;
using System.Windows.Forms;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;

namespace ELO_LOCACAO.Classes
{
    internal class Consultar
    {
        /*
            Consulta de equipamento pelo fabricante
         */

        public void ConsultaEquipamento(DataGridView dataGridView)
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
                            EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "N.S";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Tensão Miníma";
            dataGridView.Columns[4].HeaderText = "Tensão Máxima";
            dataGridView.Columns[5].HeaderText = "Corrente";
            dataGridView.Columns[6].HeaderText = "Potência";
            dataGridView.Columns[7].HeaderText = "Chooper";
            dataGridView.Columns[8].HeaderText = "Status";
            dataGridView.Columns[9].HeaderText = "Localização";
            dataGridView.Columns[10].HeaderText = "Cadastrado Por";
            dataGridView.Columns[11].HeaderText = "Entrada Digital";
            dataGridView.Columns[12].HeaderText = "Saida Digital";
            dataGridView.Columns[13].HeaderText = "Entrada Analógica";
            dataGridView.Columns[14].HeaderText = "Saida Analógica";
            dataGridView.Columns[15].HeaderText = "Largura";
            dataGridView.Columns[16].HeaderText = "Altura";
            dataGridView.Columns[17].HeaderText = "Profundidade";
            dataGridView.Columns[18].HeaderText = "Familia";

            Conexao.Close();
        }

        public void ConsultaEquipamentoFabricante(DataGridView dataGridView, string fabricante)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"SELECT
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
                            EQUIPAMENTO.FABRICANTE = '{fabricante}'";
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
            dataGridView.Columns[6].HeaderText = "Chooper";
            dataGridView.Columns[7].HeaderText = "Status";
            dataGridView.Columns[8].HeaderText = "Localização";
            dataGridView.Columns[9].HeaderText = "Cadastrado Por";
            dataGridView.Columns[10].HeaderText = "Entrada Digital";
            dataGridView.Columns[11].HeaderText = "Saida Digital";
            dataGridView.Columns[12].HeaderText = "Entrada Analógica";
            dataGridView.Columns[13].HeaderText = "Saida Analógica";
            dataGridView.Columns[14].HeaderText = "Largura (mm)";
            dataGridView.Columns[15].HeaderText = "Altura (mm)";
            dataGridView.Columns[16].HeaderText = "Profundidade (mm)";
            dataGridView.Columns[17].HeaderText = "Familia";

            Conexao.Close();
        }
        /*
            Consulta de equipamento pelo Numero de serie
         */

        public void ConsultaEquipamentoNumSerie(DataGridView dataGridView, ComboBox numserie)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"SELECT
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
                            CARACTERISTICA.NUMSERIE = '{numserie.Text}'";
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
            dataGridView.Columns[6].HeaderText = "Chooper";
            dataGridView.Columns[7].HeaderText = "Status";
            dataGridView.Columns[8].HeaderText = "Localização";
            dataGridView.Columns[9].HeaderText = "Cadastrado Por";
            dataGridView.Columns[10].HeaderText = "Entrada Digital";
            dataGridView.Columns[11].HeaderText = "Saida Digital";
            dataGridView.Columns[12].HeaderText = "Entrada Analógica";
            dataGridView.Columns[13].HeaderText = "Saida Analógica";
            dataGridView.Columns[14].HeaderText = "Largura (mm)";
            dataGridView.Columns[15].HeaderText = "Altura (mm)";
            dataGridView.Columns[16].HeaderText = "Profundidade (mm)";
            dataGridView.Columns[17].HeaderText = "Familia";

            Conexao.Close();
        }

        public void ConsultaEquipamentoTudo(DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"SELECT
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
                                EQUIPAMENTO ON CARACTERISTICA.NUMSERIE = EQUIPAMENTO.NUMSERIE";

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
            dataGridView.Columns[6].HeaderText = "Chooper";
            dataGridView.Columns[7].HeaderText = "Status";
            dataGridView.Columns[8].HeaderText = "Localização";
            dataGridView.Columns[9].HeaderText = "Cadastrado Por";
            dataGridView.Columns[10].HeaderText = "Entrada Digital";
            dataGridView.Columns[11].HeaderText = "Saida Digital";
            dataGridView.Columns[12].HeaderText = "Entrada Analógica";
            dataGridView.Columns[13].HeaderText = "Saida Analógica";
            dataGridView.Columns[14].HeaderText = "Largura (mm)";
            dataGridView.Columns[15].HeaderText = "Altura (mm)";
            dataGridView.Columns[16].HeaderText = "Profundidade (mm)";
            dataGridView.Columns[17].HeaderText = "Familia";

            Conexao.Close();
        }


        public void ConsultaEquip(
                ComboBox numserie,
                ComboBox fabricante,
                ComboBox status,
                ComboBox localizacao,
                ComboBox cadastrado,
                TextBox modelo,
                TextBox tensaomin,
                TextBox tensaomax,
                TextBox corrente,
                TextBox potencia,
                TextBox chooper,
                TextBox entradaD,
                TextBox saidaD,
                TextBox entradaA,
                TextBox saidaA,
                TextBox largura,
                TextBox altura,
                TextBox profundidade,
                TextBox familia
                
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT
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
                        	EQUIPAMENTO.NUMSERIE = @numserie";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@numserie", numserie.Text);

            var reader = comando.ExecuteReader();

            if (reader.Read() == false)
            {
                MessageBox.Show("Nenhum Equipamento encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                fabricante.Text = string.Empty;
                modelo.Text = string.Empty;
                tensaomin.Text = string.Empty;
                tensaomax.Text = string.Empty;
                corrente.Text = string.Empty;
                potencia.Text = string.Empty;
                chooper.Text = string.Empty;
                status.Text = string.Empty;
                localizacao.Text = string.Empty;
                cadastrado.Text = string.Empty;
                altura.Text = string.Empty;
                largura.Text = string.Empty;
                profundidade.Text = string.Empty;
                familia.Text = string.Empty;
                entradaA.Text = string.Empty;
                entradaD.Text = string.Empty;
                saidaA.Text = string.Empty;
                saidaD.Text = string.Empty;

                //Desabilita campos
                cadastrado.Enabled = false;
                fabricante.Enabled = false;
                localizacao.Enabled = false;
                status.Enabled = false;
                corrente.Enabled = false;
                modelo.Enabled = false;
                potencia.Enabled = false;
                tensaomax.Enabled = false;
                tensaomin.Enabled = false;
                chooper.Enabled = false;
                altura.Enabled = false;
                largura.Enabled = false;
                profundidade.Enabled = false;
                familia.Enabled = false;
                entradaA.Enabled = false;
                entradaD.Enabled = false;
                saidaA.Enabled = false;
                saidaD.Enabled = false;
            }
            else
            {
                //Habilitar campos
                cadastrado.Enabled = false;
                fabricante.Enabled = true;
                localizacao.Enabled = true;
                status.Enabled = true;
                corrente.Enabled = true;
                modelo.Enabled = true;
                potencia.Enabled = true;
                tensaomax.Enabled = true;
                tensaomin.Enabled = true;
                chooper.Enabled = true;
                altura.Enabled = true;
                largura.Enabled = true;
                profundidade.Enabled = true;
                familia.Enabled = true;
                entradaA.Enabled = true;
                entradaD.Enabled = true;
                saidaA.Enabled = true;
                saidaD.Enabled = true;
                
                fabricante.Text = reader[0].ToString();
                modelo.Text = reader[1].ToString();
                tensaomin.Text = reader[2].ToString();
                tensaomax.Text = reader[3].ToString();
                corrente.Text = reader[4].ToString();
                potencia.Text = reader[5].ToString();
                chooper.Text = reader[6].ToString();
                status.Text = reader[7].ToString();
                localizacao.Text = reader[8].ToString();
                //cadastrado.Text = reader[9].ToString();
                entradaD.Text = reader[10].ToString();
                saidaD.Text = reader[11].ToString();
                entradaA.Text = reader[12].ToString();
                saidaA.Text = reader[13].ToString();
                largura.Text = reader[14].ToString();
                altura.Text = reader[15].ToString();
                profundidade.Text = reader[16].ToString();
                familia.Text = reader[17].ToString();

                MessageBox.Show("Busca efetuada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Conexao.Close();
        }
        /*
            Consulta de adicionais para edição
         */

        /*
            Placa de I/O
         */
        public void ConsultaPlacaIO(
            ComboBox id, 
            ComboBox fabricante,
            ComboBox status, 
            TextBox config,
            TextBox entradaA,
            TextBox entradaD,
            TextBox modelo,
            TextBox saidaA,
            TextBox saidaD,
            TextBox familia
           )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM PLACA_IO WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id.Text);

            var reader = comando.ExecuteReader();

            if (reader.Read() == false)
            {
                MessageBox.Show("Nenhuma Placa I/O encontrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                fabricante.Text = string.Empty;
                status.Text = string.Empty;
                config.Text = string.Empty;
                entradaA.Text = string.Empty;
                entradaD.Text = string.Empty;
                modelo.Text = string.Empty;
                saidaA.Text = string.Empty;
                saidaD.Text = string.Empty;
                familia.Text = string.Empty;

                //Desabilita caixas de texto para edição
                fabricante.Enabled = false;
                status.Enabled = false;
                config.Enabled = false;
                entradaA.Enabled = false;
                entradaD.Enabled = false;
                modelo.Enabled = false;
                saidaA.Enabled = false;
                saidaD.Enabled = false;
                familia.Enabled = false;

            }
            else
            {
                //habilita caixas de texto para edição
                fabricante.Enabled = true;
                status.Enabled = true;
                config.Enabled = true;
                entradaA.Enabled = true;
                entradaD.Enabled = true;
                modelo.Enabled = true;
                saidaA.Enabled = true;
                saidaD.Enabled = true;
                familia.Enabled = true;

                fabricante.Text = reader[1].ToString();
                modelo.Text = reader[2].ToString();
                entradaD.Text = reader[3].ToString();
                saidaD.Text = reader[4].ToString();
                entradaA.Text = reader[5].ToString();
                saidaA.Text = reader[6].ToString();
                config.Text = reader[7].ToString();
                status.Text = reader[8].ToString();
                familia.Text = reader[9].ToString();

                MessageBox.Show("Busca Efetuada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Conexao.Close();
        }


        /*
            Placa de Comunicação
         */
        public void ConsultaPlacaComunicacao(
                ComboBox id,
                ComboBox fabricante,
                ComboBox protocolo,
                ComboBox status,
                TextBox modelo,
                TextBox familia
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM PLACA_COMUNICACAO WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id.Text);

            var reader = comando.ExecuteReader();

            if (reader.Read() == false)
            {
                MessageBox.Show("Nenhuma Placa de comunicação encontrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                fabricante.Enabled = false;
                protocolo.Enabled = false;
                status.Enabled = false;
                modelo.Enabled = false;
                familia.Enabled = false;


                fabricante.Text = string.Empty;
                protocolo.Text = string.Empty;
                status.Text = string.Empty;
                modelo.Text = string.Empty;
                familia.Text = string.Empty;
            }
            else
            {
                fabricante.Text = reader[1].ToString();
                modelo.Text = reader[2].ToString();
                protocolo.Text = reader[3].ToString();
                status.Text = reader[4].ToString();
                familia.Text = reader[5].ToString();


                fabricante.Enabled = true;
                protocolo.Enabled = true;
                status.Enabled = true;
                modelo.Enabled = true;
                familia.Enabled = true;

                MessageBox.Show("Busca efetuada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            Conexao.Close();
        }

        public void ConsultaEncoder(
                ComboBox id,
                ComboBox fabricante, 
                ComboBox tipo,
                ComboBox status,
                TextBox modelo,
                TextBox familia

            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM PLACA_ENCODER WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id.Text);

            var reader = comando.ExecuteReader();

            if (reader.Read() == false)
            {
                MessageBox.Show("Nenhuma placa de encoder encontrada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                fabricante.Enabled = false;
                modelo.Enabled = false;
                tipo.Enabled = false;
                status.Enabled = false;
                familia.Enabled = false;

                fabricante.Text = string.Empty;
                modelo.Text = string.Empty;
                tipo.Text = string.Empty;
                status.Text = string.Empty;
                familia.Text = string.Empty;
            }
            else
            {
                fabricante.Text = reader[1].ToString();
                modelo.Text = reader[2].ToString();
                tipo.Text = reader[3].ToString();
                status.Text = reader[4].ToString();
                familia.Text = reader[5].ToString();

                fabricante.Enabled = true;
                modelo.Enabled = true;
                tipo.Enabled = true;
                status.Enabled = true;
                familia.Enabled = true;

                MessageBox.Show("Busca efetuada!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            Conexao.Close();
        }

        /*
            Consulta adicionais para visualização
         */

        public void ConsultaIo(DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $"SELECT * FROM PLACA_IO";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Entrada Digital";
            dataGridView.Columns[4].HeaderText = "Saida Digital";
            dataGridView.Columns[5].HeaderText = "Entrada Analógica";
            dataGridView.Columns[6].HeaderText = "Saida Analógica";
            dataGridView.Columns[7].HeaderText = "Configurações";
            dataGridView.Columns[8].HeaderText = "Status";
            dataGridView.Columns[9].HeaderText = "Familia";
            dataGridView.Columns[10].HeaderText = "Cadastrado";

            Conexao.Close();
        }

        public void ConsultaIoFamilia(DataGridView dataGridView, string familia, string fabricante)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $"SELECT * FROM PLACA_IO WHERE FAMILIA = '{familia}' OR FABRICANTE = '{fabricante}'";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Entrada Digital";
            dataGridView.Columns[4].HeaderText = "Saida Digital";
            dataGridView.Columns[5].HeaderText = "Entrada Analógica";
            dataGridView.Columns[6].HeaderText = "Saida Analógica";
            dataGridView.Columns[7].HeaderText = "Configurações";
            dataGridView.Columns[8].HeaderText = "Status";
            dataGridView.Columns[9].HeaderText = "Familia";
            dataGridView.Columns[10].HeaderText = "Cadastrado";

            Conexao.Close();
        }

        public void ConsultaEncoder(DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $"SELECT * FROM PLACA_ENCODER";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Tipo";
            dataGridView.Columns[4].HeaderText = "Status";
            dataGridView.Columns[5].HeaderText = "Familia";
            dataGridView.Columns[6].HeaderText = "Cadastrado";

            Conexao.Close();

        }

        public void ConsultaEncoderFamilia(DataGridView dataGridView, string familia, string fabricante)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $"SELECT * FROM PLACA_ENCODER WHERE FAMILIA = '{familia}' OR FABRICANTE = '{fabricante}'";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Tipo";
            dataGridView.Columns[4].HeaderText = "Status";
            dataGridView.Columns[5].HeaderText = "Familia";
            dataGridView.Columns[6].HeaderText = "Cadastrado";

            Conexao.Close();

        }

        public void ConsultaComunicacao(DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $"SELECT * FROM PLACA_COMUNICACAO";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Protocolo";
            dataGridView.Columns[4].HeaderText = "Status";
            dataGridView.Columns[5].HeaderText = "Familia";
            dataGridView.Columns[6].HeaderText = "Cadastro";

            Conexao.Close();

        }

        public void ConsultaComunicacaoFamilia(DataGridView dataGridView, string familia, string fabricante)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $"SELECT * FROM PLACA_COMUNICACAO WHERE FAMILIA = '{familia}' OR FABRICANTE = '{fabricante}'";
            var comando = new MySqlCommand(query, Conexao);

            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Fabricante";
            dataGridView.Columns[2].HeaderText = "Modelo";
            dataGridView.Columns[3].HeaderText = "Protocolo";
            dataGridView.Columns[4].HeaderText = "Status";
            dataGridView.Columns[5].HeaderText = "Familia";
            dataGridView.Columns[6].HeaderText = "Cadastro";

            Conexao.Close();

        }
    }
}
