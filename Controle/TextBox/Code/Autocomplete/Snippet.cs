using System.Drawing;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.TextBox.Code.Autocomplete
{
    public class Snippet : AutocompleteItemBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        public override Color BackColor
        {
            get
            {
                return Color.Gray;
            }
        }

        public override string MenuText
        {
            get
            {
                return base.MenuText;
            }

            set
            {
                base.MenuText = value;

                if (string.IsNullOrEmpty(base.MenuText))
                {
                    return;
                }

                base.MenuText += " (snippet)";
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public override CompareResult Compare(string strFragmento)
        {
            if (string.IsNullOrEmpty(strFragmento))
            {
                return CompareResult.Hidden;
            }

            if (!Regex.IsMatch(this.Text, @"^\b" + strFragmento))
            {
                return CompareResult.Hidden;
            }

            return CompareResult.Visible;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}