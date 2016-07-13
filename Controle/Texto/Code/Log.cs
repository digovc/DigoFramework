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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_intLogId > 0)
                    {
                        return _intLogId;
                    }

                    _intLogId = this.intLogIdStatic++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.dtt = DateTime.Now;
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

        #endregion Construtores

        #region Métodos

        public override string ToString()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = "_log_dtt_time [_log_tipo]: _log_mensagem";

                strResultado = strResultado.Replace("_log_dtt_time", this.dtt.ToString("dd/MM/yyyy HH:mm:ss"));
                strResultado = strResultado.Replace("_log_tipo", this.enmTipo.ToString());
                strResultado = strResultado.Replace("_log_mensagem", this.strLog);

                return strResultado;
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