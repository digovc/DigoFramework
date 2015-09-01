using DigoFramework.Arquivo;
using System;
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _objNetworkCredential;
            }
        }

        #endregion Atributos

        #region Construtores

        public Ftp(string strServer, string strUser, string strPassword)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        public void downloadArquivo(string dirArquivoFtp, string dirArquivoLocal = "C:\\temp\\temp.data")
        {
            #region Variáveis

            bool booDownloadConcluido = false;
            long lngArqTamanho;
            WebClient objWebClient;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public DateTime getDttArquivoUltimaModificacao(Arquivo.ArquivoMain objArquivo)
        {
            #region Variáveis

            FtpWebRequest objFtpWebRequest;
            FtpWebResponse objFtpWebResponse;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return objFtpWebResponse.LastModified;
        }

        public void uploadArquivo(string dirArquivo)
        {
            #region Variáveis

            FileStream objFileStream;
            FileInfo objFileInfo;
            string url;
            FtpWebRequest objFtpWebRequest;
            int intBuffTamanho;
            byte[] arrBytes;
            int intContentLen;
            Stream objStream;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public void uploadArquivo(ArquivoMain objArquivo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Retorna o tamanho em bytes de um arquivo no ftp.
        /// </summary>
        private long getLngArquivoTamanho(string dirArquivoFtp)
        {
            #region Variáveis

            FtpWebRequest objFtpWebRequest;
            long lngResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return lngResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}