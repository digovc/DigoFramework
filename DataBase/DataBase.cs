using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Windows.Forms;

namespace DigoFramework.DataBase
{
    public abstract class DataBase : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private bool _booExecutandoSql;
        private int _intNumeroLinhasAfetadas;
        private int _intNumeroLinhasRetornadas;
        private int _intPorta;
        private List<DbTabela> _lstDbTabela;
        private DbDataAdapter _objAdapter;
        private DbCommand _objComando;
        private DbConnection _objConexao;
        private DbDataReader _objReader;
        private DbTransaction _objTransaction;
        private string _strDbNome;
        private string _strSenha;
        private string _strServer;
        private string _strUser;

        public int intNumeroLinhasAfetadas
        {
            get
            {
                return _intNumeroLinhasAfetadas;
            }

            set
            {
                _intNumeroLinhasAfetadas = value;
            }
        }

        public int intNumeroLinhasRetornadas
        {
            get
            {
                return _intNumeroLinhasRetornadas;
            }

            set
            {
                _intNumeroLinhasRetornadas = value;
            }
        }

        public int intPorta
        {
            get
            {
                return _intPorta;
            }

            set
            {
                _intPorta = value;
            }
        }

        public List<DbTabela> lstDbTabela
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstDbTabela != null)
                    {
                        return _lstDbTabela;
                    }

                    _lstDbTabela = new List<DbTabela>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _lstDbTabela;
            }

            set
            {
                _lstDbTabela = value;
            }
        }

        public DbDataAdapter objAdapter
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _objAdapter.SelectCommand = this.objComando;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _objAdapter;
            }

            set
            {
                _objAdapter = value;
            }
        }

        public DbCommand objComando
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _objComando.Connection = this.objConexao;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _objComando;
            }

            set
            {
                _objComando = value;
            }
        }

        public DbConnection objConexao
        {
            get
            {
                return _objConexao;
            }

            set
            {
                _objConexao = value;
            }
        }

        public DbDataReader objReader
        {
            get
            {
                return _objReader;
            }

            set
            {
                _objReader = value;
            }
        }

        public DbTransaction objTransaction
        {
            get
            {
                return _objTransaction;
            }

            set
            {
                _objTransaction = value;
            }
        }

        public string strDbNome
        {
            get
            {
                return _strDbNome;
            }

            set
            {
                _strDbNome = value;
            }
        }

        public string strSenha
        {
            get
            {
                return _strSenha;
            }

            set
            {
                _strSenha = value;
            }
        }

        public string strServer
        {
            get
            {
                return _strServer;
            }

            set
            {
                _strServer = value;
            }
        }

        public string strUser
        {
            get
            {
                return _strUser;
            }

            set
            {
                _strUser = value;
            }
        }

        private bool booExecutandoSql
        {
            get
            {
                lock (this.lockCode)
                {
                    return _booExecutandoSql;
                }
            }

            set
            {
                lock (this.lockCode)
                {
                    _booExecutandoSql = value;
                }
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DataBase()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (Aplicativo.i.objDbPrincipal == null)
                {
                    Aplicativo.i.objDbPrincipal = this;
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
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Adiciona a lista de parâmetros de entrada de uma procedure.
        /// </summary>
        public abstract void addProcedureParametros(List<PrcParametro> lstObjSpParametro);

        /// <summary>
        /// Carrega os dados da tabela de consulta em um componente "DataGridView".
        /// </summary>
        public void carregarDataGrid(DbTabela tbl, DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            DataSet objDataSet;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;
                    objDataSet = new System.Data.DataSet();
                    this.objComando.CommandText = tbl.getSqlSelectTelaConsulta();
                    this.objAdapter.Fill(objDataSet, tbl.strNomeSimplificado);
                    objDataGridView.DataSource = objDataSet.Tables[tbl.strNomeSimplificado];
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar carregar dados no Grid.", ex, Erro.ErroTipo.DATA_BASE);
            }
            finally
            {
                this.objConexao.Close();
                this.booExecutandoSql = false;
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Executa "script sql" complexo no banco de dados.
        /// </summary>
        public abstract List<String> execScript(string sqlScript);

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string sql)".
        /// </summary>
        public decimal execSqlGetDec(string sql)
        {
            #region VARIÁVEIS

            decimal decResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                decResultado = Convert.ToDecimal(this.execSqlGetLstStrLinha(sql)[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return decResultado;
        }

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string sql)".
        /// </summary>
        public int execSqlGetInt(string sql)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                intResultado = Convert.ToInt32(this.execSqlGetLstStrLinha(sql)[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return intResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<itn>". </summary>
        public List<int> execSqlGetLstInt(DbColuna cln)
        {
            #region VARIÁVEIS

            List<int> lstIntResultado;
            List<string> lstStr;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstIntResultado = new List<int>();

                lstStr = this.execSqlGetLstStr(cln);

                foreach (string str in lstStr)
                {
                    lstIntResultado.Add(Convert.ToInt32(str));
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

            return lstIntResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStr(DbColuna cln)
        {
            #region VARIÁVEIS

            List<string> lstStrResultado;
            string sql;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sql = "select _cln_nome from _tbl_nome order by _cln_nome;";
                sql = sql.Replace("_cln_nome", cln.strNomeSimplificado);
                sql = sql.Replace("_tbl_nome", cln.tbl.strNomeSimplificado);

                lstStrResultado = this.execSqlGetLstStrColuna(sql);
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

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única coluna em
        /// forma de um "List<String>". </summary>
        public List<String> execSqlGetLstStrColuna(string sql)
        {
            #region VARIÁVEIS

            List<String> lstStrLinhaValor = new List<String>();

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;

                    if (String.IsNullOrEmpty(sql))
                    {
                        return null;
                    }

                    this.abrirConexao();
                    this.objComando.CommandText = sql;
                    this.objReader = this.objComando.ExecuteReader();

                    while (this.objReader.Read())
                    {
                        lstStrLinhaValor.Add(this.objReader.GetValue(0).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.objConexao.Close();
                this.booExecutandoSql = false;
            }

            #endregion AÇÕES

            return lstStrLinhaValor;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única linha em
        /// forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStrLinha(string sql)
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;

                    if (String.IsNullOrEmpty(sql))
                    {
                        return null;
                    }

                    this.abrirConexao();

                    this.objTransaction = this.objConexao.BeginTransaction();

                    this.objComando.Transaction = this.objTransaction;
                    this.objComando.CommandText = sql;
                    this.objComando.Parameters.Add(new FbParameter("int_id", FbDbType.BigInt));

                    this.objReader = this.objComando.ExecuteReader();

                    lstStrResultado = new List<String>();

                    if (!this.objReader.Read())
                    {
                        return lstStrResultado;
                    }

                    for (int i = 0; i < this.objReader.FieldCount; i++)
                    {
                        var temp = this.objReader.GetString(i);
                        lstStrResultado.Add(this.objReader.GetString(i));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                if (this.objReader != null)
                {
                    this.objReader.Close();
                }

                if (this.objTransaction != null)
                {
                    this.objTransaction.Commit();
                }

                this.objConexao.Close();
                this.booExecutandoSql = false;
            }

            #endregion AÇÕES

            return lstStrResultado;
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados e retorna o respectivo objeto "DataTable" com os
        /// dados encontrados.
        /// </summary>
        public DataTable execSqlGetObjDataTable(string sql)
        {
            #region VARIÁVEIS

            DataTable objDataTable = null;
            DataSet objDataSet = new DataSet();

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (String.IsNullOrEmpty(sql))
                {
                    return null;
                }

                this.abrirConexao();
                this.objComando.CommandText = sql;
                this.objAdapter.Fill(objDataSet);
                objDataTable = objDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.objConexao.Close();
            }

            #endregion AÇÕES

            return objDataTable;
        }

        /// <summary> Apelido para "public List<String> executaSqlGetLstStrLinha(string sql)". </summary>
        public string execSqlGetStr(string sql)
        {
            #region VARIÁVEIS

            List<string> lstStr;
            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstStr = this.execSqlGetLstStrLinha(sql);

                if (lstStr == null || lstStr.Count == 0)
                {
                    return String.Empty;
                }

                strResultado = lstStr[0];
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

        /// <summary>
        /// Executa um "SQl" no banco de dados que não retorna valor algum.
        /// </summary>
        public void execSqlSemRetorno(string sql)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;

                    if (String.IsNullOrEmpty(sql))
                    {
                        return;
                    }

                    this.abrirConexao();
                    this.objTransaction = this.objConexao.BeginTransaction();

                    this.objComando.Transaction = this.objTransaction;
                    this.objComando.CommandText = sql;
                    this.objComando.ExecuteNonQuery();

                    this.objTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.objConexao.Close();
                this.booExecutandoSql = false;
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Executa uma "StoreProcedure" no banco de dados.
        /// </summary>
        public int execStoreProcedure(string strSpNome, List<PrcParametro> lstObjSpParamametro)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.abrirConexao();

                this.objComando = this.objConexao.CreateCommand();
                this.objComando.CommandType = CommandType.StoredProcedure;
                this.objComando.CommandText = strSpNome;

                this.addProcedureParametros(lstObjSpParamametro);

                intResultado = (int)this.objComando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.objConexao.Close();
            }

            #endregion AÇÕES

            return intResultado;
        }

        public bool getBooTabelaExiste(DbTabela tbl)
        {
            #region VARIÁVEIS

            string sql;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sql = this.getSqlTabelaExiste(tbl);

                this.execSqlGetLstStrLinha(sql);

                if (this.intNumeroLinhasRetornadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
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
        }

        public bool getBooViewExiste(DbView objDbView)
        {
            #region VARIÁVEIS

            string sql;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sql = this.getSqlViewExiste(objDbView);

                this.execSqlGetLstStrLinha(sql);

                if (this.intNumeroLinhasRetornadas > 0)
                {
                    return true;
                }
                else
                {
                    return false;
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
        }

        public abstract string getSqlTabelaExiste(DbTabela objDbTabela);

        public abstract string getSqlUpdateOrInsert();

        public abstract string getSqlViewExiste(DbView objDbView);

        private void abrirConexao()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (this.objConexao.State.Equals(ConnectionState.Closed))
                {
                    this.objConexao.Open();
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
        }

        /// <summary>
        /// Verifica e aguarda até que nenhuma execução de SQL esteja acontecendo.
        /// </summary>
        private void aguardarExecucao()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                while (this.booExecutandoSql)
                {
                    Thread.Sleep(10);
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
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}