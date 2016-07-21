using System;
using System.Drawing;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code.Autocomplete
{
    public class Snippet : AutocompleteItemMain
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    base.MenuText = value;

                    if (string.IsNullOrEmpty(base.MenuText))
                    {
                        return;
                    }

                    base.MenuText += " (snippet)";
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
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public override CompareResult Compare(string strFragmento)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
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