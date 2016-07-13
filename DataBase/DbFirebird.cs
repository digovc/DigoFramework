using System;
using System.Collections.Generic;
using System.Data.Common;
using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Isql;

namespace DigoFramework.DataBase
{
    public class DbFirebird : DataBase
    {
        #region Constantes

        public const int INT_IDENTIFICADOR_LIMITE = 31;

        #endregion Constantes

        #region Atributos

        private string _dirBancoDados;
        private int _intDialeto = 3;
        private string _strCharSet = "UTF8";

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
                return _strCharSet;
            }

            set
            {
                _strCharSet = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public DbFirebird(string dirBancoDados, string strServer = "127.0.0.1", int intPorta = 3050, string strUser = "SYSDBA", string strSenha = "masterkey")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.dirBancoDados = dirBancoDados;
                this.intPorta = intPorta;
                this.strSenha = strSenha;
                this.strServer = strServer;
                this.strUser = strUser;
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

        public override void addParam(List<PrcParametro> lstObjSpParametro)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (PrcParametro prm in lstObjSpParametro)
                {
                    switch (prm.enmTipoGrupo)
                    {
                        case Coluna.EnmGrupo.ALFANUMERICO:
                            ((FbCommand)this.objComando).Parameters.Add("@" + prm.strNome, FbDbType.Text).Value = prm.strValor;
                            break;

                        case Coluna.EnmGrupo.BOOLEANO:
                            ((FbCommand)this.objComando).Parameters.Add("@" + prm.strNome, FbDbType.Boolean).Value = prm.strValor;
                            break;

                        case Coluna.EnmGrupo.TEMPORAL:
                            ((FbCommand)this.objComando).Parameters.Add("@" + prm.strNome, FbDbType.TimeStamp).Value = prm.strValor;
                            break;

                        case Coluna.EnmGrupo.NUMERICO:
                            ((FbCommand)this.objComando).Parameters.Add("@" + prm.strNome, FbDbType.Numeric).Value = prm.strValor;
                            break;

                        default:
                            ((FbCommand)this.objComando).Parameters.Add("@" + prm.strNome, FbDbType.Text).Value = prm.strValor;
                            break;
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

            #endregion Ações
        }

        /// <summary>
        /// Executa "script sql" complexo no banco de dados.
        /// </summary>
        public override List<string> execScript(string sqlScript)
        {
            #region Variáveis

            FbBatchExecution objFbBatchExecution;
            FbScript objFbScript;
            List<string> lstStrResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return lstStrResultado;
        }

        public override string getSqlTabelaExiste(Tabela objDbTabela)
        {
            #region Variáveis

            string sqlResposta;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return sqlResposta;
        }

        public override string getSqlUpdateOrInsert()
        {
            #region Variáveis

            string sqlResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return sqlResultado;
        }

        public override string getSqlViewExiste(View viw)
        {
            #region Variáveis

            string sqlResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                sqlResultado = "select 1 from rdb$relations where not rdb$view_blr is null and rdb$relation_name = '_viw_nome';";
                sqlResultado = sqlResultado.Replace("_viw_nome", viw.strNomeSimplificado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return sqlResultado;
        }

        protected override DbDataAdapter getObjAdapter()
        {
            return new FbDataAdapter();
        }

        protected override DbCommand getObjComando()
        {
            return new FbCommand();
        }

        protected override DbConnection getObjConexao()
        {
            return new FbConnection(this.getStrConexao());
        }

        private string getStrConexao()
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}