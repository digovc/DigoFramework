﻿using System;
using System.IO;
using System.Net;
using DigoFramework.ArquivoSis;

namespace DigoFramework
{
    public class Ftp : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Int32 _intProcesso = 0;
        public Int32 intProcesso { get { return _intProcesso; } }

        public NetworkCredential objNetworkCredential
        {
            get
            {
                return new NetworkCredential(this.strUser, this.strPassword);
            }
        }

        private String _strPassword = String.Empty;
        public String strPassword { get { return _strPassword; } set { _strPassword = value; } }

        private String _strServer = String.Empty;
        public String strServer { get { return _strServer; } set { _strServer = value; } }

        private String _strUser = String.Empty;
        public String strUser { get { return _strUser; } set { _strUser = value; } }

        #endregion

        #region CONSTRUTORES

        public Ftp(String strServer, String strUser, String strPassword)
        {
            #region VARIÁVEIS

            this.strServer = strServer;
            this.strUser = strUser;
            this.strPassword = strPassword;

            #endregion

            #region AÇÕES
            #endregion
        }

        #endregion

        #region MÉTODOS

        public void downloadArquivo(String dirArquivoFtp, String dirArquivoLocal = "C:\\temp")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            using (WebClient objWebClient = new WebClient())
            {
                objWebClient.Credentials = this.objNetworkCredential;
                byte[] fileData = objWebClient.DownloadData(this.strServer + "//" + dirArquivoFtp);
                using (FileStream file = File.Create(dirArquivoLocal))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
            }

            #endregion
        }

        public DateTime getDttArquivoUltimaModificacao(Arquivo objArquivo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES


            // velho
            FtpWebRequest request = FtpWebRequest.Create(this.strServer + "//" + objArquivo.dirDiretorioFtp + "//" + objArquivo.strNome) as FtpWebRequest;
            request.KeepAlive = false;
            request.UsePassive = true;
            request.Credentials = this.objNetworkCredential;
            request.Method = WebRequestMethods.Ftp.GetDateTimestamp;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            return response.LastModified;

            #endregion
        }

        public void uploadArquivo(string dirArquivo)
        {
            #region VARIÁVEIS

            FileInfo objFileInfo = new FileInfo(dirArquivo);
            string uri = "ftp://" + strServer + "/" + objFileInfo.Name;
            FtpWebRequest objFtpWebRequest;
            int intBuffTamanho = 2048;
            byte[] buff = new byte[intBuffTamanho];
            int intContentLen;

            #endregion

            #region AÇÕES

            objFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));
            objFtpWebRequest.Credentials = new NetworkCredential(strUser, strPassword);
            objFtpWebRequest.KeepAlive = false;
            objFtpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            objFtpWebRequest.UseBinary = true;
            objFtpWebRequest.ContentLength = objFileInfo.Length;
            FileStream objFileStream = objFileInfo.OpenRead();
            try
            {
                Stream objStream = objFtpWebRequest.GetRequestStream();
                intContentLen = objFileStream.Read(buff, 0, intBuffTamanho);
                while (intContentLen != 0)
                {
                    objStream.Write(buff, 0, intContentLen);
                    intContentLen = objFileStream.Read(buff, 0, intBuffTamanho);
                    System.Windows.Forms.Application.DoEvents();
                }
                objStream.Close();
                objFileStream.Close();
            }
            catch (Exception ex)
            {
                new Erro("Erro ao fazer Upload do Arquivo.", ex, Erro.ErroTipo.Ftp);
            }

            #endregion
        }
        public void uploadArquivo(Arquivo objArquivo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.uploadArquivo(objArquivo.dirDiretorioCompleto);

            #endregion
        }

        #endregion
    }
}
