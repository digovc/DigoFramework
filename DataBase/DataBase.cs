using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using FirebirdSql.Data.FirebirdClient;

namespace DigoFramework.DataBase
{
    public abstract class DataBase : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Int64 _intNumeroLinhasAfetadas;
        public Int64 intNumeroLinhasAfetadas { get { return _intNumeroLinhasAfetadas; } set { _intNumeroLinhasAfetadas = value; } }

        private Int64 _intNumeroLinhasRetornadas;
        public Int64 intNumeroLinhasRetornadas { get { return _intNumeroLinhasRetornadas; } set { _intNumeroLinhasRetornadas = value; } }

        private Int32 _intPorta;
        public Int32 intPorta { get { return _intPorta; } set { _intPorta = value; } }

        private Aplicativo _objAplicativo = null;
        public Aplicativo objAplicativo
        {
            get { return _objAplicativo; }
            set
            {
                _objAplicativo = value;
                _objAplicativo.objDataBasePrincipal = this;
            }
        }

        private DbDataAdapter _objAdapter;
        public DbDataAdapter objAdapter
        {
            get
            {
                _objAdapter.SelectCommand = this.objComando;
                return _objAdapter;
            }
            set { _objAdapter = value; }
        }

        private DbCommand _objComando;
        public DbCommand objComando
        {
            get
            {
                _objComando.Connection = this.objConexao;
                return _objComando;
            }
            set { _objComando = value; }
        }

        private DbConnection _objConexao;
        public DbConnection objConexao { get { return _objConexao; } set { _objConexao = value; } }

        private DbDataReader _objReader;
        public DbDataReader objReader { get { return _objReader; } set { _objReader = value; } }

        private DbTransaction _objTransaction;
        public DbTransaction objTransaction { get { return _objTransaction; } set { _objTransaction = value; } }

        private List<DbTabela> _lstDbTabela = new List<DbTabela>();
        public List<DbTabela> lstDbTabela { get { return _lstDbTabela; } set { _lstDbTabela = value; } }

        //private String _strDbNome = "postgres";
        private String _strDbNome;
        public String strDbNome { get { return _strDbNome; } set { _strDbNome = value; } }

        //private String _strSenha = "postgres";
        private String _strSenha;
        public String strSenha { get { return _strSenha; } set { _strSenha = value; } }

        //private String _strServer = "localhost";
        private String _strServer = "127.0.0.1";
        public String strServer { get { return _strServer; } set { _strServer = value; } }

        private String _strSql = String.Empty;
        public String strSql
        {
            get { return _strSql; }
            set
            {
                //byte[] bytes = Encoding.Default.GetBytes(value);
                _strSql = value;
            }
        }

