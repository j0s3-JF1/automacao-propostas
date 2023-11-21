using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.CheckList;
using ELO_LOCACAO.Classes.Colecao;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormEditCheck : Form
    {
        public FormEditCheck()
        {
            InitializeComponent();
            var busca = new Carrega();
            var colecao = new Colecao();
            busca.CarregaIDCheckList(cmb_ID);
            busca.CarregaEncoder(cmb_Encoder);
            busca.CarregaProtocolo(cmb_Protocolo);
            colecao.ColecaoTensao(cmb_Tensao);
            colecao.ColecaoTensao(cmb_Rede);
            colecao.ColecaoFechamento(cmb_Fechamento);
            colecao.ColecaoProfissional(cmb_Profissional);
            colecao.ColecaoAmbiente(cmb_Ambiente);
            colecao.ColecaoCaracteristica(cmb_Caracteristica);
            colecao.ColecaoSuporte(cmb_Suporte);

        }

        private void btn_Busca_Click(object sender, EventArgs e)
        {
            if (cmb_ID.Text == string.Empty)
            {
                MessageBox.Show("Insira o ID do Check-list");
            }
            else
            {
                var check = new Check();
                check.BuscaCheck(
                        cmb_ID,
                        txt_Nome,
                        txt_Empresa,
                        txt_Cnpj,
                        txt_Endereco,
                        txt_Email,
                        txt_Telefone,
                        txt_Fone,
                        cmb_Tensao,
                        txt_velocidade,
                        txt_Corrente,
                        txt_Potencia,
                        txt_Fator,
                        txt_Aplicacao,
                        cmb_Protocolo,
                        cmb_Encoder,
                        cmb_Ambiente,
                        txt_EntradaD,
                        txt_SaidaD,
                        txt_EntradaA,
                        txt_SaidaA,
                        cmb_Rede,
                        txt_Fusivel,
                        txt_Disjuntor,
                        cmb_Fechamento,
                        cmb_Caracteristica,
                        cmb_Profissional,
                        cmb_Suporte,
                        txt_Largura,
                        txt_Altura,
                        txt_Profundidade,
                        txt_Dia
                    );
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            try
            {


                if (txt_Nome.Text == string.Empty && txt_Nome.Text == string.Empty)
                {
                    MessageBox.Show("Realize uma Busca inserindo o ID do Check-List para realizar a edição de Dados!");
                }
                else
                {
                    if (txt_Cnpj.Enabled == false)
                    {
                        MessageBox.Show("Realize a 'Busca de Dados' para poder editar os campos desejados!");
                    }
                    else
                    {
                        if (int.Parse(cmb_Tensao.Text) != int.Parse(cmb_Rede.Text))
                        {
                            MessageBox.Show("Os dados de Tensão do Motor e Rede devem ser Iguais!");
                        }
                        else
                        {
                            try
                            {
                                var check = new Check();
                                check.EditarClienteCheck(
                                    cmb_ID,
                                    txt_Nome,
                                    txt_Empresa,
                                    txt_Cnpj,
                                    txt_Endereco,
                                    txt_Email,
                                    txt_Telefone,
                                    txt_Fone
                                    );

                                check.EditarMotorCheck(
                                    cmb_ID,
                                    cmb_Tensao,
                                    txt_velocidade,
                                    txt_Corrente,
                                    txt_Potencia,
                                    txt_Fator
                                    );

                                check.EditarAplicacaoCheck(
                                    cmb_ID,
                                    txt_Aplicacao,
                                    cmb_Protocolo,
                                    cmb_Encoder,
                                    cmb_Ambiente,
                                    txt_EntradaD,
                                    txt_SaidaD,
                                    txt_EntradaA,
                                    txt_SaidaA
                                    );

                                check.EditarRedeCheck(
                                    cmb_ID,
                                    cmb_Rede,
                                    txt_Fusivel,
                                    txt_Disjuntor,
                                    cmb_Fechamento,
                                    cmb_Caracteristica
                                    );

                                check.EditarAdicionaisCheck(
                                    cmb_ID,
                                    cmb_Profissional,
                                    cmb_Suporte,
                                    txt_Largura,
                                    txt_Altura,
                                    txt_Profundidade,
                                    txt_Dia
                                    );

                                txt_Nome.Text = string.Empty;
                                txt_Empresa.Text = string.Empty;
                                txt_Cnpj.Text = string.Empty;
                                txt_Endereco.Text = string.Empty;
                                txt_Email.Text = string.Empty;
                                txt_Telefone.Text = string.Empty;
                                txt_Fone.Text = string.Empty;
                                cmb_Tensao.Text = string.Empty;
                                txt_velocidade.Text = string.Empty;
                                txt_Corrente.Text = string.Empty;
                                txt_Potencia.Text = string.Empty;
                                txt_Fator.Text = string.Empty;
                                txt_Aplicacao.Text = string.Empty;
                                cmb_Protocolo.Text = string.Empty;
                                cmb_Encoder.Text = string.Empty;
                                cmb_Ambiente.Text = string.Empty;
                                txt_EntradaD.Text = string.Empty;
                                txt_SaidaD.Text = string.Empty;
                                txt_EntradaA.Text = string.Empty;
                                txt_SaidaA.Text = string.Empty;
                                cmb_Rede.Text = string.Empty;
                                txt_Fusivel.Text = string.Empty;
                                txt_Disjuntor.Text = string.Empty;
                                cmb_Fechamento.Text = string.Empty;
                                cmb_Caracteristica.Text = string.Empty;
                                cmb_Profissional.Text = string.Empty;
                                cmb_Suporte.Text = string.Empty;
                                txt_Largura.Text = string.Empty;
                                txt_Altura.Text = string.Empty;
                                txt_Profundidade.Text = string.Empty;
                                txt_Dia.Text = string.Empty;

                                MessageBox.Show("Edição realizada com sucesso!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Erro ao Editar Check-List!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Console.WriteLine(ex.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao Editar Check-List!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmb_ID.Text);

            if (id == 0 || id.ToString() == string.Empty)
            {
                MessageBox.Show("Insira um Id para poder deletar o Check-List!");
            }
            else
            {
                var check = new Check();
                bool status = check.DeletarCheck(id);

                if (status == true)
                {
                    MessageBox.Show("Check-List deletado com sucesso!");

                    txt_Nome.Text = string.Empty;
                    txt_Empresa.Text = string.Empty;
                    txt_Cnpj.Text = string.Empty;
                    txt_Endereco.Text = string.Empty;
                    txt_Email.Text = string.Empty;
                    txt_Telefone.Text = string.Empty;
                    txt_Fone.Text = string.Empty;
                    cmb_Tensao.Text = string.Empty;
                    txt_velocidade.Text = string.Empty;
                    txt_Corrente.Text = string.Empty;
                    txt_Potencia.Text = string.Empty;
                    txt_Fator.Text = string.Empty;
                    txt_Aplicacao.Text = string.Empty;
                    cmb_Protocolo.Text = string.Empty;
                    cmb_Encoder.Text = string.Empty;
                    cmb_Ambiente.Text = string.Empty;
                    txt_EntradaD.Text = string.Empty;
                    txt_SaidaD.Text = string.Empty;
                    txt_EntradaA.Text = string.Empty;
                    txt_SaidaA.Text = string.Empty;
                    cmb_Rede.Text = string.Empty;
                    txt_Fusivel.Text = string.Empty;
                    txt_Disjuntor.Text = string.Empty;
                    cmb_Fechamento.Text = string.Empty;
                    cmb_Caracteristica.Text = string.Empty;
                    cmb_Profissional.Text = string.Empty;
                    cmb_Suporte.Text = string.Empty;
                    txt_Largura.Text = string.Empty;
                    txt_Altura.Text = string.Empty;
                    txt_Profundidade.Text = string.Empty;
                    txt_Dia.Text = string.Empty;
                }
            }
        }
    }
}
