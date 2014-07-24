using Ionic.Zip;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DigoFramework.arquivo
{
    public abstract class Arquivo : Objeto
    {
        #region CONSTANTES

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
            TEXT_PLAIN
        }

        #endregion

        #region ATRIBUTOS

        private bool _booAtualizado;
        private bool _booExiste;
        private bool _booVazio;
        private string _dir;
        private string _dirCompleto;
        private string _dirDiretorioFtp;
        private string _dirTemp;
        private string _dirTempCompleto;
        private DateTime _dttUltimaAtualizacao;
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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion

                return _booAtualizado;
            }
        }

        public bool booExiste
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _booExiste = System.IO.File.Exists(this.dirCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _booExiste;
            }
        }

        public bool booVazio
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

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

                #endregion

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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _dir = value;

                    if (!System.IO.Directory.Exists(_dir))
                    {
                        System.IO.Directory.CreateDirectory(_dir);
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
        }

        public string dirCompleto
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (string.IsNullOrEmpty(this.dir + this.strNome))
                    {
                        return string.Empty;
                    }

                    _dirCompleto = this.dir + "\\" + this.strNome;
                    _dirCompleto = _dirCompleto.Replace("\\\\", "\\");
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _dirCompleto;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        return;
                    }

                    this.dir = System.IO.Path.GetDirectoryName(value);
                    this.strNome = System.IO.Path.GetFileName(value);
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
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_dirTemp))
                    {
                        return _dirTemp;
                    }

                    _dirTemp = System.IO.Path.GetTempPath() + "\\" + Aplicativo.i.strNomeSimplificado;

                    if (!System.IO.Directory.Exists(_dirTemp))
                    {
                        System.IO.Directory.CreateDirectory(_dirTemp);
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

                return _dirTemp;
            }
        }

        public string dirTemporarioCompleto
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_dirTempCompleto))
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

                #endregion

                return _dirTempCompleto;
            }
        }

        public DateTime dttUltimaAtualizacao
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _dttUltimaAtualizacao = System.IO.File.GetLastWriteTime(this.dirCompleto);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _dttUltimaAtualizacao;
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
                #region VARIÁVEIS

                byte[] arrByte;
                StringBuilder stbResult;

                #endregion

                #region AÇÕES

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

                #endregion

                return _strMd5;
            }
        }

        public string strMimeTipo
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strMimeTipo))
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

                return "text/plain";
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

        #endregion

        #region CONSTRUTORES

        public Arquivo(Arquivo.EnmMimeTipo enmMineTipo)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

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

            #endregion
        }

        #endregion

        #region MÉTODOS

        public static string getStrMimeTipo(EnmMimeTipo enmMimeTipo)
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

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

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Atualiza este arquivo pela sua versão mais atual presente no "ftpUpdate".
        /// </summary>
        public void atualizarPeloFtp(string dirLanSalvarUpdate = Utils.STR_VAZIA)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                Aplicativo.i.ftpUpdate.downloadArquivo(this.strNome + ".zip", this.dirTemporarioCompleto + ".zip");

                if (String.IsNullOrEmpty(dirLanSalvarUpdate))
                {
                    return;
                }

                File.Delete(dirLanSalvarUpdate + "\\" + this.strNome + ".zip");
                File.Copy(this.dirTemporarioCompleto + ".zip", dirLanSalvarUpdate + "\\" + this.strNome + ".zip");
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
        /// Atualiza este arquivo pela sua versão mais atual presente no diretório interno da "LAN"
        /// indicado como repositório de atualização.
        /// </summary>
        public void atualizarPorLan(string dirLan)
        {
            #region VARIÁVEIS

            string dirCompleto;

            #endregion

            #region AÇÕES

            try
            {
                dirCompleto = dirLan + "\\" + this.strNome + ".zip";

                if (!File.Exists(dirCompleto))
                {
                    return;
                }

                File.Copy(dirCompleto, this.dirTemporarioCompleto + ".zip");
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
        /// Compacta o arquivo no diretório indicado. Se o diretório não for indicado, compacta no
        /// mesmo diretório em que o arquivo está guardado.
        /// </summary>
        public void compactar(string dirDestino = Utils.STR_VAZIA)
        {
            #region VARIÁVEIS

            ZipFile objZipFile;

            #endregion

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(dirDestino))
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

            #endregion
        }

        /// <summary>
        /// Apaga este arquivo do disco rígido.
        /// </summary>
        public void deletar()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

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

            #endregion
        }

        /// <summary>
        /// Descompacta o arquivo proveniente da atualização.
        /// </summary>
        public void descompactarUpdate()
        {
            #region VARIÁVEIS

            ZipFile objZipFile;

            #endregion

            #region AÇÕES

            try
            {
                File.Delete(this.dirCompleto + ".zip");
                File.Delete(this.dirCompleto + ".new");
                File.Move(this.dirTemporarioCompleto + ".zip", this.dirCompleto + ".zip");

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

            #endregion
        }

        /// <summary>
        /// Retorna o conteúdo do arquivo que se encontra salvo no disco.
        /// </summary>
        public string getStrConteudo()
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = File.ReadAllText(this.dirCompleto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        public virtual void salvar()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                System.IO.File.WriteAllText(this.dirCompleto, this.strConteudo);
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

        public void salvarStream(Stream objStream)
        {
            #region VARIÁVEIS

            byte[] arrbytesInStream;

            #endregion

            #region AÇÕES

            try
            {
                if (objStream.Length.Equals(0))
                {
                    return;
                }

                using (FileStream fileStream = System.IO.File.Create(this.dirCompleto, (int)objStream.Length))
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

            #endregion
        }

        /// <summary>
        /// Envia o arquivo para o servidor atravéz do protocolo "HTTP".
        /// </summary>
        public void uploadHttp(string url)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

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

            #endregion
        }

        private bool getBooAtualizado()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}