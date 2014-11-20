namespace DigoFramework.DataBase
{
    public abstract class DbView : DbTabela
    {
        #region CONSTANTES

        #endregion CONSTANTES

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

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DbView(string strNome)
            : base(strNome)
        {
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS
    }
}