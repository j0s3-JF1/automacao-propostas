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

namespace ELO_LOCACAO.Paginas
{
    public partial class FormCadComunicacao : Form
    {
        private string User;
        public FormCadComunicacao()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaFabricante(cmb_Fabricante);
            busca.CarregaStatusComunicacao(cmb_Status);
            busca.CarregaProtocolo(cmb_Protocolo);
        }
        private void FormCadComunicacao_Load(object sender, EventArgs e)
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
            }
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            //Condição de envio
            if (cmb_Protocolo.Text == string.Empty || txt_Modelo.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                string fabricante, modelo, protocolo, status, familia;

                fabricante = cmb_Fabricante.Text;
                modelo = txt_Modelo.Text;
                protocolo = cmb_Protocolo.Text;
                status = cmb_Status.Text;
                familia = txt_Familia.Text;

                if (MessageBox.Show($"Deseja Cadastrar a Placa {modelo}?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var placa_comunicacao = new Cadastrar();
                    placa_comunicacao.Placa_Comunicacao(fabricante, modelo, protocolo, status, familia, User);

                    cmb_Fabricante.Text = string.Empty;
                    txt_Modelo.Text = string.Empty;
                    cmb_Protocolo.Text = string.Empty;
                    cmb_Status.Text = string.Empty;
                    txt_Familia.Text = string.Empty;
                }
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            cmb_Fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            cmb_Protocolo.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_Familia.Text = string.Empty;
        }

    }
}
