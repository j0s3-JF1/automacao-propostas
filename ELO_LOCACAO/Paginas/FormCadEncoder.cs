using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Classes.Buscas;
using System;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormCadEncoder : Form
    {
        private string User;
        public FormCadEncoder()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaFabricante(cmb_Fabricante);
            busca.CarregaStatusEncoder(cmb_Status);
            busca.CarregaEncoder(cmb_Tipo);
        }

        private void FormCadEncoder_Load(object sender, EventArgs e)
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
            //Condição para envio
            if (cmb_Tipo.Text == string.Empty || txt_Modelo.Text == string.Empty)
            {
                MessageBox.Show("Preencha todos os campos abaixo");
            }
            else
            {
                try
                {

                    string fabricante, modelo, tipo, status, familia;

                    fabricante = cmb_Fabricante.Text;
                    modelo = txt_Modelo.Text;
                    tipo = cmb_Tipo.Text;
                    status = cmb_Status.Text;
                    familia = txt_Familia.Text;

                    if (MessageBox.Show($"Deseja Cadastrar a Placa {modelo}?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        var placa_encoder = new Cadastrar();
                        placa_encoder.Placa_Encoder(fabricante, modelo, tipo, status, familia, User);

                        cmb_Fabricante.Text = string.Empty;
                        txt_Modelo.Text = string.Empty;
                        cmb_Tipo.Text = string.Empty;
                        cmb_Status.Text = string.Empty;
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
            cmb_Fabricante.Text = string.Empty;
            txt_Modelo.Text = string.Empty;
            cmb_Tipo.Text = string.Empty;
            cmb_Status.Text = string.Empty;
            txt_Familia.Text = string.Empty;
        }

    }
}
