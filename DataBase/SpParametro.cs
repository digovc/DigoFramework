using System;

namespace DigoFramework.database
{
    public class SpParametro : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private DigoFramework.database.DbColuna.EnmGrupo _enmTipoGrupo = DbColuna.EnmGrupo.ALFANUMERICO;
        private String _strValor = String.Empty;

        public DigoFramework.database.DbColuna.EnmGrupo enmTipoGrupo
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
                return Convert.ToInt32(_strValor);
            }

            set
            {
                _strValor = Convert.ToString(value);
            }
        }

        public String strValor
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

        #endregion

        #region CONSTRUTORES

        /// <summary>
        ///
        /// </summary>
        public SpParametro(String strNome, String strValor, DigoFramework.database.DbColuna.EnmGrupo enmTipoGrupo = DbColuna.EnmGrupo.ALFANUMERICO)
        {
            #region VARIÁVEIS

            this.strNome = strNome;
            this.strValor = strValor;
            this.enmTipoGrupo = enmTipoGrupo;

            #endregion

            try
            {
                #region AÇÕES

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region MÉTODOS

        #endregion
    }
}