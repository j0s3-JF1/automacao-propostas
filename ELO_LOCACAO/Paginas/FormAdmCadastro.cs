using ELO_LOCACAO.Classes.Admin;
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
    public partial class FormAdmCadastro : Form
    {
        public FormAdmCadastro()
        {
            InitializeComponent();
            var colecao = new Colecao();
            colecao.ColecaoAcesso(cmb_Acesso);
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            string nome, usuario, senha, acesso;

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
                adm.Cadastro(nome, usuario, senha, acesso);
            }
        }
    }
}
