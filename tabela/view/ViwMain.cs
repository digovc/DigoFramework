using DigoFramework.DataBase;
using System;

namespace DigoFramework.Tabela.View
{
    public abstract class ViwMain : DbView
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private DbColuna _clnIntId;

        public DbColuna clnIntId
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_clnIntId != null)
                    {
                        return _clnIntId;
                    }

                    _clnIntId = new DbColuna("int_id", this);

                    _clnIntId.booChavePrimaria = true;
                    _clnIntId.enmTipo = DbColuna.EnmTipo.BIGINT;
                    _clnIntId.intTamanho = 25;
                    _clnIntId.strNomeExibicao = "Código";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _clnIntId;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public ViwMain(string strNome)
            : base(strNome)
        {
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        protected override int inicializarColunas(int intOrdem)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.clnIntId.intOrdem = ++intOrdem;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return intOrdem;
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}