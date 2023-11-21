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
    public partial class FormAdmin : Form
    {
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public FormAdmin()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            FormInicio mainForm = Application.OpenForms["FormInicio"] as FormInicio;
            if (mainForm != null)
            {
                string acesso = mainForm.StatusValue;

                if (acesso == "COM" || acesso == "EXP")
                {
                    MessageBox.Show("Você não tem acesso de Administrador!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
        }

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
            panelAdmin.Controls.Add(childForm);
            panelAdmin.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_Cadastrar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAdmCadastro());
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAdmAlterar());
        }

        private void btn_Verificar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAdmVerifica());
        }

        private void btn_Deletar_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAdmDeletar());
        }
    }
}
