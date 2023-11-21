using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Crypto.Tls;

namespace ELO_LOCACAO.Classes.CheckList
{
    internal class Check
    {
        /*
            Realizar Cadastro
         */

        public void CadastroCheck(
                string nome,
                string empresa,
                string cnpj,
                string endereco,
                string email,
                string telefone,
                string fone,
                int tensao,
                int velocidade,
                float corrente,
                float potencia,
                float fator,
                string rede,
                string fusivel,
                string disjuntor,
                string fechamento,
                string caracteristica,
                string tipo,
                string protocolo,
                string encoder,
                string ambiente,
                int entradaD,
                int saidaD,
                int entradaA,
                int saidaA,
                string profissional,
                string suporte,
                float largura,
                float altura,
                float profundidade,
                int dias
            )
        {
            try
            {
                //Cadastro de Cliente
                CadastroCliente(
                     nome,
                     empresa,
                     cnpj,
                     endereco,
                     email,
                     telefone,
                     fone
                );

                //Cadastro do Motor
                CadastroMotor(
                    tensao,
                    velocidade,
                    corrente,
                    potencia,
                    fator
                );

                //Cadastro Rede
                CadastroRede(
                     rede,
                     fusivel,
                     disjuntor,
                     fechamento,
                     caracteristica
                );
                //Cadastro Aplicação
                CadastroAplicacao(
                     tipo,
                     protocolo,
                     encoder,
                     ambiente,
                     entradaD,
                     saidaD,
                     entradaA,
                     saidaA
                );
                //Cadastro Adicionais
                CadastroAdicional(
                     profissional,
                     suporte,
                     largura,
                     altura,
                     profundidade,
                     dias
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar Check-List");
                Console.WriteLine($"Erro: {ex.ToString()}");
            }
        }

        private void CadastroCliente(
            string nome,
            string empresa,
            string cnpj,
            string endereco,
            string email,
            string telefone,
            string fone
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO DADOS_CLIENTE (NOME, EMPRESA, CNPJ, ENDERECO, EMAIL, TELEFONE, FONE)
                        VALUE(@nome, @empresa, @cnpj, @endereco, @email, @telefone, @fone)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", nome);
            comando.Parameters.AddWithValue("@empresa", empresa);
            comando.Parameters.AddWithValue("@cnpj", cnpj);
            comando.Parameters.AddWithValue("@endereco", endereco);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@telefone", telefone);
            comando.Parameters.AddWithValue("@fone", fone);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void CadastroMotor(
            int tensao,
            int velocidade,
            float corrente,
            float potencia,
            float fator
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO DADOS_MOTOR (TENSAO, CORRENTE, POTENCIA, VELOCIDADE, FATOR)
                        VALUE (@tensao, @corrente, @potencia, @velocidade, @fator)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@tensao", tensao);
            comando.Parameters.AddWithValue("@corrente", corrente);
            comando.Parameters.AddWithValue("@potencia", potencia);
            comando.Parameters.AddWithValue("@velocidade", velocidade);
            comando.Parameters.AddWithValue("@fator", fator);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void CadastroAplicacao(
                string tipo,
                string protocolo,
                string encoder,
                string ambiente,
                int entradaD,
                int saidaD,
                int entradaA,
                int saidaA
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO DADOS_APLICACAO(TIPO, ENTRADAS_DIGITAIS, SAIDAS_DIGITAIS, ENTRADAS_ANALOGICAS, SAIDAS_ANALOGICAS, PROTOCOLO, ENCODER, AMBIENTE)
                        VALUE (@tipo, @entradaD, @saidaD, @entradaA, @saidaA, @protocolo, @encoder, @ambiente)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@tipo", tipo);
            comando.Parameters.AddWithValue("@entradaD", entradaD);
            comando.Parameters.AddWithValue("@saidaD", saidaD);
            comando.Parameters.AddWithValue("@entradaA", entradaA);
            comando.Parameters.AddWithValue("@saidaA", saidaA);
            comando.Parameters.AddWithValue("@protocolo", protocolo);
            comando.Parameters.AddWithValue("@encoder", encoder);
            comando.Parameters.AddWithValue("@ambiente", ambiente);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void CadastroRede(
                string tensao,
                string fusivel,
                string disjuntor,
                string fechamento,
                string caracteristica
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO DADOS_REDE(TENSAO, FUSIVEIS, DISJUNTOR, FECHAMENTO, CARACTERISTICA)
                        VALUE(@tensao, @fusivel, @disjuntor, @fechamento, @caracteristica)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@tensao", tensao);
            comando.Parameters.AddWithValue("@fusivel", fusivel);
            comando.Parameters.AddWithValue("@disjuntor", disjuntor);
            comando.Parameters.AddWithValue("@fechamento", fechamento);
            comando.Parameters.AddWithValue("@caracteristica", caracteristica);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void CadastroAdicional(
                string profissional,
                string suporte,
                float largura,
                float altura,
                float profundidade,
                int dias
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"INSERT INTO DADOS_ADICIONAIS(LARGURA, ALTURA, PROFUNDIDADE, DIAS, PROFISSIONAL, SUPORTE)
                        VALUE(@largura, @altura, @profundidade,@dias, @profissional, @suporte)";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@largura", largura);
            comando.Parameters.AddWithValue("@altura", altura);
            comando.Parameters.AddWithValue("@profundidade", profundidade);
            comando.Parameters.AddWithValue("@dias", dias);
            comando.Parameters.AddWithValue("@profissional", profissional);
            comando.Parameters.AddWithValue("@suporte", suporte);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Realizar Proposta
         */

        public int IdCliente()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();


            var query = @"SELECT MAX(ID) FROM DADOS_CLIENTE";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "" || reader[0].ToString() == null)
                {
                    Conexao.Close();
                }
                else
                {
                    int id_cliente = int.Parse(reader[0].ToString());
                    return id_cliente;
                }
            }
            Conexao.Close();
            return 0;
        }

        public int IdMotor()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();


            var query = @"SELECT MAX(ID) FROM DADOS_MOTOR";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "" || reader[0].ToString() == null)
                {
                    Conexao.Close();
                }
                else
                {
                    int id_motor = int.Parse(reader[0].ToString());
                    return id_motor;
                }
            }
            Conexao.Close();
            return 0;
        }

