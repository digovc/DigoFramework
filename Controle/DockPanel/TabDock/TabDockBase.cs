using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.TabDock
{
    public partial class TabDockBase : DockContent
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public TabDockBase()
        {
            this.InitializeComponent();

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
    }
}