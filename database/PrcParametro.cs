using System;

namespace DigoFramework.DataBase
{
    public class PrcParametro : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private DbColuna.EnmGrupo _enmTipoGrupo;
        private int _intValor;
        private string _strValor;

        public DbColuna.EnmGrupo enmTipoGrupo
        {
            get
            {
                return _enmTipoGrupo;
            }

            set
            {
                _enmTipoGrupo = value;
            }
        }

        public int intValor
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intValor = Convert.ToInt32(this.strValor);
                }
                catch
                {
                    return 0;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _intValor;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intValor = value;

                    this.strValor = Convert.ToString(value);
                }
                catch
                {
                    this.strValor = String.Empty;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public string strValor
        {
            get
            {
                return _strValor;
            }

            set
            {
                _strValor = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        /// <summary>
        ///
        /// </summary>
        public PrcParametro(string strNome, string strValor, DbColuna.EnmGrupo enmTipoGrupo = DbColuna.EnmGrupo.ALFANUMERICO)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.strNome = strNome;
                this.strValor = strValor;
                this.enmTipoGrupo = enmTipoGrupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        #endregion MÉTODOS
    }
}