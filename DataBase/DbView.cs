namespace DigoFramework.DataBase
{
    public abstract class DbView : DbTabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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

        #endregion Atributos

        #region Construtores

        public DbView(string strNome)
            : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}