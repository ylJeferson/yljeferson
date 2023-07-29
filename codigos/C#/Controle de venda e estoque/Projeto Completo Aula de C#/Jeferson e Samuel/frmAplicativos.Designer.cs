namespace Jeferson_e_Samuel
{
    partial class frmAplicativos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAplicativos));
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.btnNavegador = new System.Windows.Forms.Button();
            this.btnWord = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCalc
            // 
            this.btnCalc.Image = ((System.Drawing.Image)(resources.GetObject("btnCalc.Image")));
            this.btnCalc.Location = new System.Drawing.Point(12, 12);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(88, 63);
            this.btnCalc.TabIndex = 0;
            this.btnCalc.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnNotepad
            // 
            this.btnNotepad.Image = ((System.Drawing.Image)(resources.GetObject("btnNotepad.Image")));
            this.btnNotepad.Location = new System.Drawing.Point(106, 12);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(88, 63);
            this.btnNotepad.TabIndex = 1;
            this.btnNotepad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNotepad.UseVisualStyleBackColor = true;
            this.btnNotepad.Click += new System.EventHandler(this.btnNotepad_Click);
            // 
            // btnNavegador
            // 
            this.btnNavegador.Image = ((System.Drawing.Image)(resources.GetObject("btnNavegador.Image")));
            this.btnNavegador.Location = new System.Drawing.Point(12, 81);
            this.btnNavegador.Name = "btnNavegador";
            this.btnNavegador.Size = new System.Drawing.Size(88, 63);
            this.btnNavegador.TabIndex = 2;
            this.btnNavegador.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNavegador.UseVisualStyleBackColor = true;
            this.btnNavegador.Click += new System.EventHandler(this.btnNavegador_Click);
            // 
            // btnWord
            // 
            this.btnWord.Image = ((System.Drawing.Image)(resources.GetObject("btnWord.Image")));
            this.btnWord.Location = new System.Drawing.Point(106, 81);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(88, 63);
            this.btnWord.TabIndex = 3;
            this.btnWord.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnWord.UseVisualStyleBackColor = true;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // frmAplicativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 155);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.btnNavegador);
            this.Controls.Add(this.btnNotepad);
            this.Controls.Add(this.btnCalc);
            this.Name = "frmAplicativos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aplicativos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAplicativos_FormClosed);
            this.Load += new System.EventHandler(this.frmAplicativos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnNotepad;
        private System.Windows.Forms.Button btnNavegador;
        private System.Windows.Forms.Button btnWord;
    }
}