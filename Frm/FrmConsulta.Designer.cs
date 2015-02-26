namespace DigoFramework.Frm
{
    partial class FrmConsulta
    {
        public System.Windows.Forms.DataGridView dgvPrincipal;

        private System.Windows.Forms.Button btnCancelar;

        private System.Windows.Forms.Button btnEditar;

        private System.Windows.Forms.Button btnNovo;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlComandos;

        private System.Windows.Forms.Panel pnlDados;

        private System.Windows.Forms.Panel pnlEspaco001;

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
        /// Required method for Designer support - do not modify the contents of this method with
        /// the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlDados = new System.Windows.Forms.Panel();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.pnlComandos = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pnlEspaco001 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlPesquisa = new System.Windows.Forms.Panel();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.pnlDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.pnlComandos.SuspendLayout();
            this.pnlPesquisa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.dgvPrincipal);
            this.pnlDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDados.Location = new System.Drawing.Point(0, 50);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Padding = new System.Windows.Forms.Padding(5);
            this.pnlDados.Size = new System.Drawing.Size(584, 361);
            this.pnlDados.TabIndex = 0;
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.AllowUserToAddRows = false;
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrincipal.Location = new System.Drawing.Point(5, 5);
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.ReadOnly = true;
            this.dgvPrincipal.RowHeadersVisible = false;
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(574, 351);
            this.dgvPrincipal.TabIndex = 0;
            // 
            // pnlComandos
            // 
            this.pnlComandos.Controls.Add(this.btnNovo);
            this.pnlComandos.Controls.Add(this.btnEditar);
            this.pnlComandos.Controls.Add(this.pnlEspaco001);
            this.pnlComandos.Controls.Add(this.btnCancelar);
            this.pnlComandos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComandos.Location = new System.Drawing.Point(0, 411);
            this.pnlComandos.Name = "pnlComandos";
            this.pnlComandos.Padding = new System.Windows.Forms.Padding(5);
            this.pnlComandos.Size = new System.Drawing.Size(584, 50);
            this.pnlComandos.TabIndex = 1;
            // 
            // btnNovo
            // 
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNovo.Location = new System.Drawing.Point(274, 5);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 40);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo (Ctrl + N)";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditar.Location = new System.Drawing.Point(374, 5);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 40);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar (Ctrl + E)";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEspaco001.Location = new System.Drawing.Point(474, 5);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Size = new System.Drawing.Size(5, 40);
            this.pnlEspaco001.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Location = new System.Drawing.Point(479, 5);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 40);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar (Esc)";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlPesquisa
            // 
            this.pnlPesquisa.Controls.Add(this.txtPesquisa);
            this.pnlPesquisa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPesquisa.Location = new System.Drawing.Point(0, 0);
            this.pnlPesquisa.Name = "pnlPesquisa";
            this.pnlPesquisa.Padding = new System.Windows.Forms.Padding(100, 15, 100, 5);
            this.pnlPesquisa.Size = new System.Drawing.Size(584, 50);
            this.pnlPesquisa.TabIndex = 1;
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPesquisa.Location = new System.Drawing.Point(100, 15);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(384, 21);
            this.txtPesquisa.TabIndex = 0;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.txtPesquisa_TextChanged);
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.pnlPesquisa);
            this.Controls.Add(this.pnlComandos);
            this.Name = "FrmConsulta";
            this.Shown += new System.EventHandler(this.FrmConsulta_Shown);
            this.pnlDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.pnlComandos.ResumeLayout(false);
            this.pnlPesquisa.ResumeLayout(false);
            this.pnlPesquisa.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code

        private System.Windows.Forms.Panel pnlPesquisa;
        private System.Windows.Forms.TextBox txtPesquisa;
    }
}