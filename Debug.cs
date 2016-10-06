using System;

namespace DigoFramework
{
    public sealed class Debug
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static Debug _i;

        public static Debug i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new Debug();

                return _i;
            }
        }

        #endregion Atributos

        #region Construtores

        private Debug()
        {
        }

        #endregion Construtores

        #region Métodos

        public void log(string strLog, params string[] arrParam)
        {
            if (string.IsNullOrEmpty(strLog))
            {
                return;
            }

            if (arrParam != null)
            {
                strLog = string.Format(strLog, arrParam);
            }

            string strLogFinal = "Info (_tme): _log";

            strLogFinal = strLogFinal.Replace("_tme", DateTime.Now.ToString("HH:mm:ss"));
            strLogFinal = strLogFinal.Replace("_log", strLog);

            Console.WriteLine(strLogFinal);
            System.Diagnostics.Debug.WriteLine(strLogFinal);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}