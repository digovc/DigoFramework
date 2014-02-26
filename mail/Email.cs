using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace DigoFramework.mail
{
    public class Email : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private List<Attachment> _lstObjAnexo;
        public List<Attachment> lstObjAnexo { get { return _lstObjAnexo; } set { _lstObjAnexo = value; } }

        private List<MailAddress> _lstObjDestinatario = new List<MailAddress>();
        public List<MailAddress> lstObjDestinatario { get { return _lstObjDestinatario; } set { _lstObjDestinatario = value; } }

        private List<MailAddress> _lstObjDestinatarioCc = new List<MailAddress>();
        public List<MailAddress> lstObjDestinatarioCc { get { return _lstObjDestinatarioCc; } set { _lstObjDestinatarioCc = value; } }

        private List<MailAddress> _lstObjDestinatarioCco = new List<MailAddress>();
        public List<MailAddress> lstObjDestinatarioCco { get { return _lstObjDestinatarioCco; } set { _lstObjDestinatarioCco = value; } }

        private EmailConta _objEmailConta;
        public EmailConta objEmailConta { get { return _objEmailConta; } set { _objEmailConta = value; } }

        private MailMessage _objMailMessagem = new MailMessage();
        public MailMessage objMailMessagem { get { return _objMailMessagem; } set { _objMailMessagem = value; } }

        private String _strAssunto = String.Empty;
        public String strAssunto { get { return _strAssunto; } set { _strAssunto = value; } }

        private String _strMensagem = String.Empty;
        public String strMensagem { get { return _strMensagem; } set { _strMensagem = value; } }

        #endregion

        #region CONSTRUTORES

        public Email(EmailConta objContaEmail)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES
            #endregion
        }

        #endregion

        #region MÉTODOS

        public void envia()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objMailMessagem.From = new MailAddress(this.objEmailConta.strEmailEndereco);
            // Destinatários
            foreach (MailAddress objDestinatario in this.lstObjDestinatario)
            {
                this.objMailMessagem.To.Add(objDestinatario);
            }
            // Destinatários com cópia
            foreach (MailAddress objDestinatarioCc in this.lstObjDestinatarioCc)
            {
                this.objMailMessagem.CC.Add(objDestinatarioCc);
            }
            // Destinatários com cópia oculta
            foreach (MailAddress objDestinatarioCco in this.lstObjDestinatarioCco)
            {
                this.objMailMessagem.Bcc.Add(objDestinatarioCco);
            }
            // Anexos
            foreach (Attachment objAnexo in this.lstObjAnexo)
            {
                this.objMailMessagem.Attachments.Add(objAnexo);
            }

            // Assunto
            this.objMailMessagem.Subject = this.strAssunto;
            // Corpo da mensagem
            this.objMailMessagem.Body = strMensagem;

            // Configurações finais
            objMailMessagem.IsBodyHtml = true;
            this.objEmailConta.objSmtpClient.EnableSsl = true;
            this.objEmailConta.objSmtpClient.UseDefaultCredentials = false;
            this.objEmailConta.objSmtpClient.Credentials = this.objEmailConta.objLoginInfo;
            // Envia o email
            this.objEmailConta.objSmtpClient.Send(objMailMessagem);

            #endregion
        }

        #endregion
    }
}
