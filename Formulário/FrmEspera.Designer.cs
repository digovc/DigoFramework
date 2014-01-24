namespace DigoFramework.Formulário
{
    partial class FrmEspera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEspera));
            this.pnlBarraProgresso = new System.Windows.Forms.Panel();
            this.progressBarTarefa = new System.Windows.Forms.ProgressBar();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pnlMensgem = new System.Windows.Forms.Panel();
            this.pnlMensagemDescricao = new System.Windows.Forms.Panel();
            this.lblTarefaDescricao = new System.Windows.Forms.Label();
            this.pnlMensgemTitulo = new System.Windows.Forms.Panel();
            this.lblTarefaTitulo = new System.Windows.Forms.Label();
            this.pnlEspaco001 = new System.Windows.Forms.Panel();
            this.pnlBarraProgresso.SuspendLayout();
            this.pnlImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.pnlMensgem.SuspendLayout();
            this.pnlMensagemDescricao.SuspendLayout();
            this.pnlMensgemTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBarraProgresso
            // 
            this.pnlBarraProgresso.Controls.Add(this.progressBar);
            this.pnlBarraProgresso.Controls.Add(this.pnlEspaco001);
            this.pnlBarraProgresso.Controls.Add(this.progressBarTarefa);
            this.pnlBarraProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBarraProgresso.Location = new System.Drawing.Point(0, 132);
            this.pnlBarraProgresso.Name = "pnlBarraProgresso";
            this.pnlBarraProgresso.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBarraProgresso.Size = new System.Drawing.Size(434, 60);
            this.pnlBarraProgresso.TabIndex = 0;
            // 
            // progressBarTarefa
            // 
            this.progressBarTarefa.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBarTarefa.Location = new System.Drawing.Point(10, 10);
            this.progressBarTarefa.Name = "progressBarTarefa";
            this.progressBarTarefa.Size = new System.Drawing.Size(414, 10);
            this.progressBarTarefa.TabIndex = 1;
            this.progressBarTarefa.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(10, 30);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(414, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 0;
            // 
            // pnlImagem
            // 
            this.pnlImagem.Controls.Add(this.pictureBox);
            this.pnlImagem.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImagem.Location = new System.Drawing.Point(0, 0);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlImagem.Size = new System.Drawing.Size(150, 132);
            this.pnlImagem.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(30, 20);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(90, 92);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // pnlMensgem
            // 
            this.pnlMensgem.Controls.Add(this.pnlMensagemDescricao);
            this.pnlMensgem.Controls.Add(this.pnlMensgemTitulo);
            this.pnlMensgem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMensgem.Location = new System.Drawing.Point(150, 0);
            this.pnlMensgem.Name = "pnlMensgem";
            this.pnlMensgem.Size = new System.Drawing.Size(284, 132);
            this.pnlMensgem.TabIndex = 2;
            // 
            // pnlMensagemDescricao
            // 
            this.pnlMensagemDescricao.Controls.Add(this.lblTarefaDescricao);
            this.pnlMensagemDescricao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMensagemDescricao.Location = new System.Drawing.Point(0, 54);
            this.pnlMensagemDescricao.Name = "pnlMensagemDescricao";
            this.pnlMensagemDescricao.Size = new System.Drawing.Size(284, 78);
            this.pnlMensagemDescricao.TabIndex = 1;
            // 
            // lblTarefaDescricao
            // 
            this.lblTarefaDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTarefaDescricao.Location = new System.Drawing.Point(0, 0);
            this.lblTarefaDescricao.Name = "lblTarefaDescricao";
            this.lblTarefaDescricao.Size = new System.Drawing.Size(284, 78);
            this.lblTarefaDescricao.TabIndex = 1;
            this.lblTarefaDescricao.Text = "Rotina do sistema sendo executada.";
            this.lblTarefaDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMensgemTitulo
            // 
            this.pnlMensgemTitulo.Controls.Add(this.lblTarefaTitulo);
            this.pnlMensgemTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMensgemTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlMensgemTitulo.Name = "pnlMensgemTitulo";
            this.pnlMensgemTitulo.Size = new System.Drawing.Size(284, 50);
            this.pnlMensgemTitulo.TabIndex = 0;
            // 
            // lblTarefaTitulo
            // 
            this.lblTarefaTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTarefaTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTarefaTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTarefaTitulo.Name = "lblTarefaTitulo";
            this.lblTarefaTitulo.Size = new System.Drawing.Size(284, 50);
            this.lblTarefaTitulo.TabIndex = 0;
            this.lblTarefaTitulo.Text = "Por favor, aguarde...";
            this.lblTarefaTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEspaco001.Location = new System.Drawing.Point(10, 20);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Size = new System.Drawing.Size(414, 10);
            this.pnlEspaco001.TabIndex = 3;
            // 
            // FrmEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 192);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMensgem);
            this.Controls.Add(this.pnlImagem);
            this.Controls.Add(this.pnlBarraProgresso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEspera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processando...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEspera_FormClosing);
            this.pnlBarraProgresso.ResumeLayout(false);
            this.pnlImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.pnlMensgem.ResumeLayout(false);
            this.pnlMensagemDescricao.ResumeLayout(false);
            this.pnlMensgemTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBarraProgresso;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel pnlImagem;
        private System.Windows.Forms.Panel pnlMensgem;
        private System.Windows.Forms.Panel pnlMensagemDescricao;
        private System.Windows.Forms.Panel pnlMensgemTitulo;
        private System.Windows.Forms.Label lblTarefaDescricao;
        private System.Windows.Forms.Label lblTarefaTitulo;
        private System.Windows.Forms.PictureBox pictureBox;
        public System.Windows.Forms.ProgressBar progressBarTarefa;
        private System.Windows.Forms.Panel pnlEspaco001;
    }
}