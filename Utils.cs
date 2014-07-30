using Correios.Net;
using DigoFramework.ObjMain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DigoFramework
{
    public sealed class Utils
    {
        #region CONSTANTES

        public const string STR_VAZIA = "";

        #endregion

        #region ATRIBUTOS

        #endregion

        #region MÉTODOS

        public static string formatarTitulo(string str)
        {
            #region VARIÁVEIS

            CultureInfo objCultureInfo;

            #endregion

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return Utils.STR_VAZIA;
                }

                objCultureInfo = new CultureInfo("pt-BR");
                str = str.ToLower();
                str = objCultureInfo.TextInfo.ToTitleCase(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return str;
        }

        public static bool getBooArquivoExiste(string dirArquivo)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                return File.Exists(dirArquivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// "Pinga" vários hosts para verificar se a máquina está conectada na internet.
        /// </summary>
        public static bool getBooConectadoInternet()
        {
            #region VARIÁVEIS

            bool booResultado = false;
            WebClient objWebClient;

            #endregion

            #region AÇÕES

            try
            {
                objWebClient = new WebClient();

                try
                {
                    objWebClient.OpenRead("http://www.google.com");
                    return true;
                }
                catch
                {
                    booResultado = false;
                }

                try
                {
                    objWebClient.OpenRead("http://www.microsoft.com");
                    return true;
                }
                catch
                {
                    booResultado = false;
                }

                try
                {
                    objWebClient.OpenRead("http://www.apple.com");
                    return true;
                }
                catch
                {
                    booResultado = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return booResultado;
        }

        /// <summary>
        /// REtorna "true" se o texto em "str" contiver apenas caracteres alfanuméricos.
        /// </summary>
        public static bool getBooStrAlfanumerico(string str)
        {
            #region VARIÁVEIS

            Regex objRegex;

            #endregion

            #region AÇÕES

            try
            {
                objRegex = new Regex("^[a-zA-Z0-9]*$");

                return objRegex.IsMatch(str);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Método retorna a quantidade de arquivos e pastas dentro da pasta indicadqa.
        /// </summary>
        public static int getIntQtdArquivos(string dir)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion

            #region AÇÕES

            try
            {
                intResultado = Directory.GetFiles(dir).Length;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return intResultado;
        }

        public static Endereco getObjEnderecoPeloCep(Int32 intCep)
        {
            #region VARIÁVEIS

            Address objAddress;
            Endereco objEnderecoResultado;

            #endregion

            #region AÇÕES

            try
            {
                objAddress = BuscaCep.GetAddress(intCep.ToString());

                objEnderecoResultado = new Endereco();
                objEnderecoResultado.objBairro.objCidade.objPais.strNome = "Brasil";
                objEnderecoResultado.objBairro.objCidade.strNome = objAddress.City;
                objEnderecoResultado.objBairro.strNome = objAddress.District;
                objEnderecoResultado.objLogradouro.strNome = objAddress.Street;
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao tentar recuperar o Endereço do CEP " + intCep.ToString(), ex, Erro.ErroTipo.NOTIFICACAO);
            }

            #endregion

            return objEnderecoResultado;
        }

        public static string getStrCampoFixo(string strValor, Int16 intTamanho, Char chrVazio = ' ')
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                if (strValor == null)
                {
                    strValor = Utils.STR_VAZIA;
                }

                if (chrVazio == '0')
                {
                    strValor = simplificarStr(strValor);

                    if (strValor.Length <= intTamanho)
                    {
                        strResultado = strValor.PadLeft(intTamanho, chrVazio);
                    }
                    else
                    {
                        strResultado = strValor.Substring(strValor.Length - intTamanho);
                    }
                }
                else
                {
                    if (strValor.Length <= intTamanho)
                    {
                        strResultado = strValor.PadRight(intTamanho, chrVazio);
                    }
                    else
                    {
                        strResultado = strValor.Substring(0, intTamanho);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        public static string getStrDataFormatada(DateTime dteData)
        {
            #region VARIÁVEIS

            string strResultado;
            string strAno;
            string strMes;
            string strDia = Utils.STR_VAZIA;

            #endregion

            #region AÇÕES

            try
            {
                strAno = Utils.getStrCampoFixo(Convert.ToString(dteData.Year), 4, '0');
                strMes = Utils.getStrCampoFixo(Convert.ToString(dteData.Month), 2, '0');
                strDia = Utils.getStrCampoFixo(Convert.ToString(dteData.Day), 2, '0');
                strResultado = String.Format("{0}-{1}-{2}", strAno, strMes, strDia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        public static string getStrMd5(string str)
        {
            #region VARIÁVEIS

            byte[] bteHash;
            byte[] bteInput;

            MD5 md5;

            string strResultado;

            StringBuilder stb;

            #endregion

            #region AÇÕES

            try
            {
                md5 = MD5.Create();
                bteInput = System.Text.Encoding.UTF8.GetBytes(str);
                bteHash = md5.ComputeHash(bteInput);
                stb = new StringBuilder();

                for (int i = 0; i < bteHash.Length; i++)
                {
                    stb.Append(bteHash[i].ToString("X2"));
                }

                strResultado = stb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Retorna a "string" passada como parâmetro com a primeira letra de cada palavra maiúscula.
        /// </summary>
        public static string getStrPrimeiraMaiuscula(String str)
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return Utils.STR_VAZIA;
                }

                strResultado = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Gera uma string fortemente criptografada para segurança entre aplicativos.
        /// </summary>
        public static string getStrToken(List<String> lstStrTermo, int intTamanho = 5)
        {
            #region VARIÁVEIS

            string strResultado;
            string strTermoMd5;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = Utils.STR_VAZIA;

                foreach (string strTermo in lstStrTermo)
                {
                    strTermoMd5 = Utils.getStrMd5(strTermo);
                    strResultado = Utils.getStrMd5(strResultado + strTermoMd5);
                }

                strResultado = strResultado.Substring(0, intTamanho);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Remove a última letra da string passada por parâmetro.
        /// </summary>
        public static string removerUltimaLetra(string str)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                return str.Remove(str.Length - 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion
        }

        /// <summary>
        /// Remove todos os caracteres especiais, pontuação, acentuação da string passada por parâmetro.
        /// </summary>
        public static string simplificarStr(string str)
        {
            #region VARIÁVEIS

            string[] arrStrAcentos;
            string[] arrStrCaracteresEspeciais;
            string[] arrStrSemAcento;

            #endregion

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return "";
                }

                str = str.ToLower();

                arrStrAcentos = new string[] { "ç", "á", "é", "í", "ó", "ú", "ý", "à", "è", "ì", "ò", "ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "â", "ê", "î", "ô", "û" };
                arrStrSemAcento = new string[] { "c", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u", "a", "o", "n", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u" };
                arrStrCaracteresEspeciais = new string[] { "\\.", "\\", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "^\\s+", "\\s+$", "\\s+", ".", "(", ")" };

                for (int intTemp = 0; intTemp < arrStrAcentos.Length; intTemp++)
                {
                    str = str.Replace(arrStrAcentos[intTemp], arrStrSemAcento[intTemp]);
                }

                for (int intTemp = 0; intTemp < arrStrCaracteresEspeciais.Length; intTemp++)
                {
                    str = str.Replace(arrStrCaracteresEspeciais[intTemp], "");
                }

                str = str.Replace(" ", "");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return str;
        }

        #endregion
    }
}