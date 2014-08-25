namespace DigoFramework.Frm
{
    partial class FrmInput
    {
        private System.Windows.Forms.Button btnOk;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lbl;

        private System.Windows.Forms.TextBox txt;

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
            this.lbl = new System.Windows.Forms.Label();
            this.txt = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lbl
            //
            this.lbl.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl.Location = new System.Drawing.Point(10, 10);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(264, 50);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Utilize o campo abaixo para inserir o texto";
            this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // txt
            //
            this.txt.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt.Location = new System.Drawing.Point(10, 60);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(264, 20);
            this.txt.TabIndex = 1;
            //
            // btnOk
            //
            this.btnOk.Location = new System.Drawing.Point(101, 95);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            //
            // FrmInput
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 133);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.lbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmInput";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Insira o texto";
            this.Load += new System.EventHandler(this.FrmInput_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}