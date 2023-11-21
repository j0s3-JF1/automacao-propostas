namespace ELO_LOCACAO.Paginas
{
    partial class FormEditComunicacao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditComunicacao));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Familia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_Status = new System.Windows.Forms.ComboBox();
            this.cmb_ID = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_Protocolo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_modelo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_Fabricante = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.txt_Familia);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmb_Status);
            this.panel1.Controls.Add(this.cmb_ID);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btn_Editar);
            this.panel1.Controls.Add(this.btn_Consultar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cmb_Protocolo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_modelo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmb_Fabricante);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 2;
            // 
            // txt_Familia
            // 
            this.txt_Familia.Enabled = false;
            this.txt_Familia.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.txt_Familia.Location = new System.Drawing.Point(17, 313);
            this.txt_Familia.Name = "txt_Familia";
            this.txt_Familia.Size = new System.Drawing.Size(278, 29);
            this.txt_Familia.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 18);
            this.label2.TabIndex = 32;
            this.label2.Text = "Familia:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_Status
            // 
            this.cmb_Status.Enabled = false;
            this.cmb_Status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Status.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.cmb_Status.FormattingEnabled = true;
            this.cmb_Status.Location = new System.Drawing.Point(374, 253);
            this.cmb_Status.Name = "cmb_Status";
            this.cmb_Status.Size = new System.Drawing.Size(290, 29);
            this.cmb_Status.TabIndex = 31;
            // 
            // cmb_ID
            // 
            this.cmb_ID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_ID.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.cmb_ID.FormattingEnabled = true;
            this.cmb_ID.Location = new System.Drawing.Point(17, 106);
            this.cmb_ID.Name = "cmb_ID";
            this.cmb_ID.Size = new System.Drawing.Size(123, 29);
            this.cmb_ID.TabIndex = 30;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.button3.Location = new System.Drawing.Point(212, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(189, 58);
            this.button3.TabIndex = 29;
            this.button3.Text = "Limpar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.btn_Editar.Location = new System.Drawing.Point(17, 380);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(189, 58);
            this.btn_Editar.TabIndex = 28;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.Font = new System.Drawing.Font("Century Gothic", 8F);
            this.btn_Consultar.Location = new System.Drawing.Point(152, 106);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(76, 29);
            this.btn_Consultar.TabIndex = 27;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = true;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(371, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 18);
            this.label8.TabIndex = 21;
            this.label8.Text = "Status:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_Protocolo
            // 
            this.cmb_Protocolo.Enabled = false;
            this.cmb_Protocolo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Protocolo.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.cmb_Protocolo.FormattingEnabled = true;
            this.cmb_Protocolo.Location = new System.Drawing.Point(17, 253);
            this.cmb_Protocolo.Name = "cmb_Protocolo";
            this.cmb_Protocolo.Size = new System.Drawing.Size(350, 29);
            this.cmb_Protocolo.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(14, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "Protocolo:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_modelo
            // 
            this.txt_modelo.Enabled = false;
            this.txt_modelo.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.txt_modelo.Location = new System.Drawing.Point(17, 200);
            this.txt_modelo.Name = "txt_modelo";
            this.txt_modelo.Size = new System.Drawing.Size(397, 29);
            this.txt_modelo.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(14, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 18);
            this.label6.TabIndex = 12;
            this.label6.Text = "Modelo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmb_Fabricante
            // 
            this.cmb_Fabricante.Enabled = false;
            this.cmb_Fabricante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Fabricante.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.cmb_Fabricante.FormattingEnabled = true;
            this.cmb_Fabricante.Location = new System.Drawing.Point(420, 200);
            this.cmb_Fabricante.Name = "cmb_Fabricante";
            this.cmb_Fabricante.Size = new System.Drawing.Size(244, 29);
            this.cmb_Fabricante.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(417, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 18);
            this.label3.TabIndex = 8;
            this.label3.Text = "Fabricante:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 16.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(355, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Edite os Dados A partir de um ID";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormEditComunicacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEditComunicacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edite | Placa de Comunicação";
            this.Load += new System.EventHandler(this.FormEditComunicacao_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_ID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Consultar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_Protocolo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_modelo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_Fabricante;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmb_Status;
        private System.Windows.Forms.TextBox txt_Familia;
        private System.Windows.Forms.Label label2;
    }
}