namespace DigoFramework.Frm
{
    partial class FrmEspera
    {
        public System.Windows.Forms.ProgressBar pgbTarefa;

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
        private System.Windows.Forms.ProgressBar pgb;

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
            this.pgb = new System.Windows.Forms.ProgressBar();
            this.pnlEspaco001 = new System.Windows.Forms.Panel();
            this.pgbTarefa = new System.Windows.Forms.ProgressBar();
            this.img = new System.Windows.Forms.PictureBox();
            this.pnlMensgem = new System.Windows.Forms.Panel();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlProgresso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img)).BeginInit();
            this.pnlMensgem.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlProgresso
            // 
            this.pnlProgresso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(109)))), ((int)(((byte)(140)))));
            this.pnlProgresso.Controls.Add(this.pgb);
            this.pnlProgresso.Controls.Add(this.pnlEspaco001);
            this.pnlProgresso.Controls.Add(this.pgbTarefa);
            this.pnlProgresso.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlProgresso.Location = new System.Drawing.Point(150, 107);
            this.pnlProgresso.Name = "pnlProgresso";
            this.pnlProgresso.Padding = new System.Windows.Forms.Padding(5);
            this.pnlProgresso.Size = new System.Drawing.Size(384, 54);
            this.pnlProgresso.TabIndex = 0;
            // 
            // pgb
            // 
            this.pgb.BackColor = System.Drawing.Color.LimeGreen;
            this.pgb.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgb.ForeColor = System.Drawing.Color.LimeGreen;
            this.pgb.Location = new System.Drawing.Point(5, 25);
            this.pgb.Name = "pgb";
            this.pgb.Size = new System.Drawing.Size(374, 15);
            this.pgb.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.pgb.TabIndex = 0;
            // 
            // pnlEspaco001
            // 
            this.pnlEspaco001.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEspaco001.Location = new System.Drawing.Point(5, 10);
            this.pnlEspaco001.Name = "pnlEspaco001";
            this.pnlEspaco001.Size = new System.Drawing.Size(374, 15);
            this.pnlEspaco001.TabIndex = 3;
            // 
            // pgbTarefa
            // 
            this.pgbTarefa.BackColor = System.Drawing.Color.LimeGreen;
            this.pgbTarefa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pgbTarefa.ForeColor = System.Drawing.Color.LimeGreen;
            this.pgbTarefa.Location = new System.Drawing.Point(5, 5);
            this.pgbTarefa.Name = "pgbTarefa";
            this.pgbTarefa.Size = new System.Drawing.Size(374, 5);
            this.pgbTarefa.TabIndex = 1;
            this.pgbTarefa.Visible = false;
            // 
            // img
            // 
            this.img.BackColor = System.Drawing.Color.Gainsboro;
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
            // FrmEspera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(534, 161);
            this.Controls.Add(this.pnlMensgem);
            this.Controls.Add(this.pnlProgresso);
            this.Controls.Add(this.img);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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