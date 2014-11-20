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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public MensagemUsuario(string strMensagem, int intId = -1, Lingua objLingua = Lingua.PORTUGUES)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}