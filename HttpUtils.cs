using DigoFramework.arquivo;
using System;
using System.Net;

namespace DigoFramework
{
    public sealed class HttpUtils
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Retorna uma "string" com o resultado da solicitação à "url".
        /// </summary>
        public static string getStr(string url)
        {
            #region VARIÁVEIS

            WebClient objWebClient;
            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                objWebClient = new WebClient();
                strResultado = objWebClient.DownloadString(url);
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

        public static void uploadArq(string url, Arquivo arq)
        {
            #region VARIÁVEIS

            WebClient objWebClient;

            #endregion

            #region AÇÕES

            try
            {
                objWebClient = new WebClient();
                objWebClient.UploadFile(url, "post", arq.dirCompleto);
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

        #endregion
    }
}