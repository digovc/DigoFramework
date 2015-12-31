using System;
using DigoFramework.Controle.Texto.Code;
using WeifenLuo.WinFormsUI.Docking;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public class TabLog : TabToolMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private TextBoxCodeLog _txtLog;

        private TextBoxCodeLog txtLog
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_txtLog != null)
                    {
                        return _txtLog;
                    }

                    _txtLog = new TextBoxCodeLog();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _txtLog;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void adicionar(Log log)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (log == null)
                {
                    return;
                }

                this.txtLog.adicionar(log);
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

        protected override DockState getEnmDockStateDefault()
        {
            return DockState.DockBottom;
        }

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom;
                this.Text = "Log de compilação";
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

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.pnlConteudo.Controls.Add(this.txtLog);
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

        #endregion Eventos
    }
}