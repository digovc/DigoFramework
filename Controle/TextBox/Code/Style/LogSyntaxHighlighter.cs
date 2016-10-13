using System;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code.Style
{
    public class LogSyntaxHighlighter : SyntaxHighlighterBase
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
            objRange.ClearStyle();

            objRange.SetStyle(this.BlackStyle, @"\b.*\[INFO\].*\b");
            objRange.SetStyle(this.GrayStyle, @"\b.*\[NOTIFICACAO\].*\b");
            objRange.SetStyle(this.RedStyle, @"\b.*\[ERRO\].*\b");
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