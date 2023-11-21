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

namespace ELO_LOCACAO.Paginas
{
    public partial class FormInicio : Form
    {
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public string StatusValue { get; set; }
        public string Usuario { get; set; }

        public FormInicio()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            
        }

        //Abrir Formulario
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void picLogo_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Locação | Elo Solutions";
            if (currentChildForm == null){ }
            else
            {
                currentChildForm.Close();
            }
        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            new PopupExit("Deseja Sair do Sistema?").Show();
        }

        private void btn_Cadastrar_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Cadastrar";
            OpenChildForm(new FormOpcoes());
        }

        private void btn_Editar_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Editar";
            OpenChildForm(new FormOpcoes3());
        }

        private void btn_Consultar_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Consultar";
            OpenChildForm(new FormOpcoes2());
        }

        private void btn_Deletar_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Deletar";
            OpenChildForm(new FormOpcoes4());
        }

        private void btn_Proposta_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Proposta";
            new FormProposta().Show();
        }

        private void btn_Check_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Check-List";
            new FormCheck().Show();
        }

        private void btn_Admin_Click(object sender, EventArgs e)
        {
            var destino = new FormAdmin();
            destino.Show();
        }

        private void FormInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Pergunte ao usuário se ele deseja realmente sair
                DialogResult resultado = MessageBox.Show("Deseja realmente sair do aplicativo?", "Confirmação de Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    // Se o usuário clicar em "Não", cancele o fechamento do formulário
                    e.Cancel = true;
                }
                else
                {
                    // Se o usuário clicar em "Sim", encerre a aplicação
                    Application.Exit();
                }
            }
        }
    }
}
