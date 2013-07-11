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
            this.objPnlBarraProgresso = new System.Windows.Forms.Panel();
            this.objProgressBar = new System.Windows.Forms.ProgressBar();
            this.objPnlImagem = new System.Windows.Forms.Panel();
            this.objPictureBox = new System.Windows.Forms.PictureBox();
            this.objPnlMensgem = new System.Windows.Forms.Panel();
            this.objPnlMensagemDescricao = new System.Windows.Forms.Panel();
            this.objLblMensagemDescricao = new System.Windows.Forms.Label();
            this.objPnlMensgemTitulo = new System.Windows.Forms.Panel();
            this.objLblMensagemTitulo = new System.Windows.Forms.Label();
            this.objPnlBarraProgresso.SuspendLayout();
            this.objPnlImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objPictureBox)).BeginInit();
            this.objPnlMensgem.SuspendLayout();
            this.objPnlMensagemDescricao.SuspendLayout();
            this.objPnlMensgemTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // objPnlBarraProgresso
            // 
            this.objPnlBarraProgresso.Controls.Add(this.objProgressBar);
            this.objPnlBarraProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.objPnlBarraProgresso.Location = new System.Drawing.Point(0, 131);
            this.objPnlBarraProgresso.Name = "objPnlBarraProgresso";
            this.objPnlBarraProgresso.Padding = new System.Windows.Forms.Padding(15, 18, 15, 18);
            this.objPnlBarraProgresso.Size = new System.Drawing.Size(434, 50);
            this.objPnlBarraProgresso.TabIndex = 0;
            // 
            // objProgressBar
            // 
            this.objProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objProgressBar.Location = new System.Drawing.Point(15, 18);
            this.objProgressBar.Name = "objProgressBar";
            this.objProgressBar.Size = new System.Drawing.Size(404, 14);
            this.objProgressBar.TabIndex = 0;
            this.objProgressBar.Visible = false;
            // 
            // objPnlImagem
            // 
            this.objPnlImagem.Controls.Add(this.objPictureBox);
            this.objPnlImagem.Dock = System.Windows.Forms.DockStyle.Left;
            this.objPnlImagem.Location = new System.Drawing.Point(0, 0);
            this.objPnlImagem.Name = "objPnlImagem";
            this.objPnlImagem.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.objPnlImagem.Size = new System.Drawing.Size(150, 131);
            this.objPnlImagem.TabIndex = 1;
            // 
            // objPictureBox
            // 
            this.objPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.objPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("objPictureBox.Image")));
            this.objPictureBox.InitialImage = null;
            this.objPictureBox.Location = new System.Drawing.Point(30, 20);
            this.objPictureBox.Name = "objPictureBox";
            this.objPictureBox.Size = new System.Drawing.Size(90, 91);
            this.objPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.objPictureBox.TabIndex = 0;
            this.objPictureBox.TabStop = false;
            // 
            // objPnlMensgem
            // 
            this.objPnlMensgem.Controls.Add(this.objPnlMensagemDescricao);
            this.objPnlMensgem.Controls.Add(this.objPnlMensgemTitulo);
            this.objPnlMensgem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objPnlMensgem.Location = new System.Drawing.Point(150, 0);
            this.objPnlMensgem.Name = "objPnlMensgem";
            this.objPnlMensgem.Size = new System.Drawing.Size(284, 131);
            this.objPnlMensgem.TabIndex = 2;
            // 
            // objPnlMensagemDescricao
            // 
            this.objPnlMensagemDescricao.Controls.Add(this.objLblMensagemDescricao);
            this.objPnlMensagemDescricao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.objPnlMensagemDescricao.Location = new System.Drawing.Point(0, 53);
            this.objPnlMensagemDescricao.Name = "objPnlMensagemDescricao";
            this.objPnlMensagemDescricao.Size = new System.Drawing.Size(284, 78);
            this.objPnlMensagemDescricao.TabIndex = 1;
            // 
            // objLblMensagemDescricao
            // 
            this.objLblMensagemDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objLblMensagemDescricao.Location = new System.Drawing.Point(0, 0);
            this.objLblMensagemDescricao.Name = "objLblMensagemDescricao";
            this.objLblMensagemDescricao.Size = new System.Drawing.Size(284, 78);
            this.objLblMensagemDescricao.TabIndex = 1;
            this.objLblMensagemDescricao.Text = "Rotina do sistema sendo executada.";
            this.objLblMensagemDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // objPnlMensgemTitulo
            // 
            this.objPnlMensgemTitulo.Controls.Add(this.objLblMensagemTitulo);
            this.objPnlMensgemTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.objPnlMensgemTitulo.Location = new System.Drawing.Point(0, 0);
            this.objPnlMensgemTitulo.Name = "objPnlMensgemTitulo";
            this.objPnlMensgemTitulo.Size = new System.Drawing.Size(284, 50);
            this.objPnlMensgemTitulo.TabIndex = 0;
            // 
            // objLblMensagemTitulo
            // 
            this.objLblMensagemTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objLblMensagemTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.objLblMensagemTitulo.Location = new System.Drawing.Point(0, 0);
            this.objLblMensagemTitulo.Name = "objLblMensagemTitulo";
            this.objLblMensagemTitulo.Size = new System.Drawing.Size(284, 50);
            this.objLblMensagemTitulo.TabIndex = 0;
            this.objLblMensagemTitulo.Text = "Por favor, aguarde...";
            this.objLblMensagemTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FrmEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 181);
            this.ControlBox = false;
            this.Controls.Add(this.objPnlMensgem);
            this.Controls.Add(this.objPnlImagem);
            this.Controls.Add(this.objPnlBarraProgresso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEspera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processando...";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEspera_FormClosing);
            this.objPnlBarraProgresso.ResumeLayout(false);
            this.objPnlImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objPictureBox)).EndInit();
            this.objPnlMensgem.ResumeLayout(false);
            this.objPnlMensagemDescricao.ResumeLayout(false);
            this.objPnlMensgemTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel objPnlBarraProgresso;
        private System.Windows.Forms.ProgressBar objProgressBar;
        private System.Windows.Forms.Panel objPnlImagem;
        private System.Windows.Forms.Panel objPnlMensgem;
        private System.Windows.Forms.Panel objPnlMensagemDescricao;
        private System.Windows.Forms.Panel objPnlMensgemTitulo;
        private System.Windows.Forms.Label objLblMensagemDescricao;
        private System.Windows.Forms.Label objLblMensagemTitulo;
        private System.Windows.Forms.PictureBox objPictureBox;
    }
}