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
    public partial class FormOpcoes4 : Form
    {
        public FormOpcoes4()
        {
            InitializeComponent();
        }

        private void btn_Equipamento_Click(object sender, EventArgs e)
        {
            var destino = new FormDelEquip();
            destino.Show();
        }

        private void btn_IO_Click(object sender, EventArgs e)
        {
            var destino = new FormDelIO();
            destino.Show();
        }

        private void btn_Comunicacao_Click(object sender, EventArgs e)
        {
            var destino = new FormDelComunicacao();
            destino.Show();
        }

        private void btn_Encoder_Click(object sender, EventArgs e)
        {
            var destino = new FormDelEncoder();
            destino.Show();
        }
    }
}
