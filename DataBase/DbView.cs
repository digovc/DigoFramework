using System;

namespace DigoFramework.database
{
    public abstract class DbView : DbTabela
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booPrincipal = false;

        public Boolean booPrincipal
        {
            get
            {
                return _booPrincipal;
            }

            set
            {
                _booPrincipal = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        public DbView(String strNome)
            : base(strNome)
        {
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}