using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Ionic.Zip;

namespace DigoFramework.Arquivo
{
    public abstract class ArquivoMain : Objeto
    {
        #region Constantes

        public enum EnmMimeTipo
        {
            APPLICATION_OCTET_STREAM,
            APPLICATION_VND_GOOGLE_APPS_FOLDER,
            APPLICATION_VND_MS_EXCEL,
            APPLICATION_XML,
            APPLICATION_ZIP,
            AUDIO_MPEG,
            IMAGE_GIF,
            IMAGE_JPEG,
            IMAGE_PNG,
            TEXT_PLAIN,
            TEXT_XML,
        }

        #endregion Constantes

        #region Atributos

        private bool _booAtualizado;
        private bool _booExiste;
        private bool _booNaoCriarDiretorio;
        private bool _booVazio;
        private string _dir;
        private string _dirCompleto;
        private string _dirDiretorioFtp;
        private string _dirTemp;
        private string _dirTempCompleto;
        private DateTime _dttUltimaModificacao;
        private EnmMimeTipo _enmMimeTipo;
        private int _intVersaoCompleta;
        private string _strConteudo;
        private string _strGoogleDriveId;
        private string _strMd5;
        private string _strMimeTipo;

        public bool booAtualizado
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booAtualizado = this.getBooAtualizado();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _booAtualizado;
            }
        }

        public bool booExiste
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booExiste = File.Exists(this.dirCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _booExiste;
            }
        }

        public bool booVazio
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _booVazio = new FileInfo(this.dirCompleto).Length.Equals(0);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _booVazio;
            }
        }

        public virtual string dir
        {
            get
            {
                return _dir;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _dir = value;

                    this.atualizarDir();
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
        }

        public string dirCompleto
        {
            get
            {
                #region Variáveis

                string dirRemote;

                #endregion Variáveis

                #region Ações

                try
                {
                    if (string.IsNullOrEmpty(this.dir + this.strNome))
                    {
                        return string.Empty;
                    }

                    _dirCompleto = this.dir + "\\" + this.strNome;
                    dirRemote = string.Empty;

                    if (_dirCompleto.StartsWith("\\\\"))
                    {
                        dirRemote = "\\";
                    }

                    _dirCompleto = _dirCompleto.Replace("\\\\", "\\");
                    _dirCompleto = dirRemote + _dirCompleto;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dirCompleto;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        return;
                    }

                    this.dir = Path.GetDirectoryName(value);
                    this.strNome = Path.GetFileName(value);
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
        }

        public virtual string dirDiretorioFtp
        {
            get
            {
                return _dirDiretorioFtp;
            }

            set
            {
                _dirDiretorioFtp = value;
            }
        }

        public string dirTemp
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_dirTemp))
                    {
                        return _dirTemp;
                    }

                    _dirTemp = Aplicativo.i.dirTemp;

                    if (!Directory.Exists(_dirTemp))
                    {
                        Directory.CreateDirectory(_dirTemp);
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

                return _dirTemp;
            }
        }

        /// <summary>
        /// Diretório temporário completo.
        /// </summary>
        public string dirTempCompleto
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_dirTempCompleto))
                    {
                        return _dirTempCompleto;
                    }

                    _dirTempCompleto = this.dirTemp + "\\" + this.strNome;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dirTempCompleto;
            }
        }

        public DateTime dttUltimaModificacao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _dttUltimaModificacao = this.getDttUltimaModificacao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _dttUltimaModificacao;
            }
        }

        public EnmMimeTipo enmMimeTipo
        {
            get
            {
                return _enmMimeTipo;
            }

            set
            {
                _enmMimeTipo = value;
            }
        }

        public string strConteudo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_strConteudo != null)
                    {
                        return _strConteudo;
                    }

                    if (!File.Exists(this.dirCompleto))
                    {
                        return _strConteudo;
                    }

                    _strConteudo = this.getStrConteudo();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strConteudo;
            }

            set
            {
                _strConteudo = value;
            }
        }

        public string strGoogleDriveId
        {
            get
            {
                return _strGoogleDriveId;
            }

            set
            {
                _strGoogleDriveId = value;
            }
        }

        public string strMd5
        {
            get
            {
                #region Variáveis

                byte[] arrByte;
                StringBuilder stbResult;

                #endregion Variáveis

                #region Ações

                try
                {
                    using (var md5 = MD5.Create())
                    using (var stream = File.OpenRead(this.dirCompleto))
                    {
                        arrByte = md5.ComputeHash(stream);
                        stbResult = new StringBuilder(arrByte.Length * 2);

                        for (int i = 0; i < arrByte.Length; i++)
                        {
                            stbResult.Append(arrByte[i].ToString("X2"));
                        }

                        _strMd5 = stbResult.ToString();
                    }
                }
                catch
                {
                    _strMd5 = "<nulo>";
                }
                finally
                {
                }

                #endregion Ações

                return _strMd5;
            }
        }

        public string strMimeTipo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_strMimeTipo))
                    {
                        return _strMimeTipo;
                    }

                    switch (this.enmMimeTipo)
                    {
                        case EnmMimeTipo.APPLICATION_OCTET_STREAM:
                            _strMimeTipo = "application/octet-stream";
                            break;

                        case EnmMimeTipo.APPLICATION_VND_GOOGLE_APPS_FOLDER:
                            _strMimeTipo = "application/vnd.google-apps.folder";
                            break;

                        case EnmMimeTipo.APPLICATION_VND_MS_EXCEL:
                            _strMimeTipo = "application/vnd.ms-excel";
                            break;

                        case EnmMimeTipo.APPLICATION_XML:
                            _strMimeTipo = "application/xml";
                            break;

                        case EnmMimeTipo.APPLICATION_ZIP:
                            _strMimeTipo = "application/zip";
                            break;

                        case EnmMimeTipo.AUDIO_MPEG:
                            _strMimeTipo = "audio/mpeg";
                            break;

                        case EnmMimeTipo.IMAGE_GIF:
                            _strMimeTipo = "image/gif";
                            break;

                        case EnmMimeTipo.IMAGE_JPEG:
                            _strMimeTipo = "image/jpeg";
                            break;

                        case EnmMimeTipo.IMAGE_PNG:
                            _strMimeTipo = "image/png";
                            break;

                        case EnmMimeTipo.TEXT_PLAIN:
                            _strMimeTipo = "text/plain";
                            break;

                        case EnmMimeTipo.TEXT_XML:
                            _strMimeTipo = "text/xml";
                            break;
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

                return "text/plain";
            }
        }

        protected bool booNaoCriarDiretorio
        {
            get
            {
                return _booNaoCriarDiretorio;
            }

            set
            {
                _booNaoCriarDiretorio = value;
            }
        }

        private int intVersaoCompleta
        {
            get
            {
                return _intVersaoCompleta;
            }

            set
            {
                _intVersaoCompleta = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public ArquivoMain(ArquivoMain.EnmMimeTipo enmMineTipo)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.enmMimeTipo = enmMineTipo;
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

        public static string getStrMimeTipo(EnmMimeTipo enmMimeTipo)
        {
            #region Variáveis

            string strResultado = null;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = new ArquivoDiverso(enmMimeTipo).strMimeTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Atualiza este arquivo pela sua versão mais atual presente no "ftpUpdate".
        /// </summary>
        public void atualizarFtp(string dirLanSalvarUpdate)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                Aplicativo.i.ftpUpdate.downloadArquivo(this.strNome + ".zip", this.dirTempCompleto + ".zip");

                if (string.IsNullOrEmpty(dirLanSalvarUpdate))
                {
                    return;
                }

                File.Delete(dirLanSalvarUpdate + "\\" + this.strNome + ".zip");
                File.Copy(this.dirTempCompleto + ".zip", dirLanSalvarUpdate + "\\" + this.strNome + ".zip", true);
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
        /// Atualiza este arquivo pela sua versão mais atual presente no diretório interno da "LAN"
        /// indicado como repositório de atualização.
        /// </summary>
        public void atualizarLan(string dirLan)
        {
            #region Variáveis

            string dirCompleto;

            #endregion Variáveis

            #region Ações

            try
            {
                dirCompleto = dirLan + "\\" + this.strNome + ".zip";

                if (!File.Exists(dirCompleto))
                {
                    return;
                }

                File.Copy(dirCompleto, this.dirTempCompleto + ".zip", true);
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
        /// Compacta o arquivo no diretório indicado. Se o diretório não for indicado, compacta no
        /// mesmo diretório em que o arquivo está guardado.
        /// </summary>
        public void compactar(string dirDestino)
        {
            #region Variáveis

            ZipFile objZipFile;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(dirDestino))
                {
                    dirDestino = this.dirCompleto + ".zip";
                }
                else
                {
                    dirDestino = dirDestino + "\\" + this.strNome + ".zip";
                }

                objZipFile = new ZipFile();
                objZipFile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                objZipFile.CompressionMethod = CompressionMethod.BZip2;
                objZipFile.AddFile(this.dirCompleto, "\\");
                objZipFile.Save(dirDestino);
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
        /// Apaga este arquivo do disco rígido.
        /// </summary>
        public void deletar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.booExiste)
                {
                    File.Delete(this.dirCompleto);
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

        /// <summary>
        /// Descompacta o arquivo proveniente da atualização.
        /// </summary>
        public void descompactarUpdate()
        {
            #region Variáveis

            ZipFile objZipFile;

            #endregion Variáveis

            #region Ações

            try
            {
                File.Delete(this.dirCompleto + ".zip");
                File.Delete(this.dirCompleto + ".new");
                File.Move(this.dirTempCompleto + ".zip", this.dirCompleto + ".zip");

                objZipFile = ZipFile.Read(this.dirCompleto + ".zip");
                objZipFile[0].FileName = this.strNome + ".new";
                objZipFile[0].Extract();
                objZipFile.Dispose();

                File.Delete(this.dirCompleto + ".zip");
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
        /// Retorna o conteúdo do arquivo que se encontra salvo no disco.
        /// </summary>
        public virtual string getStrConteudo()
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                return null;
            }

            if (!File.Exists(this.dirCompleto))
            {
                return null;
            }

            return File.ReadAllText(this.dirCompleto);
        }

        public virtual void salvar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                File.WriteAllText(this.dirCompleto, this.strConteudo);
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

        public void salvarStream(Stream objStream)
        {
            #region Variáveis

            byte[] arrbytesInStream;

            #endregion Variáveis

            #region Ações

            try
            {
                if (objStream.Length.Equals(0))
                {
                    return;
                }

                using (FileStream fileStream = File.Create(this.dirCompleto, (int)objStream.Length))
                {
                    arrbytesInStream = new byte[objStream.Length];
                    objStream.Read(arrbytesInStream, 0, (int)arrbytesInStream.Length);
                    fileStream.Write(arrbytesInStream, 0, arrbytesInStream.Length);
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

        /// <summary>
        /// Envia o arquivo para o servidor atravéz do protocolo "HTTP".
        /// </summary>
        public void uploadHttp(string url)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                HttpCliente.i.uploadArq(url, this);
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

        internal bool getBooAtualizado(XmlNode xmlNodeArq, ArquivoMain arq)
        {
            if (xmlNodeArq == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(xmlNodeArq.Name))
            {
                return true;
            }

            if (xmlNodeArq.ChildNodes.Item(1) == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(xmlNodeArq.ChildNodes.Item(1).InnerText))
            {
                return true;
            }

            if (arq == null)
            {
                return true;
            }

            if (string.IsNullOrEmpty(arq.strNomeSimplificado))
            {
                return true;
            }

            if (!xmlNodeArq.Name.Equals(arq.strNomeSimplificado))
            {
                return true;
            }

            return xmlNodeArq.ChildNodes.Item(1).InnerText.Equals(arq.strMd5);
        }

        protected virtual DateTime getDttUltimaModificacao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.dirCompleto))
                {
                    return DateTime.MinValue;
                }

                if (!File.Exists(this.dirCompleto))
                {
                    return DateTime.MinValue;
                }

                return File.GetLastWriteTime(this.dirCompleto);
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

        private void atualizarDir()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.dir))
                {
                    return;
                }

                if (this.booNaoCriarDiretorio)
                {
                    return;
                }

                if (Directory.Exists(this.dir))
                {
                    return;
                }

                Directory.CreateDirectory(this.dir);
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

        private bool getBooAtualizado()
        {
            throw new NotImplementedException();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}