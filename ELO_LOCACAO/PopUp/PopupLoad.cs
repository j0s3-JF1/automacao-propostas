using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.PopUp
{
    public partial class PopupLoad : Form
    {
        private string mensagem;
        public PopupLoad(string mensagem)
        {
            InitializeComponent();
            this.mensagem = mensagem;

            label1.Text = mensagem;
        }
    }
}
