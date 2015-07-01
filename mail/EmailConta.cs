using System;
using System.Net;
using System.Net.Mail;

namespace DigoFramework.Mail
{
    public class EmailConta : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

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

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

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

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!string.IsNullOrEmpty(_strUsuarioNome))
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

                #endregion AÇÕES

                return _strUsuarioNome;
            }

            set
            {
                _strUsuarioNome = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS
    }
}