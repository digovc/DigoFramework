using System;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code.Style
{
    public abstract class SyntaxHighlighterMain : SyntaxHighlighter
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public SyntaxHighlighterMain()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.InitStyleSchema(this.getEnmLanguage());
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

        protected abstract Language getEnmLanguage();

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}