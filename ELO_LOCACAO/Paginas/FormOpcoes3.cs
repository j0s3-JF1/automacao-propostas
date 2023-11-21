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
    public partial class FormOpcoes3 : Form
    {
        public FormOpcoes3()
        {
            InitializeComponent();
        }

        private void btn_Equipamento_Click(object sender, EventArgs e)
        {
            var destino = new FormEditEquip();
            destino.Show();
        }

        private void btn_IO_Click(object sender, EventArgs e)
        {
            var destino = new FormEditIO();
            destino.Show();
        }

        private void btn_Comunicacao_Click(object sender, EventArgs e)
        {
            var destino = new FormEditComunicacao();
            destino.Show();
        }

        private void btn_Encoder_Click(object sender, EventArgs e)
        {
            var destino = new FormEditEncoder();
            destino.Show();
        }
    }
}
