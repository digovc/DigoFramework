using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using DigoFramework.Import;

namespace DigoFramework
{
    public sealed class Utils
    {
        #region Constantes

        private const int INT_MESSAGE_ID = (0x8000 + 1);

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Abre um arquivo de texto no Notepad.
        /// </summary>
        /// <param name="dirFile">Diretório para o arquivo que se deseja abrir.</param>
        public static Process abrirNotePad(string dirFile)
        {
            if (string.IsNullOrEmpty(dirFile))
            {
                return null;
            }

            if (!File.Exists(dirFile))
            {
                return null;
            }

            return Process.Start("notepad", dirFile);
        }

        /// <summary>
        /// Envia uma mensagem para outra aplicação.
        /// </summary>
        /// <param name="strAppNome">Nome da aplicação que irá receber a mensagem.</param>
        /// <param name="intData">Informação que será enviada dentro da mensagem.</param>
        public static void enviarMensagem(string strAppNome, int intData)
        {
            if (string.IsNullOrEmpty(strAppNome))
            {
                return;
            }

            Process objProcessApp = null;

            foreach (Process objProcess in Process.GetProcesses())
            {
                if (objProcess == null)
                {
                    continue;
                }

                if (string.IsNullOrEmpty(objProcess.ProcessName))
                {
                    continue;
                }

                if (!objProcess.ProcessName.Contains(strAppNome))
                {
                    continue;
                }

                objProcessApp = objProcess;
                break;
            }

            if (objProcessApp == null)
            {
                return;
            }

            User32.SendMessage(objProcessApp.MainWindowHandle, INT_MESSAGE_ID, 0, intData);
        }

        public static bool getBoo(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            switch (str.ToLower())
            {
                case "sim":
                case "s":
                case "true":
                case "t":
                case "1":
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// "Pinga" vários hosts para verificar se a máquina está conectada na internet.
        /// </summary>
        public static bool getBooConectadoInternet()
        {
            try
            {
                new TcpClient("www.google.com", 80).Close();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna "true" se o texto contido em "str" contiver apenas caracteres alfanuméricos.
        /// </summary>
        public static bool getBooStrAlfanumerico(string str)
        {
            Regex objRegex = new Regex("^[a-zA-Z0-9]*$");

            return objRegex.IsMatch(str);
        }

        /// <summary>
        /// Método retorna a quantidade de arquivos e pastas dentro da pasta indicadqa.
        /// </summary>
        public static int getIntQtdArquivos(string dir)
        {
            return Directory.GetFiles(dir).Length;
        }

        public static string getStrCampoFixo(string strValor, int intTamanho, char chrVazio = ' ')
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
                    return strValor.PadLeft(intTamanho, chrVazio);
                }
                else
                {
                    return strValor.Substring(strValor.Length - intTamanho);
                }
            }

            if (strValor.Length <= intTamanho)
            {
                return strValor.PadRight(intTamanho, chrVazio);
            }

            return strValor.Substring(0, intTamanho);
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
            MD5 md5 = MD5.Create();
            byte[] bteInput = Encoding.UTF8.GetBytes(str);
            byte[] bteHash = md5.ComputeHash(bteInput);
            StringBuilder stb = new StringBuilder();

            for (int i = 0; i < bteHash.Length; i++)
            {
                stb.Append(bteHash[i].ToString("X2"));
            }

            return stb.ToString();
        }

        /// <summary>
        /// Retorna a "string" passada como parâmetro com a primeira letra de cada palavra maiúscula.
        /// </summary>
        public static string getStrPrimeiraMaiuscula(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            string strResultado = str.ToUpper().Substring(0, 1);

            strResultado += str.Substring(1, (str.Length - 1));

            return strResultado;
        }

        public static string getStrTitulo(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }

            CultureInfo objCultureInfo = new CultureInfo("pt-BR");

            str = str.ToLower();
            str = objCultureInfo.TextInfo.ToTitleCase(str);

            return str;
        }

        /// <summary>
        /// Gera uma string fortemente criptografada para segurança entre aplicativos.
        /// </summary>
        public static string getStrToken(List<string> lstStrTermo, int intTamanho = 5)
        {
            string strResultado = string.Empty;
            string strTermoMd5;

            foreach (string strTermo in lstStrTermo)
            {
                strTermoMd5 = getStrMd5(strTermo);
                strResultado = getStrMd5(strResultado + strTermoMd5);
            }

            return strResultado?.Substring(0, intTamanho);
        }

        public static int indexOf(byte[] arrBteSource, byte[] arrBteSearch)
        {
            if (arrBteSource == null)
            {
                return -1;
            }

            if (arrBteSource.Length < 1)
            {
                return -1;
            }

            if (arrBteSearch == null)
            {
                return -1;
            }

            if (arrBteSearch.Length < 1)
            {
                return -1;
            }

            int i = 0;
            int intStartPos = Array.IndexOf(arrBteSource, arrBteSearch[0], 0);

            if (intStartPos < 0)
            {
                return -1;
            }

            while ((intStartPos + i) < arrBteSource.Length)
            {
                if (arrBteSource[intStartPos + i] == arrBteSearch[i])
                {
                    i++;

                    if (i == arrBteSearch.Length)
                    {
                        return intStartPos;
                    }

                    continue;
                }

                intStartPos = Array.IndexOf(arrBteSource, arrBteSearch[0], (intStartPos + i));

                if (intStartPos == -1)
                {
                    return -1;
                }

                i = 0;
            }

            return -1;
        }

        public static string limitar(string str, int intQtdTotal)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            if (str.Length < intQtdTotal)
            {
                return str;
            }

            return str.Substring(0, intQtdTotal);
        }

        /// <summary>
        /// Remove caracteres do final do texto.
        /// </summary>
        public static string removerCaracter(string str, int intQtd = 1)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            if (str.Length < intQtd)
            {
                return null;
            }

            return str?.Remove(str.Length - intQtd);
        }

        /// <summary>
        /// Remove todos os caracteres especiais, pontuação, acentuação da string passada por parâmetro.
        /// </summary>
        public static string simplificar(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            str = str.ToLower();
            str = str.Trim();

            string[] arrStrAcentos = new string[] { "ç", "á", "é", "í", "ó", "ú", "ý", "à", "è", "ì", "ò", "ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "â", "ê", "î", "ô", "û" };
            string[] arrStrSemAcento = new string[] { "c", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u", "a", "o", "n", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u" };
            string[] arrStrCaracteresEspeciais = new string[] { "\\.", "\\", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "^\\s+", "\\s+$", "\\s+", ".", "(", ")" };

            for (int intTemp = 0; intTemp < arrStrAcentos.Length; intTemp++)
            {
                str = str.Replace(arrStrAcentos[intTemp], arrStrSemAcento[intTemp]);
            }

            for (int intTemp = 0; intTemp < arrStrCaracteresEspeciais.Length; intTemp++)
            {
                str = str.Replace(arrStrCaracteresEspeciais[intTemp], "");
            }

            return str?.Replace(" ", "_");
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}