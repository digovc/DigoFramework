using System;

namespace DigoFramework
{
    public sealed class Utils
    {
        #region CONSTANTES
        public const String STRING_VAZIA = "";

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        public static String getStrSimplificada(String strComplexa)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            // Tudo minúsculo
            strComplexa = strComplexa.ToLower();

            // Acentos
            string[] arrChrAcentos = new string[] { "ç", "á", "é", "í", "ó", "ú", "ý", "à", "è", "ì", "ò", "ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "â", "ê", "î", "ô", "û" };
            string[] arrChrSemAcento = new string[] { "c", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u", "a", "o", "n", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u" };
            for (int intTemp = 0; intTemp < arrChrAcentos.Length; intTemp++)
            {
                strComplexa = strComplexa.Replace(arrChrAcentos[intTemp], arrChrSemAcento[intTemp]);
            }

            // Caracteres especiais
            string[] arrChrCaracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "^\\s+", "\\s+$", "\\s+" };
            for (int intTemp = 0; intTemp < arrChrCaracteresEspeciais.Length; intTemp++)
            {
                strComplexa = strComplexa.Replace(arrChrCaracteresEspeciais[intTemp], "");
            }

            // Espaços em branco
            strComplexa = strComplexa.Replace(" ", "_");

            return strComplexa;

            #endregion
        }

        #endregion
    }
}