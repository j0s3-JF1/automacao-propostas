using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.CheckList;
using ELO_LOCACAO.Classes.Colecao;
using System;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormCheck : Form
    {
        public FormCheck()
        {
            InitializeComponent();
            var carrega = new Carrega();
            var colecao = new Colecao();
            carrega.CarregaEncoder(cmb_Encoder);
            carrega.CarregaProtocolo(cmb_Protocolo);

            colecao.ColecaoTensao(cmb_Tensao);
            colecao.ColecaoTensao(cmb_Rede);
            colecao.ColecaoFechamento(cmb_Fechamento);
            colecao.ColecaoCaracteristica(cmb_Caracteristica);
            colecao.ColecaoProfissional(cmb_Profissional);
            colecao.ColecaoSuporte(cmb_Suporte);
            colecao.ColecaoAmbiente(cmb_Ambiente);

            txt_Largura.Text = "0";
            txt_Altura.Text = "0";
            txt_Profundidade.Text = "0";
            txt_velocidade.Text = "0";
            txt_Fator.Text = "0";
            txt_Corrente.Text = "0";
            txt_Potencia.Text = "0";
            txt_Fusivel.Text = "0";
            txt_Disjuntor.Text = "0";
            txt_Dia.Text = "0";
            txt_EntradaA.Text = "0";
            txt_EntradaD.Text = "0";
            txt_SaidaA.Text = "0";
            txt_SaidaD.Text = "0";
            cmb_Tensao.Text = "0";
            cmb_Rede.Text = "0";

        }

        private void FormCheck_Load(object sender, EventArgs e)
        {
            FormInicio mainForm = Application.OpenForms["FormInicio"] as FormInicio;
            if (mainForm != null)
            {
                string acesso = mainForm.StatusValue;

                if (acesso == "EXP")
                {
                    MessageBox.Show("Seu tipo de Acesso não permite realizar Check-List´s");
                    this.Close();
                }
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Chamando Métodos da Classe
                var check = new Check();
                //Criando Array
                object[] campos = new object[30];

                //Variaveis Cliente
                string nome, empresa, cnpj, endereco, email, telefone, fone;

                nome = txt_cliente.Text;
                empresa = txt_Empresa.Text;
                cnpj = txt_Cnpj.Text;
                endereco = txt_Endereco.Text;
                email = txt_Email.Text;
                telefone = txt_Telefone.Text;
                fone = txt_Fone.Text;


                //Variaveis Motor
                int tensao, velocidade;
                float corrente, potencia, fator;

                tensao = int.Parse(cmb_Tensao.Text);
                velocidade = int.Parse(txt_velocidade.Text);
                corrente = float.Parse(txt_Corrente.Text);
                potencia = float.Parse(txt_Potencia.Text);
                fator = float.Parse(txt_Fator.Text);

                //Variaveis Rede
                string rede, fusivel, disjuntor, fechamento, caracteristica;

                rede = cmb_Rede.Text;
                fusivel = txt_Fusivel.Text;
                disjuntor = txt_Disjuntor.Text;
                fechamento = cmb_Fechamento.Text;
                caracteristica = cmb_Caracteristica.Text;

                //Variaveis Aplicação
                string tipo, protocolo, encoder, ambiente;
                int entradaD, saidaD, entradaA, saidaA;

                tipo = txt_Aplicacao.Text;
                protocolo = cmb_Protocolo.Text;
                encoder = cmb_Encoder.Text;
                ambiente = cmb_Ambiente.Text;
                entradaD = int.Parse(txt_EntradaD.Text);
                saidaD = int.Parse(txt_SaidaD.Text);
                entradaA = int.Parse(txt_EntradaA.Text);
                saidaA = int.Parse(txt_SaidaA.Text);

                //Variaveis Adicional
                string profissional, suporte;
                float largura, altura, profundidade;
                int dias;

                profissional = cmb_Profissional.Text;
                suporte = cmb_Suporte.Text;
                largura = float.Parse(txt_Largura.Text);
                altura = float.Parse(txt_Altura.Text);
                profundidade = float.Parse(txt_Profundidade.Text);
                dias = int.Parse(txt_Dia.Text);


                //Lista com Campos
                campos[0] = nome;
                campos[1] = empresa;
                campos[2] = email;
                campos[3] = telefone;
                campos[4] = fone;
                campos[5] = cnpj;
                campos[6] = endereco;
                campos[7] = tensao;
                campos[8] = velocidade;
                campos[9] = corrente;
                campos[10] = potencia;
                campos[10] = fator;
                campos[11] = rede;
                campos[12] = fusivel;
                campos[13] = disjuntor;
                campos[14] = fechamento;
                campos[15] = caracteristica;
                campos[16] = tipo;
                campos[17] = protocolo;
                campos[18] = encoder;
                campos[19] = ambiente;
                campos[20] = entradaD;
                campos[21] = saidaD;
                campos[22] = entradaA;
                campos[23] = saidaA;
                campos[24] = profissional;
                campos[25] = suporte;
                campos[26] = largura;
                campos[27] = altura;
                campos[28] = profundidade;
                campos[29] = dias;

                bool campoVazio = false;

                foreach (object item in campos)
                {
                    if (item == null || (item is string && string.IsNullOrWhiteSpace((string)item)))
                    {
                        campoVazio = true;
                        break;
                    }
                }

                if (campoVazio)
                {
                    MessageBox.Show("Preencha Todos os Campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (tensao != int.Parse(rede))
                    {
                        MessageBox.Show("As tensões do Motor e da Rede devem ser Iguais, Verifique o Check-List novamente ou entre em contato com o Provedor!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        check.CadastroCheck(
                             nome,
                             empresa,
                             cnpj,
                             endereco,
                             email,
                             telefone,
                             fone,
                             tensao,
                             velocidade,
                             corrente,
                             potencia,
                             fator,
                             rede,
                             fusivel,
                             disjuntor,
                             fechamento,
                             caracteristica,
                             tipo,
                             protocolo,
                             encoder,
                             ambiente,
                             entradaD,
                             saidaD,
                             entradaA,
                             saidaA,
                             profissional,
                             suporte,
                             largura,
                             altura,
                             profundidade,
                             dias
                            );

                        check.Proposta();

                        MessageBox.Show("Check-List Cadastrado com Sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Cadastrar Check-List");
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            new FormConCheck().Show();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            new FormEditCheck().Show();
            this.Close();
        }
    }
}
