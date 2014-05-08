using System;
using System.IO;
using System.Net;
using DigoFramework.arquivo;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DigoFramework
{
    public class Ftp : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Int32 _intProcesso = 0;
        private String _strPassword = String.Empty;

        private String _strServer = String.Empty;

        private String _strUser = String.Empty;

        public Int32 intProcesso { get { return _intProcesso; } }

        public NetworkCredential objNetworkCredential
        {
            get
            {
                return new NetworkCredential(this.strUser, this.strPassword);
            }
        }
        public String strPassword { get { return _strPassword; } set { _strPassword = value; } }
        public String strServer
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (!_strServer.Contains("ftp://"))
                    {
                        _strServer = "ftp://" + _strServer;
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _strServer;
            }
            set { _strServer = value; }
        }
        public String strUser { get { return _strUser; } set { _strUser = value; } }

        #endregion

        #region CONSTRUTORES

        public Ftp() { }

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

        public void downloadArquivo(String dirArquivoFtp, String dirArquivoLocal = "C:\\temp\\temp.data")
        {
            #region VARIÁVEIS

            Boolean booDownloadConcluido = false;
            long lngArquivoTamanho;

            #endregion
            try
            {
                #region AÇÕES

                lngArquivoTamanho = this.getLngArquivoTamanho(dirArquivoFtp);

                using (WebClient objWebClient = new WebClient())
                {
                    objWebClient.Credentials = this.objNetworkCredential;

                    if (Aplicativo.i.frmEspera.progressBarTarefa != null)
                    {
                        objWebClient.DownloadProgressChanged += (s, e) =>
                        {
                            try
                            {
                                if (Aplicativo.i.frmEspera.Visible == true)
                                {
                                    Aplicativo.i.frmEspera.progressBarTarefa.Invoke((MethodInvoker)delegate
                                    {
                                        Aplicativo.i.frmEspera.progressBarTarefa.Visible = true;
                                        Aplicativo.i.frmEspera.progressBarTarefa.Value = (int)((decimal)e.BytesReceived / (decimal)lngArquivoTamanho * 100);
                                        Application.DoEvents();
                                    });
                                }
                            }
                            catch { }
                        };

                        objWebClient.DownloadFileCompleted += (s, e) =>
                        {
                            try
                            {
                                booDownloadConcluido = true;

                                if (Aplicativo.i.frmEspera.Visible == true)
                                {
                                    Aplicativo.i.frmEspera.progressBarTarefa.Invoke((MethodInvoker)delegate
                                    {
                                        Aplicativo.i.frmEspera.progressBarTarefa.Value = 0;
                                    });
                                }

                                if (e.Error != null)
                                {
                                    throw new Exception("Erro ao fazer download do arquivo.");
                                }

                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        };
                    }

                    try
                    {
                        objWebClient.DownloadFileAsync(new Uri(this.strServer + "/" + dirArquivoFtp), dirArquivoLocal);
                    }
                    catch (Exception ex)
                    {
                        String strTemp = ex.Message;
                        strTemp = ex.Message;
                    }

                    do
                    {
                        Application.DoEvents();
                    } while (!booDownloadConcluido);
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex.InnerException != null ? ex.InnerException : ex;
            }
            finally
            {
            }
        }

        public DateTime getDttArquivoUltimaModificacao(Arquivo objArquivo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + this.strServer + "//" + objArquivo.strNome);
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

            this.uploadArquivo(objArquivo.dirCompleto);

            #endregion
        }

        /// <summary>
        /// Retorna o tamanho em bytes de um arquivo no ftp.
        /// </summary>
        private long getLngArquivoTamanho(String dirArquivoFtp)
        {
            #region VARIÁVEIS

            FtpWebRequest objFtpWebRequest = null;
            FtpWebResponse objFtpWebResponse = null;
            long lngResultado = 0;
            Match objMatch = null;
            Regex objRegex = null;
            Stream objStream = null;
            StreamReader objStreamReader = null;

            #endregion
            try
            {
                #region AÇÕES

                objFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.strServer + "/" + dirArquivoFtp));
                objFtpWebRequest.Credentials = this.objNetworkCredential;
                objFtpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                objFtpWebResponse = (FtpWebResponse)objFtpWebRequest.GetResponse();

                objStream = objFtpWebResponse.GetResponseStream();
                objStreamReader = new StreamReader(objStream);

                // Grupos:
                // 1: object type:
                // 1.1: d : directory
                // 1.1: - : file
                // 2: Array[3] of permissions (rwx-)
                // 3: File Size
                // 4: Last Modified Date
                // 5: Last Modified Time
                // 6: File/Directory Name

                objRegex = new Regex(@"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$",
RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                objMatch = objRegex.Match(objStreamReader.ReadLine());
                lngResultado = Convert.ToInt64(objMatch.Groups[3].Value);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objFtpWebResponse.Close();
                objStream.Close();
                objStreamReader.Close();
            }

            return lngResultado;
        }

        #endregion
    }
}
