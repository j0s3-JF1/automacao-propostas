using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormEditEquip : Form
    {
        private string User;
        public FormEditEquip()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaNumSerie(cmb_NumSerie);
            busca.CarregaFabricante(cmb_Fabricante);
            busca.CarregaCadastrado(cmb_Cadastrado);
            busca.CarregaLocalizacao(cmb_localizacao);
            busca.CarregaStatusEquipamento(cmb_Status);
        }
        private void FormEditEquip_Load(object sender, EventArgs e)
        {
            FormInicio mainForm = Application.OpenForms["FormInicio"] as FormInicio;
            if (mainForm != null)
            {
                string acesso = mainForm.StatusValue;

                if (acesso == "COM")
                {
                    MessageBox.Show("Seu tipo de Acesso não permite realizar Edições");
                    this.Close();
                }
                User = mainForm.Usuario;
                cmb_Cadastrado.Enabled = false;
                cmb_Cadastrado.Text = User;
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            if (cmb_NumSerie.Text == string.Empty)
            {
                MessageBox.Show("Insira um numero de série!");
            }
            else
            {
                //Busca de itens apartir do numero de serie
                var consulta = new Consultar();
                consulta.ConsultaEquip(
                    cmb_NumSerie,
                    cmb_Fabricante,
                    cmb_Status,
                    cmb_localizacao,
                    cmb_Cadastrado,
                    txt_Modelo,
                    txt_TensaoMin,
                    txt_TensaoMax,
                    txt_Corrente,
                    txt_Potencia,
                    txt_Chooper,
                    txt_entradaD,
                    txt_saidaD,
                    txt_entradaA,
                    txt_saidaA,
                    txt_largura,
                    txt_altura,
                    txt_profundidade,
                    txt_Familia
                    );
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //Declaração de variaveis
            string numserie, fabricante, modelo, chooper, status, localizacao, cadastrado;
            string largura, altura, profundidade, familia;

            int entradaD, saidaD, entradaA, saidaA;
            float corrente, potencia;
            int tensaomin, tensaomax;

            numserie = cmb_NumSerie.Text;
            fabricante = cmb_Fabricante.Text;
            modelo = txt_Modelo.Text;
            chooper = txt_Chooper.Text;
            status = cmb_Status.Text;
            localizacao = cmb_localizacao.Text;
            cadastrado = cmb_Cadastrado.Text;

            largura = txt_largura.Text;
            altura = txt_altura.Text;
            profundidade = txt_profundidade.Text;
            familia = txt_Familia.Text;

            if (largura == "" || altura == "" || profundidade == "" || familia == "" ||
                numserie == "" || fabricante == "" || modelo == "" || chooper == "" || status == "" || localizacao == "" ||
                cadastrado == ""
                )
            {
                MessageBox.Show("Selecione um Numero de Série para poder editar os campos");
            }
            else
            {
                corrente = float.Parse(txt_Corrente.Text);
                potencia = float.Parse(txt_Potencia.Text);

                tensaomax = int.Parse(txt_TensaoMax.Text);
                tensaomin = int.Parse(txt_TensaoMin.Text);

                entradaD = int.Parse(txt_entradaD.Text);
                saidaD = int.Parse(txt_saidaD.Text);
                entradaA = int.Parse(txt_entradaA.Text);
                saidaA = int.Parse(txt_saidaA.Text);


                var editar = new Editar();
                editar.Equipamento(numserie, fabricante, modelo, chooper, status, localizacao, cadastrado, tensaomin, tensaomax, corrente, potencia);
                editar.Caracteristica(
                    entradaD,
                    saidaD,
                    entradaA,
                    saidaA,
                    largura,
                    altura,
                    profundidade,
                    familia,
                    numserie);

                cmb_NumSerie.Text = string.Empty;
                cmb_Fabricante.Text = string.Empty;
                txt_Modelo.Text = string.Empty;
                txt_Chooper.Text = string.Empty;
                cmb_Status.Text = string.Empty;
                cmb_localizacao.Text = string.Empty;
                cmb_Cadastrado.Text = string.Empty;
                txt_largura.Text = string.Empty;
                txt_altura.Text = string.Empty;
                txt_profundidade.Text = string.Empty;
                txt_Familia.Text = string.Empty;
                txt_saidaA.Text = string.Empty;
                txt_entradaA.Text = string.Empty;
                txt_saidaD.Text = string.Empty;
                txt_entradaD.Text = string.Empty;
                txt_TensaoMax.Text = string.Empty;
                txt_TensaoMin.Text = string.Empty;
                txt_Corrente.Text = string.Empty;
                txt_Potencia.Text = string.Empty;
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            cmb_NumSerie.Text = string.Empty;
            cmb_Fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            txt_Chooper.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            cmb_localizacao.Text = string.Empty;
            cmb_Cadastrado.Text = string.Empty;
            txt_largura.Text = string.Empty;
            txt_altura.Text = string.Empty;
            txt_profundidade.Text = string.Empty;
            txt_Familia.Text = string.Empty;
            txt_saidaA.Text = string.Empty;
            txt_entradaA.Text = string.Empty;
            txt_saidaD.Text = string.Empty;
            txt_entradaD.Text = string.Empty;
            txt_TensaoMax.Text = string.Empty;
            txt_TensaoMin.Text = string.Empty;
            txt_Corrente.Text = string.Empty;
            txt_Potencia.Text = string.Empty;
        }

        
    }
}
