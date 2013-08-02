using Google.Apis.Drive.v2;
using System.Security.Cryptography.X509Certificates;
using Google.Apis.Authentication.OAuth2.DotNetOpenAuth;
using Google.Apis.Authentication.OAuth2;
using Google.Apis.Services;

namespace DigoFramework.GoogleApi
{
    public abstract class Google : Objeto
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private ContaServico _objContaServico;
        public ContaServico objContaServico { get { return _objContaServico; } set { _objContaServico = value; } }

        #endregion

        #region CONSTRUTORES
        #endregion

        #region MÉTODOS

        #endregion

        #region EVENTOS
        #endregion
    }
}
