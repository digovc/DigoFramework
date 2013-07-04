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

        public static Boolean getBooArquivoExiste(String dirArquivo)
        {
            #region VARIÁVEIS

            Boolean booDiretorioExiste = false;

            #endregion

            #region AÇÕES

            booDiretorioExiste = System.IO.File.Exists(dirArquivo);
            return booDiretorioExiste;

            #endregion
        }

        public static String getStrCampoFixo(String strValor, Int16 intTamanho, Char chrVazio = ' ')
        {
            #region VARIÁVEIS

            String strCampoFixo = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            if (strValor == null)
            {
                strValor = Utils.STRING_VAZIA;
            }

            if (chrVazio == '0')
            {
                strValor = getStrSimplificada(strValor);
                if (strValor.Length <= intTamanho) { strCampoFixo = strValor.PadLeft(intTamanho, chrVazio); }
                else { strCampoFixo = strValor.Substring(strValor.Length - intTamanho); }
            }
            else
            {
                if (strValor.Length <= intTamanho) { strCampoFixo = strValor.PadRight(intTamanho, chrVazio); }
                else { strCampoFixo = strValor.Substring(0, intTamanho); }
            }

            return strCampoFixo;

            #endregion
        }

        // TODO: Melhorar este método com mais formatos de datas
        public static String getStrDataFormatada(DateTime dteData)
        {
            #region VARIÁVEIS

            String strDataFormatada, strAno, strMes, strDia = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strAno = Utils.getStrCampoFixo(Convert.ToString(dteData.Year), 4, '0');
            strMes = Utils.getStrCampoFixo(Convert.ToString(dteData.Month), 2, '0');
            strDia = Utils.getStrCampoFixo(Convert.ToString(dteData.Day), 2, '0');
            strDataFormatada = String.Format("{0}-{1}-{2}", strAno, strMes, strDia);
            return strDataFormatada;

            #endregion
        }

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
            string[] arrChrCaracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "^\\s+", "\\s+$", "\\s+", "." };
            for (int intTemp = 0; intTemp < arrChrCaracteresEspeciais.Length; intTemp++)
            {
                strComplexa = strComplexa.Replace(arrChrCaracteresEspeciais[intTemp], "");
            }

            // Espaços em branco
            strComplexa = strComplexa.Replace(" ", "");

            return strComplexa;

            #endregion
        }

        #endregion
    }
}