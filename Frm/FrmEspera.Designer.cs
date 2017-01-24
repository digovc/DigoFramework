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
            this.img = new System.Windows.Forms.PictureBox();
            this.pnlMensgem = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.pnlProgresso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.pnlMensgem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProgresso
            // 
            this.pnlProgresso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.pnlProgresso.Controls.Add(this.pgbTotal);
            this.pnlProgresso.Controls.Add(this.pnlEspaco001);
            this.pnlProgresso.Controls.Add(this.pgbParcial);
            this.pnlProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgresso.Location = new System.Drawing.Point(150, 107);
            this.pnlProgresso.Name = "pnlProgresso";
            this.pnlProgresso.Padding = new System.Windows.Forms.Padding(5);
            this.pnlProgresso.Size = new System.Drawing.Size(384, 54);
            this.pnlProgresso.TabIndex = 0;
            // 
            // pgbTotal
            // 
            this.pgbTotal.BackColor = System.Drawing.Color.LimeGreen;
            this.pgbTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbTotal.ForeColor = System.Drawing.Color.LimeGreen;
            this.pgbTotal.Location = new System.Drawing.Point(5, 25);
            this.pgbTotal.Name = "pgbTotal";
            this.pgbTotal.Size = new System.Drawing.Size(374, 15);
            this.pgbTotal.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgbTotal.TabIndex = 0;
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEspaco001.Location = new System.Drawing.Point(5, 10);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Size = new System.Drawing.Size(374, 15);
            this.pnlEspaco001.TabIndex = 3;
            // 
            // pgbParcial
            // 
            this.pgbParcial.BackColor = System.Drawing.Color.LimeGreen;
            this.pgbParcial.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbParcial.ForeColor = System.Drawing.Color.LimeGreen;
            this.pgbParcial.Location = new System.Drawing.Point(5, 5);
            this.pgbParcial.Name = "pgbParcial";
            this.pgbParcial.Size = new System.Drawing.Size(374, 5);
            this.pgbParcial.TabIndex = 1;
            this.pgbParcial.Visible = false;
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.Color.WhiteSmoke;
            this.img.Dock = System.Windows.Forms.DockStyle.Left;
            this.img.Image = ((System.Drawing.Image)(resources.GetObject("img.Image")));
            this.img.InitialImage = null;
            this.img.Location = new System.Drawing.Point(0, 0);
            this.img.Name = "img";
            this.img.Size = new System.Drawing.Size(150, 161);
            this.img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img.TabIndex = 0;
            this.img.TabStop = false;
            // 
            // pnlMensgem
            // 
            this.pnlMensgem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.pnlMensgem.Controls.Add(this.lblDescricao);
            this.pnlMensgem.Controls.Add(this.lblTitulo);
            this.pnlMensgem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMensgem.Location = new System.Drawing.Point(150, 0);
            this.pnlMensgem.Name = "pnlMensgem";
            this.pnlMensgem.Size = new System.Drawing.Size(384, 107);
            this.pnlMensgem.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitulo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(384, 36);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Por favor, aguarde...";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lblDescricao
            // 
            this.lblDescricao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescricao.ForeColor = System.Drawing.Color.White;
            this.lblDescricao.Location = new System.Drawing.Point(0, 36);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(384, 71);
            this.lblDescricao.TabIndex = 1;
            this.lblDescricao.Text = "Rotina do sistema sendo executada.";
            this.lblDescricao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmEspera
            // 
            this.ClientSize = new System.Drawing.Size(534, 161);
            this.Controls.Add(this.pnlMensgem);
            this.Controls.Add(this.pnlProgresso);
            this.Controls.Add(this.img);
            this.Name = "FrmEspera";
            this.Text = "Processando";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEspera_FormClosing);
            this.pnlProgresso.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img)).EndInit();
            this.pnlMensgem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion Windows Form Designer generated code
    }
}