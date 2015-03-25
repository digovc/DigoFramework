using System;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public abstract class DbFunction : DbTabela
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private List<string> _lstStrParamIn;

        protected List<string> lstStrParamIn
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstStrParamIn != null)
                    {
                        return _lstStrParamIn;
                    }

                    _lstStrParamIn = new List<string>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lstStrParamIn;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DbFunction(string strNome)
            : base(strNome)
        {
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Executa a função no banco de dados.
        /// </summary>
        public void executar()
        {
            #region VARIÁVEIS

            string sql;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (!"DataBasePostgreSql".Equals(this.objDataBase.GetType().Name))
                {
                    new Erro("Não é possível executar uma \"DbFunction\" num banco de dados diferente do \"PostgreSQL\".");
                    return;
                }

                sql = "select _fnc_nome(_param);";

                sql = sql.Replace("_fnc_nome", this.strNomeSimplificado);
                sql = sql.Replace("_param", this.getStrParamFormatado());

                this.objDataBase.execSqlSemRetorno(sql);
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

        private string getStrParamFormatado()
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = String.Empty;

                foreach (string strParam in this.lstStrParamIn)
                {
                    if (String.IsNullOrEmpty(strParam))
                    {
                        strResultado += "null,";
                        continue;
                    }

                    strResultado += "'";
                    strResultado += strParam.Replace("'", "''");
                    strResultado += "',";
                }

                strResultado = Utils.removerUltimaLetra(strResultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}