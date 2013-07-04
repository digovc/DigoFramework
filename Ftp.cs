using System;
using System.IO;
using System.Net;

namespace DigoFramework
{
    public class Ftp : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Int32 _intProcesso = 0;
        public Int32 intProcesso { get { return _intProcesso; } }

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


        public void uploadArquivo(string dirArquivo)
        {
            FileInfo objFileInfo = new FileInfo(dirArquivo);
            string uri = "ftp://" + strServer + "/" + objFileInfo.Name;
            FtpWebRequest objFtpWebRequest;

            // Cria objeto FtpWebRequest
            objFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + strServer + "/" + objFileInfo.Name));
            // Cria credenciais
            objFtpWebRequest.Credentials = new NetworkCredential(strUser, strPassword);
            // Desativa a conexão ao terminar
            objFtpWebRequest.KeepAlive = false;
            // Especifica o comando que será executado
            objFtpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
            // Especifica que o arquivo é binário
            objFtpWebRequest.UseBinary = true;
            // Notifica o servidor do tamanho do arquivo que será enviado
            objFtpWebRequest.ContentLength = objFileInfo.Length;
            // Seta o tamanho do buffer
            int intBuffTamanho = 2048;
            byte[] buff = new byte[intBuffTamanho];
            int intContentLen;
            // Abre um Stream (System.IO.FileStream) para ler o arquivo que será enviado
            FileStream objFileStream = objFileInfo.OpenRead();
            try
            {
                // Stream to which the file to be upload is written
                Stream objStream = objFtpWebRequest.GetRequestStream();
                // Read from the file stream 2kb at a time
                intContentLen = objFileStream.Read(buff, 0, intBuffTamanho);
                //Int32 intQtdLoops = intContentLen / intBuffTamanho;                
                //intQtdLoops = 100 / intQtdLoops;
                // Till Stream content ends
                while (intContentLen != 0)
                {
                    // Write Content from the file stream to the 
                    // FTP Upload Stream
                    objStream.Write(buff, 0, intContentLen);
                    intContentLen = objFileStream.Read(buff, 0, intBuffTamanho);
                    //this._intProcesso += intQtdLoops;
                    System.Windows.Forms.Application.DoEvents();
                }
                // Close the file stream and the Request Stream
                objStream.Close();
                objFileStream.Close();
            }
            catch (Exception ex)
            {
                throw new Erro("Erro ao fazer Upload do arquivo.\n" + ex.Message, Erro.ErroTipo.Ftp);
            }
        }

        #endregion
    }
}
