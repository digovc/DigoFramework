using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Ionic.Zip;

namespace DigoFramework.Arquivo
{
    public abstract class ArquivoBase : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private byte[] _arrBteConteudo;
        private bool _booExiste;
        private bool _booNaoCriarDiretorio;
        private bool _booVazio;
        private string _dir;
        private string _dirCompleto;
        private string _dirDiretorioFtp;
        private string _dirTemp;
        private string _dirTempCompleto;
        private DateTime _dttUltimaModificacao;
        private EnmContentType _enmContentType = EnmContentType.NONE;
        private int _intVersaoCompleta;
        private string _strContentType;
        private string _strConteudo;
        private string _strGoogleDriveId;
        private string _strMd5;

        public byte[] arrBteConteudo
        {
            get
            {
                if (_arrBteConteudo != null)
                {
                    return _arrBteConteudo;
                }

                _arrBteConteudo = this.getArrBteConteudo();

                return _arrBteConteudo;
            }

            set
            {
                _arrBteConteudo = value;
            }
        }

        public bool booExiste
        {
            get
            {
                return _booExiste = this.getBooExiste();
            }
        }

        public bool booVazio
        {
            get
            {
                return _booVazio = this.getBooVazio();
            }
        }

        public string dir
        {
            get
            {
                return _dir;
            }

            set
            {
                if (_dir == value)
                {
                    return;
                }

                _dir = value;

                this.setDir(_dir);
            }
        }

        public string dirCompleto
        {
            get
            {
                if (_dirCompleto != null)
                {
                    return _dirCompleto;
                }

                _dirCompleto = this.getDirCompleto();

                return _dirCompleto;
            }

            set
            {
                if (_dirCompleto == value)
                {
                    return;
                }

                _dirCompleto = value;

                this.setDirCompleto(_dirCompleto);
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
                if (_dirTemp != null)
                {
                    return _dirTemp;
                }

                _dirTemp = this.getDirTemp();

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
                if (_dirTempCompleto != null)
                {
                    return _dirTempCompleto;
                }

                _dirTempCompleto = this.getDirTempCompleto();

                return _dirTempCompleto;
            }
        }

        public DateTime dttUltimaModificacao
        {
            get
            {
                if (_dttUltimaModificacao != default(DateTime))
                {
                    return _dttUltimaModificacao;
                }

                _dttUltimaModificacao = this.getDttUltimaModificacao();

                return _dttUltimaModificacao;
            }

            set
            {
                _dttUltimaModificacao = value;
            }
        }

        public EnmContentType enmContentType
        {
            get
            {
                if (_enmContentType != EnmContentType.NONE)
                {
                    return _enmContentType;
                }

                _enmContentType = this.getEnmContentType();

                return _enmContentType;
            }

            set
            {
                if (_enmContentType == value)
                {
                    return;
                }

                _enmContentType = value;

                this.setEnmContentType(_enmContentType);
            }
        }

        public string strContentType
        {
            get
            {
                if (_strContentType != null)
                {
                    return _strContentType;
                }

                _strContentType = EnmContentTypeManager.getStrContentType(this.enmContentType);

                return _strContentType;
            }
            private set
            {
                _strContentType = value;
            }
        }

        public string strConteudo
        {
            get
            {
                if (_strConteudo != null)
                {
                    return _strConteudo;
                }

                _strConteudo = this.getStrConteudo();

                return _strConteudo;
            }

            set
            {
                if (_strConteudo == value)
                {
                    return;
                }

                _strConteudo = value;

                this.setStrConteudo(_strConteudo);
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
                if (_strMd5 != null)
                {
                    return _strMd5;
                }

                _strMd5 = this.getStrMd5();

                return _strMd5;
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

        protected ArquivoBase()
        {
            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Atualiza este arquivo pela sua versão mais atual presente no "ftpUpdate".
        /// </summary>
        public void atualizarFtp(string dirLanSalvarUpdate)
        {
            if (AppBase.i == null)
            {
                return;
            }

            if (AppBase.i.ftpUpdate == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(this.strNome))
            {
                return;
            }

            AppBase.i.ftpUpdate.downloadArquivo((this.strNome + ".zip"), (this.dirTempCompleto + ".zip"));

            if (string.IsNullOrEmpty(dirLanSalvarUpdate))
            {
                return;
            }

            File.Copy((this.dirTempCompleto + ".zip"), Path.Combine(dirLanSalvarUpdate, (this.strNome + ".zip")), true);
        }

        /// <summary>
        /// Atualiza este arquivo pela sua versão mais atual presente no diretório interno da "LAN"
        /// indicado como repositório de atualização.
        /// </summary>
        public void atualizarLan(string dirLan)
        {
            if (string.IsNullOrEmpty(dirLan))
            {
                return;
            }

            if (Directory.Exists(dirLan))
            {
                return;
            }

            string dirCompleto = Path.Combine(dirLan, (this.strNome + ".zip"));

            if (!File.Exists(dirCompleto))
            {
                return;
            }

            File.Copy(dirCompleto, (this.dirTempCompleto + ".zip"), true);
        }

        /// <summary>
        /// Compacta o arquivo no diretório indicado. Se o diretório não for indicado, compacta no
        /// mesmo diretório em que o arquivo está guardado.
        /// </summary>
        public void compactar(string dirDestino)
        {
            if (!this.booExiste)
            {
                return;
            }

            if (string.IsNullOrEmpty(dirDestino))
            {
                dirDestino = (this.dirCompleto + ".zip");
            }
            else
            {
                dirDestino = Path.Combine(dirDestino, (this.strNome + ".zip"));
            }

            using (ZipFile objZipFile = new ZipFile())
            {
                objZipFile.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                objZipFile.CompressionMethod = CompressionMethod.BZip2;

                objZipFile.AddFile(this.dirCompleto);

                objZipFile.Save(dirDestino);
            }
        }

        /// <summary>
        /// Apaga este arquivo do disco rígido.
        /// </summary>
        public void deletar()
        {
            if (!this.booExiste)
            {
                return;
            }

            File.Delete(this.dirCompleto);
        }

        /// <summary>
        /// Descompacta o arquivo proveniente da atualização.
        /// </summary>
        public void descompactarUpdate()
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                return;
            }

            File.Delete(this.dirCompleto + ".zip");
            File.Delete(this.dirCompleto + ".new");

            File.Move((this.dirTempCompleto + ".zip"), (this.dirCompleto + ".zip"));

            using (ZipFile objZipFile = ZipFile.Read(this.dirCompleto + ".zip"))
            {
                objZipFile[0].FileName = (this.strNome + ".new");

                objZipFile[0].Extract();
            }

            File.Delete(this.dirCompleto + ".zip");
        }

        /// <summary>
        /// Retorna o conteúdo do arquivo que se encontra salvo no disco.
        /// </summary>
        public virtual string getStrConteudo()
        {
            if (this.arrBteConteudo == null)
            {
                return null;
            }

            if (this.arrBteConteudo.Length < 1)
            {
                return null;
            }

            return Encoding.UTF8.GetString(this.arrBteConteudo);
        }

        public virtual void salvar()
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                return;
            }

