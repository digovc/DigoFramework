using FastColoredTextBoxNS;

namespace DigoFramework.Controle.TextBox.Code.Style
{
    public abstract class SyntaxHighlighterBase : SyntaxHighlighter
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public SyntaxHighlighterBase()
        {
            this.InitStyleSchema(this.getEnmLanguage());
        }

        #endregion Construtores

        #region Métodos

        protected abstract Language getEnmLanguage();

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}