namespace ELO_LOCACAO.Paginas
{
    partial class FormAdmCadastro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmCadastro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Senha = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Usuario = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txt_Nome = new System.Windows.Forms.TextBox();
            this.btn_Cadastrar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_Acesso = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmb_Acesso);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btn_Cadastrar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_Senha);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_Usuario);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.txt_Nome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 502);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(492, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Senha";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Senha
            // 
            this.txt_Senha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Senha.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.txt_Senha.Location = new System.Drawing.Point(367, 334);
            this.txt_Senha.Name = "txt_Senha";
            this.txt_Senha.Size = new System.Drawing.Size(321, 29);
            this.txt_Senha.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(487, 213);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Usuário";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Usuario
            // 
            this.txt_Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Usuario.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.txt_Usuario.Location = new System.Drawing.Point(367, 248);
            this.txt_Usuario.Name = "txt_Usuario";
            this.txt_Usuario.Size = new System.Drawing.Size(321, 29);
            this.txt_Usuario.TabIndex = 9;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(424, 131);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(207, 23);
            this.lblTitle.TabIndex = 8;
            this.lblTitle.Text = "Nome e Sobrenome";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Nome
            // 
            this.txt_Nome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_Nome.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.txt_Nome.Location = new System.Drawing.Point(367, 166);
            this.txt_Nome.Name = "txt_Nome";
            this.txt_Nome.Size = new System.Drawing.Size(321, 29);
            this.txt_Nome.TabIndex = 7;
            // 
            // btn_Cadastrar
            // 
            this.btn_Cadastrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Cadastrar.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.btn_Cadastrar.Location = new System.Drawing.Point(433, 407);
            this.btn_Cadastrar.Name = "btn_Cadastrar";
            this.btn_Cadastrar.Size = new System.Drawing.Size(189, 58);
            this.btn_Cadastrar.TabIndex = 29;
            this.btn_Cadastrar.Text = "Cadastrar";
            this.btn_Cadastrar.UseVisualStyleBackColor = true;
            this.btn_Cadastrar.Click += new System.EventHandler(this.btn_Cadastrar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(486, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "Acesso";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmb_Acesso
            // 
            this.cmb_Acesso.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmb_Acesso.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.cmb_Acesso.FormattingEnabled = true;
            this.cmb_Acesso.Location = new System.Drawing.Point(367, 85);
            this.cmb_Acesso.Name = "cmb_Acesso";
            this.cmb_Acesso.Size = new System.Drawing.Size(321, 29);
            this.cmb_Acesso.TabIndex = 32;
            // 
            // FormAdmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(1080, 502);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAdmCadastro";
            this.Text = "Elo Solutions | Cadastro Usuário";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Nome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Senha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Usuario;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btn_Cadastrar;
        private System.Windows.Forms.ComboBox cmb_Acesso;
        private System.Windows.Forms.Label label3;
    }
}