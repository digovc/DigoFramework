using System;
using System.Net.Mail;
using System.Net;

namespace DigoFramework.Mailing
{
    public class EmailConta : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private NetworkCredential _objLoginInfo;
        public NetworkCredential objLoginInfo { get { return _objLoginInfo; } set { _objLoginInfo = value; } }

        private SmtpClient _objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
        public SmtpClient objSmtpClient { get { return _objSmtpClient; } set { _objSmtpClient = value; } }

        private String _strEmailEndereco = String.Empty;
        public String strEmailEndereco { get { return _strEmailEndereco; } set { _strEmailEndereco = value; } }
        
        private String _strUsuarioNome = "User";
        public String strUsuarioNome { get { return _strUsuarioNome; } set { _strUsuarioNome = value; } }

        private String _strSenha = String.Empty;
        public String strSenha { get { return _strSenha; } set { _strSenha = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}
