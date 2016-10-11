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

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.DockAreas = DockAreas.DockRight | DockAreas.DockLeft;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.DockState = this.getEnmDockStateDefault();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Eventos
    }
}