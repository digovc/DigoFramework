using System;

namespace DigoFramework
{
    public class MensagemUsuario : Objeto
    {
        #region CONSTANTES

        public enum Lingua
        {
            PORTUGUES,
            INGLES
        }

        #endregion CONSTANTES

        #region ATRIBUTOS

        private int _intId;
        private Lingua _objLingua = Lingua.PORTUGUES;
        private string _strMsg;

        public int intId
        {
            get
            {
                return _intId;
            }

            set
            {
                _intId = value;
            }
        }

        public Lingua objLingua
        {
            get
            {
                return _objLingua;
            }

            set
            {
                _objLingua = value;
            }
        }

        public string strMsg
        {
            get
            {
                return _strMsg;
            }

            set
            {
                _strMsg = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public MensagemUsuario(string strMsg, int intId, Lingua objLingua = Lingua.PORTUGUES)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.intId = intId;
                this.objLingua = objLingua;
                this.strMsg = strMsg;
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

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}