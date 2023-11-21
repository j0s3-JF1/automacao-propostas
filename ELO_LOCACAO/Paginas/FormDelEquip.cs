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
    public partial class FormDelEquip : Form
    {
        public FormDelEquip()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaNumSerie(cmb_numserie);
        }
        private void FormDelEquip_Load(object sender, EventArgs e)
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
            if (cmb_numserie.Text == "")
            {
                MessageBox.Show("Insira um Número de Série!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Verificar Modelo pelo Numero de série
                var Conexao = ConnectionFactory.Build();
                Conexao.Open();

                var query = @"SELECT MODELO FROM EQUIPAMENTO WHERE NUMSERIE = @numserie";
                var comando = new MySqlCommand(query, Conexao);
                comando.Parameters.AddWithValue("numserie", cmb_numserie.Text);
                var reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    txt_modelo.Text = reader[0].ToString();
                }

                Conexao.Close();
            }
        }

        private void btn_deletar_Click(object sender, EventArgs e)
        {
            if (cmb_numserie.Text == "")
            {
                MessageBox.Show("Insira um Número de Série!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txt_modelo.Text == "")
                {
                    MessageBox.Show("Verifique o Equipamento antes de Apagar!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var deletar = new Deletar();
                    if (MessageBox.Show($"Deseja apagar o equipamento referente ao Número de série {cmb_numserie.Text}?", "Aviso",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        deletar.DeletarCaracteristica(cmb_numserie);
                        deletar.DeletarEquip(cmb_numserie);

                        MessageBox.Show("Equipamento deletado com sucesso!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmb_numserie.Text = string.Empty;
            txt_modelo.Text = string.Empty;
        }
    }
}
