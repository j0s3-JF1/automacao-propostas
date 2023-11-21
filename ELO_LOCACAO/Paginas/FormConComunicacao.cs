﻿using ELO_LOCACAO.Classes;
using ELO_LOCACAO.Classes.Buscas;
using ELO_LOCACAO.Classes.Relatorio;
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
    public partial class FormConComunicacao : Form
    {
        public FormConComunicacao()
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
                consulta.ConsultaComunicacaoFamilia(dgv_Consulta, txt_Familia.Text, cmb_Fabricante.Text);
            }
            else
            {
                consulta.ConsultaComunicacao(dgv_Consulta);
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
                if (MessageBox.Show("Deseja gerar o relatório de Equipamentos?", "Aviso", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var relatorio = new Relatorio();

                    while (!status)
                    {
                        MessageBox.Show("Gerando Relatório, Aguarde...");
                        
                        status = relatorio.GeradorComm(dgv_Consulta);

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
