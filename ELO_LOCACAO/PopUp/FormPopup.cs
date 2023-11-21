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
    public partial class FormPopUp : Form
    {
        private string mensagem;
        public FormPopUp(string msg)
        {
            InitializeComponent();
            this.mensagem = msg;
            label1.Text = mensagem;
        }

        private void btn_Fechar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
