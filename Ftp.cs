using DigoFramework.Arquivo;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DigoFramework
{
    public class Ftp : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

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

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!_strServer.StartsWith("ftp://"))
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

                #endregion AÇÕES

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

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

                return _objNetworkCredential;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Ftp(string strServer, string strUser, string strPassword)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        public void downloadArquivo(string dirArquivoFtp, string dirArquivoLocal = "C:\\temp\\temp.data")
        {
            #region VARIÁVEIS

            bool booDownloadConcluido = false;
            long lngArqTamanho;
            WebClient objWebClient;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lngArqTamanho = this.getLngArquivoTamanho(dirArquivoFtp);

                objWebClient = new WebClient();
                objWebClient.Credentials = this.objNetworkCredential;

                if (Aplicativo.i.frmEspera.pgbParcial != null)
                {
                    objWebClient.DownloadProgressChanged += (s, e) =>
                    {
                        try
                        {
                            if (!Aplicativo.i.frmEspera.Visible)
                            {
                                return;
                            }

                            Aplicativo.i.frmEspera.pgbParcial.Invoke((MethodInvoker)delegate
                            {
                                Aplicativo.i.frmEspera.pgbParcial.Visible = true;
                                Aplicativo.i.frmEspera.pgbParcial.Value = (int)((decimal)e.BytesReceived / (decimal)lngArqTamanho * 100);
                                Aplicativo.i.frmEspera.pgbParcial.Refresh();
                            });
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

                            if (Aplicativo.i.frmEspera.Visible)
                            {
                                Aplicativo.i.frmEspera.pgbParcial.Invoke((MethodInvoker)delegate
                                {
                                    Aplicativo.i.frmEspera.pgbParcial.Value = 0;
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
                catch
                {
                }

                do
                {
                    Application.DoEvents();
                } while (!booDownloadConcluido);
            }
            catch (Exception ex)
            {
                throw ex.InnerException != null ? ex.InnerException : ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        public DateTime getDttArquivoUltimaModificacao(Arquivo.ArquivoMain objArquivo)
        {
            #region VARIÁVEIS

            FtpWebRequest objFtpWebRequest;
            FtpWebResponse objFtpWebResponse;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

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

            #endregion VARIÁVEIS

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
                    new Erro("Erro ao fazer Upload do ArquivoMain.", ex, Erro.ErroTipo.FTP);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        public void uploadArquivo(ArquivoMain objArquivo)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Retorna o tamanho em bytes de um arquivo no ftp.
        /// </summary>
        private long getLngArquivoTamanho(string dirArquivoFtp)
        {
            #region VARIÁVEIS

            FtpWebRequest objFtpWebRequest;
            long lngResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                objFtpWebRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(this.strServer + "/" + dirArquivoFtp));
                objFtpWebRequest.Credentials = this.objNetworkCredential;
                objFtpWebRequest.Method = WebRequestMethods.Ftp.GetFileSize;

                lngResultado = ((FtpWebResponse)objFtpWebRequest.GetResponse()).ContentLength;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return lngResultado;
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}