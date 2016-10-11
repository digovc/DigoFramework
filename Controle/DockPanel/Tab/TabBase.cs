using DigoFramework.Controle.Painel;
using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public class TabBase : DockContent
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private PainelConteudo _pnlConteudo;

        protected PainelConteudo pnlConteudo
        {
            get
            {
                if (_pnlConteudo != null)
                {
                    return _pnlConteudo;
                }

                _pnlConteudo = new PainelConteudo();

                return _pnlConteudo;
            }
        }

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
            this.Controls.Add(this.pnlConteudo);
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