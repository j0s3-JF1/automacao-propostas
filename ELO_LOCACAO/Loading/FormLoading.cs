using ELO_LOCACAO.Conn;
using ELO_LOCACAO.Paginas;
using ELO_LOCACAO.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ELO_LOCACAO.Loading
{
    public partial class FormLoading : Form
    {
        private Timer timer;
        private int segundosPassados = 0;

        public FormLoading()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;

            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundosPassados++;

            // Atualiza a ProgressBar
            progressBar1.Value = segundosPassados;

            if (segundosPassados >= 10)
            {
                timer.Stop();

                var conexao = ConnectionFactory.Build();

                if (conexao != null)
                {
                    FormLogin mainForm = new FormLogin();
                    mainForm.Show();
                    //new FormPopUp("Seja Bem-Vindo").Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Falha na Conexão com os Servidores, Reinicie o sistema ou tente novamente mais tarde!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
        }
    }
}
