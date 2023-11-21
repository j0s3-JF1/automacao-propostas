using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.PopUp
{
    public partial class PopupExit : Form
    {
        private string mensagem;
        public PopupExit(string mensagem)
        {
            InitializeComponent();
            this.mensagem = mensagem;
            label1.Text = mensagem;
        }

        private void btn_Sim_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Nao_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
