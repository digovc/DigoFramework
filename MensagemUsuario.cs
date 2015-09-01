using System;

namespace DigoFramework
{
    public class MensagemUsuario : Objeto
    {
        #region Constantes

        public enum Lingua
        {
            PORTUGUES,
            INGLES
        }

        #endregion Constantes

        #region Atributos

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

        #endregion Atributos

        #region Construtores

        public MensagemUsuario(string strMsg, int intId, Lingua objLingua = Lingua.PORTUGUES)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}