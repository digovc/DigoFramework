using Correios.Net;
using DigoFramework.objeto;
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

        public const String STRING_VAZIA = "";

        #endregion

        #region ATRIBUTOS

        #endregion

        #region MÉTODOS

        public static String formatarTitulo(String str)
        {
            #region VARIÁVEIS

            CultureInfo objCultureInfo;

            #endregion

            try
            {
                #region AÇÕES

                if (String.IsNullOrEmpty(str))
                {
                    throw new Erro("Não é possível formatar uma 'String' vazia ou 'Null' como título.");
                }

                objCultureInfo = new CultureInfo("pt-BR");
                str = str.ToLower();
                str = objCultureInfo.TextInfo.ToTitleCase(str);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return str;
        }

        public static Boolean getBooArquivoExiste(String dirArquivo)
        {
            return File.Exists(dirArquivo);
        }

        /// <summary>
        /// "Pinga" vários hosts para verificar se a máquina está conectada na internet.
        /// </summary>
        public static Boolean getBooConectadoInternet()
        {
            #region VARIÁVEIS

            Boolean booResultado = false;
            WebClient objWebClient;

            #endregion

            try
            {
                #region AÇÕES

                objWebClient = new WebClient();

                try
                {
                    objWebClient.OpenRead("http://www.google.com");
                    booResultado = true;
                }
                catch
                {
                    booResultado = false;
                }

                try
                {
                    objWebClient.OpenRead("http://www.microsoft.com");
                    booResultado = true;
                }
                catch
                {
                    booResultado = false;
                }

                try
                {
                    objWebClient.OpenRead("http://www.apple.com");
                    booResultado = true;
                }
                catch
                {
                    booResultado = false;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

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
        public static int getIntQtdArquivos(String dir)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion

            try
            {
                #region AÇÕES

                intResultado = Directory.GetFiles(dir).Length;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return intResultado;
        }

        public static Endereco getObjEnderecoPeloCep(Int32 intCep)
        {
            #region VARIÁVEIS

            Address objAddress;
            Endereco objEnderecoResultado;

            #endregion

            try
            {
                #region AÇÕES

                objAddress = BuscaCep.GetAddress(intCep.ToString());

                objEnderecoResultado = new Endereco();
                objEnderecoResultado.objBairro.objCidade.objPais.strNome = "Brasil";
                objEnderecoResultado.objBairro.objCidade.strNome = objAddress.City;
                objEnderecoResultado.objBairro.strNome = objAddress.District;
                objEnderecoResultado.objLogradouro.strNome = objAddress.Street;

                #endregion
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao tentar recuperar o Endereço do CEP " + intCep.ToString(), ex, Erro.ErroTipo.NOTIFICACAO);
            }

            return objEnderecoResultado;
        }

        public static String getStrCampoFixo(String strValor, Int16 intTamanho, Char chrVazio = ' ')
        {
            #region VARIÁVEIS

            String strResultado;

            #endregion

            try
            {
                #region AÇÕES

                if (strValor == null)
                {
                    strValor = Utils.STRING_VAZIA;
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

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        public static String getStrDataFormatada(DateTime dteData)
        {
            #region VARIÁVEIS

            String strResultado;
            String strAno;
            String strMes;
            String strDia = Utils.STRING_VAZIA;

            #endregion

            try
            {
                #region AÇÕES

                strAno = Utils.getStrCampoFixo(Convert.ToString(dteData.Year), 4, '0');
                strMes = Utils.getStrCampoFixo(Convert.ToString(dteData.Month), 2, '0');
                strDia = Utils.getStrCampoFixo(Convert.ToString(dteData.Day), 2, '0');
                strResultado = String.Format("{0}-{1}-{2}", strAno, strMes, strDia);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        public static String getStrMd5(String str)
        {
            #region VARIÁVEIS

            byte[] bteHash;
            byte[] bteInput;

            MD5 md5;

            String strResultado;

            StringBuilder stb;

            #endregion

            try
            {
                #region AÇÕES

                md5 = MD5.Create();
                bteInput = System.Text.Encoding.UTF8.GetBytes(str);
                bteHash = md5.ComputeHash(bteInput);
                stb = new StringBuilder();

                for (int i = 0; i < bteHash.Length; i++)
                {
                    stb.Append(bteHash[i].ToString("X2"));
                }

                strResultado = stb.ToString();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        /// <summary>
        /// Gera uma string fortemente criptografada para segurança entre aplicativos.
        /// </summary>
        public static String getStrToken(List<String> lstStrTermo, int intTamanho = 5)
        {
            #region VARIÁVEIS

            String strResultado;
            String strTermoMd5;

            #endregion

            try
            {
                #region AÇÕES

                strResultado = Utils.STRING_VAZIA;

                foreach (String strTermo in lstStrTermo)
                {
                    strTermoMd5 = Utils.getStrMd5(strTermo);
                    strResultado = Utils.getStrMd5(strResultado + strTermoMd5);
                }

                strResultado = strResultado.Substring(0, intTamanho);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return strResultado;
        }

        /// <summary>
        /// Remove a última letra da string passada por parâmetro.
        /// </summary>
        public static String removerUltimaLetra(String str)
        {
            #region VARIÁVEIS

            #endregion

            try
            {
                #region AÇÕES

                return str.Remove(str.Length - 1);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Remove todos os caracteres especiais, pontuação, acentuação da string passada por parâmetro.
        /// </summary>
        public static String simplificarStr(String str)
        {
            #region VARIÁVEIS

            string[] arrStrAcentos;
            string[] arrStrCaracteresEspeciais;
            string[] arrStrSemAcento;

            #endregion

            try
            {
                #region AÇÕES

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

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return str;
        }

        #endregion
    }
}