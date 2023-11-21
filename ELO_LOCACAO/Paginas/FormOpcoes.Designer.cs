﻿namespace ELO_LOCACAO.Paginas
{
    partial class FormOpcoes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Encoder = new System.Windows.Forms.Button();
            this.btn_Comunicacao = new System.Windows.Forms.Button();
            this.btn_IO = new System.Windows.Forms.Button();
            this.btn_Equipamento = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.btn_Encoder);
            this.panel1.Controls.Add(this.btn_Comunicacao);
            this.panel1.Controls.Add(this.btn_IO);
            this.panel1.Controls.Add(this.btn_Equipamento);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 1;
            // 
            // btn_Encoder
            // 
            this.btn_Encoder.FlatAppearance.BorderSize = 4;
            this.btn_Encoder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Encoder.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.btn_Encoder.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Encoder.Location = new System.Drawing.Point(600, 202);
            this.btn_Encoder.Name = "btn_Encoder";
            this.btn_Encoder.Size = new System.Drawing.Size(189, 58);
            this.btn_Encoder.TabIndex = 35;
            this.btn_Encoder.Text = "Cadastrar Placa encoder";
            this.btn_Encoder.UseVisualStyleBackColor = true;
            this.btn_Encoder.Click += new System.EventHandler(this.btn_Encoder_Click_1);
            // 
            // btn_Comunicacao
            // 
            this.btn_Comunicacao.FlatAppearance.BorderSize = 4;
            this.btn_Comunicacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Comunicacao.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.btn_Comunicacao.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Comunicacao.Location = new System.Drawing.Point(405, 202);
            this.btn_Comunicacao.Name = "btn_Comunicacao";
            this.btn_Comunicacao.Size = new System.Drawing.Size(189, 58);
            this.btn_Comunicacao.TabIndex = 34;
            this.btn_Comunicacao.Text = "Cadastrar Placa Comunicação";
            this.btn_Comunicacao.UseVisualStyleBackColor = true;
            this.btn_Comunicacao.Click += new System.EventHandler(this.btn_Comunicacao_Click_1);
            // 
            // btn_IO
            // 
            this.btn_IO.FlatAppearance.BorderSize = 4;
            this.btn_IO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_IO.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.btn_IO.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_IO.Location = new System.Drawing.Point(210, 202);
            this.btn_IO.Name = "btn_IO";
            this.btn_IO.Size = new System.Drawing.Size(189, 58);
            this.btn_IO.TabIndex = 33;
            this.btn_IO.Text = "Cadastrar Placa I/O";
            this.btn_IO.UseVisualStyleBackColor = true;
            this.btn_IO.Click += new System.EventHandler(this.btn_IO_Click_1);
            // 
            // btn_Equipamento
            // 
            this.btn_Equipamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(35)))), ((int)(((byte)(74)))));
            this.btn_Equipamento.FlatAppearance.BorderSize = 4;
            this.btn_Equipamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Equipamento.Font = new System.Drawing.Font("Century Gothic", 13.25F);
            this.btn_Equipamento.ForeColor = System.Drawing.SystemColors.Control;
            this.btn_Equipamento.Location = new System.Drawing.Point(15, 202);
            this.btn_Equipamento.Name = "btn_Equipamento";
            this.btn_Equipamento.Size = new System.Drawing.Size(189, 58);
            this.btn_Equipamento.TabIndex = 32;
            this.btn_Equipamento.Text = "Cadastrar Equipamento";
            this.btn_Equipamento.UseVisualStyleBackColor = false;
            this.btn_Equipamento.Click += new System.EventHandler(this.btn_Equipamento_Click_1);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 16.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(12, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(386, 26);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Selecione uma das opções abaixo";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormOpcoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "FormOpcoes";
            this.Text = "FormOpcoes";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Encoder;
        private System.Windows.Forms.Button btn_Comunicacao;
        private System.Windows.Forms.Button btn_IO;
        private System.Windows.Forms.Button btn_Equipamento;
        private System.Windows.Forms.Label lblTitle;
    }
}