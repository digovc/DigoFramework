using System;

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
                throw new NotImplementedException();
            }
        }

        public DateTime dttultimaAtualizacao
        {
            get
            {
                return System.IO.File.GetLastWriteTime(this.dirDiretorioCompleto);
            }
        }

        private String _dirDiretorio = String.Empty;
        public virtual String dirDiretorio { get { return _dirDiretorio; } set { _dirDiretorio = value; } }

        public String dirDiretorioCompleto
        {
            get
            {
                return _dirDiretorio + "\\" + this.strNome;
            }
            set
            {
                this.dirDiretorio = System.IO.Path.GetDirectoryName(value);
                this.strNome = System.IO.Path.GetFileName(value);
            }
        }

        private String _dirDiretorioFtp = String.Empty;
        public virtual String dirDiretorioFtp { get { return _dirDiretorioFtp; } set { _dirDiretorioFtp = value; } }

        private MimeTipo _objMimeTipo = MimeTipo.TEXT_PLAIN;
        public MimeTipo objMimeTipo { get { return _objMimeTipo; } set { _objMimeTipo = value; } }

        private Ftp _objFtpAtualizacao;
        public Ftp objFtpAtualizacao { get { return _objFtpAtualizacao; } set { _objFtpAtualizacao = value; } }

        private String _strConteudo = String.Empty;
        public String strConteudo { get { return _strConteudo; } set { _strConteudo = value; } }

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

            System.IO.File.WriteAllText(this.dirDiretorio, this.strConteudo);

            #endregion
        }

        protected abstract void setInMimeType();

        #endregion
    }
}
