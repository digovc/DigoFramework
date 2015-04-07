namespace DigoFramework.Frm
{
    partial class FrmEspera
    {
        public System.Windows.Forms.ProgressBar pgbParcial;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblDescricao;

        private System.Windows.Forms.Label lblTitulo;

        private System.Windows.Forms.PictureBox img;

        private System.Windows.Forms.Panel pnlProgresso;

        private System.Windows.Forms.Panel pnlEspaco001;

        private System.Windows.Forms.Panel pnlImagem;

        private System.Windows.Forms.Panel pnlMensgem;

        private System.Windows.Forms.ProgressBar pgbTotal;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEspera));
            this.pnlProgresso = new System.Windows.Forms.Panel();
            this.pgbTotal = new System.Windows.Forms.ProgressBar();
            this.pnlEspaco001 = new System.Windows.Forms.Panel();
            this.pgbParcial = new System.Windows.Forms.ProgressBar();
            this.pnlImagem = new System.Windows.Forms.Panel();
            this.img = new System.Windows.Forms.PictureBox();
            this.pnlMensgem = new System.Windows.Forms.Panel();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlProgresso.SuspendLayout();
            this.pnlImagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.pnlMensgem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProgresso
            // 
            this.pnlProgresso.Controls.Add(this.pgbTotal);
            this.pnlProgresso.Controls.Add(this.pnlEspaco001);
            this.pnlProgresso.Controls.Add(this.pgbParcial);
            this.pnlProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgresso.Location = new System.Drawing.Point(0, 126);
            this.pnlProgresso.Name = "pnlProgresso";
            this.pnlProgresso.Padding = new System.Windows.Forms.Padding(5);
            this.pnlProgresso.Size = new System.Drawing.Size(484, 60);
            this.pnlProgresso.TabIndex = 0;
            // 
            // pgbTotal
            // 
            this.pgbTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgbTotal.Location = new System.Drawing.Point(5, 25);
            this.pgbTotal.Name = "pgbTotal";
            this.pgbTotal.Size = new System.Drawing.Size(474, 30);
            this.pgbTotal.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbTotal.TabIndex = 0;
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEspaco001.Location = new System.Drawing.Point(5, 20);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Size = new System.Drawing.Size(474, 5);
            this.pnlEspaco001.TabIndex = 3;
            // 
            // pgbParcial
            // 
            this.pgbParcial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbParcial.Location = new System.Drawing.Point(5, 5);
            this.pgbParcial.Name = "pgbParcial";
            this.pgbParcial.Size = new System.Drawing.Size(474, 15);
            this.pgbParcial.TabIndex = 1;
            this.pgbParcial.Visible = false;
            // 
            // pnlImagem
            // 
            this.pnlImagem.Controls.Add(this.img);
            this.pnlImagem.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlImagem.Location = new System.Drawing.Point(0, 0);
            this.pnlImagem.Name = "pnlImagem";
            this.pnlImagem.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlImagem.Size = new System.Drawing.Size(150, 126);
            this.pnlImagem.TabIndex = 1;
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.Color.Transparent;
            this.img.Dock = System.Windows.Forms.DockStyle.Fill;
            this.img.Image = ((System.Drawing.Image)(resources.GetObject("img.Image")));
            this.img.InitialImage = null;
            this.img.Location = new System.Drawing.Point(30, 20);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(90, 86);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            // 
            // pnlMensgem
            // 
            this.pnlMensgem.Controls.Add(this.lblTitulo);
            this.pnlMensgem.Controls.Add(this.lblDescricao);
            this.pnlMensgem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMensgem.Location = new System.Drawing.Point(150, 0);
            this.pnlMensgem.Name = "pnlMensgem";
            this.pnlMensgem.Size = new System.Drawing.Size(334, 126);
            this.pnlMensgem.TabIndex = 2;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescricao.Location = new System.Drawing.Point(0, 0);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(334, 126);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Rotina do sistema sendo executada.";
            this.lblDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(334, 50);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Por favor, aguarde...";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmEspera
            // 
            this.ClientSize = new System.Drawing.Size(484, 186);
            this.Controls.Add(this.pnlMensgem);
            this.Controls.Add(this.pnlImagem);
            this.Controls.Add(this.pnlProgresso);
            this.Name = "FrmEspera";
            this.Text = "Processando";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEspera_FormClosing);
            this.pnlProgresso.ResumeLayout(false);
            this.pnlImagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.pnlMensgem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code
    }
}