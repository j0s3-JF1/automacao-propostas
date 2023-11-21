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
    public partial class FormEditEncoder : Form
    {
        private string User;
        public FormEditEncoder()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaIDEncoder(cmb_ID);
            busca.CarregaStatusEncoder(cmb_Status);
            busca.CarregaFabricante(cmb_Fabricante);
            busca.CarregaEncoder(cmb_Tipo);

        }
        private void FormEditEncoder_Load(object sender, EventArgs e)
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
                var consulta = new Consultar();
                consulta.ConsultaEncoder(
                        cmb_ID,
                        cmb_Fabricante,
                        cmb_Tipo,
                        cmb_Status,
                        txt_Modelo,
                        txt_Familia
                    );
            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //Declaração de variaveis
            int id;
            id = int.Parse(cmb_ID.Text);

            string fabricante, modelo, tipo, status, familia;
            fabricante = cmb_Fabricante.Text;
            modelo = txt_Modelo.Text;
            tipo = cmb_Tipo.Text;
            status = cmb_Status.Text;
            familia = txt_Familia.Text;

            var editar = new Editar();
            editar.Placa_Encoder(id, fabricante, modelo, tipo, status, familia, User);

            cmb_Fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            cmb_Tipo.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_Familia.Text = string.Empty;
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            cmb_Fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            cmb_Tipo.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_Familia.Text = string.Empty;
        }

        
    }
}
