using System;
using DigoFramework.DataBase;

namespace DigoFramework.Tabela.View
{
    public abstract class ViwMain : DbView
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DbColuna _clnIntId;

        public DbColuna clnIntId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _clnIntId;
            }
        }

        #endregion Atributos

        #region Construtores

        public ViwMain(string strNome)
            : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        protected override int inicializarColunas(int intOrdem)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return intOrdem;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}