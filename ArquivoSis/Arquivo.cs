using System;

namespace DigoFramework.ArquivoSis
{
     abstract public class Arquivo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        public Boolean booAtualizado
        {
            get
            {
                throw new NotImplementedException();
                return false;
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
        }

        private String _dirDiretorioFtp = String.Empty;
        public virtual String dirDiretorioFtp { get { return _dirDiretorioFtp; } set { _dirDiretorioFtp = value; } }

        private Ftp _objFtpAtualizacao;
        public Ftp objFtpAtualizacao { get { return _objFtpAtualizacao; } set { _objFtpAtualizacao = value; } }

        private String _strConteudo = String.Empty;
        public String strConteudo { get { return _strConteudo; } set { _strConteudo = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        public abstract void salvar();

        #endregion
    }
}
