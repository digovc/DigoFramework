using DigoFramework.DataBase;
using System;

namespace DigoFramework.Tabela.View
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

                #region AÇÕES

                try
                {
                    if (_clnIntId == null)
                    {
                        _clnIntId = new DbColuna("int_id", this);
                        _clnIntId.booChavePrimaria = true;
                        _clnIntId.enmTipo = DbColuna.EnmTipo.BIGINT;
                        _clnIntId.intTamanho = 25;
                        _clnIntId.strNomeExibicao = "Código";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _clnIntId;
            }
        }

        #endregion

        #region CONSTRUTORES

        public ViwMain(string strNome)
            : base(strNome)
        {
        }

        #endregion

        #region DESTRUTOR

        #endregion

        #region MÉTODOS

        protected override int inicializarColunas(int intOrdem)
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion

            return intOrdem;
        }

        #endregion

        #region EVENTOS

        #endregion
    }
}