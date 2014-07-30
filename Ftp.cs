using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DigoFramework
{
    public class Ftp : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private int _intProcesso;
        private NetworkCredential _objNetworkCredential;
        private string _strPassword;
        private string _strServer;
        private string _strUser;

        public int intProcesso
        {
            get
            {
                return _intProcesso;
            }
        }

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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (!_strServer.Contains("ftp://"))
                    {
                        _strServer = "ftp://" + _strServer;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _strServer;
            }

            set
            {
                _strServer = value;
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

        private NetworkCredential objNetworkCredential
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_objNetworkCredential != null)
                    {
                        return _objNetworkCredential;
                    }

                    _objNetworkCredential = new NetworkCredential(this.strUser, this.strPassword);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _objNetworkCredential;
            }
        }

        #endregion

        #region CONSTRUTORES

        public Ftp(string strServer, string strUser, string strPassword)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.strServer = strServer;
                this.strUser = strUser;
                this.strPassword = strPassword;
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

        public void downloadArquivo(string dirArquivoFtp, string dirArquivoLocal = "C:\\temp\\temp.data")
        {
            #region VARIÁVEIS

            bool booDownloadConcluido = false;
            long lngArquivoTamanho;

            #endregion

            #region AÇÕES

            try
            {
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
                                        Aplicativo.i.frmEspera.progressBarTarefa.Refresh();
                                    });
                                }
                            }
                            catch
                            {
                            }
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
                        string strTemp = ex.Message;
                        strTemp = ex.Message;
                    }

                    do
                    {
                        Application.DoEvents();
                    } while (!booDownloadConcluido);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException != null ? ex.InnerException : ex;
            }
            finally
            {
            }

            #endregion
        }

        public DateTime getDttArquivoUltimaModificacao(Arquivo.Arquivo objArquivo)
        {
            #region VARIÁVEIS

            FtpWebRequest objFtpWebRequest;
            FtpWebResponse objFtpWebResponse;

            #endregion

            #region AÇÕES

            try
            {
                objFtpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://" + this.strServer + "//" + objArquivo.strNome);
                objFtpWebRequest.Credentials = this.objNetworkCredential;
                objFtpWebRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                objFtpWebResponse = (FtpWebResponse)objFtpWebRequest.GetResponse();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return objFtpWebResponse.LastModified;
        }

        public void uploadArquivo(string dirArquivo)
        {
            #region VARIÁVEIS

            FileStream objFileStream;
            FileInfo objFileInfo;
            string url;
            FtpWebRequest objFtpWebRequest;
            int intBuffTamanho;
            byte[] arrBytes;
            int intContentLen;
            Stream objStream;

            #endregion

            #region AÇÕES

            try
            {
                objFileInfo = new FileInfo(dirArquivo);
                url = "ftp://" + strServer + "/" + objFileInfo.Name;

                objFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(url));
                objFtpWebRequest.Credentials = new NetworkCredential(strUser, strPassword);
                objFtpWebRequest.KeepAlive = false;
                objFtpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
                objFtpWebRequest.UseBinary = true;
                objFtpWebRequest.ContentLength = objFileInfo.Length;

                objFileStream = objFileInfo.OpenRead();

                try
                {
                    objStream = objFtpWebRequest.GetRequestStream();

                    intBuffTamanho = 2048;
                    arrBytes = new byte[intBuffTamanho];
                    intContentLen = objFileStream.Read(arrBytes, 0, intBuffTamanho);

                    while (intContentLen != 0)
                    {
                        objStream.Write(arrBytes, 0, intContentLen);
                        intContentLen = objFileStream.Read(arrBytes, 0, intBuffTamanho);
                        Application.DoEvents();
                    }
                    objStream.Close();
                    objFileStream.Close();
                }
                catch (Exception ex)
                {
                    new Erro("Erro ao fazer Upload do Arquivo.", ex, Erro.ErroTipo.FTP);
                }
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

        public void uploadArquivo(Arquivo.Arquivo objArquivo)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.uploadArquivo(objArquivo.dirCompleto);
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

        /// <summary>
        /// Retorna o tamanho em bytes de um arquivo no ftp.
        /// </summary>
        private long getLngArquivoTamanho(string dirArquivoFtp)
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

            #region AÇÕES

            try
            {
                objFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.strServer + "/" + dirArquivoFtp));
                objFtpWebRequest.Credentials = this.objNetworkCredential;
                objFtpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                objFtpWebResponse = (FtpWebResponse)objFtpWebRequest.GetResponse();

                objStream = objFtpWebResponse.GetResponseStream();
                objStreamReader = new StreamReader(objStream);

                // Grupos:
                // 1: object type:
                // 1. 1: d : directory
                // 1. 1: - : file
                // 2: Array[3] of permissions (rwx-)
                // 3: File Size
                // 4: Last Modified Date
                // 5: Last Modified Time
                // 6: File/Directory Name

                objRegex = new Regex(@"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                objMatch = objRegex.Match(objStreamReader.ReadLine());
                lngResultado = Convert.ToInt64(objMatch.Groups[3].Value);
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

            #endregion

            return lngResultado;
        }

        #endregion
    }
}