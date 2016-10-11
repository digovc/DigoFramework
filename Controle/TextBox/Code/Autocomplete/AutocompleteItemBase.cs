using System;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code.Autocomplete
{
    public abstract class AutocompleteItemBase : AutocompleteItem
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        protected AutocompleteItemBase()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.montarLayout();
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