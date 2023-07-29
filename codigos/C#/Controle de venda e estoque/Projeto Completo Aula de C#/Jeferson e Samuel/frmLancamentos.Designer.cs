namespace Jeferson_e_Samuel
{
    partial class frmLancamentos
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
            this.nudParc = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnGravar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.grbDespesa = new System.Windows.Forms.GroupBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.cboDespesa = new System.Windows.Forms.ComboBox();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.lklFornecedor = new System.Windows.Forms.LinkLabel();
            this.lklDespesa = new System.Windows.Forms.LinkLabel();
            this.dtpMovimento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.grbInformacoes = new System.Windows.Forms.GroupBox();
            this.mtbValor = new System.Windows.Forms.TextBox();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCartao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDinheiro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpVencimento = new System.Windows.Forms.DateTimePicker();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudParc)).BeginInit();
            this.grbDespesa.SuspendLayout();
            this.grbInformacoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // nudParc
            // 
            this.nudParc.Location = new System.Drawing.Point(148, 32);
            this.nudParc.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudParc.Name = "nudParc";
            this.nudParc.Size = new System.Drawing.Size(81, 20);
            this.nudParc.TabIndex = 49;
            this.nudParc.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudParc.ValueChanged += new System.EventHandler(this.nudParc_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(145, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(84, 13);
            this.label10.TabIndex = 48;
            this.label10.Text = "Nº. de Parcelas:";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(438, 240);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(68, 35);
            this.btnFechar.TabIndex = 47;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(289, 240);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(68, 35);
            this.btnGravar.TabIndex = 50;
            this.btnGravar.Text = "Lançar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(364, 240);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(68, 35);
            this.btnCancelar.TabIndex = 51;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // grbDespesa
            // 
            this.grbDespesa.Controls.Add(this.btnConfirmar);
            this.grbDespesa.Controls.Add(this.cboDespesa);
            this.grbDespesa.Controls.Add(this.cboFornecedor);
            this.grbDespesa.Controls.Add(this.lklFornecedor);
            this.grbDespesa.Controls.Add(this.lklDespesa);
            this.grbDespesa.Location = new System.Drawing.Point(12, 12);
            this.grbDespesa.Name = "grbDespesa";
            this.grbDespesa.Size = new System.Drawing.Size(500, 104);
            this.grbDespesa.TabIndex = 43;
            this.grbDespesa.TabStop = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(401, 73);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(93, 23);
            this.btnConfirmar.TabIndex = 24;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // cboDespesa
            // 
            this.cboDespesa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDespesa.FormattingEnabled = true;
            this.cboDespesa.Location = new System.Drawing.Point(76, 19);
            this.cboDespesa.Name = "cboDespesa";
            this.cboDespesa.Size = new System.Drawing.Size(418, 21);
            this.cboDespesa.TabIndex = 23;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(76, 46);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(418, 21);
            this.cboFornecedor.TabIndex = 22;
            // 
            // lklFornecedor
            // 
            this.lklFornecedor.AutoSize = true;
            this.lklFornecedor.Location = new System.Drawing.Point(6, 49);
            this.lklFornecedor.Name = "lklFornecedor";
            this.lklFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lklFornecedor.TabIndex = 21;
            this.lklFornecedor.TabStop = true;
            this.lklFornecedor.Text = "Fornecedor:";
            this.lklFornecedor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklFornecedor_LinkClicked);
            // 
            // lklDespesa
            // 
            this.lklDespesa.AutoSize = true;
            this.lklDespesa.Location = new System.Drawing.Point(6, 22);
            this.lklDespesa.Name = "lklDespesa";
            this.lklDespesa.Size = new System.Drawing.Size(52, 13);
            this.lklDespesa.TabIndex = 20;
            this.lklDespesa.TabStop = true;
            this.lklDespesa.Text = "Despesa:";
            this.lklDespesa.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklDespesa_LinkClicked);
            // 
            // dtpMovimento
            // 
            this.dtpMovimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpMovimento.Location = new System.Drawing.Point(270, 32);
            this.dtpMovimento.Name = "dtpMovimento";
            this.dtpMovimento.Size = new System.Drawing.Size(96, 20);
            this.dtpMovimento.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 53;
            this.label1.Text = "Movimento";
            // 
            // grbInformacoes
            // 
            this.grbInformacoes.Controls.Add(this.mtbValor);
            this.grbInformacoes.Controls.Add(this.txtCheque);
            this.grbInformacoes.Controls.Add(this.label7);
            this.grbInformacoes.Controls.Add(this.txtCartao);
            this.grbInformacoes.Controls.Add(this.label8);
            this.grbInformacoes.Controls.Add(this.txtDinheiro);
            this.grbInformacoes.Controls.Add(this.label9);
            this.grbInformacoes.Controls.Add(this.label4);
            this.grbInformacoes.Controls.Add(this.label1);
            this.grbInformacoes.Controls.Add(this.label2);
            this.grbInformacoes.Controls.Add(this.label10);
            this.grbInformacoes.Controls.Add(this.nudParc);
            this.grbInformacoes.Controls.Add(this.dtpMovimento);
            this.grbInformacoes.Controls.Add(this.dtpVencimento);
            this.grbInformacoes.Location = new System.Drawing.Point(12, 122);
            this.grbInformacoes.Name = "grbInformacoes";
            this.grbInformacoes.Size = new System.Drawing.Size(500, 112);
            this.grbInformacoes.TabIndex = 52;
            this.grbInformacoes.TabStop = false;
            // 
            // mtbValor
            // 
            this.mtbValor.Location = new System.Drawing.Point(15, 31);
            this.mtbValor.Name = "mtbValor";
            this.mtbValor.Size = new System.Drawing.Size(97, 20);
            this.mtbValor.TabIndex = 65;
            this.mtbValor.TextChanged += new System.EventHandler(this.mtbValor_TextChanged);
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(348, 81);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(140, 20);
            this.txtCheque.TabIndex = 64;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(396, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Cheque:";
            // 
            // txtCartao
            // 
            this.txtCartao.Location = new System.Drawing.Point(182, 81);
            this.txtCartao.Name = "txtCartao";
            this.txtCartao.Size = new System.Drawing.Size(140, 20);
            this.txtCartao.TabIndex = 62;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 61;
            this.label8.Text = "Cartão:";
            // 
            // txtDinheiro
            // 
            this.txtDinheiro.Location = new System.Drawing.Point(13, 81);
            this.txtDinheiro.Name = "txtDinheiro";
            this.txtDinheiro.Size = new System.Drawing.Size(140, 20);
            this.txtDinheiro.TabIndex = 60;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(54, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 59;
            this.label9.Text = "Dinheiro:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 57;
            this.label4.Text = "Valor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Vencimento";
            // 
            // dtpVencimento
            // 
            this.dtpVencimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpVencimento.Location = new System.Drawing.Point(389, 32);
            this.dtpVencimento.Name = "dtpVencimento";
            this.dtpVencimento.Size = new System.Drawing.Size(96, 20);
            this.dtpVencimento.TabIndex = 50;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblTotal.Location = new System.Drawing.Point(67, 246);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(74, 24);
            this.lblTotal.TabIndex = 54;
            this.lblTotal.Text = "R$0,00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Total:";
            // 
            // frmLancamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 285);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grbInformacoes);
            this.Controls.Add(this.grbDespesa);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.btnFechar);
            this.Name = "frmLancamentos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lancamentos";
            this.Activated += new System.EventHandler(this.frmLancamentos_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmLancamentos_FormClosed);
            this.Load += new System.EventHandler(this.frmLancamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudParc)).EndInit();
            this.grbDespesa.ResumeLayout(false);
            this.grbDespesa.PerformLayout();
            this.grbInformacoes.ResumeLayout(false);
            this.grbInformacoes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nudParc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox grbDespesa;
        private System.Windows.Forms.LinkLabel lklFornecedor;
        private System.Windows.Forms.LinkLabel lklDespesa;
        private System.Windows.Forms.ComboBox cboDespesa;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpMovimento;
        private System.Windows.Forms.GroupBox grbInformacoes;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpVencimento;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCartao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDinheiro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox mtbValor;
    }
}