﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DigoFramework
{
    public sealed class Log
    {
        #region Constantes

        private enum EnmTipo
        {
            DEBUG,
            ERRO,
            INFO,
            VERBOSE,
        }

        #endregion Constantes

        #region Atributos

        private static Log _i;

        private bool _booDetalhado;
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

        public bool booDetalhado
        {
            get
            {
                return _booDetalhado;
            }

            set
            {
                _booDetalhado = value;
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

        public void debug(string strLog, params object[] arrObjParam)
        {
            this.addLog(strLog, EnmTipo.DEBUG, arrObjParam);
        }

        public void detalhe(string strLog, params object[] arrObjParam)
        {
            if (!this.booDetalhado)
            {
                return;
            }

            this.addLog(strLog, EnmTipo.VERBOSE, arrObjParam);
        }

        public void erro(Exception ex)
        {
            if (ex == null)
            {
                return;
            }

            this.addLog("{0} ({1}){2}{3}", EnmTipo.ERRO, ex.Message, ex.GetType().FullName, Environment.NewLine, ex.StackTrace);
        }

        public void erro(string strLog, params object[] arrObjParam)
        {
            this.addLog(strLog, EnmTipo.ERRO, arrObjParam);
        }

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

        public void info(string strLog, params object[] arrObjParam)
        {
            this.addLog(strLog, EnmTipo.INFO, arrObjParam);
        }

        private void addLog(string strLog, EnmTipo enmTipo, params object[] arrObjParam)
        {
            if (string.IsNullOrEmpty(strLog))
            {
                return;
            }

            if ((arrObjParam != null) && (arrObjParam.Length > 0))
            {
                strLog = string.Format(strLog, arrObjParam);
            }

            var strLogFinal = "_tipo (_tme): _log";

            strLogFinal = strLogFinal.Replace("_tipo", this.getStrTipo(enmTipo));
            strLogFinal = strLogFinal.Replace("_tme", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
            strLogFinal = strLogFinal.Replace("_log", strLog);

            Console.ForegroundColor = this.getCor(enmTipo);

            Console.WriteLine(strLogFinal);

            Debug.WriteLine(strLogFinal);

            this.lstKpvLog.Add(new KeyValuePair<DateTime, string>(DateTime.Now, strLogFinal));
        }

        private ConsoleColor getCor(EnmTipo enmTipo)
        {
            switch (enmTipo)
            {
                case EnmTipo.DEBUG:
                    return ConsoleColor.Cyan;

                case EnmTipo.ERRO:
                    return ConsoleColor.DarkRed;

                case EnmTipo.VERBOSE:
                    return ConsoleColor.Yellow;

                default:
                    return ConsoleColor.White;
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

        private string getStrTipo(EnmTipo enmTipo)
        {
            switch (enmTipo)
            {
                case EnmTipo.DEBUG:
                    return "Debug";

                case EnmTipo.ERRO:
                    return "Erro";

                case EnmTipo.VERBOSE:
                    return "Detalhe";

                default:
                    return "Info";
            }
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}