using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public class TabBase : DockContent
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TabBase()
        {
            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        protected void finalizar()
        {
        }

        protected virtual void inicializar()
        {
        }

        protected virtual void montarLayout()
        {
        }

        protected virtual void setEventos()
        {
        }

        private void iniciar()
        {
            this.inicializar();
            this.montarLayout();
            this.setEventos();
            this.finalizar();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TabBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TabBase";
            this.ResumeLayout(false);

        }
    }
}