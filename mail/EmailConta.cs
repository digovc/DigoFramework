using System;
using System.Net;
using System.Net.Mail;

namespace DigoFramework.mail
{
    public class EmailConta : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private NetworkCredential _objLoginInfo;
        private SmtpClient _objSmtpClient = new SmtpClient("smtp.gmail.com", 587);

        private String _strEmailEndereco = String.Empty;

        private String _strSenha = String.Empty;

        private String _strUsuarioNome = "User";

        public NetworkCredential objLoginInfo
        {
            get
            {
                return _objLoginInfo;
            }

            set
            {
                _objLoginInfo = value;
            }
        }

        public SmtpClient objSmtpClient
        {
            get
            {
                return _objSmtpClient;
            }

            set
            {
                _objSmtpClient = value;
            }
        }

        public String strEmailEndereco
        {
            get
            {
                return _strEmailEndereco;
            }

            set
            {
                _strEmailEndereco = value;
            }
        }

        public String strSenha
        {
            get
            {
                return _strSenha;
            }

            set
            {
                _strSenha = value;
            }
        }

        public String strUsuarioNome
        {
            get
            {
                return _strUsuarioNome;
            }

            set
            {
                _strUsuarioNome = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}