        //private String _strUser = "postgres";
        private String _strUser;
        public String strUser { get { return _strUser; } set { _strUser = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        /// <summary>
        /// 
        /// </summary>
        public abstract void addProcedureParametros(List<SpParametro> lstObjSpParametro);

        public void carregaDataGrid(DbTabela objDbTabela, System.Windows.Forms.DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            System.Data.DataSet objDataSet = new System.Data.DataSet();

            #endregion

            #region AÇÕES

            try
            {
                this.objComando.CommandText = objDbTabela.getSqlViewPadrao();
                this.objAdapter.Fill(objDataSet, objDbTabela.strNomeSimplificado);
                objDataGridView.DataSource = objDataSet.Tables[objDbTabela.strNomeSimplificado];
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar carregar dados no Grid.", ex, Erro.ErroTipo.BancoDados);
            }
            finally
            {
                this.objConexao.Close();
            }

            #endregion
        }

        public DataTable executaSqlRetornaDataTable(String strSql)
        {
            #region VARIÁVEIS

            DataTable objDataTable = null;
            DataSet objDataSet = new DataSet();

            #endregion

            #region AÇÕES

            this.strSql = strSql;
            if (this.strSql != Utils.STRING_VAZIA)
            {
                try
                {
                    try { this.objConexao.Open(); }
                    catch (Exception) { }
                    this.objComando.CommandText = strSql;
                    this.objAdapter.Fill(objDataSet);
                    objDataTable = objDataSet.Tables[0];
                }
                catch (Exception ex)
                {
                    new Erro("Erro ao executar SQL (" + strSql + ").", ex, Erro.ErroTipo.BancoDados);
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                throw new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", new Exception(), Erro.ErroTipo.BancoDados);
            }
            return objDataTable;

            #endregion
        }

        public List<String> executaSqlRetornaUmaColuna(String strSql)
        {
            #region VARIÁVEIS

            List<String> lstStrLinhaValor = new List<String>();

            #endregion

            #region AÇÕES

            this.strSql = strSql;
            if (this.strSql != Utils.STRING_VAZIA)
            {
                try
                {
                    try { this.objConexao.Open(); }
                    catch (Exception) { }
                    this.objComando.CommandText = strSql;
                    this.objReader = this.objComando.ExecuteReader();
                    while (this.objReader.Read())
                    {
                        try
                        {
                            var varColunaValor = this.objReader.GetValue(0);
                            var vatValorTipo = varColunaValor.GetType();
                            switch (vatValorTipo.Name)
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
                            new Erro("Erro ao tentar converter tipo no Banco de Dados.", ex, Erro.ErroTipo.BancoDados);
                        }
                    }
                }
                catch (Exception ex)
                {
                    new Erro("Erro ao executar SQL (" + strSql + ").", ex, Erro.ErroTipo.BancoDados);
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                throw new Erro("Estrutura do SQL não pode estar em branco. Comando não executado.", new Exception(), Erro.ErroTipo.BancoDados);
            }

            return lstStrLinhaValor;

            #endregion
        }

        public List<String> executaSqlRetornaUmaColuna(DbColuna objDbColuna)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strSql = String.Format("SELECT {0} FROM {1} ORDER BY {0};", objDbColuna.strNomeSimplificado, objDbColuna.objDbTabela.strNomeSimplificado);
            return this.executaSqlRetornaUmaColuna(this.strSql);

            #endregion

        }

        public List<String> executaSqlRetornaUmaLinha(String strSql)
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            this.strSql = strSql;
            if (this.strSql != Utils.STRING_VAZIA)
            {
                try
                {
                    try { this.objConexao.Open(); }
                    catch (Exception) { }
                    this.objComando.CommandText = strSql;
                    this.objReader = this.objComando.ExecuteReader();
                    this.objReader.Read();
                    for (int intTemp = 0; intTemp < this.objReader.FieldCount; intTemp++)
                    {
                        try { lstStrColunaValor.Add(this.objReader.GetString(intTemp)); }
                        catch (Exception) { lstStrColunaValor.Add(Utils.STRING_VAZIA); }
                    }
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                throw new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", new Exception(), Erro.ErroTipo.BancoDados);
            }

            return lstStrColunaValor;

            #endregion
        }

        public void executaSqlSemRetorno(String strSql)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strSql = strSql;
            if (this.strSql != Utils.STRING_VAZIA)
            {
                try
                {
                    try { this.objConexao.Open(); }
                    catch (Exception) { }
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
        public int executaStoreProcedure(String strSpNome, List<SpParametro> lstObjSpParamametro)
        {
            #region VARIÁVEIS

            int intResultado = 0;
            object objTipoValor;

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
            this.executaSqlRetornaUmaLinha(strSql);
            if (this.intNumeroLinhasRetornadas > 0) { return true; }
            else { return false; }

            #endregion
        }

        public Boolean getBooViewExiste(DbView objDbView)
        {
            #region VARIÁVEIS

            String strSql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strSql = this.getSqlViewExiste(objDbView);
            this.executaSqlRetornaUmaLinha(strSql);
            if (this.intNumeroLinhasRetornadas > 0) { return true; }
            else { return false; }

            #endregion
        }

        public abstract String getSqlTabelaExiste(DbTabela objDbTabela);

        public abstract String getSqlUpdateOrInserte();

        public abstract String getSqlViewExiste(DbView objDbView);

        #endregion
    }
}