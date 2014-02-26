namespace DigoFramework.form
{
    partial class FrmConsulta
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
            this.pnlDados = new System.Windows.Forms.Panel();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.pnlComandos = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.pnlEspaco001 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.pnlComandos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDados
            // 
            this.pnlDados.Controls.Add(this.dgvPrincipal);
            this.pnlDados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDados.Location = new System.Drawing.Point(0, 0);
            this.pnlDados.Name = "pnlDados";
            this.pnlDados.Padding = new System.Windows.Forms.Padding(10, 10, 10, 0);
            this.pnlDados.Size = new System.Drawing.Size(584, 414);
            this.pnlDados.TabIndex = 0;
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.AllowUserToAddRows = false;
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrincipal.Location = new System.Drawing.Point(10, 10);
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.ReadOnly = true;
            this.dgvPrincipal.RowHeadersVisible = false;
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(564, 404);
            this.dgvPrincipal.TabIndex = 0;
            // 
            // pnlComandos
            // 
            this.pnlComandos.Controls.Add(this.btnNovo);
            this.pnlComandos.Controls.Add(this.btnEditar);
            this.pnlComandos.Controls.Add(this.pnlEspaco001);
            this.pnlComandos.Controls.Add(this.btnCancelar);
            this.pnlComandos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComandos.Location = new System.Drawing.Point(0, 414);
            this.pnlComandos.Name = "pnlComandos";
            this.pnlComandos.Padding = new System.Windows.Forms.Padding(10);
            this.pnlComandos.Size = new System.Drawing.Size(584, 47);
            this.pnlComandos.TabIndex = 1;
            // 
            // btnNovo
            // 
            this.btnNovo.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNovo.Location = new System.Drawing.Point(264, 10);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(0);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(100, 27);
            this.btnNovo.TabIndex = 0;
            this.btnNovo.Text = "Novo (Ctrl + N)";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEditar.Location = new System.Drawing.Point(364, 10);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(0);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 27);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar (Ctrl + E)";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEspaco001.Location = new System.Drawing.Point(464, 10);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEspaco001.Size = new System.Drawing.Size(10, 27);
            this.pnlEspaco001.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCancelar.Location = new System.Drawing.Point(474, 10);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 27);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar (Esc)";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.pnlDados);
            this.Controls.Add(this.pnlComandos);
            this.Name = "FrmConsulta";
            this.Shown += new System.EventHandler(this.FrmConsulta_Shown);
            this.pnlDados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.pnlComandos.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlDados;
        private System.Windows.Forms.Panel pnlComandos;
        public System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Panel pnlEspaco001;
        private System.Windows.Forms.Button btnNovo;
    }
}