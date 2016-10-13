using System;
using DigoFramework.Controle.Texto.Code;
using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public class TabLog : TabToolBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private TextBoxCodeLog _txtLog;

        private TextBoxCodeLog txtLog
        {
            get
            {
                if (_txtLog != null)
                {
                    return _txtLog;
                }

                _txtLog = new TextBoxCodeLog();

                return _txtLog;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void adicionar(Log log)
        {
            if (log == null)
            {
                return;
            }

            this.txtLog.adicionar(log);
        }

        protected override DockState getEnmDockStateDefault()
        {
            return DockState.DockBottom;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.DockAreas = (DockAreas.DockRight | DockAreas.DockLeft | DockAreas.DockBottom);
            this.Text = "Log de compilação";
        }

        protected override void montarLayout()
        {
            base.montarLayout();

            this.Controls.Add(this.txtLog);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}