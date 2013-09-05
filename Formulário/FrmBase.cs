using System.Windows.Forms;

namespace DigoFramework.Formulário
{
    public class FrmBase : Form
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS
        #endregion

        #region CONSTRUTORES

        public FrmBase()
        {
            // VARIÁVEIS
            // AÇÕES
            this.InitializeComponent();
        }

        #endregion

        #region MÉTODOS

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.KeyPreview = true;
            this.Name = "FrmBase";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBase_KeyDown);
            this.ResumeLayout(false);
        }

        
        #endregion

        #region EVENTOS

        protected void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            // VARIÁVEIS
            // AÇÕES
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #endregion
    }
}
