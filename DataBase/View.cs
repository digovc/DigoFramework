namespace DigoFramework.DataBase
{
    public abstract class View : Tabela
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

        public View(string strNome)
            : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}