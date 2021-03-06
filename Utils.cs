﻿using DigoFramework.Import;
using Ionic.Zlib;
using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DigoFramework
{
    public static class Utils
    {
        #region Constantes

        public const int INT_MESSAGE_ID = 0x8000;

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

        public static string compactar(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            var arrBteBuffer = Encoding.UTF8.GetBytes(str);

            var objMemoryStream = new MemoryStream();

            using (GZipStream objGZipStream = new GZipStream(objMemoryStream, CompressionMode.Compress, true))
            {
                objGZipStream.Write(arrBteBuffer, 0, arrBteBuffer.Length);
            }

            objMemoryStream.Position = 0;

            var outStream = new MemoryStream();

            var arrBteComprimido = new byte[objMemoryStream.Length];

            objMemoryStream.Read(arrBteComprimido, 0, arrBteComprimido.Length);

            var arrBteComprimidoBuffer = new byte[arrBteComprimido.Length + 4];

            Buffer.BlockCopy(arrBteComprimido, 0, arrBteComprimidoBuffer, 4, arrBteComprimido.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(arrBteBuffer.Length), 0, arrBteComprimidoBuffer, 0, 4);

            return Convert.ToBase64String(arrBteComprimidoBuffer);
        }

        /// <summary>
        /// Verificar se o primeiro valor é igual a algum dos outros passados na sequência.
        /// </summary>
        /// <returns>
        /// Retorna true caso a lista passada em <paramref name="arrObj"/> contiver um item igual a
        /// <paramref name="obj"/>.
        /// </returns>
        /// <param name="arrObj">Lista de objetos que seram verificados.</param>
        /// <param name="obj">Objeto que será comparado com cada um dos elementos.</param>
        public static bool contem(object obj, params object[] arrObj)
        {
            if (arrObj == null)
            {
                return false;
            }

            foreach (object objItem in arrObj)
            {
                if (objItem == null)
                {
                    continue;
                }

                if (objItem.Equals(obj))
                {
                    return true;
                }
            }

            return false;
        }

        public static string descompactar(string str)
        {
            var arrBte = Encoding.UTF8.GetBytes(str);

            using (var objMemoryStreamIn = new MemoryStream(arrBte))
            using (var objMemoryStreamOut = new MemoryStream())
            {
                using (var objGZipStream = new GZipStream(objMemoryStreamIn, CompressionMode.Decompress))
                {
                    objGZipStream.CopyTo(objMemoryStreamOut);
                }

                return Encoding.UTF8.GetString(objMemoryStreamOut.ToArray());
            }
        }

        /// <summary>
        /// Envia uma mensagem para outra aplicação.
        /// </summary>
        /// <param name="strAppNome">Nome da aplicação que irá receber a mensagem.</param>
        /// <param name="intMensagemId">
        /// Código que identifica a mensagem para que o aplicativo de destino possa tratar cada
        /// mensagem indistintamente.
        /// </param>
        /// <param name="intData">Informação que será enviada dentro da mensagem.</param>
        public static void enviarMensagem(string strAppNome, int intMensagemId, int intData)
        {
            if (string.IsNullOrEmpty(strAppNome))
            {
                return;
            }

            foreach (var objProcess in Process.GetProcesses())
            {
                enviarMensagem(strAppNome, intMensagemId, intData, objProcess);
            }
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
        /// Retorna "true" se o texto contido em "str" contiver apenas caracteres alfanuméricos.
        /// </summary>
        public static bool getBooAlfanumerico(string str)
        {
            return new Regex("^[a-zA-Z0-9]*$").IsMatch(str);
        }

        /// <summary>
        /// "Pinga" vários hosts para verificar se a máquina está conectada na internet.
        /// </summary>
        public static bool getBooConectadoInternet()
        {
            try
            {
                using (var tcp = new TcpClient("www.google.com", 80))
                {
                    tcp.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retorna "true" se o texto contido em "str" contiver apenas caracteres numéricos.
        /// </summary>
        public static bool getBooNumerico(string str)
        {
            return new Regex("^[0-9]*$").IsMatch(str);
        }

        public static bool getBooRodando(string strAppNome)
        {
            if (string.IsNullOrWhiteSpace(strAppNome))
            {
                return false;
            }

            foreach (Process prc in Process.GetProcesses())
            {
                if (prc.ProcessName.Contains(strAppNome))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Retorna o diretório relativo a outro no formato de URL.
        /// </summary>
        /// <param name="dirFrom">Diretório base para comparação.</param>
        /// <param name="dirTo">Diretório que se deseja comparar.</param>
        /// <returns>Diretório relativo a outro no formato de URL.</returns>
        public static string getDirRelativo(string dirFrom, string dirTo)
        {
            if (string.IsNullOrEmpty(dirFrom))
            {
                return null;
            }

            if (string.IsNullOrEmpty(dirTo))
            {
                return null;
            }

            Uri uriFrom = new Uri(dirFrom);
            Uri uriTo = new Uri(dirTo);

            if (uriFrom.Scheme != uriTo.Scheme)
            {
                return dirTo;
            }

            Uri uriRelativa = uriFrom.MakeRelativeUri(uriTo);

            return Uri.UnescapeDataString(uriRelativa.ToString());
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
            var bteInput = Encoding.UTF8.GetBytes(str);
            var md5 = MD5.Create();
            var stb = new StringBuilder();

            var bteHash = md5.ComputeHash(bteInput);

            for (int i = 0; i < bteHash.Length; i++)
            {
                stb.Append(bteHash[i].ToString("X2"));
            }

            return stb.ToString().ToLower();
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
        public static string getStrToken(int intTamanho = 5, params object[] arrObjTermo)
        {
            if (arrObjTermo == null || arrObjTermo.Length < 1)
            {
                var rnd = new Random();

                arrObjTermo = new object[] { rnd.Next(0, int.MaxValue), rnd.Next(0, int.MaxValue), rnd.Next(0, int.MaxValue) };
            }

            string strResultado = string.Empty;
            string strTermoMd5;

            foreach (object objTermo in arrObjTermo)
            {
                if (objTermo == null)
                {
                    continue;
                }

                strTermoMd5 = getStrMd5(objTermo.ToString());
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

        public static bool ping(Uri url)
        {
            try
            {
                using (var tcp = new TcpClient(url.Host, url.Port))
                {
                    tcp.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
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

            for (int i = 1; i < str.Length; i++)
            {
                if (!char.IsUpper(str[i]))
                {
                    continue;
                }

                if ((i + 1) >= str.Length)
                {
                    break;
                }

                str = str.Insert(i, "_");

                i++;
            }

            str = str.ToLower();
            str = str.Trim();

            string[] arrStrAcentos = new string[] { "ç", "á", "é", "í", "ó", "ú", "ý", "à", "è", "ì", "ò", "ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "â", "ê", "î", "ô", "û" };
            string[] arrStrSemAcento = new string[] { "c", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u", "a", "o", "n", "a", "e", "i", "o", "u", "y", "a", "e", "i", "o", "u" };
            string[] arrStrCaracteresEspeciais = new string[] { "\\.", "\\", ",", "-", ":", "\\(", "\\)", "ª", "\\|", "\\\\", "°", "^\\s+", "\\s+$", "\\s+", ".", "(", ")", "/" };

            for (int intTemp = 0; intTemp < arrStrAcentos.Length; intTemp++)
            {
                str = str.Replace(arrStrAcentos[intTemp], arrStrSemAcento[intTemp]);
            }

            for (int intTemp = 0; intTemp < arrStrCaracteresEspeciais.Length; intTemp++)
            {
                str = str.Replace(arrStrCaracteresEspeciais[intTemp], "");
            }

            return str?.Replace(" ", "_").Replace("__", "_");
        }

        private static void enviarMensagem(string strAppNome, int intMensagemId, int intData, Process objProcess)
        {
            if (objProcess == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(objProcess.ProcessName))
            {
                return;
            }

            if (!objProcess.ProcessName.Contains(strAppNome))
            {
                return;
            }

            Log.i.info("Enviando a informação \"{0}.{1}\" para a aplicação \"{2}\" que está rodando no processo PID {2}.", intMensagemId, intData, strAppNome, objProcess.Id);

            User32.SendMessage(objProcess.MainWindowHandle, (INT_MESSAGE_ID + intMensagemId), 0, intData);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}