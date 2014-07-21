using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace DigoFramework.database
{
    public abstract class DataBase : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private int _intNumeroLinhasAfetadas;
        private int _intNumeroLinhasRetornadas;
        private int _intPorta;
        private List<DbTabela> _lstDbTabela;
        private DbDataAdapter _objAdapter;
        private Aplicativo _objAplicativo;
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

                #endregion

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

                #endregion

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

                #endregion

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

                #endregion

                return _objAdapter;
            }

            set
            {
                _objAdapter = value;
            }
        }

        public Aplicativo objAplicativo
        {
            get
            {
                return _objAplicativo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _objAplicativo = value;

                    if (_objAplicativo.objDataBasePrincipal != null)
                    {
                        _objAplicativo.objDataBasePrincipal = this;
                    }
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
        }

        public DbCommand objComando
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

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

        #endregion

        #region CONSTRUTORES

        #endregion

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

            #endregion

            #region AÇÕES

            try
            {
                objDataSet = new System.Data.DataSet();
                this.objComando.CommandText = tbl.getSqlSelectTelaConsulta();
                this.objAdapter.Fill(objDataSet, tbl.strNomeSimplificado);
                objDataGridView.DataSource = objDataSet.Tables[tbl.strNomeSimplificado];
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar carregar dados no Grid.", ex, Erro.ErroTipo.DATA_BASE);
            }
            finally
            {
                this.objConexao.Close();
            }

            #endregion
        }

        /// <summary>
        /// Executa "script sql" complexo no banco de dados.
        /// </summary>
        public abstract List<String> execScript(string sqlScript);

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string strSql)".
        /// </summary>
        public double execSqlGetDbl(string strSql)
        {
            #region VARIÁVEIS

            double dblResultado;

            #endregion

            #region AÇÕES

            try
            {
                dblResultado = Convert.ToDouble(this.execSqlGetLstStrLinha(strSql)[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return dblResultado;
        }

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string strSql)".
        /// </summary>
        public int execSqlGetInt(string strSql)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion

            #region AÇÕES

            try
            {
                intResultado = Convert.ToInt32(this.execSqlGetLstStrLinha(strSql)[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return intResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<itn>". </summary>
        public List<int> execSqlGetLstInt(DbColuna cln)
        {
            #region VARIÁVEIS

            List<int> lstIntResultado;
            List<string> lstStr;

            #endregion

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

            #endregion

            return lstIntResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStr(DbColuna cln)
        {
            #region VARIÁVEIS

            List<string> lstStrResultado;
            string sql;

            #endregion

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

            #endregion

            return lstStrResultado;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única coluna em
        /// forma de um "List<String>". </summary>
        public List<String> execSqlGetLstStrColuna(string sql)
        {
            #region VARIÁVEIS

            List<String> lstStrLinhaValor = new List<String>();

            #endregion

            #region AÇÕES

            try
            {
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.objConexao.Close();
            }

            #endregion

            return lstStrLinhaValor;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única linha em
        /// forma de um "List<String>". </summary>
        public List<string> execSqlGetLstStrLinha(string sql)
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion

            #region AÇÕES

            try
            {
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
                this.objReader.Read();

                lstStrResultado = new List<String>();

                for (int intTemp = 0; intTemp < this.objReader.FieldCount; intTemp++)
                {
                    lstStrResultado.Add(this.objReader.GetString(intTemp));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.objReader.Close();
                this.objTransaction.Commit();
                this.objConexao.Close();
            }

            #endregion

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

            #endregion

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

            #endregion

            return objDataTable;
        }

        /// <summary> Apelido para "public List<String> executaSqlGetLstStrLinha(string strSql)". </summary>
        public string execSqlGetStr(string strSql)
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = this.execSqlGetLstStrLinha(strSql)[0];
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

        /// <summary>
        /// Executa um "SQl" no banco de dados que não retorna valor algum.
        /// </summary>
        public void execSqlSemRetorno(string sql)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
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
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.objConexao.Close();
            }

            #endregion
        }

        /// <summary>
        /// Executa uma "StoreProcedure" no banco de dados.
        /// </summary>
        public int execStoreProcedure(string strSpNome, List<PrcParametro> lstObjSpParamametro)
        {
            #region VARIÁVEIS

            int intResultado;

            #endregion

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

            #endregion

            return intResultado;
        }

        public bool getBooTabelaExiste(DbTabela tbl)
        {
            #region VARIÁVEIS

            string sql;

            #endregion

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

            #endregion
        }

        public bool getBooViewExiste(DbView objDbView)
        {
            #region VARIÁVEIS

            string sql;

            #endregion

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

            #endregion
        }

        public abstract string getSqlTabelaExiste(DbTabela objDbTabela);

        public abstract string getSqlUpdateOrInsert();

        public abstract string getSqlViewExiste(DbView objDbView);

        private void abrirConexao()
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion
        }

        #endregion
    }
}