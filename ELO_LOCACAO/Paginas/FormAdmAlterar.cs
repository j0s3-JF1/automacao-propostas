using ELO_LOCACAO.Classes.Admin;
using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.Colecao;
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
    public partial class FormAdmAlterar : Form
    {
        public FormAdmAlterar()
        {
            InitializeComponent();
            var busca = new Carrega();
            var colecao = new Colecao();
            busca.CarregaIDUsuario(cmb_ID);
            colecao.ColecaoAcesso(cmb_Acesso);
        }

        private void btn_Consulta_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = int.Parse(cmb_ID.Text);

            if (id == 0 || id.ToString() == string.Empty)
            {
                MessageBox.Show("Insira um ID para alterar o Usuario!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var adm = new Admin();
                adm.ConsultaID(txt_Nome, txt_Senha, txt_Usuario, cmb_Acesso, id);
            }
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = int.Parse(cmb_ID.Text);

            string nome, acesso, usuario, senha;

            nome = txt_Nome.Text;
            usuario = txt_Usuario.Text;
            senha = txt_Senha.Text;
            acesso = cmb_Acesso.Text;

            if (nome == string.Empty || usuario == string.Empty || senha == string.Empty || acesso == string.Empty)
            {
                MessageBox.Show("Preencha Todos os Campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var adm = new Admin();
                adm.Alterar(nome, usuario, senha, acesso, id);
            }
        }
    }
}
