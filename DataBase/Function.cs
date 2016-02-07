using System;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public abstract class Function : Tabela
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<string> _lstStrParamIn;

        protected List<string> lstStrParamIn
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

                return _lstStrParamIn;
            }
        }

        #endregion Atributos

        #region Construtores

        public Function(string strNome)
            : base(strNome)
        {
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Executa a função no banco de dados.
        /// </summary>
        public void executar()
        {
            #region Variáveis

            string sql;

            #endregion Variáveis

            #region Ações

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

                this.objDataBase.execSql(sql);
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

        private string getStrParamFormatado()
        {
            #region Variáveis

            string strResultado = null;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = string.Empty;

                foreach (string strParam in this.lstStrParamIn)
                {
                    if (string.IsNullOrEmpty(strParam))
                    {
                        strResultado += "null,";
                        continue;
                    }

                    strResultado += "'";
                    strResultado += strParam.Replace("'", "''");
                    strResultado += "',";
                }

                strResultado = Utils.removerCaracter(strResultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}