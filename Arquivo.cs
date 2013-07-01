using System;

namespace DigoFramework
{
    public abstract class Arquivo : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private String _dirDiretorio = String.Empty;
        public virtual String dirDiretorio { get { return _dirDiretorio; }set { _dirDiretorio = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}
