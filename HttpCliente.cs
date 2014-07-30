using System;
using System.Net;

namespace DigoFramework
{
    public class HttpCliente : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private static HttpCliente _i;

        public static HttpCliente i
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _i;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Retorna uma "string" com o resultado da solicitação à "url".
        /// </summary>
        public string getStr(string url)
        {
            #region VARIÁVEIS

            WebClient objWebClient;
            string strResultado;

            #endregion

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

            #endregion

            return strResultado;
        }

        public string uploadArq(string url, Arquivo.ArquivoMain arq)
        {
            #region VARIÁVEIS

            byte[] arrBytes;
            WebClient objWebClient;
            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                lock (this.lockCode)
                {
                    objWebClient = new WebClient();
                    arrBytes = objWebClient.UploadFile(url, "post", arq.dirCompleto);
                    strResultado = System.Text.Encoding.ASCII.GetString(arrBytes);
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

        #endregion

        #region EVENTOS

        #endregion
    }
}