namespace DigoFramework
{
    public class MensagemUsuario : Objeto
    {
        #region Constantes

        public enum EnmLingua
        {
            INGLES,
            PORTUGUES,
        }

        #endregion Constantes

        #region Atributos

        private EnmLingua _enmLingua = EnmLingua.PORTUGUES;
        private int _intId;
        private string _strMsg;

        public EnmLingua enmLingua
        {
            get
            {
                return _enmLingua;
            }

            set
            {
                _enmLingua = value;
            }
        }

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

        public MensagemUsuario(string strMsg, int intId, EnmLingua objLingua = EnmLingua.PORTUGUES)
        {
            this.enmLingua = objLingua;
            this.intId = intId;
            this.strMsg = strMsg;
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}