using System;

namespace DigoFramework.database
{
    public class SpParametro : Objeto
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private DigoFramework.database.DbColuna.EnmDbColunaTipoGrupo _enmTipoGrupo = DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO;
        public DigoFramework.database.DbColuna.EnmDbColunaTipoGrupo enmTipoGrupo { get { return _enmTipoGrupo; } set { _enmTipoGrupo = value; } }

        private String _strValor = String.Empty;
        public String strValor { get { return _strValor; } set { _strValor = value; } }
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

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// 
        /// </summary>
        public SpParametro(String strNome, String strValor, DigoFramework.database.DbColuna.EnmDbColunaTipoGrupo enmTipoGrupo = DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO)
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