        public int IdRede()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();


            var query = @"SELECT MAX(ID) FROM DADOS_REDE";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "" || reader[0].ToString() == null)
                {
                    Conexao.Close();
                }
                else
                {
                    int id_rede = int.Parse(reader[0].ToString());
                    return id_rede;
                }
            }
            Conexao.Close();
            return 0;
        }

        public int IdAplicacao()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();


            var query = @"SELECT MAX(ID) FROM DADOS_APLICACAO";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "" || reader[0].ToString() == null)
                {
                    Conexao.Close();
                }
                else
                {
                    int id_aplicacao = int.Parse(reader[0].ToString());
                    return id_aplicacao;
                }
            }
            Conexao.Close();
            return 0;
        }

        public int IdAdicional()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();


            var query = @"SELECT MAX(ID) FROM DADOS_ADICIONAIS";
            var comando = new MySqlCommand(query, Conexao);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == "" || reader[0].ToString() == null)
                {
                    Conexao.Close();
                }
                else
                {
                    int id_add = int.Parse(reader[0].ToString());
                    return id_add;
                }
            }
            Conexao.Close();
            return 0;
        }

        /*
            Verificação de existencia de ID´s na tabela Proposta
         */
        public bool VerificaIdProposta(int cliente)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"SELECT * FROM PROPOSTA WHERE ID_CLIENTE = @id";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", cliente);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                return true;
            }

            Conexao.Close();
            return false;
        }

        //Proposta
        public void Proposta()
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            int[] id = new int[5];

            int cliente = IdCliente();
            int motor = IdMotor();
            int rede = IdRede();
            int adicional = IdAdicional();
            int aplicacao = IdAplicacao();

            bool verify = VerificaIdProposta(cliente);

            id[0] = cliente;
            id[1] = motor;
            id[2] = rede;
            id[3] = adicional;
            id[4] = aplicacao;

            bool contemZero = false;

            //Verifica se ja contem o Cliente na Tabela Proposta
            if (verify == true)
            {
                Conexao.Close();
            }
            else
            {
                //Verifica se há algum ID igual a zero
                for (int i = 0; i < id.Length; i++)
                {
                    if (id[i] == 0)
                    {
                        contemZero = true;
                        break;
                    }
                }

                if (contemZero)
                {
                    Conexao.Close();
                }
                else
                {
                    //Inseri os ID´s do CheckList em um só
                    var query = @"INSERT INTO PROPOSTA(ID_CLIENTE, ID_MOTOR, ID_REDE, ID_APLICACAO, ID_ADICIONAL)
                            VALUE(@id_cliente, @id_motor, @id_rede, @id_aplicacao, @id_adicional)";
                    var comando = new MySqlCommand(query, Conexao);
                    comando.Parameters.AddWithValue("@id_cliente", cliente);
                    comando.Parameters.AddWithValue("@id_motor", motor);
                    comando.Parameters.AddWithValue("@id_rede", rede);
                    comando.Parameters.AddWithValue("@id_aplicacao", aplicacao);
                    comando.Parameters.AddWithValue("@id_adicional", adicional);

                    comando.ExecuteNonQuery();
                }
            }
            Conexao.Close();

        }


        /*
            Consulta de Check-List
         */


        public void ConsultaCheckList(
            int id,
            TextBox cliente,
            TextBox empresa,
            MaskedTextBox cnpj,
            TextBox endereco,
            TextBox email,
            MaskedTextBox telefone,
            MaskedTextBox fone,
            TextBox tensao,
            TextBox potencia,
            TextBox dias,
            TextBox unid
         )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"
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
                	PROPOSTA.ID = @id
            ";
            var comando = new MySqlCommand(query, Conexao);
            comando.Parameters.AddWithValue("@id", id);
            var reader = comando.ExecuteReader();

            if (reader.Read())
            {
                cliente.Text = reader[0].ToString();
                empresa.Text = reader[1].ToString();
                cnpj.Text = reader[2].ToString();
                endereco.Text = reader[3].ToString();
                email.Text = reader[4].ToString();
                telefone.Text = reader[5].ToString();
                fone.Text = reader[6].ToString();
                tensao.Text = reader[7].ToString() + "V";
                potencia.Text = reader[9].ToString();
                dias.Text = reader[28].ToString();
                unid.Text = "KW";

                MessageBox.Show("Check-List Encontrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                cliente.Text = string.Empty;
                empresa.Text = string.Empty;
                cnpj.Text = string.Empty;
                endereco.Text = string.Empty;
                email.Text = string.Empty;
                telefone.Text = string.Empty;
                fone.Text = string.Empty;
                tensao.Text = string.Empty;
                potencia.Text = string.Empty;

                MessageBox.Show("Nenhum Dado encontrado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Conexao.Close();
        }

        /*
            Consulta do Check-List
         */

        public void ConsultaTudo(DataGridView dataGridView)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"
                SELECT
                    -- DADOS DO CLIENTE
                    PROPOSTA.ID AS ID,
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
            ";
            var comando = new MySqlCommand(query, Conexao);
            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Cliente";
            dataGridView.Columns[2].HeaderText = "Empresa";
            dataGridView.Columns[3].HeaderText = "CNPJ";
            dataGridView.Columns[4].HeaderText = "Endereço";
            dataGridView.Columns[5].HeaderText = "E-mail";
            dataGridView.Columns[6].HeaderText = "Telefone";
            dataGridView.Columns[7].HeaderText = "Fone";
            dataGridView.Columns[8].HeaderText = "Tensão Motor";
            dataGridView.Columns[9].HeaderText = "Corrente Motor";
            dataGridView.Columns[10].HeaderText = "Potência Motor";
            dataGridView.Columns[11].HeaderText = "Velocidade Motor";
            dataGridView.Columns[12].HeaderText = "Fator Serviço";
            dataGridView.Columns[13].HeaderText = "Tensão de Rede";
            dataGridView.Columns[14].HeaderText = "Fusiveis (A)";
            dataGridView.Columns[15].HeaderText = "Disjuntor (A)";
            dataGridView.Columns[16].HeaderText = "Fechamento de Rede";
            dataGridView.Columns[17].HeaderText = "Caracteristica Rede";
            dataGridView.Columns[18].HeaderText = "Aplicação";
            dataGridView.Columns[19].HeaderText = "Entrada(s) Digital(is)";
            dataGridView.Columns[20].HeaderText = "Saida(s) Digital(is)";
            dataGridView.Columns[21].HeaderText = "Entrada(s) Analógica(s)";
            dataGridView.Columns[22].HeaderText = "Saida(s) Analógica(s)";
            dataGridView.Columns[23].HeaderText = "Protocolo";
            dataGridView.Columns[24].HeaderText = "Encoder";
            dataGridView.Columns[25].HeaderText = "Ambiente";
            dataGridView.Columns[26].HeaderText = "Largura (mm)";
            dataGridView.Columns[27].HeaderText = "Altura (mm)";
            dataGridView.Columns[28].HeaderText = "Profundidade (mm)";
            dataGridView.Columns[29].HeaderText = "Dias";
            dataGridView.Columns[30].HeaderText = "Profissional";
            dataGridView.Columns[31].HeaderText = "Suporte";

            Conexao.Close();
        }

        public void ConsultaCheckList(DataGridView dataGridView, ComboBox cliente, ComboBox empresa)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = $@"
                SELECT
                    -- DADOS DO CLIENTE
                    PROPOSTA.ID AS ID,
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
                	DADOS_CLIENTE.NOME = '{cliente.Text}' OR DADOS_CLIENTE.EMPRESA = '{empresa.Text}'
            ";
            var comando = new MySqlCommand(query, Conexao);
            var data = new MySqlDataAdapter(query, Conexao);
            var tabela = new DataSet();
            data.Fill(tabela);
            dataGridView.DataSource = tabela.Tables[0];

            dataGridView.Columns[0].HeaderText = "ID";
            dataGridView.Columns[1].HeaderText = "Cliente";
            dataGridView.Columns[2].HeaderText = "Empresa";
            dataGridView.Columns[3].HeaderText = "CNPJ";
            dataGridView.Columns[4].HeaderText = "Endereço";
            dataGridView.Columns[5].HeaderText = "E-mail";
            dataGridView.Columns[6].HeaderText = "Telefone";
            dataGridView.Columns[7].HeaderText = "Fone";
            dataGridView.Columns[8].HeaderText = "Tensão Motor";
            dataGridView.Columns[9].HeaderText = "Corrente Motor";
            dataGridView.Columns[10].HeaderText = "Potência Motor";
            dataGridView.Columns[11].HeaderText = "Velocidade Motor";
            dataGridView.Columns[12].HeaderText = "Fator Serviço";
            dataGridView.Columns[13].HeaderText = "Tensão de Rede";
            dataGridView.Columns[14].HeaderText = "Fusiveis (A)";
            dataGridView.Columns[15].HeaderText = "Disjuntor (A)";
            dataGridView.Columns[16].HeaderText = "Fechamento de Rede";
            dataGridView.Columns[17].HeaderText = "Caracteristica Rede";
            dataGridView.Columns[18].HeaderText = "Aplicação";
            dataGridView.Columns[19].HeaderText = "Entrada(s) Digital(is)";
            dataGridView.Columns[20].HeaderText = "Saida(s) Digital(is)";
            dataGridView.Columns[21].HeaderText = "Entrada(s) Analógica(s)";
            dataGridView.Columns[22].HeaderText = "Saida(s) Analógica(s)";
            dataGridView.Columns[23].HeaderText = "Protocolo";
            dataGridView.Columns[24].HeaderText = "Encoder";
            dataGridView.Columns[25].HeaderText = "Ambiente";
            dataGridView.Columns[26].HeaderText = "Largura (mm)";
            dataGridView.Columns[27].HeaderText = "Altura (mm)";
            dataGridView.Columns[28].HeaderText = "Profundidade (mm)";
            dataGridView.Columns[29].HeaderText = "Dias";
            dataGridView.Columns[30].HeaderText = "Profissional";
            dataGridView.Columns[31].HeaderText = "Suporte";

            Conexao.Close();
        }

        /*
            Edição do Check-List
         */

        public void BuscaCheck(
                ComboBox id,
                TextBox cliente,
                TextBox empresa,
                MaskedTextBox cnpj,
                TextBox endereco,
                TextBox email,
                MaskedTextBox telefone,
                MaskedTextBox fone,
                ComboBox tensao,
                TextBox velocidade,
                TextBox corrente,
                TextBox potencia,
                TextBox fator,
                TextBox tipo,
                ComboBox protocolo,
                ComboBox encoder,
                ComboBox ambiente,
                TextBox entradaD,
                TextBox saidaD,
                TextBox entradaA,
                TextBox saidaA,
                ComboBox rede,
                TextBox fusivel,
                TextBox disjuntor,
                ComboBox fechamento,
                ComboBox caracteristica,
                ComboBox profissional,
                ComboBox suporte,
                TextBox largura,
                TextBox altura,
                TextBox profundidade,
                TextBox dias
            )
        {
            try
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
                	DADOS_CLIENTE.ID = {id.Text};
            ";
                var comando = new MySqlCommand(query, Conexao);
                var reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    cliente.Enabled = true;
                    empresa.Enabled = true;
                    cnpj.Enabled = true;
                    endereco.Enabled = true;
                    email.Enabled = true;
                    telefone.Enabled = true;
                    fone.Enabled = true;
                    tensao.Enabled = true;
                    velocidade.Enabled = true;
                    corrente.Enabled = true;
                    potencia.Enabled = true;
                    fator.Enabled = true;
                    tipo.Enabled = true;
                    protocolo.Enabled = true;
                    encoder.Enabled = true;
                    ambiente.Enabled = true;
                    entradaD.Enabled = true;
                    saidaD.Enabled = true;
                    entradaA.Enabled = true;
                    saidaA.Enabled = true;
                    rede.Enabled = true;
                    fusivel.Enabled = true;
                    disjuntor.Enabled = true;
                    fechamento.Enabled = true;
                    caracteristica.Enabled = true;
                    profissional.Enabled = true;
                    suporte.Enabled = true;
                    largura.Enabled = true;
                    altura.Enabled = true;
                    profundidade.Enabled = true;
                    dias.Enabled = true;

                    cliente.Text = reader[0].ToString();
                    empresa.Text = reader[1].ToString();
                    cnpj.Text = reader[2].ToString();
                    endereco.Text = reader[3].ToString();
                    email.Text = reader[4].ToString();
                    telefone.Text = reader[5].ToString();
                    fone.Text = reader[6].ToString();
                    tensao.Text = reader[7].ToString();
                    corrente.Text = reader[8].ToString();
                    potencia.Text = reader[9].ToString();
                    velocidade.Text = reader[10].ToString();
                    fator.Text = reader[11].ToString();
                    rede.Text = reader[12].ToString();
                    fusivel.Text = reader[13].ToString();
                    disjuntor.Text = reader[14].ToString();
                    fechamento.Text = reader[15].ToString();
                    caracteristica.Text = reader[16].ToString();
                    tipo.Text = reader[17].ToString();
                    entradaD.Text = reader[18].ToString();
                    saidaD.Text = reader[19].ToString();
                    entradaA.Text = reader[20].ToString();
                    saidaA.Text = reader[21].ToString();
                    protocolo.Text = reader[22].ToString();
                    encoder.Text = reader[23].ToString();
                    ambiente.Text = reader[24].ToString();
                    largura.Text = reader[25].ToString();
                    altura.Text = reader[26].ToString();
                    profundidade.Text = reader[27].ToString();
                    dias.Text = reader[28].ToString();
                    profissional.Text = reader[29].ToString();
                    suporte.Text = reader[30].ToString();

                    MessageBox.Show("Dados Encontrados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Dados não encontrados!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Conexao.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao Buscar Check-List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex);
            }
        }

        public void EditarClienteCheck(
                ComboBox id,
                TextBox cliente,
                TextBox empresa,
                MaskedTextBox cnpj,
                TextBox endereco,
                TextBox email,
                MaskedTextBox telefone,
                MaskedTextBox fone
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE DADOS_CLIENTE SET NOME = @nome, EMPRESA = @empresa, CNPJ = @cnpj, ENDERECO = @endereco, EMAIL = @email,
                          TELEFONE = @telefone, FONE = @fone WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@nome", cliente.Text);
            comando.Parameters.AddWithValue("@empresa", empresa.Text);
            comando.Parameters.AddWithValue("@cnpj", cnpj.Text);
            comando.Parameters.AddWithValue("@endereco", endereco.Text);
            comando.Parameters.AddWithValue("@email", email.Text);
            comando.Parameters.AddWithValue("@telefone", telefone.Text);
            comando.Parameters.AddWithValue("@fone", fone.Text);
            comando.Parameters.AddWithValue("@id", id.Text);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void EditarMotorCheck(
                ComboBox id,
                ComboBox tensao,
                TextBox velocidade,
                TextBox corrente,
                TextBox potencia,
                TextBox fator
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE DADOS_MOTOR SET TENSAO = @tensao, CORRENTE = @corrente, POTENCIA = @potencia, VELOCIDADE = @velocidade, 
                          FATOR = @fator WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@tensao", tensao.Text);
            comando.Parameters.AddWithValue("@corrente", corrente.Text);
            comando.Parameters.AddWithValue("@potencia", potencia.Text);
            comando.Parameters.AddWithValue("@velocidade", velocidade.Text);
            comando.Parameters.AddWithValue("@fator", fator.Text);
            comando.Parameters.AddWithValue("@id", id.Text);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void EditarAplicacaoCheck(
                ComboBox id,
                TextBox tipo,
                ComboBox protocolo,
                ComboBox encoder,
                ComboBox ambiente,
                TextBox entradaD,
                TextBox saidaD,
                TextBox entradaA,
                TextBox saidaA
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE DADOS_APLICACAO SET TIPO = @tipo, ENTRADAS_DIGITAIS = @entradaD, SAIDAS_DIGITAIS = @saidaD, 
                          ENTRADAS_ANALOGICAS = @entradaA, SAIDAS_ANALOGICAS = @saidaA, PROTOCOLO = @protocolo, ENCODER = @encoder,
                          AMBIENTE = @ambiente WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@tipo", tipo.Text);
            comando.Parameters.AddWithValue("@entradaD", entradaD.Text);
            comando.Parameters.AddWithValue("@saidaD", saidaD.Text);
            comando.Parameters.AddWithValue("@entradaA", entradaA.Text);
            comando.Parameters.AddWithValue("@saidaA", saidaA.Text);
            comando.Parameters.AddWithValue("@protocolo", protocolo.Text);
            comando.Parameters.AddWithValue("@encoder", encoder.Text);
            comando.Parameters.AddWithValue("@ambiente", ambiente.Text);
            comando.Parameters.AddWithValue("@id", id.Text);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void EditarRedeCheck(
                ComboBox id,
                ComboBox rede,
                TextBox fusivel,
                TextBox disjuntor,
                ComboBox fechamento,
                ComboBox caracteristica
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE DADOS_REDE SET TENSAO = @rede, FUSIVEIS = @fusivel, DISJUNTOR = @disjuntor, FECHAMENTO = @fechamento, 
                          CARACTERISTICA = @caracteristica WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@rede", rede.Text);
            comando.Parameters.AddWithValue("@fusivel", fusivel.Text);
            comando.Parameters.AddWithValue("@disjuntor", disjuntor.Text);
            comando.Parameters.AddWithValue("@fechamento", fechamento.Text);
            comando.Parameters.AddWithValue("@caracteristica", caracteristica.Text);
            comando.Parameters.AddWithValue("@id", id.Text);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void EditarAdicionaisCheck(
                ComboBox id,
                ComboBox profissional,
                ComboBox suporte,
                TextBox largura,
                TextBox altura,
                TextBox profundidade,
                TextBox dias
            )
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"UPDATE DADOS_ADICIONAIS SET LARGURA = @largura, ALTURA = @altura, PROFUNDIDADE = @profundidade, DIAS = @dias, 
                          PROFISSIONAL = @profissional, SUPORTE = @suporte WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@largura", largura.Text);
            comando.Parameters.AddWithValue("@altura", altura.Text);
            comando.Parameters.AddWithValue("@profundidade", profundidade.Text);
            comando.Parameters.AddWithValue("@dias", dias.Text);
            comando.Parameters.AddWithValue("@profissional", profissional.Text);
            comando.Parameters.AddWithValue("@suporte", suporte.Text);
            comando.Parameters.AddWithValue("@id", id.Text);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        /*
            Deletar Check-List
         */

        public bool DeletarCheck(int id)
        {
            if (MessageBox.Show("Tem certeza que deseja deletar este check-List (Esta ação é irreversivel)?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    DeletarProposta(id);
                    DeletarCliente(id);
                    DeletarMotor(id);
                    DeletarRede(id);
                    DeletarAplicacao(id);
                    DeletarAdd(id);

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao Deletar Check-List", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine(ex);

                    return false;
                }
            }
            else
            {
                return false;
            }
        }


        private void DeletarCliente(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM DADOS_CLIENTE WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void DeletarMotor(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM DADOS_MOTOR WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void DeletarRede(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM DADOS_REDE WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void DeletarAplicacao(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM DADOS_APLICACAO WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void DeletarAdd(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM DADOS_ADICIONAIS WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }

        private void DeletarProposta(int id)
        {
            var Conexao = ConnectionFactory.Build();
            Conexao.Open();

            var query = @"DELETE FROM PROPOSTA WHERE ID = @id";
            var comando = new MySqlCommand(query, Conexao);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();

            Conexao.Close();
        }
    }
}
