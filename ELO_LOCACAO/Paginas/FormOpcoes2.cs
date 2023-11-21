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
    public partial class FormOpcoes2 : Form
    {
        public FormOpcoes2()
        {
            InitializeComponent();
        }

        private void btn_Equipamento_Click(object sender, EventArgs e)
        {
            new FormConEquip().Show();
        }

        private void btn_IO_Click(object sender, EventArgs e)
        {
            new FormConIO().Show();
        }

        private void btn_Comunicacao_Click(object sender, EventArgs e)
        {
            new FormConComunicacao().Show();
        }

        private void btn_Encoder_Click(object sender, EventArgs e)
        {
            new FormConEncoder().Show();
        }
    }
}
