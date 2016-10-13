using System;

namespace DigoFramework.Controle.Texto.Code
{
    public class Log : Objeto
    {
        #region Constantes

        public enum EnmTipo
        {
            ERRO,
            INFO,
            NOTIFICACAO,
        }

        #endregion Constantes

        #region Atributos

        private static int _intLogIdStatic;
        private DateTime _dtt;
        private EnmTipo _enmTipo = EnmTipo.INFO;
        private int _intLogId;
        private string _strLog;

        public EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        public string strLog
        {
            get
            {
                return _strLog;
            }

            set
            {
                _strLog = value;
            }
        }

        private DateTime dtt
        {
            get
            {
                return _dtt;
            }

            set
            {
                _dtt = value;
            }
        }

        private int intLogId
        {
            get
            {
                if (_intLogId > 0)
                {
                    return _intLogId;
                }

                _intLogId = this.intLogIdStatic++;

                return _intLogId;
            }
        }

        private int intLogIdStatic
        {
            get
            {
                return _intLogIdStatic;
            }

            set
            {
                _intLogIdStatic = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Log()
        {
            this.dtt = DateTime.Now;
        }

        #endregion Construtores

        #region Métodos

        public override string ToString()
        {
            string strResultado;

            strResultado = "_log_dtt_time [_log_tipo]: _log_mensagem";

            strResultado = strResultado.Replace("_log_dtt_time", this.dtt.ToString("dd/MM/yyyy HH:mm:ss"));
            strResultado = strResultado.Replace("_log_tipo", this.enmTipo.ToString());
            strResultado = strResultado.Replace("_log_mensagem", this.strLog);

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}