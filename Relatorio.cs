using System;
using DigoFramework.database;

namespace DigoFramework
{
    public class Relatorio : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private DbTabela _objDbTabela;
        public DbTabela objDbTabela
        {
            get { return _objDbTabela; }
            set
            {
                _objDbTabela = value;
                _objDbTabela.lstObjRelatorio.Add(this);
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}
