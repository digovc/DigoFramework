using DigoFramework.mail;

namespace DigoFramework.google
{
    public abstract class Conta : Google
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private EmailConta _objEmailConta;

        public EmailConta objEmailConta
        {
            get
            {
                return _objEmailConta;
            }

            set
            {
                _objEmailConta = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion

        #region EVENTOS

        #endregion
    }
}