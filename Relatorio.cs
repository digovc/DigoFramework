using DigoFramework.database;
using System;

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
            get
            {
                return _objDbTabela;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _objDbTabela = value;
                    _objDbTabela.lstObjRelatorio.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        #endregion
    }
}