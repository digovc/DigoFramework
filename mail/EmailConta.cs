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
        private SmtpClient _objSmtpClient;
        private string _strEmailEndereco;
        private string _strSenha;
        private string _strUsuarioNome;

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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_objSmtpClient != null)
                    {
                        return _objSmtpClient;
                    }

                    _objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _objSmtpClient;
            }

            set
            {
                _objSmtpClient = value;
            }
        }

        public string strEmailEndereco
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

        public string strSenha
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

        public string strUsuarioNome
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strUsuarioNome))
                    {
                        return _strUsuarioNome;
                    }

                    _strUsuarioNome = "User";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

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