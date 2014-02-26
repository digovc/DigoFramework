using Google.Apis.Drive.v2;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Services;
using DigoFramework.mail;

namespace DigoFramework.google
{
    public abstract class Google : Objeto
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private ContaServico _objContaServico;
        public ContaServico objContaServico
        {
            get
            {
                if (_objContaServico == null)
                {
                    _objContaServico = new ContaServico();
                    _objContaServico.objEmailConta = new EmailConta()
                    {
                        strEmailEndereco = "866891830258-6ue3dsrpo4s9i1eu5v4jiuhok5tmtojb@developer.gserviceaccount.com",
                    };
                }
                return _objContaServico;
            }
            set { _objContaServico = value; }
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
