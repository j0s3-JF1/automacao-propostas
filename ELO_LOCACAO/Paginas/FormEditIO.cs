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
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormEditIO : Form
    {
        private string User;
        public FormEditIO()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaIDIO(cmb_ID);
            busca.CarregaStatusIO(cmb_Status);

            txt_EntradaA.Text = "0";
            txt_EntradaD.Text = "0";
            txt_SaidaA.Text = "0";
            txt_SaidaD.Text = "0";
        }
        private void FormEditIO_Load(object sender, EventArgs e)
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
                MessageBox.Show("Insira um numero de ID");
            }
            else
            {
                //Consulta de item para edição
                var consulta = new Consultar();
                consulta.ConsultaPlacaIO(
                        cmb_ID,
                        cmb_Fabricante,
                        cmb_Status,
                        txt_Config,
                        txt_EntradaA,
                        txt_EntradaD,
                        txt_Modelo,
                        txt_SaidaA,
                        txt_SaidaD,
                        txtFamilia
                    );

            }
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            //Declaração de variaveis
            int id;
            id = int.Parse(cmb_ID.Text);

            string fabricante, modelo, config, status, familia;
            fabricante = cmb_Fabricante.Text;
            modelo = txt_Modelo.Text;
            config = txt_Config.Text;
            status = cmb_Status.Text;
            familia = txtFamilia.Text;

            if (modelo == "" || status == "" || fabricante == "" || familia == "")
            {
                MessageBox.Show("Realize uma Busca ou Preencha Todos os Campos");
            }
            else
            {
                int digital_input, digital_output, analog_input, analog_output;
                digital_input = int.Parse(txt_EntradaD.Text);
                digital_output = int.Parse(txt_SaidaD.Text);
                analog_input = int.Parse(txt_EntradaA.Text);
                analog_output = int.Parse(txt_SaidaA.Text);

                var editar = new Editar();
                editar.Placa_IO(id, fabricante, modelo, config, status, digital_input, digital_output, analog_input, analog_output, familia, User);

                cmb_Fabricante.Text = string.Empty;
                cmb_Status.Text = string.Empty;
                txt_Config.Text = string.Empty;
                txt_EntradaA.Text = string.Empty;
                txt_EntradaD.Text = string.Empty;
                txt_Modelo.Text = string.Empty;
                txt_SaidaA.Text = string.Empty;
                txt_SaidaD.Text = string.Empty;
                txtFamilia.Text = string.Empty;
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            cmb_Fabricante.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_Config.Text = string.Empty;
            txt_EntradaA.Text = string.Empty;
            txt_EntradaD.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            txt_SaidaA.Text = string.Empty;
            txt_SaidaD.Text = string.Empty;
            txtFamilia.Text = string.Empty;
        }
    }
}
