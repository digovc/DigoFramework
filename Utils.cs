using System;
using System.Security.Cryptography;
using Correios.Net;
using DigoFramework.ObjetoDiverso;

namespace DigoFramework
{
    public sealed class Utils
    {
        #region CONSTANTES
        public const String STRING_VAZIA = "";

        #endregion

        #region ATRIBUTOS

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

        public static Endereco getObjEnderecoPeloCep(Int32 intCep)
        {
            #region VARIÁVEIS

            Endereco objEndereco = new Endereco();

            #endregion

            #region AÇÕES

            try
            {
                Address objAddress = BuscaCep.GetAddress(intCep.ToString());
                objEndereco.objBairro.objCidade.objPais.strNome = "Brasil";
                objEndereco.objBairro.objCidade.strNome = objAddress.City;
                objEndereco.objBairro.strNome = objAddress.District;
                objEndereco.objLogradouro.strNome = objAddress.Street;
                return objEndereco;
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao tentar recuperar o Endereço do CEP " + intCep.ToString(), ex, Erro.ErroTipo.Notificao);
            }

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

        public static String getStrFormataTitulo(String strTituloNaoFormatado)
        {
            #region VARIÁVEIS

            System.Globalization.CultureInfo objCultureInfo = new System.Globalization.CultureInfo("pt-BR");

            #endregion

            #region AÇÕES

            strTituloNaoFormatado = strTituloNaoFormatado.ToLower();
            return objCultureInfo.TextInfo.ToTitleCase(strTituloNaoFormatado);

            #endregion
        }

        public static String getStrMd5(String strInput)
        {
            #region VARIÁVEIS

            MD5 md5 = MD5.Create();

            #endregion

            #region AÇÕES

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(strInput);
            byte[] hash = md5.ComputeHash(inputBytes);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();

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
            string[] arrChrCaracteresEspeciais = { "\\.", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "^\\s+", "\\s+$", "\\s+", ".", "(", ")" };
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