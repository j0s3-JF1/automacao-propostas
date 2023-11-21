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
    public partial class FormAdmVerifica : Form
    {
        public FormAdmVerifica()
        {
            InitializeComponent();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            var adm = new Admin();
            adm.Consulta(dataGridView1);
        }
    }
}
