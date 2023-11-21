using ELO_LOCACAO.Classes.Admin;
using ELO_LOCACAO.Classes.Buscas;
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
    public partial class FormAdmDeletar : Form
    {
        public FormAdmDeletar()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaIDUsuario(cmb_ID);
        }

        private void btn_Consulta_Click(object sender, EventArgs e)
        {
            int id = 0;
            id = cmb_ID.SelectedIndex;

            if (id == 0 || id.ToString() == string.Empty)
            {
                MessageBox.Show("Insira um ID para buscar o usuário!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var adm = new Admin();
                adm.ConsultaDel(txt_Usuario, id);
            }
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            string usuario = txt_Usuario.Text;
            int id = 0;
            id = int.Parse(cmb_ID.Text);

            if (usuario == "" || id == 0 || id.ToString() == "")
            {
                MessageBox.Show("Nenhum usuário encontrado, consulte um antes de Deletar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                if (MessageBox.Show("Deseja realmente deletar este usuário?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var adm = new Admin();
                    adm.Deletar(id);
                }
            }
        }
    }
}
