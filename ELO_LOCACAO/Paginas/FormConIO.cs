using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.Relatorio;
using ELO_LOCACAO.PopUp;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormConIO : Form
    {
        public FormConIO()
        {
            InitializeComponent();
            var busca = new Carrega();
            busca.CarregaFabricante(cmb_Fabricante);
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            var consulta = new Consultar();

            if (txt_Familia.Text != string.Empty || cmb_Fabricante.Text != string.Empty)
            {
                consulta.ConsultaIoFamilia(dgv_Consulta, txt_Familia.Text, cmb_Fabricante.Text);
            }
            else
            {
                consulta.ConsultaIo(dgv_Consulta);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (dgv_Consulta.DataSource == null)
            {
                MessageBox.Show("Realize uma consulta antes de gerar um relatório");
            }
            else
            {
                if (MessageBox.Show("Deseja gerar o relatório de Placas I/O?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var relatorio = new Relatorio();

                    while (!status)
                    {
                        var load = new PopupLoad("Carregando...");
                        load.Show();
                        Cursor = Cursors.WaitCursor;

                        status = relatorio.GeradorIO(dgv_Consulta);

                        if (!status)
                        {
                            Thread.Sleep(1000);
                        }

                        load.Close();
                        Cursor = Cursors.Default;
                    }

                }
            }
        }
    }
}
