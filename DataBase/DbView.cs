namespace DigoFramework.DataBase
{
    public abstract class DbView : DbTabela
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private bool _booPrincipal;

        public bool booPrincipal
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

        public DbView(string strNome)
            : base(strNome)
        {
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}