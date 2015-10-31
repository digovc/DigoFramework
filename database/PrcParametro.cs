using System;

namespace DigoFramework.DataBase
{
    public class PrcParametro : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _intValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = value;

                    this.strValor = Convert.ToString(value);
                }
                catch
                {
                    this.strValor = string.Empty;
                }
                finally
                {
                }

                #endregion Ações
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

        #endregion Atributos

        #region Construtores

        /// <summary>
        /// </summary>
        public PrcParametro(string strNome, string strValor, DbColuna.EnmGrupo enmTipoGrupo = DbColuna.EnmGrupo.ALFANUMERICO)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos
    }
}