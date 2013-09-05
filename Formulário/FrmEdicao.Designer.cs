namespace DigoFramework.Formulário
{
    partial class FrmEdicao
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
            this.pnlCampo = new System.Windows.Forms.Panel();
            this.pnlCampoConteudo = new System.Windows.Forms.Panel();
            this.pnlCampoAjuda = new System.Windows.Forms.Panel();
            this.chbObrigatorio = new System.Windows.Forms.CheckBox();
            this.lblCampoDescricao = new System.Windows.Forms.Label();
            this.pnlCampoDados = new System.Windows.Forms.Panel();
            this.pnlCampoTitulo = new System.Windows.Forms.Panel();
            this.lblCampoTitulo = new System.Windows.Forms.Label();
            this.pnlDireita = new System.Windows.Forms.Panel();
            this.btnDireita = new System.Windows.Forms.Button();
            this.pnlEsquerda = new System.Windows.Forms.Panel();
            this.btnEsquerda = new System.Windows.Forms.Button();
            this.pnlComandos = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.pnlEspaco001 = new System.Windows.Forms.Panel();
            this.pnlCampo.SuspendLayout();
            this.pnlCampoConteudo.SuspendLayout();
            this.pnlCampoAjuda.SuspendLayout();
            this.pnlCampoTitulo.SuspendLayout();
            this.pnlDireita.SuspendLayout();
            this.pnlEsquerda.SuspendLayout();
            this.pnlComandos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCampo
            // 
            this.pnlCampo.Controls.Add(this.pnlCampoConteudo);
            this.pnlCampo.Controls.Add(this.pnlDireita);
            this.pnlCampo.Controls.Add(this.pnlEsquerda);
            this.pnlCampo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampo.Location = new System.Drawing.Point(0, 0);
            this.pnlCampo.Name = "pnlCampo";
            this.pnlCampo.Size = new System.Drawing.Size(584, 421);
            this.pnlCampo.TabIndex = 2;
            // 
            // pnlCampoConteudo
            // 
            this.pnlCampoConteudo.Controls.Add(this.pnlCampoAjuda);
            this.pnlCampoConteudo.Controls.Add(this.pnlCampoDados);
            this.pnlCampoConteudo.Controls.Add(this.pnlCampoTitulo);
            this.pnlCampoConteudo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampoConteudo.Location = new System.Drawing.Point(36, 0);
            this.pnlCampoConteudo.Name = "pnlCampoConteudo";
            this.pnlCampoConteudo.Size = new System.Drawing.Size(512, 421);
            this.pnlCampoConteudo.TabIndex = 0;
            // 
            // pnlCampoAjuda
            // 
            this.pnlCampoAjuda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCampoAjuda.Controls.Add(this.chbObrigatorio);
            this.pnlCampoAjuda.Controls.Add(this.lblCampoDescricao);
            this.pnlCampoAjuda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCampoAjuda.Location = new System.Drawing.Point(0, 340);
            this.pnlCampoAjuda.Name = "pnlCampoAjuda";
            this.pnlCampoAjuda.Size = new System.Drawing.Size(512, 81);
            this.pnlCampoAjuda.TabIndex = 5;
            // 
            // chbObrigatorio
            // 
            this.chbObrigatorio.AutoSize = true;
            this.chbObrigatorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chbObrigatorio.Enabled = false;
            this.chbObrigatorio.Location = new System.Drawing.Point(0, 50);
            this.chbObrigatorio.Name = "chbObrigatorio";
            this.chbObrigatorio.Padding = new System.Windows.Forms.Padding(5);
            this.chbObrigatorio.Size = new System.Drawing.Size(510, 29);
            this.chbObrigatorio.TabIndex = 2;
            this.chbObrigatorio.Text = "Campo obrigatório";
            this.chbObrigatorio.UseVisualStyleBackColor = true;
            // 
            // lblCampoDescricao
            // 
            this.lblCampoDescricao.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCampoDescricao.Location = new System.Drawing.Point(0, 0);
            this.lblCampoDescricao.Name = "lblCampoDescricao";
            this.lblCampoDescricao.Padding = new System.Windows.Forms.Padding(5);
            this.lblCampoDescricao.Size = new System.Drawing.Size(510, 50);
            this.lblCampoDescricao.TabIndex = 1;
            this.lblCampoDescricao.Text = "Descrição do campo";
            // 
            // pnlCampoDados
            // 
            this.pnlCampoDados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCampoDados.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCampoDados.Location = new System.Drawing.Point(0, 40);
            this.pnlCampoDados.Name = "pnlCampoDados";
            this.pnlCampoDados.Size = new System.Drawing.Size(512, 300);
            this.pnlCampoDados.TabIndex = 4;
            // 
            // pnlCampoTitulo
            // 
            this.pnlCampoTitulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCampoTitulo.Controls.Add(this.lblCampoTitulo);
            this.pnlCampoTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCampoTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlCampoTitulo.Name = "pnlCampoTitulo";
            this.pnlCampoTitulo.Size = new System.Drawing.Size(512, 40);
            this.pnlCampoTitulo.TabIndex = 3;
            // 
            // lblCampoTitulo
            // 
            this.lblCampoTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCampoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCampoTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblCampoTitulo.Name = "lblCampoTitulo";
            this.lblCampoTitulo.Size = new System.Drawing.Size(510, 38);
            this.lblCampoTitulo.TabIndex = 0;
            this.lblCampoTitulo.Text = "Título do campo";
            this.lblCampoTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDireita
            // 
            this.pnlDireita.Controls.Add(this.btnDireita);
            this.pnlDireita.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDireita.Location = new System.Drawing.Point(548, 0);
            this.pnlDireita.Name = "pnlDireita";
            this.pnlDireita.Size = new System.Drawing.Size(36, 421);
            this.pnlDireita.TabIndex = 6;
            // 
            // btnDireita
            // 
            this.btnDireita.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDireita.Location = new System.Drawing.Point(0, 0);
            this.btnDireita.Name = "btnDireita";
            this.btnDireita.Size = new System.Drawing.Size(36, 421);
            this.btnDireita.TabIndex = 1;
            this.btnDireita.Text = ">";
            this.btnDireita.UseVisualStyleBackColor = true;
            this.btnDireita.Click += new System.EventHandler(this.btnDireita_Click);
            // 
            // pnlEsquerda
            // 
            this.pnlEsquerda.Controls.Add(this.btnEsquerda);
            this.pnlEsquerda.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlEsquerda.Location = new System.Drawing.Point(0, 0);
            this.pnlEsquerda.Name = "pnlEsquerda";
            this.pnlEsquerda.Size = new System.Drawing.Size(36, 421);
            this.pnlEsquerda.TabIndex = 7;
            // 
            // btnEsquerda
            // 
            this.btnEsquerda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEsquerda.Location = new System.Drawing.Point(0, 0);
            this.btnEsquerda.Name = "btnEsquerda";
            this.btnEsquerda.Size = new System.Drawing.Size(36, 421);
            this.btnEsquerda.TabIndex = 0;
            this.btnEsquerda.Text = "<";
            this.btnEsquerda.UseVisualStyleBackColor = true;
            this.btnEsquerda.Visible = false;
            this.btnEsquerda.Click += new System.EventHandler(this.btnEsquerda_Click);
            // 
            // pnlComandos
            // 
            this.pnlComandos.Controls.Add(this.btnSalvar);
            this.pnlComandos.Controls.Add(this.pnlEspaco001);
            this.pnlComandos.Controls.Add(this.btnFechar);
            this.pnlComandos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlComandos.Location = new System.Drawing.Point(0, 421);
            this.pnlComandos.Name = "pnlComandos";
            this.pnlComandos.Padding = new System.Windows.Forms.Padding(5);
            this.pnlComandos.Size = new System.Drawing.Size(584, 40);
            this.pnlComandos.TabIndex = 6;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalvar.Location = new System.Drawing.Point(324, 5);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(125, 30);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFechar.Location = new System.Drawing.Point(454, 5);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(125, 30);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlEspaco001.Location = new System.Drawing.Point(449, 5);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Padding = new System.Windows.Forms.Padding(5);
            this.pnlEspaco001.Size = new System.Drawing.Size(5, 30);
            this.pnlEspaco001.TabIndex = 3;
            // 
            // FrmEdicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.pnlCampo);
            this.Controls.Add(this.pnlComandos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmEdicao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmEdicao";
            this.Shown += new System.EventHandler(this.FrmEdicao_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEdicao_KeyDown);
            this.pnlCampo.ResumeLayout(false);
            this.pnlCampoConteudo.ResumeLayout(false);
            this.pnlCampoAjuda.ResumeLayout(false);
            this.pnlCampoAjuda.PerformLayout();
            this.pnlCampoTitulo.ResumeLayout(false);
            this.pnlDireita.ResumeLayout(false);
            this.pnlEsquerda.ResumeLayout(false);
            this.pnlComandos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCampo;
        private System.Windows.Forms.Panel pnlComandos;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Panel pnlCampoDados;
        private System.Windows.Forms.Panel pnlCampoTitulo;
        private System.Windows.Forms.Panel pnlCampoAjuda;
        private System.Windows.Forms.Label lblCampoTitulo;
        private System.Windows.Forms.Label lblCampoDescricao;
        private System.Windows.Forms.CheckBox chbObrigatorio;
        private System.Windows.Forms.Panel pnlCampoConteudo;
        private System.Windows.Forms.Panel pnlDireita;
        private System.Windows.Forms.Button btnDireita;
        private System.Windows.Forms.Panel pnlEsquerda;
        private System.Windows.Forms.Button btnEsquerda;
        private System.Windows.Forms.Panel pnlEspaco001;
    }
}