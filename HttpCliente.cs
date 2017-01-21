using System.IO;
using System.Net;
using System.Text;
using DigoFramework.Arquivo;

namespace DigoFramework
{
    public class HttpCliente : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static HttpCliente _i;

        private object _objGetStrLock;
        private object _objUploadStringLock;

        public static HttpCliente i
        {
            get
            {
                if (_i == null)
                {
                    _i = new HttpCliente();
                }

                return _i;
            }
        }

        private object objGetStrLock
        {
            get
            {
                if (_objGetStrLock != null)
                {
                    return _objGetStrLock;
                }

                _objGetStrLock = new object();

                return _objGetStrLock;
            }
        }

        private object objUploadStringLock
        {
            get
            {
                if (_objUploadStringLock != null)
                {
                    return _objUploadStringLock;
                }

                _objUploadStringLock = new object();

                return _objUploadStringLock;
            }
        }

        #endregion Atributos

        #region Construtores

        private HttpCliente()
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Retorna uma "string" com o resultado da solicitação à "url".
        /// </summary>
        public string getStr(string url)
        {
            lock (this.objGetStrLock)
            {
                WebClient objWebClient = new WebClient();

                return objWebClient.DownloadString(url);
            }
        }

        public string uploadArquivo(string url, ArquivoBase arq)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }

            if (arq == null)
            {
                return null;
            }

            if (!File.Exists(arq.dirCompleto))
            {
                return null;
            }

            return this.uploadString(url, File.ReadAllText(arq.dirCompleto));
        }

        /// <summary>
        /// Enviar uma string para o servidor pelo método POST.
        /// </summary>
        public string uploadString(string url, string strObj)
        {
            if (string.IsNullOrEmpty(strObj))
            {
                return string.Empty;
            }

            lock (this.objUploadStringLock)
            {
                HttpWebRequest objHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                objHttpWebRequest.ContentType = "text/json";
                objHttpWebRequest.Method = "POST";

                StreamWriter objStreamWriter = new StreamWriter(objHttpWebRequest.GetRequestStream());

                objStreamWriter.Write(strObj);
                objStreamWriter.Flush();
                objStreamWriter.Close();

                HttpWebResponse objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                StreamReader objStreamReader = new StreamReader(objHttpWebResponse.GetResponseStream(), Encoding.Default);

                return objStreamReader.ReadToEnd();
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}