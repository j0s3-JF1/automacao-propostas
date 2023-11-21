using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.Relatorio;
using ELO_LOCACAO.Conn;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Paginas
{
    public partial class FormConEquip : Form
    {
        public FormConEquip()
        {
            InitializeComponent();
            var carrega = new Carrega();
            carrega.CarregaFabricante(cmb_Fabricante);
            carrega.CarregaNumSerie(cmb_NumSerie);
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            string numserie = cmb_NumSerie.Text;
            string fabricante = cmb_Fabricante.Text;


            var consulta = new Consultar();

            if (numserie != string.Empty)
            {
                consulta.ConsultaEquipamentoNumSerie(dgv_Consulta, cmb_NumSerie);
            }
            else if (fabricante != string.Empty)
            {
                consulta.ConsultaEquipamentoFabricante(dgv_Consulta, fabricante);
            }
            else if (numserie == string.Empty && fabricante == string.Empty)
            {
                consulta.ConsultaEquipamentoTudo(dgv_Consulta);
            }
        }

        private void btn_Relatorio_Click(object sender, EventArgs e)
        {
            bool status = false;

            if (dgv_Consulta.DataSource == null)
            {
                MessageBox.Show("Realize uma consulta antes de gerar um relatório");
            }
            else
            {
                if (MessageBox.Show("Deseja gerar o relatório de Equipamentos?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var relatorio = new Relatorio();

                    while (!status)
                    {
                        MessageBox.Show("Gerando Relatório, Aguarde...");

                        status = relatorio.GeradorEquip(dgv_Consulta);

                        if (!status)
                        {
                            Thread.Sleep(1000);
                        }
                    }

                }
            }
        }
    }
}
