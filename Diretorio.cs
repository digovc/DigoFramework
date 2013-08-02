using System;

namespace DigoFramework
{
    public class Diretorio : Objeto
    {
        #region CONSTANTES

        #endregion

        #region 

        private String _dirDiretorio = String.Empty;
        public String dirDiretorio
        {
            get { return _dirDiretorio; }
            set
            {
                _dirDiretorio = value;
                System.IO.Directory.CreateDirectory(_dirDiretorio);
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}
