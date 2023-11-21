using ELO_LOCACAO.Conn;
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
    public partial class FormEditComunicacao : Form
    {
        private string User;
        public FormEditComunicacao()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaIDComunicacao(cmb_ID);
            busca.CarregaProtocolo(cmb_Protocolo);
            busca.CarregaFabricante(cmb_Fabricante);
            busca.CarregaStatusComunicacao(cmb_Status);
        }
        private void FormEditComunicacao_Load(object sender, EventArgs e)
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
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            if (cmb_ID.Text == string.Empty)
            {
                MessageBox.Show("Insira um ID!");
            }
            else
            {
                //Lógica de busca
                var consulta = new Consultar();
                consulta.ConsultaPlacaComunicacao(
                        cmb_ID,
                        cmb_Fabricante,
                        cmb_Protocolo,
                        cmb_Status,
                        txt_modelo,
                        txt_Familia
                    );
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //Declaração de variaveis
            int id;
            id = int.Parse(cmb_ID.Text);

            string fabricante, modelo, protocolo, status, familia;
            fabricante = cmb_Fabricante.Text;
            modelo = txt_modelo.Text;
            protocolo = cmb_Protocolo.Text;
            status = cmb_Status.Text;
            familia = txt_Familia.Text;

            var editar = new Editar();
            editar.Placa_Comunicacao( id,  fabricante,  modelo,  protocolo,  status, familia, User);

            cmb_Fabricante.Text = string.Empty;
            cmb_Protocolo.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_modelo.Text = string.Empty;
            txt_Familia.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmb_Fabricante.Text = string.Empty;
            cmb_Protocolo.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_modelo.Text = string.Empty;
            txt_Familia.Text = string.Empty;
        }
    }
}
