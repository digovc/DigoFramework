using System;

namespace DigoFramework
{
    public abstract class Arquivo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private String _dirDiretorio = String.Empty;
        public virtual String dirDiretorio { get { return _dirDiretorio; } set { _dirDiretorio = value; } }

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
