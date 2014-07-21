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

        #endregion

        #region ATRIBUTOS

        private Lingua _objLingua = Lingua.PORTUGUES;
        private string _strMensagem;

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

        public string strMensagem
        {
            get
            {
                return _strMensagem;
            }

            set
            {
                _strMensagem = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        public MensagemUsuario(string strMensagem, int intId = -1, Lingua objLingua = Lingua.PORTUGUES)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.strMensagem = strMensagem;
                this.intId = intId;
                this.objLingua = objLingua;
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

        #region MÉTODOS

        #endregion

        #region EVENTOS

        #endregion
    }
}