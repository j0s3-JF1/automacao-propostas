using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Classes.Colecao
{
    internal class Colecao
    {
        public void ColecaoChooper(ComboBox comboBox)
        {
            comboBox.Items.Add("Sim");
            comboBox.Items.Add("Não");
        }
        public void ColecaoAcesso(ComboBox comboBox)
        {
            comboBox.Items.Add("COM");
            comboBox.Items.Add("ALL");
            comboBox.Items.Add("EXP");
        }
        public void ColecaoTensao(ComboBox comboBox)
        {
            comboBox.Items.Add("220");
            comboBox.Items.Add("380");
            comboBox.Items.Add("440");
            comboBox.Items.Add("500");
            comboBox.Items.Add("690");
        }

        public void ColecaoFechamento(ComboBox comboBox)
        {
            comboBox.Items.Add("MONOFÁSICO");
            comboBox.Items.Add("TRIFÁSICO");
        }

        public void ColecaoCaracteristica(ComboBox comboBox)
        {
            comboBox.Items.Add("DELTA ABERTA");
            comboBox.Items.Add("NEUTRO SOLIDAMENTE ATERRADO");
        }

        public void ColecaoProfissional(ComboBox comboBox)
        {
            comboBox.Items.Add("NÃO");
            comboBox.Items.Add("SIM");
        }

        public void ColecaoSuporte(ComboBox comboBox)
        {
            comboBox.Items.Add("NÃO");
            comboBox.Items.Add("LOCAL");
            comboBox.Items.Add("REMOTO");
        }

        public void ColecaoAmbiente(ComboBox comboBox)
        {
            comboBox.Items.Add("NENHUM");
            comboBox.Items.Add("ÚMIDO");
            comboBox.Items.Add("SECO");
            comboBox.Items.Add("OUTROS");
        }
    }
}
