using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.Colecao;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormCadEquipamento : Form
    {
        private string User;

        public FormCadEquipamento()
        {
            InitializeComponent();
            var busca = new Carrega();
            var colecao = new Colecao();
            busca.CarregaFabricante(cmb_Fabricante);
            busca.CarregaStatusEquipamento(cmb_Status);
            busca.CarregaCadastrado(cmb_Cadastrado);
            busca.CarregaLocalizacao(cmb_Localizacao);
            colecao.ColecaoChooper(cmb_Chooper);

            txt_TensaoMin.Text = "0";
            txt_TensaoMax.Text = "0";
            txt_Corrente.Text = "0";
            txt_Potencia.Text = "0";
            txt_EntradaA.Text = "0";
            txt_EntradaD.Text = "0";
            txt_SaidaA.Text = "0";
            txt_SaidaD.Text = "0";
        }

        private void FormCadEquipamento_Load(object sender, EventArgs e)
        {
            FormInicio mainForm = Application.OpenForms["FormInicio"] as FormInicio;
            if (mainForm != null)
            {
                string acesso = mainForm.StatusValue;

                if (acesso == "COM")
                {
                    MessageBox.Show("Seu tipo de Acesso não permite realizar Cadastros");
                    this.Close();
                }
                User = mainForm.Usuario;
                cmb_Cadastrado.Enabled = false;
                cmb_Cadastrado.Text = User;
            }

        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            //Condição para envio
            if (
                txt_NumSerie.Text == string.Empty ||
                cmb_Fabricante.Text == string.Empty ||
                txt_Modelo.Text == string.Empty ||
                txt_TensaoMin.Text == string.Empty ||
                txt_TensaoMax.Text == string.Empty ||
                txt_Corrente.Text == string.Empty ||
                txt_Potencia.Text == string.Empty
            )
            {
                MessageBox.Show("Preencha Todos os Campos!");
            }
            else
            {
                try
                {
                    //Declaração de variaveis
                    string numserie, fabricante, modelo, chooper, status, localizacao, cadastrado, entradaD, entradaA, saidaD, saidaA, largura, altura, profundidade, familia;

                    numserie = txt_NumSerie.Text;
                    fabricante = cmb_Fabricante.Text;
                    modelo = txt_Modelo.Text;
                    chooper = cmb_Chooper.Text;
                    status = cmb_Status.Text;
                    localizacao = cmb_Localizacao.Text;
                    cadastrado = cmb_Cadastrado.Text;
                    entradaD = txt_EntradaD.Text;
                    saidaD = txt_SaidaD.Text;
                    entradaA = txt_EntradaA.Text;
                    saidaA = txt_SaidaA.Text;
                    largura = txt_Largura.Text;
                    altura = txt_Altura.Text;
                    profundidade = txt_Profundidade.Text;
                    familia = txt_Familia.Text;


                    int tensaomin, tensaomax;

                    tensaomin = int.Parse(txt_TensaoMin.Text);
                    tensaomax = int.Parse(txt_TensaoMax.Text);

                    float corrente, potencia;

                    corrente = float.Parse(txt_Corrente.Text);
                    potencia = float.Parse(txt_Potencia.Text);

                    //Classe para cadastro de equipamento
                    if (MessageBox.Show($"Deseja Cadastrar o Equipamento {modelo}?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var equipamento = new Cadastrar();
                        equipamento.Equipamento(
                            numserie,
                            fabricante,
                            modelo,
                            chooper,
                            status,
                            localizacao,
                            cadastrado,
                            tensaomin,
                            tensaomax,
                            corrente,
                            potencia
                            );

                        equipamento.Caracteristica(
                               entradaD,
                               saidaD,
                               entradaA,
                               saidaA,
                               largura,
                               altura,
                               profundidade,
                               numserie,
                               familia
                            );

                        //Apagar variaveis após o envio
                        txt_NumSerie.Text = string.Empty;
                        cmb_Fabricante.Text = string.Empty;
                        txt_Modelo.Text = string.Empty;
                        cmb_Chooper.Text = string.Empty;
                        cmb_Status.Text = string.Empty;
                        cmb_Localizacao.Text = string.Empty;
                        cmb_Cadastrado.Text = string.Empty;
                        txt_TensaoMin.Text = string.Empty;
                        txt_TensaoMax.Text = string.Empty;
                        txt_Corrente.Text = string.Empty;
                        txt_Potencia.Text = string.Empty;
                        txt_EntradaA.Text = string.Empty;
                        txt_EntradaD.Text = string.Empty;
                        txt_SaidaA.Text = string.Empty;
                        txt_SaidaD.Text = string.Empty;
                        txt_Largura.Text = string.Empty;
                        txt_Altura.Text = string.Empty;
                        txt_Profundidade.Text = string.Empty;
                        txt_Familia.Text = string.Empty;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar!", "Aviso");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            txt_NumSerie.Text = string.Empty;
            cmb_Fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            cmb_Chooper.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            cmb_Localizacao.Text = string.Empty;
            txt_Familia.Text = string.Empty;
            txt_Largura.Text = string.Empty;
            txt_Altura.Text = string.Empty;
            txt_Profundidade.Text = string.Empty;

            TextBox[] campos = new TextBox[8];

            campos[0] = txt_TensaoMin;
            campos[1] = txt_TensaoMax;
            campos[2] = txt_Corrente;
            campos[3] = txt_Potencia;
            campos[4] = txt_EntradaA;
            campos[5] = txt_EntradaD;
            campos[6] = txt_SaidaA;
            campos[7] = txt_SaidaD;

            for(int i = 0; i < campos.Length; i++)
            {
                if (campos[i].Text != "0")
                {
                    campos[i].Text = "0";
                }
            }
        }
    }
}
