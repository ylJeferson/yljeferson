namespace Jeferson_e_Samuel
{
    partial class frmBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBackup));
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestauracao = new System.Windows.Forms.Button();
            this.ofdRestauracao = new System.Windows.Forms.OpenFileDialog();
            this.sfdBackup = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // btnBackup
            // 
            this.btnBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnBackup.Image")));
            this.btnBackup.Location = new System.Drawing.Point(12, 12);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(91, 76);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Backup";
            this.btnBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestauracao
            // 
            this.btnRestauracao.Image = ((System.Drawing.Image)(resources.GetObject("btnRestauracao.Image")));
            this.btnRestauracao.Location = new System.Drawing.Point(109, 12);
            this.btnRestauracao.Name = "btnRestauracao";
            this.btnRestauracao.Size = new System.Drawing.Size(91, 76);
            this.btnRestauracao.TabIndex = 1;
            this.btnRestauracao.Text = "Restauração";
            this.btnRestauracao.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnRestauracao.UseVisualStyleBackColor = true;
            this.btnRestauracao.Click += new System.EventHandler(this.btnRestauracao_Click);
            // 
            // ofdRestauracao
            // 
            this.ofdRestauracao.FileName = "openFileDialog1";
            // 
            // frmBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 96);
            this.Controls.Add(this.btnRestauracao);
            this.Controls.Add(this.btnBackup);
            this.Name = "frmBackup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestauracao;
        private System.Windows.Forms.OpenFileDialog ofdRestauracao;
        private System.Windows.Forms.SaveFileDialog sfdBackup;
    }
}