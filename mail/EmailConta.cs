using System;
using System.Net;
using System.Net.Mail;

namespace DigoFramework.Mail
{
    public class EmailConta : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _strUsuarioNome;
            }

            set
            {
                _strUsuarioNome = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}