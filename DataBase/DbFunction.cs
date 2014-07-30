﻿using System;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public abstract class DbFunction : DbTabela
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private List<string> _lstStrParamIn;

        protected List<string> lstStrParamIn
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _lstStrParamIn;
            }
        }

        #endregion

        #region CONSTRUTORES

        public DbFunction(string strNome)
            : base(strNome)
        {
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Executa a função no banco de dados.
        /// </summary>
        public void executar()
        {
            #region VARIÁVEIS

            string sql;

            #endregion

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

            #endregion
        }

        private string getStrParamFormatado()
        {
            #region VARIÁVEIS

            string strResultado = null;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = Utils.STR_VAZIA;

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

            #endregion

            return strResultado;
        }

        #endregion

        #region EVENTOS

        #endregion
    }
}