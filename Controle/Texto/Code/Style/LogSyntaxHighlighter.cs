using System;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code.Style
{
    public class LogSyntaxHighlighter : SyntaxHighlighterMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public override void SQLSyntaxHighlight(Range objRange)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                objRange.ClearStyle();

                objRange.SetStyle(this.BlackStyle, @"\b.*\[INFO\].*\b");
                objRange.SetStyle(this.GrayStyle, @"\b.*\[NOTIFICACAO\].*\b");
                objRange.SetStyle(this.RedStyle, @"\b.*\[ERRO\].*\b");
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

        protected override Language getEnmLanguage()
        {
            return Language.Custom;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}