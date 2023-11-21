using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELO_LOCACAO.Paginas;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormOpcoes : Form
    {
        public FormOpcoes()
        {
            InitializeComponent();
        }

        private void btn_Equipamento_Click_1(object sender, EventArgs e)
        {
            var frmEquipamento = new FormCadEquipamento();
            frmEquipamento.Show();
        }

        private void btn_IO_Click_1(object sender, EventArgs e)
        {
            var frmIO = new FormCadIO();
            frmIO.Show();
        }

        private void btn_Comunicacao_Click_1(object sender, EventArgs e)
        {
            var frmComunicacao = new FormCadComunicacao();
            frmComunicacao.Show();
        }

        private void btn_Encoder_Click_1(object sender, EventArgs e)
        {
            var frmEncoder = new FormCadEncoder();
            frmEncoder.Show();
        }
    }
}
