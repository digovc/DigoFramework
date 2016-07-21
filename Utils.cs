using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Correios.Net;
using DigoFramework.ObjMain;

namespace DigoFramework
{
    public sealed class Utils
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// "Pinga" vários hosts para verificar se a máquina está conectada na internet.
        /// </summary>
        public static bool getBooConectadoInternet()
        {
            #region Variáveis

            TcpClient objTcpClient;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Retorna "true" se o texto contido em "str" contiver apenas caracteres alfanuméricos.
        /// </summary>
        public static bool getBooStrAlfanumerico(string str)
        {
            #region Variáveis

            Regex objRegex;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Retorna o diretório relativo a outro no formato de URL.
        /// </summary>
        /// <param name="dirFrom">Diretório base para comparação.</param>
        /// <param name="dirTo">Diretório que se deseja comparar.</param>
        /// <returns>Diretório relativo a outro no formato de URL.</returns>
        public static string getDirRelativo(string dirFrom, string dirTo)
        {
            #region Variáveis

            Uri uriFrom;
            Uri uriRelativa;
            Uri uriTo;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(dirFrom))
                {
                    return null;
                }

                if (string.IsNullOrEmpty(dirTo))
                {
                    return null;
                }

                uriFrom = new Uri(dirFrom);
                uriTo = new Uri(dirTo);

                if (uriFrom.Scheme != uriTo.Scheme)
                {
                    return dirTo;
                }

                uriRelativa = uriFrom.MakeRelativeUri(uriTo);

                return Uri.UnescapeDataString(uriRelativa.ToString());
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

        /// <summary>
        /// Método retorna a quantidade de arquivos e pastas dentro da pasta indicadqa.
        /// </summary>
        public static int getIntQtdArquivos(string dir)
        {
            #region Variáveis

            int intResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return intResultado;
        }

        public static Endereco getObjEnderecoPeloCep(int intCep)
        {
            #region Variáveis

            Address objAddress;
            Endereco objEnderecoResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return objEnderecoResultado;
        }

        public static string getStrCampoFixo(string strValor, int intTamanho, char chrVazio = ' ')
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                if (strValor == null)
                {
                    strValor = null;
                }

                if ('0'.Equals(chrVazio))
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

                    return strResultado;
                }

                if (strValor.Length <= intTamanho)
                {
                    strResultado = strValor.PadRight(intTamanho, chrVazio);
                }
                else
                {
                    strResultado = strValor.Substring(0, intTamanho);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Cria um nomde de exibição amigável para um identificador do banco de dados.
        /// </summary>
        /// <param name="strNome">Identificador do banco de dados que será formatado.</param>
        /// <returns></returns>
        public static string getStrDbNomeExibicao(string strNome)
        {
            if (string.IsNullOrEmpty(strNome))
            {
                return "<Desconhecido>";
            }

            if (strNome.Length < 4)
            {
                return strNome;
            }

            strNome = strNome.Substring(4);
            strNome = getStrPrimeiraMaiuscula(strNome);

            return strNome;
        }

        public static string getStrMd5(string str)
        {
            #region Variáveis

            byte[] bteHash;
            byte[] bteInput;
            MD5 md5;
            string strResultado;
            StringBuilder stb;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Retorna a "string" passada como parâmetro com a primeira letra de cada palavra maiúscula.
        /// </summary>
        public static string getStrPrimeiraMaiuscula(string str)
        {
            #region Variáveis

            string strResultado = null;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }

                strResultado = str.ToUpper().Substring(0, 1);
                strResultado += str.Substring(1, (str.Length - 1));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        public static string getStrTitulo(string str)
        {
            #region Variáveis

            CultureInfo objCultureInfo;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return string.Empty;
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

            #endregion Ações

            return str;
        }

        /// <summary>
        /// Gera uma string fortemente criptografada para segurança entre aplicativos.
        /// </summary>
        public static string getStrToken(List<string> lstStrTermo, int intTamanho = 5)
        {
            #region Variáveis

            string strResultado;
            string strTermoMd5;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = string.Empty;

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

            #endregion Ações

            return strResultado;
        }

        public static string limitar(string str, int intQtdTotal)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return null;
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

            #endregion Ações

            return str;
        }

        /// <summary>
        /// Remove caracteres do final do texto.
        /// </summary>
        public static string removerCaracter(string str, int intQtd = 1)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(str))
                {
                    return null;
                }

                if (str.Length < intQtd)
                {
                    return null;
                }

                return str.Remove(str.Length - intQtd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            #endregion Ações
        }

        /// <summary>
        /// Remove todos os caracteres especiais, pontuação, acentuação da string passada por parâmetro.
        /// </summary>
        public static string simplificar(string str)
        {
            #region Variáveis

            string[] arrStrAcentos;
            string[] arrStrCaracteresEspeciais;
            string[] arrStrSemAcento;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(str))
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

            #endregion Ações

            return str;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}