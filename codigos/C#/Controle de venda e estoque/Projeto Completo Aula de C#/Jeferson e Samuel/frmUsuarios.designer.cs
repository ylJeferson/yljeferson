﻿namespace Jeferson_e_Samuel
{
    partial class frmUsuarios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarios));
            this.chkADM = new System.Windows.Forms.CheckBox();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grbCadastro = new System.Windows.Forms.GroupBox();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsTxtBusca = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNovo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbCancelar = new System.Windows.Forms.ToolStripButton();
            this.tsbGravar = new System.Windows.Forms.ToolStripButton();
            this.tsbExcluir = new System.Windows.Forms.ToolStripButton();
            this.tsbBusca = new System.Windows.Forms.ToolStripButton();
            this.tsbPrimeiro = new System.Windows.Forms.ToolStripButton();
            this.tsbAnterior = new System.Windows.Forms.ToolStripButton();
            this.tsbProximo = new System.Windows.Forms.ToolStripButton();
            this.tsbUltimo = new System.Windows.Forms.ToolStripButton();
            this.tsbImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsbFechar = new System.Windows.Forms.ToolStripButton();
            this.pdoImprimir = new System.Drawing.Printing.PrintDocument();
            this.ppdVisualizar = new System.Windows.Forms.PrintPreviewDialog();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grbCadastro.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // chkADM
            // 
            this.chkADM.AutoSize = true;
            this.chkADM.Location = new System.Drawing.Point(493, 34);
            this.chkADM.Name = "chkADM";
            this.chkADM.Size = new System.Drawing.Size(50, 17);
            this.chkADM.TabIndex = 7;
            this.chkADM.Text = "ADM";
            this.chkADM.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
            this.dgvUsuarios.AllowUserToResizeColumns = false;
            this.dgvUsuarios.AllowUserToResizeRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 115);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(549, 150);
            this.dgvUsuarios.TabIndex = 8;
            this.dgvUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellClick);
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(281, 31);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(206, 20);
            this.txtSenha.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Senha:";
            // 
            // grbCadastro
            // 
            this.grbCadastro.AutoSize = true;
            this.grbCadastro.Controls.Add(this.txtSenha);
            this.grbCadastro.Controls.Add(this.label3);
            this.grbCadastro.Controls.Add(this.txtLogin);
            this.grbCadastro.Controls.Add(this.chkADM);
            this.grbCadastro.Controls.Add(this.txtID);
            this.grbCadastro.Controls.Add(this.label2);
            this.grbCadastro.Controls.Add(this.label1);
            this.grbCadastro.Location = new System.Drawing.Point(12, 38);
            this.grbCadastro.Name = "grbCadastro";
            this.grbCadastro.Size = new System.Drawing.Size(549, 71);
            this.grbCadastro.TabIndex = 0;
            this.grbCadastro.TabStop = false;
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(52, 32);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(223, 20);
            this.txtLogin.TabIndex = 4;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(6, 32);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(40, 20);
            this.txtID.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Login:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // tsTxtBusca
            // 
            this.tsTxtBusca.AutoSize = false;
            this.tsTxtBusca.Name = "tsTxtBusca";
            this.tsTxtBusca.Size = new System.Drawing.Size(250, 35);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNovo,
            this.tsbEditar,
            this.tsbCancelar,
            this.tsbGravar,
            this.tsbExcluir,
            this.toolStripSeparator1,
            this.tsTxtBusca,
            this.tsbBusca,
            this.toolStripSeparator2,
            this.tsbPrimeiro,
            this.tsbAnterior,
            this.tsbProximo,
            this.tsbUltimo,
            this.toolStripSeparator3,
            this.tsbImprimir,
            this.tsbFechar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(572, 35);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNovo
            // 
            this.tsbNovo.AutoSize = false;
            this.tsbNovo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNovo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNovo.Image")));
            this.tsbNovo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNovo.Name = "tsbNovo";
            this.tsbNovo.Size = new System.Drawing.Size(23, 32);
            this.tsbNovo.Text = "Novo";
            this.tsbNovo.Click += new System.EventHandler(this.tsbNovo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.AutoSize = false;
            this.tsbEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(23, 32);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbCancelar
            // 
            this.tsbCancelar.AutoSize = false;
            this.tsbCancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCancelar.Image = ((System.Drawing.Image)(resources.GetObject("tsbCancelar.Image")));
            this.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelar.Name = "tsbCancelar";
            this.tsbCancelar.Size = new System.Drawing.Size(23, 32);
            this.tsbCancelar.Text = "Cancelar";
            this.tsbCancelar.Click += new System.EventHandler(this.tsbCancelar_Click);
            // 
            // tsbGravar
            // 
            this.tsbGravar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGravar.Image = ((System.Drawing.Image)(resources.GetObject("tsbGravar.Image")));
            this.tsbGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGravar.Name = "tsbGravar";
            this.tsbGravar.Size = new System.Drawing.Size(23, 32);
            this.tsbGravar.Text = "Salvar";
            this.tsbGravar.Click += new System.EventHandler(this.tsbGravar_Click);
            // 
            // tsbExcluir
            // 
            this.tsbExcluir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExcluir.Image = ((System.Drawing.Image)(resources.GetObject("tsbExcluir.Image")));
            this.tsbExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExcluir.Name = "tsbExcluir";
            this.tsbExcluir.Size = new System.Drawing.Size(23, 32);
            this.tsbExcluir.Text = "Excluir";
            this.tsbExcluir.Click += new System.EventHandler(this.tsbExcluir_Click);
            // 
            // tsbBusca
            // 
            this.tsbBusca.AutoSize = false;
            this.tsbBusca.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBusca.Image = ((System.Drawing.Image)(resources.GetObject("tsbBusca.Image")));
            this.tsbBusca.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBusca.Name = "tsbBusca";
            this.tsbBusca.Size = new System.Drawing.Size(23, 32);
            this.tsbBusca.Text = "Busca";
            this.tsbBusca.Click += new System.EventHandler(this.tsbBusca_Click);
            // 
            // tsbPrimeiro
            // 
            this.tsbPrimeiro.AutoSize = false;
            this.tsbPrimeiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrimeiro.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrimeiro.Image")));
            this.tsbPrimeiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrimeiro.Name = "tsbPrimeiro";
            this.tsbPrimeiro.Size = new System.Drawing.Size(23, 32);
            this.tsbPrimeiro.Text = "Primeiro";
            this.tsbPrimeiro.Click += new System.EventHandler(this.tsbPrimeiro_Click);
            // 
            // tsbAnterior
            // 
            this.tsbAnterior.AutoSize = false;
            this.tsbAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAnterior.Image = ((System.Drawing.Image)(resources.GetObject("tsbAnterior.Image")));
            this.tsbAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAnterior.Name = "tsbAnterior";
            this.tsbAnterior.Size = new System.Drawing.Size(23, 32);
            this.tsbAnterior.Text = "Anterior";
            this.tsbAnterior.Click += new System.EventHandler(this.tsbAnterior_Click);
            // 
            // tsbProximo
            // 
            this.tsbProximo.AutoSize = false;
            this.tsbProximo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProximo.Image = ((System.Drawing.Image)(resources.GetObject("tsbProximo.Image")));
            this.tsbProximo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProximo.Name = "tsbProximo";
            this.tsbProximo.Size = new System.Drawing.Size(23, 32);
            this.tsbProximo.Text = "Proximo";
            this.tsbProximo.Click += new System.EventHandler(this.tsbProximo_Click);
            // 
            // tsbUltimo
            // 
            this.tsbUltimo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUltimo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUltimo.Image")));
            this.tsbUltimo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUltimo.Name = "tsbUltimo";
            this.tsbUltimo.Size = new System.Drawing.Size(23, 32);
            this.tsbUltimo.Text = "Ultimo";
            this.tsbUltimo.Click += new System.EventHandler(this.tsbUltimo_Click);
            // 
            // tsbImprimir
            // 
            this.tsbImprimir.AutoSize = false;
            this.tsbImprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsbImprimir.Image")));
            this.tsbImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImprimir.Name = "tsbImprimir";
            this.tsbImprimir.Size = new System.Drawing.Size(23, 32);
            this.tsbImprimir.Text = "Imprimir";
            this.tsbImprimir.Click += new System.EventHandler(this.tsbImprimir_Click);
            // 
            // tsbFechar
            // 
            this.tsbFechar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFechar.Image = ((System.Drawing.Image)(resources.GetObject("tsbFechar.Image")));
            this.tsbFechar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFechar.Name = "tsbFechar";
            this.tsbFechar.Size = new System.Drawing.Size(23, 20);
            this.tsbFechar.Text = "Fechar";
            this.tsbFechar.Click += new System.EventHandler(this.tsbFechar_Click);
            // 
            // pdoImprimir
            // 
            this.pdoImprimir.DocumentName = "print";
            this.pdoImprimir.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdoImprimir_PrintPage);
            // 
            // ppdVisualizar
            // 
            this.ppdVisualizar.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdVisualizar.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdVisualizar.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdVisualizar.Document = this.pdoImprimir;
            this.ppdVisualizar.Enabled = true;
            this.ppdVisualizar.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdVisualizar.Icon")));
            this.ppdVisualizar.Name = "ppdVisualizar";
            this.ppdVisualizar.Visible = false;
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 278);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.grbCadastro);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Cadastro de Usuários";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grbCadastro.ResumeLayout(false);
            this.grbCadastro.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkADM;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grbCadastro;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton tsbFechar;
        private System.Windows.Forms.ToolStripButton tsbImprimir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbUltimo;
        private System.Windows.Forms.ToolStripButton tsbProximo;
        private System.Windows.Forms.ToolStripButton tsbAnterior;
        private System.Windows.Forms.ToolStripButton tsbPrimeiro;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbBusca;
        private System.Windows.Forms.ToolStripTextBox tsTxtBusca;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbExcluir;
        private System.Windows.Forms.ToolStripButton tsbGravar;
        private System.Windows.Forms.ToolStripButton tsbCancelar;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbNovo;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Drawing.Printing.PrintDocument pdoImprimir;
        private System.Windows.Forms.PrintPreviewDialog ppdVisualizar;
    }
}