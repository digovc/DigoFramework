using Correios.Net;
using DigoFramework.ObjMain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DigoFramework
{
    public sealed class Utils
    {
        #region CONSTANTES

        public const string STR_VAZIA = "";

        #endregion CONSTANTES

        #region ATRIBUTOS

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        public static string formatarTitulo(string str)
        {
            #region VARIÁVEIS

            CultureInfo objCultureInfo;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return String.Empty;
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

            #endregion AÇÕES

            return str;
        }

        public static bool getBooArquivoExiste(string dirArquivo)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// "Pinga" vários hosts para verificar se a máquina está conectada na internet.
        /// </summary>
        public static bool getBooConectadoInternet()
        {
            #region VARIÁVEIS

            TcpClient objTcpClient;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                objTcpClient = new TcpClient("www.google.com", 80);
                objTcpClient.Close();
                
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// REtorna "true" se o texto em "str" contiver apenas caracteres alfanuméricos.
        /// </summary>
        public static bool getBooStrAlfanumerico(string str)
        {
            #region VARIÁVEIS

            Regex objRegex;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Método retorna a quantidade de arquivos e pastas dentro da pasta indicadqa.
        /// </summary>
        public static int getIntQtdArquivos(string dir)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

            return intResultado;
        }

        public static Endereco getObjEnderecoPeloCep(Int32 intCep)
        {
            #region VARIÁVEIS

            Address objAddress;
            Endereco objEnderecoResultado;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

            return objEnderecoResultado;
        }

        public static string getStrCampoFixo(string strValor, Int16 intTamanho, Char chrVazio = ' ')
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (strValor == null)
                {
                    strValor = String.Empty;
                }

                if (chrVazio == '0')
                {
                    strValor = simplificar(strValor);

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

            #endregion AÇÕES

            return strResultado;
        }

        public static string getStrDataFormatada(DateTime dteData)
        {
            #region VARIÁVEIS

            string strResultado;
            string strAno;
            string strMes;
            string strDia = String.Empty;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

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

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Retorna a "string" passada como parâmetro com a primeira letra de cada palavra maiúscula.
        /// </summary>
        public static string getStrPrimeiraMaiuscula(String str)
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return String.Empty;
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

            #endregion AÇÕES

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

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = String.Empty;

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

            #endregion AÇÕES

            return strResultado;
        }

        public static string limitar(string str, int intQtdTotal)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return String.Empty;
                }

                if (str.Length < intQtdTotal)
                {
                    return str;
                }

                str = str.Substring(0, intQtdTotal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return str;
        }

        /// <summary>
        /// Remove caracteres do final do texto.
        /// </summary>
        public static string removerCaracter(string str, int intQtd = 1)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(str))
                {
                    return String.Empty;
                }

                if (str.Length < intQtd)
                {
                    return String.Empty;
                }

                return str.Remove(str.Length - intQtd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Remove todos os caracteres especiais, pontuação, acentuação da string passada por parâmetro.
        /// </summary>
        public static string simplificar(string str)
        {
            #region VARIÁVEIS

            string[] arrStrAcentos;
            string[] arrStrCaracteresEspeciais;
            string[] arrStrSemAcento;

            #endregion VARIÁVEIS

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

                str = str.Replace(" ", "_");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return str;
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}