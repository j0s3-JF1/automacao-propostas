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
    public partial class FormDelIO : Form
    {
        public FormDelIO()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaIDIO(cmb_ID);
        }
        private void FormDelIO_Load(object sender, EventArgs e)
        {
            FormInicio mainForm = Application.OpenForms["FormInicio"] as FormInicio;
            if (mainForm != null)
            {
                string acesso = mainForm.StatusValue;

                if (acesso == "COM")
                {
                    MessageBox.Show("Seu tipo de Acesso não permite Deletar");
                    this.Close();
                }
            }
        }

        private void btn_verificar_Click(object sender, EventArgs e)
        {
            if (cmb_ID.Text == "")
            {
                MessageBox.Show("Insira um ID!", "Aviso");
            }
            else
            {
                try
                {
                    var Conexao = ConnectionFactory.Build();
                    Conexao.Open();

                    var query = @"SELECT MODELO FROM PLACA_IO WHERE ID = @id";
                    var comando = new MySqlCommand(query, Conexao);
                    comando.Parameters.AddWithValue("@id", cmb_ID.Text);
                    var reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        txt_modelo.Text = reader[0].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao Encontrar Placa!");
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (cmb_ID.Text == "")
            {
                MessageBox.Show("Insira um ID!", "Aviso");
            }
            else
            {
                if (txt_modelo.Text == "")
                {
                    MessageBox.Show("Verifique a Placa na qual será deletada!", "Aviso");
                }
                else
                {
                    var deletar = new Deletar();
                    deletar.DeletarIO(cmb_ID);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmb_ID.Text = string.Empty;
            txt_modelo.Text = string.Empty;
        }
    }
}
