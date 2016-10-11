using System;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_pnlConteudo != null)
                    {
                        return _pnlConteudo;
                    }

                    _pnlConteudo = new PainelConteudo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _pnlConteudo;
            }
        }

        #endregion Atributos

        #region Construtores

        public TabBase()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.iniciar();
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

        #endregion Construtores

        #region Métodos

        protected virtual void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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

        protected virtual void montarLayout()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.Controls.Add(this.pnlConteudo);
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

        protected virtual void setEventos()
        {
        }

        private void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.montarLayout();
                this.setEventos();
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