using DigoFramework.Arquivo;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DigoFramework
{
    public class Ftp : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booDownloadConcluido;
        private NetworkCredential _objNetworkCredential;
        private string _strPassword;
        private string _strServer;
        private string _strUser;

        public string strPassword
        {
            get
            {
                return _strPassword;
            }

            set
            {
                _strPassword = value;
            }
        }

        public string strServer
        {
            get
            {
                if (!string.IsNullOrEmpty(_strServer))
                {
                    return _strServer;
                }

                return _strServer;
            }

            set
            {
                if (_strServer == value)
                {
                    return;
                }

                _strServer = value;

                this.setStrServer(_strServer);
            }
        }

        public string strUser
        {
            get
            {
                return _strUser;
            }

            set
            {
                _strUser = value;
            }
        }

        private bool booDownloadConcluido
        {
            get
            {
                return _booDownloadConcluido;
            }

            set
            {
                _booDownloadConcluido = value;
            }
        }

        private NetworkCredential objNetworkCredential
        {
            get
            {
                if (_objNetworkCredential != null)
                {
                    return _objNetworkCredential;
                }

                _objNetworkCredential = new NetworkCredential(this.strUser, this.strPassword);

                return _objNetworkCredential;
            }
        }

        #endregion Atributos

        #region Construtores

        public Ftp(string strServer, string strUser, string strPassword)
        {
            this.strPassword = strPassword;
            this.strServer = strServer;
            this.strUser = strUser;
        }

        #endregion Construtores

        #region Métodos

        public void downloadArquivo(string dirArquivoFtp, string dirArquivoLocal = "C:\\temp\\temp.data")
        {
            if (!this.validar())
            {
                return;
            }

            this.booDownloadConcluido = false;

            WebClient objWebClient = new WebClient();

            objWebClient.Credentials = this.objNetworkCredential;
            objWebClient.DownloadFileCompleted += this.objWebClient_DownloadFileCompleted;
            objWebClient.DownloadProgressChanged += this.objWebClient_DownloadProgressChanged;

            objWebClient.DownloadFileAsync(new Uri(this.strServer + "/" + dirArquivoFtp), dirArquivoLocal);

            do
            {
                Application.DoEvents();
            } while (!this.booDownloadConcluido);
        }

        public DateTime getDttArquivoUltimaModificacao(ArquivoBase objArquivo)
        {
            if (!this.validar())
            {
                return DateTime.MinValue;
            }

            FtpWebRequest objFtpWebRequest = (FtpWebRequest)WebRequest.Create(this.strServer + "//" + objArquivo.strNome);

            objFtpWebRequest.Credentials = this.objNetworkCredential;
            objFtpWebRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;

            FtpWebResponse objFtpWebResponse = (FtpWebResponse)objFtpWebRequest.GetResponse();

            return objFtpWebResponse.LastModified;
        }

        public void uploadArquivo(string dirArquivo)
        {
            if (!this.validar())
            {
                return;
            }

            if (string.IsNullOrEmpty(dirArquivo))
            {
                return;
            }

            if (!File.Exists(dirArquivo))
            {
                throw new FileNotFoundException(string.Format("O arquivo \"{0}\" não foi encontrado.", dirArquivo));
            }

            FileInfo objFileInfo = new FileInfo(dirArquivo);
            FileStream objFileStream = objFileInfo.OpenRead();

            FtpWebRequest objFtpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.strServer + "/" + objFileInfo.Name));

            objFtpWebRequest.ContentLength = objFileInfo.Length;
            objFtpWebRequest.Credentials = new NetworkCredential(strUser, strPassword);
            objFtpWebRequest.KeepAlive = false;
            objFtpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            objFtpWebRequest.UseBinary = true;

            Stream objStream = objFtpWebRequest.GetRequestStream();

            int intBuffTamanho = 2048;
            byte[] arrBytes = new byte[intBuffTamanho];
            int intContentLen = objFileStream.Read(arrBytes, 0, intBuffTamanho);

            while (intContentLen != 0)
            {
                objStream.Write(arrBytes, 0, intContentLen);
                intContentLen = objFileStream.Read(arrBytes, 0, intBuffTamanho);

                Application.DoEvents();
            }

            objFileStream.Close();
            objFileStream.Dispose();

            objStream.Close();
            objStream.Dispose();
        }

        public void uploadArquivo(ArquivoBase arq)
        {
            if (arq == null)
            {
                return;
            }

            this.uploadArquivo(arq.dirCompleto);
        }

        /// <summary>
        /// Retorna o tamanho em bytes de um arquivo no ftp.
        /// </summary>
        private long getLngArquivoTamanho(string dirArquivoFtp)
        {
            FtpWebRequest objFtpWebRequest = (FtpWebRequest)WebRequest.Create(new Uri(this.strServer + "/" + dirArquivoFtp));

            objFtpWebRequest.Credentials = this.objNetworkCredential;
            objFtpWebRequest.Method = WebRequestMethods.Ftp.GetFileSize;

            return ((FtpWebResponse)objFtpWebRequest.GetResponse()).ContentLength;
        }

        private void setStrServer(string strServer)
        {
            if (string.IsNullOrEmpty(strServer))
            {
                return;
            }

            if (strServer.StartsWith("ftp://"))
            {
                return;
            }

            this.strServer = ("ftp://" + strServer);
        }

        private bool validar()
        {
            if (string.IsNullOrEmpty(this.strServer))
            {
                throw new NullReferenceException("O endereço do FTP não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(this.strUser))
            {
                throw new NullReferenceException("O nome do usuário do FTP não pode estar vazio.");
            }

            if (string.IsNullOrEmpty(this.strPassword))
            {
                throw new NullReferenceException("A senha do usuário do FTP não pode estar vazio.");
            }

            return true;
        }

        #endregion Métodos

        #region Eventos

        private void objWebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (!AppBase.i.frmEspera.Visible)
                {
                    AppBase.i.frmEspera.decProgressoTarefa = AppBase.i.frmEspera.intProgressoMaximoTarefa;
                    return;
                }

                if (e.Error == null)
                {
                    return;
                }

                throw e.Error;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
            finally
            {
                this.booDownloadConcluido = true;
            }
        }

        private void objWebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                if (!AppBase.i.frmEspera.Visible)
                {
                    return;
                }

                AppBase.i.frmEspera.decProgressoTarefa = e.ProgressPercentage;
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}