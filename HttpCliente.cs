using DigoFramework.Arquivo;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace DigoFramework
{
    public class HttpCliente : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private static HttpCliente _i;

        public static HttpCliente i
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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

                #endregion AÇÕES

                return _i;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        private HttpCliente()
        {

        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Retorna uma "string" com o resultado da solicitação à "url".
        /// </summary>
        public string getStr(string url)
        {
            #region VARIÁVEIS

            WebClient objWebClient;
            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lock (this.lockCode)
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

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Enviar uma string para o servidor pelo método POST.
        /// </summary>
        public string uploadString(string url, string strObj)
        {
            #region VARIÁVEIS

            HttpWebRequest objHttpWebRequest;
            HttpWebResponse objHttpWebResponse;
            StreamReader objStreamReader;
            StreamWriter objStreamWriter;

            #endregion VARIÁVEIS

            #region AÇÕES
            try
            {
                if (String.IsNullOrEmpty(strObj))
                {
                    return Utils.STR_VAZIA;
                }

                lock (this.lockCode)
                {

                    objHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                    objHttpWebRequest.ContentType = "text/json";
                    objHttpWebRequest.Method = "POST";

                    objStreamWriter = new StreamWriter(objHttpWebRequest.GetRequestStream());

                    objStreamWriter.Write(strObj);
                    objStreamWriter.Flush();
                    objStreamWriter.Close();

                    objHttpWebResponse = (HttpWebResponse)objHttpWebRequest.GetResponse();

                    objStreamReader = new StreamReader(objHttpWebResponse.GetResponseStream());

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
            #endregion AÇÕES
        }

        public string uploadArq(string url, ArquivoMain arq)
        {
            #region VARIÁVEIS
            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (arq == null)
                {
                    return Utils.STR_VAZIA;
                }

                if (!File.Exists(arq.dirCompleto))
                {
                    return Utils.STR_VAZIA;
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

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}