            Directory.CreateDirectory(this.dir);

            if (_arrBteConteudo != null && _arrBteConteudo.Length > 0)
            {
                File.WriteAllBytes(this.dirCompleto, _arrBteConteudo);
                return;
            }

            if (!string.IsNullOrEmpty(_strConteudo))
            {
                File.WriteAllText(this.dirCompleto, this.strConteudo);
                return;
            }
        }

        /// <summary>
        /// Envia o arquivo para o servidor atravéz do protocolo "HTTP".
        /// </summary>
        public void uploadHttp(string url)
        {
            HttpCliente.i.uploadArquivo(url, this);
        }

        internal bool getBooAtualizado(XmlNode xmlNodeArq, ArquivoBase arq)
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

        protected virtual byte[] getArrBteConteudo()
        {
            if (!this.booExiste)
            {
                return null;
            }

            return File.ReadAllBytes(this.dirCompleto);
        }

        protected virtual DateTime getDttUltimaModificacao()
        {
            if (!this.booExiste)
            {
                return DateTime.MinValue;
            }

            return File.GetLastWriteTime(this.dirCompleto);
        }

        protected virtual void inicializar()
        {
        }

        protected virtual void setEventos()
        {
        }

        private void setDir(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return;
            }

            if (this.booNaoCriarDiretorio)
            {
                return;
            }

            Directory.CreateDirectory(dir);
        }

        private void setDirCompleto(string dirCompleto)
        {
            if (string.IsNullOrEmpty(dirCompleto))
            {
                return;
            }

            this.dir = Path.GetDirectoryName(dirCompleto);

            this.strNome = Path.GetFileName(dirCompleto);
        }

        private void setEnmContentType(EnmContentType enmContentType)
        {
            this.strContentType = null;
        }

        private void setStrConteudo(string strConteudo)
        {
            if (string.IsNullOrEmpty(strConteudo))
            {
                this.arrBteConteudo = null;
                return;
            }

            this.arrBteConteudo = Encoding.UTF8.GetBytes(strConteudo);
        }

        private bool getBooExiste()
        {
            if (string.IsNullOrEmpty(this.dirCompleto))
            {
                return false;
            }

            return File.Exists(this.dirCompleto);
        }

        private bool getBooVazio()
        {
            if (!this.booExiste)
            {
                return true;
            }

            return new FileInfo(this.dirCompleto).Length.Equals(0);
        }

        private string getDirCompleto()
        {
            if (string.IsNullOrEmpty(this.dir))
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.strNome))
            {
                return null;
            }

            return Path.Combine(this.dir, this.strNome);
        }

        private string getDirTemp()
        {
            string dirTemp = string.Format("{0}\\_app_nome", Path.GetTempPath());

            try
            {
                if (AppBase.i == null)
                {
                    return dirTemp.Replace("_app_nome", "digoframework_temp_folder");
                }

                if (string.IsNullOrEmpty(AppBase.i.strNome))
                {
                    return dirTemp.Replace("_app_nome", "digoframework_temp_folder");
                }

                return dirTemp.Replace("_app_nome", "digoframework_temp_folder");
            }
            finally
            {
                Directory.CreateDirectory(dirTemp);
            }
        }

        private string getDirTempCompleto()
        {
            if (string.IsNullOrEmpty(this.dirTemp))
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.strNome))
            {
                return null;
            }

            return Path.Combine(this.dirTemp, this.strNome);
        }

        private EnmContentType getEnmContentType()
        {
            if (string.IsNullOrEmpty(this.strNome))
            {
                return EnmContentType.TXT_TEXT_PLAIN;
            }

            return EnmContentTypeManager.getEnmContentType(Path.GetExtension(this.strNome));
        }

        private string getStrMd5()
        {
            if (!this.booExiste)
            {
                return null;
            }

            using (var objMd5 = MD5.Create())
            using (var objStream = File.OpenRead(this.dirCompleto))
            {
                byte[] arrBteHash = objMd5.ComputeHash(objStream);

                StringBuilder stbResult = new StringBuilder(arrBteHash.Length * 2);

                for (int i = 0; i < arrBteHash.Length; i++)
                {
                    stbResult.Append(arrBteHash[i].ToString("X2"));
                }

                return stbResult.ToString();
            }
        }

        private void iniciar()
        {
            this.inicializar();
            this.setEventos();
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}