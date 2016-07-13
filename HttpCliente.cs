using System;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_i == null)
                    {
                        _i = new HttpCliente();
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

                return _i;
            }
        }

        private object objGetStrLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objGetStrLock != null)
                    {
                        return _objGetStrLock;
                    }

                    _objGetStrLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objGetStrLock;
            }
        }

        private object objUploadStringLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objUploadStringLock != null)
                    {
                        return _objUploadStringLock;
                    }

                    _objUploadStringLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objUploadStringLock;
            }
        }

        #endregion Atributos

        #region Construtores

        protected HttpCliente()
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Retorna uma "string" com o resultado da solicitação à "url".
        /// </summary>
        public string getStr(string url)
        {
            #region Variáveis

            WebClient objWebClient;
            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lock (this.objGetStrLock)
                {
                    objWebClient = new WebClient();
                    strResultado = objWebClient.DownloadString(url);
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

        public string uploadArq(string url, ArquivoMain arq)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (arq == null)
                {
                    return string.Empty;
                }

                if (!File.Exists(arq.dirCompleto))
                {
                    return string.Empty;
                }

                return this.uploadString(url, File.ReadAllText(arq.dirCompleto));
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
        /// Enviar uma string para o servidor pelo método POST.
        /// </summary>
        public string uploadString(string url, string strObj)
        {
            #region Variáveis

            HttpWebRequest objHttpWebRequest;
            HttpWebResponse objHttpWebResponse;
            StreamReader objStreamReader;
            StreamWriter objStreamWriter;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(strObj))
                {
                    return string.Empty;
                }

                lock (this.objUploadStringLock)
                {
                    objHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                    objHttpWebRequest.ContentType = "text/json";
                    objHttpWebRequest.Method = "POST";

                    objStreamWriter = new StreamWriter(objHttpWebRequest.GetRequestStream());

                    objStreamWriter.Write(strObj);
                    objStreamWriter.Flush();
                    objStreamWriter.Close();

                    objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                    objStreamReader = new StreamReader(objHttpWebResponse.GetResponseStream(), Encoding.Default);

                    return objStreamReader.ReadToEnd();
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
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}