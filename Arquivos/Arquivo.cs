using DigoFramework.GoogleApi;
using Ionic.Zip;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DigoFramework.Arquivos
{
    abstract public class Arquivo : Objeto
    {
        #region CONSTANTES

        public enum MimeTipo
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

        public DateTime dttultimaAtualizacao
        {
            get
            {
                return System.IO.File.GetLastWriteTime(this.dirCompleto);
            }
        }

        private String _dir = String.Empty;
        public virtual String dir
        {
            get { return _dir; }
            set
            {
                _dir = value;
                if (!System.IO.Directory.Exists(_dir))
                {
                    System.IO.Directory.CreateDirectory(_dir);
                }
            }
        }

        public String dirCompleto
        {
            get
            {
                return _dir + "\\" + this.strNome;
            }
            set
            {
                this.dir = System.IO.Path.GetDirectoryName(value);
                this.strNome = System.IO.Path.GetFileName(value);
            }
        }

        private String _dirDiretorioFtp = String.Empty;
        public virtual String dirDiretorioFtp { get { return _dirDiretorioFtp; } set { _dirDiretorioFtp = value; } }

        private String _dirTemporario;
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

        private String _dirTemporarioCompleto;
        public String dirTemporarioCompleto
        {
            get
            {
                _dirTemporarioCompleto = this.dirTemporario + "\\" + this.strNome;
                return _dirTemporarioCompleto;
            }
        }

        private int _intVersaoCompleta = 0;
        private int intVersaoCompleta { get { return _intVersaoCompleta; } set { _intVersaoCompleta = value; } }

        private MimeTipo _objMimeTipo = MimeTipo.TEXT_PLAIN;
        public MimeTipo objMimeTipo { get { return _objMimeTipo; } set { _objMimeTipo = value; } }

        private String _strConteudo = String.Empty;
        public String strConteudo { get { return _strConteudo; } set { _strConteudo = value; } }

        private String _strGoogleDriveId = String.Empty;
        public String strGoogleDriveId { get { return _strGoogleDriveId; } set { _strGoogleDriveId = value; } }

        private String _strMd5;
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
                    throw ex;
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
                switch (this.objMimeTipo)
                {
                    case MimeTipo.APPLICATION_OCTET_STREAM:
                        return "application/octet-stream";
                    case MimeTipo.APPLICATION_VND_GOOGLE_APPS_FOLDER:
                        return "application/vnd.google-apps.folder";
                    case MimeTipo.APPLICATION_VND_MS_EXCEL:
                        return "application/vnd.ms-excel";
                    case MimeTipo.APPLICATION_XML:
                        return "application/xml";
                    case MimeTipo.APPLICATION_ZIP:
                        return "application/zip";
                    case MimeTipo.AUDIO_MPEG:
                        return "audio/mpeg";
                    case MimeTipo.IMAGE_GIF:
                        return "image/gif";
                    case MimeTipo.IMAGE_JPEG:
                        return "image/jpeg";
                    case MimeTipo.IMAGE_PNG:
                        return "image/png";
                    case MimeTipo.TEXT_PLAIN:
                        return "text/plain";
                    default:
                        return "text/plain";
                }
            }
        }

        #endregion

        #region CONSTRUTORES

        public Arquivo()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.setInMimeType();

            #endregion
        }
        #endregion

        #region MÉTODOS

        /// <summary>
        /// 
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
        /// 
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
        /// Compacta o arquivo no diretório indicado. Se o diretório não for indicado, compacta no mesmo diretório
        /// em que o arquivo está guardado.
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
                objZipFile.AddFile(this.dirCompleto,"\\");
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
        /// 
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
            else { return false; }

            #endregion
        }

        public static String getMimeTipo(MimeTipo objMimeTipo)
        {
            #region VARIÁVEIS

            ArquivoDiverso arqTemp = new ArquivoDiverso(objMimeTipo);

            #endregion

            #region AÇÕES

            return arqTemp.strMimeTipo;

            #endregion
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

            if (objStream.Length == 0) return;
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

        protected abstract void setInMimeType();

        #endregion
    }
}
