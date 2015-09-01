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
        #region Constantes

        #endregion Constantes

        #region Atributos

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações

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

        #endregion Atributos

        #region Construtores

        public DataBase()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        /// <summary>
        /// Adiciona a lista de parâmetros de entrada de uma procedure.
        /// </summary>
        public abstract void addProcedureParametros(List<PrcParametro> lstObjSpParametro);

        /// <summary>
        /// Carrega os dados da tabela de consulta em um componente "DataGridView".
        /// </summary>
        public void carregarDataGrid(DbTabela tbl, DataGridView objDataGridView)
        {
            #region Variáveis

            DataSet objDataSet;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Executa "script sql" complexo no banco de dados.
        /// </summary>
        public abstract List<string> execScript(string sqlScript);

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string sql)".
        /// </summary>
        public decimal execSqlGetDec(string sql)
        {
            #region Variáveis

            decimal decResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return decResultado;
        }

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string sql)".
        /// </summary>
        public int execSqlGetInt(string sql)
        {
            #region Variáveis

            int intResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return intResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<itn>". </summary>
        public List<int> execSqlGetLstInt(DbColuna cln)
        {
            #region Variáveis

            List<int> lstIntResultado;
            List<string> lstStr;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return lstIntResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStr(DbColuna cln)
        {
            #region Variáveis

            List<string> lstStrResultado;
            string sql;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return lstStrResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única coluna em
        /// forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStrColuna(string sql)
        {
            #region Variáveis

            List<string> lstStrLinhaValor = new List<string>();

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;

                    if (string.IsNullOrEmpty(sql))
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

            #endregion Ações

            return lstStrLinhaValor;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única linha em
        /// forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStrLinha(string sql)
        {
            #region Variáveis

            List<string> lstStrResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;

                    if (string.IsNullOrEmpty(sql))
                    {
                        return null;
                    }

                    this.abrirConexao();

                    this.objTransaction = this.objConexao.BeginTransaction();

                    this.objComando.Transaction = this.objTransaction;
                    this.objComando.CommandText = sql;
                    this.objComando.Parameters.Add(new FbParameter("int_id", FbDbType.BigInt));

                    this.objReader = this.objComando.ExecuteReader();

                    lstStrResultado = new List<string>();

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

            #endregion Ações

            return lstStrResultado;
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados e retorna o respectivo objeto "DataTable" com os
        /// dados encontrados.
        /// </summary>
        public DataTable execSqlGetObjDataTable(string sql)
        {
            #region Variáveis

            DataTable objDataTable = null;
            DataSet objDataSet = new DataSet();

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(sql))
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

            #endregion Ações

            return objDataTable;
        }

        /// <summary> Apelido para "public List<String> executaSqlGetLstStrLinha(string sql)". </summary>
        public string execSqlGetStr(string sql)
        {
            #region Variáveis

            List<string> lstStr;
            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstStr = this.execSqlGetLstStrLinha(sql);

                if (lstStr == null || lstStr.Count == 0)
                {
                    return string.Empty;
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

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados que não retorna valor algum.
        /// </summary>
        public void execSqlSemRetorno(string sql)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.lockCode)
                {
                    this.booExecutandoSql = true;

                    if (string.IsNullOrEmpty(sql))
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

            #endregion Ações
        }

        /// <summary>
        /// Executa uma "StoreProcedure" no banco de dados.
        /// </summary>
        public int execStoreProcedure(string strSpNome, List<PrcParametro> lstObjSpParamametro)
        {
            #region Variáveis

            int intResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return intResultado;
        }

        public bool getBooTabelaExiste(DbTabela tbl)
        {
            #region Variáveis

            string sql;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public bool getBooViewExiste(DbView objDbView)
        {
            #region Variáveis

            string sql;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        public abstract string getSqlTabelaExiste(DbTabela objDbTabela);

        public abstract string getSqlUpdateOrInsert();

        public abstract string getSqlViewExiste(DbView objDbView);

        private void abrirConexao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Verifica e aguarda até que nenhuma execução de SQL esteja acontecendo.
        /// </summary>
        private void aguardarExecucao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                while (this.booExecutandoSql)
                {
                    Thread.Sleep(100);
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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}