using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.CheckList;
using ELO_LOCACAO.Classes.Proposta;
using ELO_LOCACAO.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormProposta : Form
    {
        public FormProposta()
        {
            InitializeComponent();
            var proposta = new Check();
            proposta.Proposta();
            var carrega = new Carrega();
            carrega.CarregaIDCheckList(cmb_ID);
            carrega.CarregaEquipamento(cmb_Equipamento);
            lbl_Count1.Text = "0";
            lbl_Count2.Text = "0";
            lbl_Count3.Text = "0";
            lbl_OBS1.Text = "";
            lbl_OBS2.Text = "";
            lbl_OBS3.Text = "";
            lbl_OBS4.Text = "";
        }

        private void FormProposta_Load(object sender, EventArgs e)
        {
            FormInicio mainForm = Application.OpenForms["FormInicio"] as FormInicio;
            if (mainForm != null)
            {
                string acesso = mainForm.StatusValue;

                if (acesso == "EXP")
                {
                    MessageBox.Show("Seu tipo de Acesso não permite realizar Propostas");
                    this.Close();
                }
            }
        }

        private void btn_Preencher_Click(object sender, EventArgs e)
        {
            int id = int.Parse(cmb_ID.Text);
            var proposta = new Check();
            var recomenda = new Recomenda();
            proposta.ConsultaCheckList(id,
             txt_Cliente,
             txt_Empresa,
             txt_cnpj,
             txt_Endereco,
             txt_Email,
             txt_Telefone,
             txt_Fone,
             txt_Tensao,
             txt_Potencia,
             txt_Dia,
             txt_Unidade
            );

            recomenda.Equipamento(id, cmb_Equipamento, dgv_recomenda);
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            if (cmb_Equipamento.Text == string.Empty)
            {
                MessageBox.Show("Insira um Equipamento!", "Erro");
            }
            else
            {
                var recomenda = new Recomenda();
                recomenda.InfoEquipamento(dgv_selecionado, cmb_Equipamento);
                recomenda.EquipIO(cmb_Equipamento, cmb_ID, lbl_OBS1, lbl_Count1);
                recomenda.CheckComunicacao(cmb_ID, cmb_Equipamento, lbl_OBS2, lbl_Count2);
                recomenda.CheckEncoder(cmb_ID, cmb_Equipamento, lbl_OBS3, lbl_Count3);
                recomenda.CheckDimensao(cmb_ID, cmb_Equipamento, lbl_OBS4);
            }
        }

        private void btn_Proposta_Click(object sender, EventArgs e)
        {
            //Chamando classe
            var proposta = new Proposta();

            //Variavel para status de geração de proposta
            bool geracaoBemSucedida = false;

            //Cliente
            string cliente, depto, empresa, cnpj, email, telefone, fone;
            //Remetente
            string nome, deptoR, emailR, foneR, telefoneR;
            //Escopo
            string quantidade, potencia, unidPot, unidTensao, dias;
            //Adicional
            string numero, referencia, dataInicio, dataEnvio;
            //Obs
            string obs1, obs2, obs3, obs4;
            //Increment
            string count1, count2, count3;

            cliente = txt_Cliente.Text;
            empresa = txt_Empresa.Text;
            depto = txt_Depto.Text;
            cnpj = txt_cnpj.Text;
            email = txt_Email.Text;
            telefone = txt_Telefone.Text;
            fone = txt_Fone.Text;

            nome = txt_Nome.Text;
            deptoR = txt_DeptoR.Text;
            emailR = txt_EmailR.Text;
            foneR = txt_FoneR.Text;
            telefoneR = txt_TelefoneR.Text;

            quantidade = "1";
            potencia = txt_Potencia.Text;
            unidPot = txt_Unidade.Text;
            unidTensao = txt_Tensao.Text;
            dias = txt_Dia.Text;

            numero = txt_Proposta.Text;
            referencia = txt_Referencia.Text;
            dataInicio = txt_Inicio.Text;
            dataEnvio = txt_Envio.Text;

            obs1 = lbl_OBS1.Text;
            obs2 = lbl_OBS2.Text;
            obs3 = lbl_OBS3.Text;
            obs4 = lbl_OBS4.Text;

            count1 = lbl_Count1.Text;
            count2 = lbl_Count2.Text;
            count3 = lbl_Count3.Text;

            if (rad_Recuperadora.Checked == false && rad_Servicos.Checked == false)
            {
                MessageBox.Show("Assinale se a proposta será da Recuperadora ou Serviços!");
            }
            else
            {
                if (txt_Proposta.Text == string.Empty)
                {
                    MessageBox.Show("Insira um Numero para a Proposta!");
                }
                else
                {
                    if (MessageBox.Show($"Deseja gerar essa proposta?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        while (!geracaoBemSucedida)
                        {
                            var load = new PopupLoad("Carregando...");
                            load.Show();

                            Cursor = Cursors.WaitCursor;

                            geracaoBemSucedida = proposta.EnvioCliente(
                                                        empresa,
                                                        cnpj,
                                                        cliente,
                                                        depto,
                                                        fone,
                                                        telefone,
                                                        email,
                                                        nome,
                                                        deptoR,
                                                        foneR,
                                                        telefoneR,
                                                        emailR,
                                                        quantidade,
                                                        potencia,
                                                        unidPot,
                                                        unidTensao,
                                                        dias,
                                                        numero,
                                                        referencia,
                                                        dataInicio,
                                                        dataEnvio,
                                                        obs1,
                                                        obs2,
                                                        obs3,
                                                        obs4,
                                                        count1,
                                                        count2,
                                                        count3,
                                                        rad_Recuperadora,
                                                        rad_Servicos
                                                      );
                            if (!geracaoBemSucedida)
                            {
                                Thread.Sleep(1000);
                            }

                            load.Close();
                            Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

    }
}
