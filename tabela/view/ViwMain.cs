using DigoFramework.database;
using System;

namespace DigoFramework.tabela.view
{
    public abstract class ViwMain : DbView
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private DbColuna _clnIntId;
        public DbColuna clnIntId
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnIntId == null)
                    {
                        _clnIntId = new DbColuna("int_id", this);
                        _clnIntId.booChavePrimaria = true;
                        _clnIntId.enmDbColunaTipo = DbColuna.EnmDbColunaTipo.BIGINT;
                        _clnIntId.intTamanho = 25;
                        _clnIntId.strNomeExibicao = "Código";
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _clnIntId;
            }
        }

        #endregion

        #region CONSTRUTORES

        public ViwMain(String strNome)
            : base(strNome)
        {
        }

        #endregion

        #region DESTRUTOR
        #endregion

        #region MÉTODOS
        #endregion

        #region EVENTOS
        #endregion
    }
}
