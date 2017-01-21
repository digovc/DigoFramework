using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DigoFramework
{
    public sealed class Log
    {
        #region Constantes

        enum EnmTipo
        {
            ERRO,
            INFO,
        }

        #endregion Constantes

        #region Atributos

        private static Log _i;

        private List<KeyValuePair<DateTime, string>> _lstKpvLog;

        public static Log i
        {
            get
            {
                if (_i != null)
                {
                    return _i;
                }

                _i = new Log();

                return _i;
            }
        }

        private List<KeyValuePair<DateTime, string>> lstKpvLog
        {
            get
            {
                if (_lstKpvLog != null)
                {
                    return _lstKpvLog;
                }

                _lstKpvLog = new List<KeyValuePair<DateTime, string>>();

                return _lstKpvLog;
            }
        }

        #endregion Atributos

        #region Construtores

        private Log()
        {
        }

        #endregion Construtores

        #region Métodos

        public string getStrHistorico(DateTime dtt)
        {
            if (this.lstKpvLog.Count < 1)
            {
                return null;
            }

            StringBuilder stbResultado = new StringBuilder();

            foreach (KeyValuePair<DateTime, string> kpvLog in this.lstKpvLog)
            {
                this.getStrHistorico(dtt, kpvLog, stbResultado);
            }

            return stbResultado.ToString();
        }

        public void info(string strLog, params string[] arrParam)
        {
            this.addLog(strLog, EnmTipo.INFO, arrParam);
        }

        public void erro(string strLog, params string[] arrParam)
        {
            this.addLog(strLog, EnmTipo.ERRO, arrParam);
        }

        public void erro(Exception ex)
        {
            if (ex == null)
            {
                return;
            }

            this.addLog("Erro do tipo \"{0}\": {1}{2}{2}{3}", EnmTipo.ERRO, ex.GetType().Name, ex.Message, Environment.NewLine, ex.StackTrace);
        }

        private void addLog(string strLog, EnmTipo enmTipo, params string[] arrParam)
        {
            if (string.IsNullOrEmpty(strLog))
            {
                return;
            }

            if (arrParam != null)
            {
                strLog = string.Format(strLog, arrParam);
            }

            string strLogFinal = "_tipo (_tme): _log";

            strLogFinal = strLogFinal.Replace("_tipo", this.getStrTipo(enmTipo));
            strLogFinal = strLogFinal.Replace("_tme", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            strLogFinal = strLogFinal.Replace("_log", strLog);

            Console.WriteLine(strLogFinal);
            Debug.WriteLine(strLogFinal);

            this.lstKpvLog.Add(new KeyValuePair<DateTime, string>(DateTime.Now, strLogFinal));
        }

        private string getStrTipo(EnmTipo enmTipo)
        {
            switch (enmTipo)
            {
                case EnmTipo.ERRO:
                    return "Erro";

                default:
                    return "Info";
            }
        }

        private void getStrHistorico(DateTime dtt, KeyValuePair<DateTime, string> kpvLog, StringBuilder stbResultado)
        {
            if (!kpvLog.Key.Year.Equals(dtt.Year))
            {
                return;
            }

            if (!kpvLog.Key.Month.Equals(dtt.Month))
            {
                return;
            }

            if (!kpvLog.Key.Day.Equals(dtt.Day))
            {
                return;
            }

            stbResultado.AppendLine(kpvLog.Value);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}