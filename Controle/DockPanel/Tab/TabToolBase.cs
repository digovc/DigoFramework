using System;
using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public class TabToolBase : TabBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected virtual DockState getEnmDockStateDefault()
        {
            return DockState.Document;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.DockAreas = (DockAreas.DockRight | DockAreas.DockLeft);
        }

        #endregion Métodos

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            try
            {
                this.DockState = this.getEnmDockStateDefault();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
        }

        #endregion Eventos
    }
}