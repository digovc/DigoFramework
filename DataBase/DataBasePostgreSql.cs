using Npgsql;
using System;
using System.Collections.Generic;

namespace DigoFramework.database
{
    public class DataBasePostgreSql : DataBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private NpgsqlDataReader _objNpgsqlDataReader;

        public NpgsqlDataReader objNpgsqlDataReader
        {
            get
            {
                return _objNpgsqlDataReader;
            }

            set
            {
                _objNpgsqlDataReader = value;
            }
        }

        #endregion

        #region CONSTRUTORES

        public DataBasePostgreSql(Aplicativo objAplicativo, string strServer = "127.0.0.1", int intPorta = 5432, string strUser = "postgres", string strSenha = "postgres", string strDbNome = "postgres")
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.objAplicativo = objAplicativo;
                this.strServer = strServer;
                this.intPorta = intPorta;
                this.strUser = strUser;
                this.strSenha = strSenha;
                this.strDbNome = strDbNome;
                this.objConexao = new NpgsqlConnection(this.getStrConexao());
                this.objAdapter = new NpgsqlDataAdapter();
                this.objComando = new NpgsqlCommand();
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

        #endregion

        #region MÉTODOS

        public override void addProcedureParametros(System.Collections.Generic.List<PrcParametro> lstObjSpParametro)
        {
            throw new NotImplementedException();
        }

        public override List<string> execScript(string sqlScript)
        {
            throw new NotImplementedException();
        }

        public override string getSqlTabelaExiste(DbTabela tbl)
        {
            #region VARIÁVEIS

            string sqlResultado = Utils.STR_VAZIA;

            #endregion

            #region AÇÕES

            try
            {
                sqlResultado = "select relname from pg_class where relname = '_tbl_nome' and relkind='r';";
                sqlResultado = sqlResultado.Replace("_tbl_nome", tbl.strNomeSimplificado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return sqlResultado;
        }

        public override string getSqlUpdateOrInsert()
        {
            #region VARIÁVEIS

            string sql;

            #endregion

            #region AÇÕES

            try
            {
                sql = "update {0} set {5} where {1}={2}; insert into {0} ({3}) select {4} where not exists (select 1 from {0} where {1}={2});";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return sql;
        }

        public override string getSqlViewExiste(DbView objDbView)
        {
            throw new NotImplementedException();
        }

        private string getStrConexao()
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = "server=_server;port=_port;user id=_user;password=_pass;database=_database;";
                strResultado = strResultado.Replace("_server", this.strServer);
                strResultado = strResultado.Replace("_port", this.intPorta.ToString());
                strResultado = strResultado.Replace("_user", this.strUser);
                strResultado = strResultado.Replace("_pass", this.strSenha);
                strResultado = strResultado.Replace("_database", this.strDbNome);
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
    }
}