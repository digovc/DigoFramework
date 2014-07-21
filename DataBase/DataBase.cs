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

        private Int64 _intNumeroLinhasAfetadas;
        private Int64 _intNumeroLinhasRetornadas;

        private Int32 _intPorta;

        private List<DbTabela> _lstDbTabela = new List<DbTabela>();

        private DbDataAdapter _objAdapter;

        private Aplicativo _objAplicativo = null;

        private DbCommand _objComando;

        private DbConnection _objConexao;

        private DbDataReader _objReader;

        private DbTransaction _objTransaction;

        //private String _strDbNome = "postgres";
        private String _strDbNome;

        //private String _strSenha = "postgres";
        private String _strSenha;

        //private String _strServer = "localhost";
        private String _strServer = "127.0.0.1";

        private String _strSql = String.Empty;

        //private String _strUser = "postgres";
        private String _strUser;

        public Int64 intNumeroLinhasAfetadas
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

        public Int64 intNumeroLinhasRetornadas
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

        public Int32 intPorta
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
                _objAdapter.SelectCommand = this.objComando;
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
                _objAplicativo = value;
                _objAplicativo.objDataBasePrincipal = this;
            }
        }

        public DbCommand objComando
        {
            get
            {
                _objComando.Connection = this.objConexao;
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

        public String sql
        {
            get
            {
                return _strSql;
            }

            set
            {
                //byte[] bytes = Encoding.Default.GetBytes(value);
                _strSql = value;
            }
        }

        public String strDbNome
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

        public String strSenha
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

        public String strServer
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

        public String strUser
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
        public abstract void addProcedureParametros(List<SpParametro> lstObjSpParametro);

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
        public abstract List<String> execScript(String sqlScript);

        /// <summary>
        /// Apelido para "public String executaSqlGetStr(String strSql)".
        /// </summary>
        public double execSqlGetDbl(String strSql)
        {
            return Convert.ToDouble(this.execSqlGetLstStrLinha(strSql)[0]);
        }

        /// <summary>
        /// Apelido para "public String executaSqlGetStr(String strSql)".
        /// </summary>
        public int execSqlGetInt(String strSql)
        {
            return Convert.ToInt32(this.execSqlGetLstStrLinha(strSql)[0]);
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<String>".
        /// </summary>
        public List<String> execSqlGetLstStr(DbColuna cln)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            this.sql = String.Format("SELECT {0} FROM {1} ORDER BY {0};", cln.strNomeSimplificado, cln.tbl.strNomeSimplificado);
            return this.execSqlGetLstStrColuna(this.sql);

            #endregion
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<itn>".
        /// </summary>
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

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única coluna em
        /// forma de um "List<String>". </summary>
        public List<String> execSqlGetLstStrColuna(String strSql)
        {
            #region VARIÁVEIS

            List<String> lstStrLinhaValor = new List<String>();

            #endregion

            #region AÇÕES

            this.sql = strSql;
            if (this.sql != Utils.STRING_VAZIA)
            {
                try
                {
                    try
                    {
                        this.objConexao.Open();
                    }
                    catch (Exception)
                    {
                    }
                    this.objComando.CommandText = strSql;
                    this.objReader = this.objComando.ExecuteReader();
                    while (this.objReader.Read())
                    {
                        try
                        {
                            var varColunaValor = this.objReader.GetValue(0);
                            var varValorTipo = varColunaValor.GetType();
                            switch (varValorTipo.Name)
                            {
                                //case "Int64":
                                //lstStrLinhaValor.Add(varTemp.ToString());
                                //break;
                                default:
                                    lstStrLinhaValor.Add(varColunaValor.ToString());
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            new Erro("Erro ao tentar converter tipo no Banco de Dados.", ex, Erro.ErroTipo.DATA_BASE);
                        }
                    }
                }
                catch (Exception ex)
                {
                    new Erro("Erro ao executar SQL (" + strSql + ").", ex, Erro.ErroTipo.DATA_BASE);
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                throw new Erro("Estrutura do SQL não pode estar em branco. Comando não executado.", new Exception(), Erro.ErroTipo.DATA_BASE);
            }

            return lstStrLinhaValor;

            #endregion
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única linha em
        /// forma de um "List<String>". </summary>
        public List<String> execSqlGetLstStrLinha(String strSql)
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion

            try
            {
                #region AÇÕES

                if (String.IsNullOrEmpty(strSql))
                {
                    throw new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", new Exception(), Erro.ErroTipo.DATA_BASE);
                }

                lstStrResultado = new List<String>();
                this.sql = strSql;

                try
                {
                    this.objConexao.Open();
                }
                catch (Exception)
                {
                }

                this.objTransaction = this.objConexao.BeginTransaction();

                this.objComando.Transaction = this.objTransaction;
                this.objComando.CommandText = strSql;
                this.objComando.Parameters.Add(new FbParameter("int_id", FbDbType.BigInt));

                this.objReader = this.objComando.ExecuteReader();
                this.objReader.Read();

                for (int intTemp = 0; intTemp < this.objReader.FieldCount; intTemp++)
                {
                    try
                    {
                        lstStrResultado.Add(this.objReader.GetString(intTemp));
                    }
                    catch (Exception)
                    {
                        lstStrResultado.Add(Utils.STRING_VAZIA);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + strSql + ").\n" + ex.Message);
            }
            finally
            {
                this.objReader.Close();
                this.objTransaction.Commit();
                this.objConexao.Close();
            }

            return lstStrResultado;
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados e retorna o respectivo objeto "DataTable" com os
        /// dados encontrados.
        /// </summary>
        public DataTable execSqlGetObjDataTable(String strSql)
        {
            #region VARIÁVEIS

            DataTable objDataTable = null;
            DataSet objDataSet = new DataSet();

            #endregion

            #region AÇÕES

            this.sql = strSql;
            if (this.sql != Utils.STRING_VAZIA)
            {
                try
                {
                    try
                    {
                        this.objConexao.Open();
                    }
                    catch (Exception)
                    {
                    }
                    this.objComando.CommandText = strSql;
                    this.objAdapter.Fill(objDataSet);
                    objDataTable = objDataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    new Erro("Erro ao executar SQL (" + strSql + ").", ex, Erro.ErroTipo.DATA_BASE);
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                throw new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", new Exception(), Erro.ErroTipo.DATA_BASE);
            }
            return objDataTable;

            #endregion
        }

        /// <summary> Apelido para "public List<String> executaSqlGetLstStrLinha(String strSql)". </summary>
        public String execSqlGetStr(String strSql)
        {
            return this.execSqlGetLstStrLinha(strSql)[0];
        }

        /// <summary>
        /// Executa um "SQl" no banco de dados que não retorna valor algum.
        /// </summary>
        public void execSqlSemRetorno(String strSql)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            this.sql = strSql;
            if (this.sql != Utils.STRING_VAZIA)
            {
                try
                {
                    try
                    {
                        this.objConexao.Open();
                    }
                    catch (Exception)
                    {
                    }

                    this.objTransaction = this.objConexao.BeginTransaction();

                    this.objComando.Transaction = this.objTransaction;
                    this.objComando.CommandText = strSql;
                    this.objComando.ExecuteNonQuery();

                    this.objTransaction.Commit();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao executar SQL (" + strSql + ").\n" + ex.Message);
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                throw new Exception("Estrutura do SQL não pode estar em branco. Comando não executado");
            }

            #endregion
        }

        /// <summary>
        ///
        /// </summary>
        public int execStoreProcedure(String strSpNome, List<SpParametro> lstObjSpParamametro)
        {
            #region VARIÁVEIS

            int intResultado = 0;

            #endregion

            try
            {
                #region AÇÕES

                this.objComando = this.objConexao.CreateCommand();
                this.objComando.CommandType = CommandType.StoredProcedure;
                this.objComando.CommandText = strSpNome;

                this.addProcedureParametros(lstObjSpParamametro);

                this.objConexao.Open();
                intResultado = (int)this.objComando.ExecuteScalar();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.objConexao.Close();
            }

            return intResultado;
        }

        public Boolean getBooTabelaExiste(DbTabela objDbTabela)
        {
            #region VARIÁVEIS

            String strSql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strSql = this.getSqlTabelaExiste(objDbTabela);
            this.execSqlGetLstStrLinha(strSql);
            if (this.intNumeroLinhasRetornadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            #endregion
        }

        public Boolean getBooViewExiste(DbView objDbView)
        {
            #region VARIÁVEIS

            String strSql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strSql = this.getSqlViewExiste(objDbView);
            this.execSqlGetLstStrLinha(strSql);
            if (this.intNumeroLinhasRetornadas > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            #endregion
        }

        public abstract String getSqlTabelaExiste(DbTabela objDbTabela);

        public abstract String getSqlUpdateOrInsert();

        public abstract String getSqlViewExiste(DbView objDbView);

        #endregion
    }
}