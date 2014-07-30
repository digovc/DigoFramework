using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace DigoFramework.Mail
{
    public class Email : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private List<Attachment> _lstObjAnexo;
        private List<MailAddress> _lstObjDestinatario;
        private List<MailAddress> _lstObjDestinatarioCc;
        private List<MailAddress> _lstObjDestinatarioCco;
        private EmailConta _objEmailConta;
        private MailMessage _objMailMessagem;
        private string _strAssunto;
        private string _strMensagem;

        public List<Attachment> lstObjAnexo
        {
            get
            {
                return _lstObjAnexo;
            }

            set
            {
                _lstObjAnexo = value;
            }
        }

        public List<MailAddress> lstObjDestinatario
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjDestinatario != null)
                    {
                        return _lstObjDestinatario;
                    }

                    _lstObjDestinatario = new List<MailAddress>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjDestinatario;
            }

            set
            {
                _lstObjDestinatario = value;
            }
        }

        public List<MailAddress> lstObjDestinatarioCc
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjDestinatarioCc != null)
                    {
                        return _lstObjDestinatarioCc;
                    }

                    _lstObjDestinatarioCc = new List<MailAddress>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjDestinatarioCc;
            }

            set
            {
                _lstObjDestinatarioCc = value;
            }
        }

        public List<MailAddress> lstObjDestinatarioCco
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjDestinatarioCco != null)
                    {
                        return _lstObjDestinatarioCco;
                    }

                    _lstObjDestinatarioCco = new List<MailAddress>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjDestinatarioCco;
            }

            set
            {
                _lstObjDestinatarioCco = value;
            }
        }

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

        public MailMessage objMailMessagem
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_objMailMessagem != null)
                    {
                        return _objMailMessagem;
                    }

                    _objMailMessagem = new MailMessage();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _objMailMessagem;
            }

            set
            {
                _objMailMessagem = value;
            }
        }

        public string strAssunto
        {
            get
            {
                return _strAssunto;
            }

            set
            {
                _strAssunto = value;
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

        public Email(EmailConta objEmailConta)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.objEmailConta = objEmailConta;
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

        public void enviar()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.objMailMessagem.From = new MailAddress(this.objEmailConta.strEmailEndereco);

                foreach (MailAddress objDestinatario in this.lstObjDestinatario)
                {
                    this.objMailMessagem.To.Add(objDestinatario);
                }

                foreach (MailAddress objDestinatarioCc in this.lstObjDestinatarioCc)
                {
                    this.objMailMessagem.CC.Add(objDestinatarioCc);
                }

                foreach (MailAddress objDestinatarioCco in this.lstObjDestinatarioCco)
                {
                    this.objMailMessagem.Bcc.Add(objDestinatarioCco);
                }

                foreach (Attachment objAnexo in this.lstObjAnexo)
                {
                    this.objMailMessagem.Attachments.Add(objAnexo);
                }

                this.objMailMessagem.Subject = this.strAssunto;
                this.objMailMessagem.Body = strMensagem;
                this.objMailMessagem.IsBodyHtml = true;

                this.objEmailConta.objSmtpClient.EnableSsl = true;
                this.objEmailConta.objSmtpClient.UseDefaultCredentials = false;
                this.objEmailConta.objSmtpClient.Credentials = this.objEmailConta.objLoginInfo;
                this.objEmailConta.objSmtpClient.Send(objMailMessagem);
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
    }
}