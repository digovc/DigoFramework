using DigoFramework.google;
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

        private String _dir = String.Empty;
        private String _dirCompleto;
        private String _dirDiretorioFtp = String.Empty;
        private String _dirTemporario;
        private String _dirTemporarioCompleto;
        private EnmMimeTipo _enmMimeTipo = EnmMimeTipo.TEXT_PLAIN;
        private int _intVersaoCompleta = 0;
        private String _strConteudo = String.Empty;
        private String _strGoogleDriveId = String.Empty;
        private String _strMd5;

        public Boolean booAtualizado
        {
            get
            {
                return this.getBooAtualizado();
            }
        }

        public Boolean booExiste
        {
            get
            {
                return System.IO.File.Exists(this.dirCompleto);
            }
        }

        public Boolean booVazio
        {
            get
            {
                return new FileInfo(this.dirCompleto).Length == 0;
            }
        }

        public virtual String dir
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

        public String dirCompleto
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

        public virtual String dirDiretorioFtp
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

        public String dirTemporario
        {
            get
            {
                if (String.IsNullOrEmpty(_dirTemporario))
                {
                    _dirTemporario = System.IO.Path.GetTempPath() + "\\" + Aplicativo.i.strNomeSimplificado;

                    if (!System.IO.Directory.Exists(_dirTemporario))
                    {
                        System.IO.Directory.CreateDirectory(_dirTemporario);
                    }
                }
                return _dirTemporario;
            }
        }

        public String dirTemporarioCompleto
        {
            get
            {
                _dirTemporarioCompleto = this.dirTemporario + "\\" + this.strNome;
                return _dirTemporarioCompleto;
            }
        }

        public DateTime dttultimaAtualizacao
        {
            get
            {
                return System.IO.File.GetLastWriteTime(this.dirCompleto);
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

        public String strConteudo
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

        public String strGoogleDriveId
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

        public String strMd5
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(this.dirCompleto))
                        {
                            byte[] lstByte = md5.ComputeHash(stream);
                            StringBuilder result = new StringBuilder(lstByte.Length * 2);
                            for (int i = 0; i < lstByte.Length; i++)
                                result.Append(lstByte[i].ToString("X2"));

                            _strMd5 = result.ToString();
                        }
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    _strMd5 = "<nulo>";
                }
                finally
                {
                }

                return _strMd5;
            }
        }

        public String strMimeTipo
        {
            get
            {
                switch (this.enmMimeTipo)
                {
                    case EnmMimeTipo.APPLICATION_OCTET_STREAM:
                        return "application/octet-stream";

                    case EnmMimeTipo.APPLICATION_VND_GOOGLE_APPS_FOLDER:
                        return "application/vnd.google-apps.folder";

                    case EnmMimeTipo.APPLICATION_VND_MS_EXCEL:
                        return "application/vnd.ms-excel";

                    case EnmMimeTipo.APPLICATION_XML:
                        return "application/xml";

                    case EnmMimeTipo.APPLICATION_ZIP:
                        return "application/zip";

                    case EnmMimeTipo.AUDIO_MPEG:
                        return "audio/mpeg";

                    case EnmMimeTipo.IMAGE_GIF:
                        return "image/gif";

                    case EnmMimeTipo.IMAGE_JPEG:
                        return "image/jpeg";

                    case EnmMimeTipo.IMAGE_PNG:
                        return "image/png";

                    case EnmMimeTipo.TEXT_PLAIN:
                        return "text/plain";

                    default:
                        return "text/plain";
                }
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

            this.enmMimeTipo = enmMineTipo;

            #endregion
        }

        #endregion

        #region MÉTODOS

        public static String getMimeTipo(EnmMimeTipo objMimeTipo)
        {
            #region VARIÁVEIS

            ArquivoDiverso arqTemp = new ArquivoDiverso(objMimeTipo);

            #endregion

            #region AÇÕES

            return arqTemp.strMimeTipo;

            #endregion
        }

        /// <summary>
        /// Atualiza este arquivo pela sua versão mais atual presente no "ftpUpdate".
        /// </summary>
        public void atualizarPeloFtp(String dirLanSalvarUpdate = Utils.STRING_VAZIA)
        {
            #region VARIÁVEIS

            #endregion

            try
            {
                #region AÇÕES

                Aplicativo.i.ftpUpdate.downloadArquivo(this.strNome + ".zip", this.dirTemporarioCompleto + ".zip");

                if (!String.IsNullOrEmpty(dirLanSalvarUpdate))
                {
                    File.Delete(dirLanSalvarUpdate + "\\" + this.strNome + ".zip");
                    File.Copy(this.dirTemporarioCompleto + ".zip", dirLanSalvarUpdate + "\\" + this.strNome + ".zip");
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
        }

        /// <summary>
        /// Atualiza este arquivo pela sua versão mais atual presente no diretório interno da "LAN"
        /// indicado como repositório de atualização.
        /// </summary>
        public void atualizarPorLan(String dirLan)
        {
            #region VARIÁVEIS

            String dirCompleto;

            #endregion

            try
            {
                #region AÇÕES

                dirCompleto = dirLan + "\\" + this.strNome + ".zip";

                if (File.Exists(dirCompleto))
                {
                    File.Copy(dirCompleto, this.dirTemporarioCompleto + ".zip");
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
        }

        /// <summary>
        /// Compacta o arquivo no diretório indicado. Se o diretório não for indicado, compacta no
        /// mesmo diretório em que o arquivo está guardado.
        /// </summary>
        public void compactar(String dirDestino = Utils.STRING_VAZIA)
        {
            #region VARIÁVEIS

            ZipFile objZipFile;

            #endregion

            try
            {
                #region AÇÕES

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

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
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

            try
            {
                #region AÇÕES

                File.Delete(this.dirCompleto + ".zip");
                File.Delete(this.dirCompleto + ".new");
                File.Move(this.dirTemporarioCompleto + ".zip", this.dirCompleto + ".zip");

                objZipFile = ZipFile.Read(this.dirCompleto + ".zip");
                objZipFile[0].FileName = this.strNome + ".new";
                objZipFile[0].Extract();

                objZipFile.Dispose();

                File.Delete(this.dirCompleto + ".zip");

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public void enviaGoogleDrive(ContaServico objContaServico)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            throw new NotImplementedException();

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

            System.IO.File.WriteAllText(this.dirCompleto, this.strConteudo);

            #endregion
        }

        public void salvarStream(Stream objStream)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            if (objStream.Length == 0)
                return;
            // Create a FileStream object to write a stream to a file
            using (FileStream fileStream = System.IO.File.Create(this.dirCompleto, (int)objStream.Length))
            {
                // Fill the bytes[] array with the stream data
                byte[] bytesInStream = new byte[objStream.Length];
                objStream.Read(bytesInStream, 0, (int)bytesInStream.Length);
                // Use FileStream object to write to the specified file
                fileStream.Write(bytesInStream, 0, bytesInStream.Length);
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
                HttpUtils.uploadArq(url, this);
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
            #region VARIÁVEIS

            GoogleDrive objGoogleDrive = new GoogleDrive();

            #endregion

            #region AÇÕES

            Google.Apis.Drive.v2.Data.File objGoogleFile = objGoogleDrive.getArquivo(this);

            if (objGoogleFile != null)
            {
                return objGoogleFile.Description.Equals(this.intVersaoCompleta);
            }
            else
            {
                return false;
            }

            #endregion
        }

        #endregion
    }
}