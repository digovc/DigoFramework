using System.Collections.Generic;
using System.Net.Mail;

namespace DigoFramework.Mail
{
    public class Email : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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
                if (_lstObjDestinatario != null)
                {
                    return _lstObjDestinatario;
                }

                _lstObjDestinatario = new List<MailAddress>();

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
                if (_lstObjDestinatarioCc != null)
                {
                    return _lstObjDestinatarioCc;
                }

                _lstObjDestinatarioCc = new List<MailAddress>();

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
                if (_lstObjDestinatarioCco != null)
                {
                    return _lstObjDestinatarioCco;
                }

                _lstObjDestinatarioCco = new List<MailAddress>();

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
                if (_objMailMessagem != null)
                {
                    return _objMailMessagem;
                }

                _objMailMessagem = new MailMessage();

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

        #endregion Atributos

        #region Construtores

        public Email(EmailConta objEmailConta)
        {
            this.objEmailConta = objEmailConta;
        }

        #endregion Construtores

        #region Métodos

        public void enviar()
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

        #endregion Métodos
    }
}