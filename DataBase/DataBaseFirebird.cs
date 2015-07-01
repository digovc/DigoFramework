using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;
using System;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public class DataBaseFirebird : DataBase
    {
        #region CONSTANTES

        public const int INT_IDENTIFICADOR_LIMITE = 31;

        #endregion CONSTANTES

        #region ATRIBUTOS

        private string _dirBancoDados;
        private int _intDialeto = 3;
        private string _strCharSet;

        public string dirBancoDados
        {
            get
            {
                return _dirBancoDados;
            }

            set
            {
                _dirBancoDados = value;
            }
        }

        public int intDialect
        {
            get
            {
                return _intDialeto;
            }

            set
            {
                _intDialeto = value;
            }
        }

        public string strCharSet
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!string.IsNullOrEmpty(_strCharSet))
                    {
                        return _strCharSet;
                    }

                    _strCharSet = "UTF8";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _strCharSet;
            }

            set
            {
                _strCharSet = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DataBaseFirebird(string dirBancoDados, string strServer = "127.0.0.1", int intPorta = 3050, string strUser = "SYSDBA", string strSenha = "masterkey")
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.dirBancoDados = dirBancoDados;
                this.strServer = strServer;
                this.intPorta = intPorta;
                this.strUser = strUser;
                this.strSenha = strSenha;
                this.objConexao = new FbConnection(this.getStrConexao());
                this.objAdapter = new FbDataAdapter();
                this.objComando = new FbCommand();
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

        public override void addProcedureParametros(List<PrcParametro> lstObjSpParametro)
        {
            #region VARIÁVEIS

            FbCommand objFbCommandTemp;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                objFbCommandTemp = (FbCommand)this.objComando;

                foreach (PrcParametro objSpParamNome in lstObjSpParametro)
                {
                    switch (objSpParamNome.enmTipoGrupo)
                    {
                        case DbColuna.EnmGrupo.ALFANUMERICO:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Text).Value = objSpParamNome.strValor;
                            break;

                        case DbColuna.EnmGrupo.BOOLEANO:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Boolean).Value = objSpParamNome.strValor;
                            break;

                        case DbColuna.EnmGrupo.TEMPORAL:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.TimeStamp).Value = objSpParamNome.strValor;
                            break;

                        case DbColuna.EnmGrupo.NUMERICO:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Numeric).Value = objSpParamNome.strValor;
                            break;

                        default:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Text).Value = objSpParamNome.strValor;
                            break;
                    }
                }

                this.objComando = objFbCommandTemp;
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

        /// <summary>
        /// Executa "script sql" complexo no banco de dados.
        /// </summary>
        public override List<string> execScript(string sqlScript)
        {
            #region VARIÁVEIS

            FbBatchExecution objFbBatchExecution;
            FbScript objFbScript;
            List<string> lstStrResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstStrResultado = new List<string>();
                objFbScript = new FbScript(sqlScript);
                objFbScript.Parse();
                objFbBatchExecution = new FbBatchExecution((FbConnection)this.objConexao);

                foreach (var item in objFbScript.Results)
                {
                    objFbBatchExecution.SqlStatements.Clear();
                    objFbBatchExecution.SqlStatements.Add(item);

                    try
                    {
                        objFbBatchExecution.Execute(true);
                    }
                    catch (Exception ex)
                    {
                        lstStrResultado.Add(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return lstStrResultado;
        }

        public override string getSqlTabelaExiste(DbTabela objDbTabela)
        {
            #region VARIÁVEIS

            string sqlResposta;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sqlResposta = "select rdb$relation_name from rdb$relations where rdb$view_blr is null and rdb$relation_name = '_tbl_nome';";
                sqlResposta = sqlResposta.Replace("_tbl_nome", objDbTabela.strNomeSimplificado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return sqlResposta;
        }

        public override string getSqlUpdateOrInsert()
        {
            #region VARIÁVEIS

            string sqlResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sqlResultado = "update or insert into {0} ({3}) values ({4}) matching ({1});";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return sqlResultado;
        }

        public override string getSqlViewExiste(DbView viw)
        {
            #region VARIÁVEIS

            string sqlResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sqlResultado = "select rdb$relation_name from rdb$relations where not rdb$view_blr is null and rdb$relation_name = '_viw_nome';";
                sqlResultado = sqlResultado.Replace("_viw_nome", viw.strNomeSimplificado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return sqlResultado;
        }

        private string getStrConexao()
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = "user=_user;password=_pass;database=_database;datasource=_datasorce;port=_port;dialect=_dialect;charset=_charset;role=;connection lifetime=15;pooling=true;minpoolsize=0;maxpoolsize=50;packet size=8192;servertype=0";
                strResultado = strResultado.Replace("_user", this.strUser);
                strResultado = strResultado.Replace("_pass", this.strSenha);
                strResultado = strResultado.Replace("_database", this.dirBancoDados);
                strResultado = strResultado.Replace("_datasorce", this.strServer);
                strResultado = strResultado.Replace("_port", this.intPorta.ToString());
                strResultado = strResultado.Replace("_dialect", this.intDialect.ToString());
                strResultado = strResultado.Replace("_charset", this.strCharSet);
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