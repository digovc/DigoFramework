using FastColoredTextBoxNS;

namespace DigoFramework.Controle.TextBox.Code.Autocomplete
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
            this.inicializar();
            this.montarLayout();
        }

        #endregion Construtores

        #region Métodos

        protected virtual void inicializar()
        {
        }

        protected virtual void montarLayout()
        {
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}