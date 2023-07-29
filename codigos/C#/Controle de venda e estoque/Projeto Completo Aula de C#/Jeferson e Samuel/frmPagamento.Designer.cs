namespace Jeferson_e_Samuel
{
    partial class frmPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagamento));
            this.btnDesmarca = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimeiro = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSelecao = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheque = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCartao = new System.Windows.Forms.TextBox();
            this.dgvTitulos = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDinheiro = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDesmarcar = new System.Windows.Forms.Button();
            this.btnMarcar = new System.Windows.Forms.Button();
            this.btnCarregar = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGravar = new System.Windows.Forms.Button();
            this.grbCaixa = new System.Windows.Forms.GroupBox();
            this.grbClientes = new System.Windows.Forms.GroupBox();
            this.cboFornecedor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulos)).BeginInit();
            this.grbCaixa.SuspendLayout();
            this.grbClientes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDesmarca
            // 
            this.btnDesmarca.Location = new System.Drawing.Point(203, 94);
            this.btnDesmarca.Name = "btnDesmarca";
            this.btnDesmarca.Size = new System.Drawing.Size(84, 23);
            this.btnDesmarca.TabIndex = 44;
            this.btnDesmarca.Text = "Desmarca";
            this.btnDesmarca.UseVisualStyleBackColor = true;
            this.btnDesmarca.Click += new System.EventHandler(this.btnDesmarca_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.Location = new System.Drawing.Point(128, 94);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(69, 23);
            this.btnMarca.TabIndex = 43;
            this.btnMarca.Text = "Marca";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // btnUltimo
            // 
            this.btnUltimo.Image = ((System.Drawing.Image)(resources.GetObject("btnUltimo.Image")));
            this.btnUltimo.Location = new System.Drawing.Point(99, 94);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(23, 23);
            this.btnUltimo.TabIndex = 33;
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Image = ((System.Drawing.Image)(resources.GetObject("btnProximo.Image")));
            this.btnProximo.Location = new System.Drawing.Point(70, 94);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(23, 23);
            this.btnProximo.TabIndex = 32;
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.Location = new System.Drawing.Point(41, 94);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(23, 23);
            this.btnAnterior.TabIndex = 31;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.Image = ((System.Drawing.Image)(resources.GetObject("btnPrimeiro.Image")));
            this.btnPrimeiro.Location = new System.Drawing.Point(12, 94);
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(23, 23);
            this.btnPrimeiro.TabIndex = 30;
            this.btnPrimeiro.UseVisualStyleBackColor = true;
            this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(424, 358);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 42;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(343, 358);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 41;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSelecao
            // 
            this.lblSelecao.AutoSize = true;
            this.lblSelecao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelecao.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblSelecao.Location = new System.Drawing.Point(95, 357);
            this.lblSelecao.Name = "lblSelecao";
            this.lblSelecao.Size = new System.Drawing.Size(74, 24);
            this.lblSelecao.TabIndex = 39;
            this.lblSelecao.Text = "R$0,00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 38;
            this.label6.Text = "Selecionados:";
            // 
            // txtCheque
            // 
            this.txtCheque.Location = new System.Drawing.Point(341, 39);
            this.txtCheque.Name = "txtCheque";
            this.txtCheque.Size = new System.Drawing.Size(140, 20);
            this.txtCheque.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Cheque:";
            // 
            // txtCartao
            // 
            this.txtCartao.Location = new System.Drawing.Point(173, 39);
            this.txtCartao.Name = "txtCartao";
            this.txtCartao.Size = new System.Drawing.Size(140, 20);
            this.txtCartao.TabIndex = 19;
            // 
            // dgvTitulos
            // 
            this.dgvTitulos.AllowUserToAddRows = false;
            this.dgvTitulos.AllowUserToDeleteRows = false;
            this.dgvTitulos.AllowUserToResizeColumns = false;
            this.dgvTitulos.AllowUserToResizeRows = false;
            this.dgvTitulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitulos.Location = new System.Drawing.Point(12, 123);
            this.dgvTitulos.Name = "dgvTitulos";
            this.dgvTitulos.Size = new System.Drawing.Size(487, 150);
            this.dgvTitulos.TabIndex = 36;
            this.dgvTitulos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTitulos_CellContentClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Cartão:";
            // 
            // txtDinheiro
            // 
            this.txtDinheiro.Location = new System.Drawing.Point(6, 39);
            this.txtDinheiro.Name = "txtDinheiro";
            this.txtDinheiro.Size = new System.Drawing.Size(140, 20);
            this.txtDinheiro.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Dinheiro:";
            // 
            // btnDesmarcar
            // 
            this.btnDesmarcar.Location = new System.Drawing.Point(399, 94);
            this.btnDesmarcar.Name = "btnDesmarcar";
            this.btnDesmarcar.Size = new System.Drawing.Size(100, 23);
            this.btnDesmarcar.TabIndex = 35;
            this.btnDesmarcar.Text = "Desmarcar todos";
            this.btnDesmarcar.UseVisualStyleBackColor = true;
            this.btnDesmarcar.Click += new System.EventHandler(this.btnDesmarcar_Click);
            // 
            // btnMarcar
            // 
            this.btnMarcar.Location = new System.Drawing.Point(293, 94);
            this.btnMarcar.Name = "btnMarcar";
            this.btnMarcar.Size = new System.Drawing.Size(100, 23);
            this.btnMarcar.TabIndex = 34;
            this.btnMarcar.Text = "Marcar todos";
            this.btnMarcar.UseVisualStyleBackColor = true;
            this.btnMarcar.Click += new System.EventHandler(this.btnMarcar_Click);
            // 
            // btnCarregar
            // 
            this.btnCarregar.Location = new System.Drawing.Point(399, 43);
            this.btnCarregar.Name = "btnCarregar";
            this.btnCarregar.Size = new System.Drawing.Size(75, 23);
            this.btnCarregar.TabIndex = 5;
            this.btnCarregar.Text = "Carregar";
            this.btnCarregar.UseVisualStyleBackColor = true;
            this.btnCarregar.Click += new System.EventHandler(this.btnCarregar_Click);
            // 
            // txtData
            // 
            this.txtData.Enabled = false;
            this.txtData.Location = new System.Drawing.Point(76, 46);
            this.txtData.Name = "txtData";
            this.txtData.ReadOnly = true;
            this.txtData.Size = new System.Drawing.Size(106, 20);
            this.txtData.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data:";
            // 
            // btnGravar
            // 
            this.btnGravar.Location = new System.Drawing.Point(262, 358);
            this.btnGravar.Name = "btnGravar";
            this.btnGravar.Size = new System.Drawing.Size(75, 23);
            this.btnGravar.TabIndex = 40;
            this.btnGravar.Text = "Gravar";
            this.btnGravar.UseVisualStyleBackColor = true;
            this.btnGravar.Click += new System.EventHandler(this.btnGravar_Click);
            // 
            // grbCaixa
            // 
            this.grbCaixa.Controls.Add(this.txtCheque);
            this.grbCaixa.Controls.Add(this.label5);
            this.grbCaixa.Controls.Add(this.txtCartao);
            this.grbCaixa.Controls.Add(this.label4);
            this.grbCaixa.Controls.Add(this.txtDinheiro);
            this.grbCaixa.Controls.Add(this.label3);
            this.grbCaixa.Location = new System.Drawing.Point(12, 279);
            this.grbCaixa.Name = "grbCaixa";
            this.grbCaixa.Size = new System.Drawing.Size(487, 73);
            this.grbCaixa.TabIndex = 37;
            this.grbCaixa.TabStop = false;
            this.grbCaixa.Text = "Caixa";
            // 
            // grbClientes
            // 
            this.grbClientes.Controls.Add(this.cboFornecedor);
            this.grbClientes.Controls.Add(this.label7);
            this.grbClientes.Controls.Add(this.btnCarregar);
            this.grbClientes.Controls.Add(this.txtData);
            this.grbClientes.Controls.Add(this.label2);
            this.grbClientes.Location = new System.Drawing.Point(12, 12);
            this.grbClientes.Name = "grbClientes";
            this.grbClientes.Size = new System.Drawing.Size(487, 76);
            this.grbClientes.TabIndex = 29;
            this.grbClientes.TabStop = false;
            // 
            // cboFornecedor
            // 
            this.cboFornecedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFornecedor.FormattingEnabled = true;
            this.cboFornecedor.Location = new System.Drawing.Point(76, 19);
            this.cboFornecedor.Name = "cboFornecedor";
            this.cboFornecedor.Size = new System.Drawing.Size(398, 21);
            this.cboFornecedor.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fornecedor:";
            // 
            // frmPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 389);
            this.Controls.Add(this.btnDesmarca);
            this.Controls.Add(this.btnMarca);
            this.Controls.Add(this.btnUltimo);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.btnPrimeiro);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblSelecao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvTitulos);
            this.Controls.Add(this.btnDesmarcar);
            this.Controls.Add(this.btnMarcar);
            this.Controls.Add(this.btnGravar);
            this.Controls.Add(this.grbCaixa);
            this.Controls.Add(this.grbClientes);
            this.Name = "frmPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento de Dividas";
            this.Activated += new System.EventHandler(this.frmLancamentos_Activated);
            this.Load += new System.EventHandler(this.frmCaixa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitulos)).EndInit();
            this.grbCaixa.ResumeLayout(false);
            this.grbCaixa.PerformLayout();
            this.grbClientes.ResumeLayout(false);
            this.grbClientes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDesmarca;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimeiro;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSelecao;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCheque;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCartao;
        private System.Windows.Forms.DataGridView dgvTitulos;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDinheiro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDesmarcar;
        private System.Windows.Forms.Button btnMarcar;
        private System.Windows.Forms.Button btnCarregar;
        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGravar;
        private System.Windows.Forms.GroupBox grbCaixa;
        private System.Windows.Forms.GroupBox grbClientes;
        private System.Windows.Forms.ComboBox cboFornecedor;
        private System.Windows.Forms.Label label7;
    }
}