using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.CheckList;
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
    public partial class FormConCheck : Form
    {
        public FormConCheck()
        {
            InitializeComponent();
            var carrega = new Carrega();
            carrega.CarregaEmpresa(cmb_Empresa);
            carrega.CarregaCliente(cmb_Cliente);
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            var check = new Check();
            if (cmb_Cliente.Text != string.Empty || cmb_Empresa.Text != string.Empty)
            {
                check.ConsultaCheckList(dgv_Consulta, cmb_Cliente, cmb_Empresa);
            }
            else
            {
                check.ConsultaTudo(dgv_Consulta);
            }
        }
    }
}
