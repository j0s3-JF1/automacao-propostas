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
    public partial class FormCadIO : Form
    {
        private string User;
        public FormCadIO()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaFabricante(cmb_fabricante);
            busca.CarregaStatusIO(cmb_Status);

            txt_EntradaA.Text = "0";
            txt_EntradaD.Text = "0";
            txt_SaidaA.Text = "0";
            txt_SaidaD.Text = "0";
        }

        private void FormCadIO_Load(object sender, EventArgs e)
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
            //Condição de Envio
            if (cmb_fabricante.Text == string.Empty || txt_Modelo.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos!");
            }
            else
            {
                try
                {
                    string fabricante, modelo, config, status, familia;

                    fabricante = cmb_fabricante.Text;
                    modelo = txt_Modelo.Text;
                    config = txt_Config.Text;
                    status = cmb_Status.Text;
                    familia = txt_Familia.Text;

                    int digital_input, digital_output, analog_input, analog_output;

                    digital_input = int.Parse(txt_EntradaD.Text);
                    digital_output = int.Parse(txt_SaidaD.Text);
                    analog_input = int.Parse(txt_EntradaA.Text);
                    analog_output = int.Parse(txt_SaidaA.Text);

                    if (MessageBox.Show($"Deseja Cadastrar a Placa {modelo}?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var placa_io = new Cadastrar();
                        placa_io.Placa_IO(fabricante, modelo, config, status, digital_input, digital_output, analog_input, analog_output, familia, User);

                        cmb_fabricante.Text = string.Empty;
                        txt_Modelo.Text = string.Empty;
                        txt_Config.Text = string.Empty;
                        cmb_Status.Text = string.Empty;
                        txt_EntradaD.Text = string.Empty;
                        txt_SaidaD.Text = string.Empty;
                        txt_EntradaA.Text = string.Empty;
                        txt_SaidaA.Text = string.Empty;
                        txt_Familia.Text = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar!", "Aviso");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btn_Limpar_Click(object sender, EventArgs e)
        {
            cmb_fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            txt_Config.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_Familia.Text = string.Empty;

            TextBox[] campos = new TextBox[4];

            campos[0] = txt_EntradaD;
            campos[1] = txt_SaidaD;
            campos[2] = txt_EntradaA;
            campos[3] = txt_SaidaA;

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
