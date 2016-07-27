using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace DigoFramework.DataBase
{
    public abstract class DataBase : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booExecutandoSql;
        private int _intLinhaAfetadaQtd;
        private int _intLinhaRetornadaQtd;
        private int _intPorta;
        private List<Tabela> _lstTbl;
        private DbDataAdapter _objAdapter;
        private object _objBooExecutandoSqlLock;
        private object _objCarregarGridLock;
        private DbCommand _objComando;
        private DbConnection _objConexao;
        private object _objExecSqlLock;
        private object _objExecSqlLstStrColunaLock;
        private object _objExecSqlLstStrLinhaLock;
        private DbDataReader _objReader;
        private DbTransaction _objTransaction;
        private string _strDbNome;
        private string _strSenha;
        private string _strServer = "127.0.0.1";
        private string _strUser;

        public int intLinhaAfetadaQtd
        {
            get
            {
                return _intLinhaAfetadaQtd;
            }

            set
            {
                _intLinhaAfetadaQtd = value;
            }
        }

        public int intLinhaRetornadaQtd
        {
            get
            {
                return _intLinhaRetornadaQtd;
            }

            set
            {
                _intLinhaRetornadaQtd = value;
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

        public List<Tabela> lstTbl
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstTbl != null)
                    {
                        return _lstTbl;
                    }

                    _lstTbl = new List<Tabela>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstTbl;
            }

            set
            {
                _lstTbl = value;
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

        protected DbDataAdapter objAdapter
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objAdapter != null)
                    {
                        return _objAdapter;
                    }

                    _objAdapter = this.getObjAdapter();

                    if (_objAdapter == null)
                    {
                        return null;
                    }

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
        }

        protected DbCommand objComando
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objComando != null)
                    {
                        return _objComando;
                    }

                    _objComando = this.getObjComando();

                    if (_objComando == null)
                    {
                        return null;
                    }

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
        }

        protected DbConnection objConexao
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objConexao != null)
                    {
                        return _objConexao;
                    }

                    _objConexao = this.getObjConexao();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objConexao;
            }
        }

        private bool booExecutandoSql
        {
            get
            {
                lock (this.objBooExecutandoSqlLock)
                {
                    return _booExecutandoSql;
                }
            }

            set
            {
                lock (this.objBooExecutandoSqlLock)
                {
                    _booExecutandoSql = value;
                }
            }
        }

        private object objBooExecutandoSqlLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objBooExecutandoSqlLock != null)
                    {
                        return _objBooExecutandoSqlLock;
                    }

                    _objBooExecutandoSqlLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objBooExecutandoSqlLock;
            }
        }

        private object objCarregarGridLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objCarregarGridLock != null)
                    {
                        return _objCarregarGridLock;
                    }

                    _objCarregarGridLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objCarregarGridLock;
            }
        }

        private object objExecSqlLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objExecSqlLock != null)
                    {
                        return _objExecSqlLock;
                    }

                    _objExecSqlLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objExecSqlLock;
            }
        }

        private object objExecSqlLstStrColunaLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objExecSqlLstStrColunaLock != null)
                    {
                        return _objExecSqlLstStrColunaLock;
                    }

                    _objExecSqlLstStrColunaLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objExecSqlLstStrColunaLock;
            }
        }

        private object objExecSqlLstStrLinhaLock
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objExecSqlLstStrLinhaLock != null)
                    {
                        return _objExecSqlLstStrLinhaLock;
                    }

                    _objExecSqlLstStrLinhaLock = new object();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objExecSqlLstStrLinhaLock;
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

                this.iniciar();
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
        public abstract void addParam(List<PrcParametro> lstObjSpParametro);

        /// <summary>
        /// Carrega os dados da tabela de consulta em um componente "DataGridView".
        /// </summary>
        public void carregarGrid(Tabela tbl, DataGridView dgv)
        {
            #region Variáveis

            DataSet objDataSet;

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.objCarregarGridLock)
                {
                    this.booExecutandoSql = true;

                    objDataSet = new DataSet();

                    this.objComando.CommandText = tbl.getSqlSelectTelaConsulta();
                    this.objAdapter.Fill(objDataSet, tbl.strNomeSimplificado);

                    dgv.DataSource = objDataSet.Tables[tbl.strNomeSimplificado];
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar carregar dados no Grid.", ex, Erro.EnmTipo.DATA_BASE);
            }
            finally
            {
                this.desconectar();
                this.booExecutandoSql = false;
            }

            #endregion Ações
        }

        public virtual void desconectar()
        {
            if (this.objConexao == null)
            {
                return;
            }

            if (!ConnectionState.Open.Equals(this.objConexao.State))
            {
                return;
            }

            this.objConexao.Close();
        }

        /// <summary>
        /// Executa uma "StoreProcedure" no banco de dados.
        /// </summary>
        public int execcutarProcedure(string strSpNome, List<PrcParametro> lstObjSpParamametro)
        {
            #region Variáveis

            int intResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                this.abrirConexao();

                this.objComando.CommandType = CommandType.StoredProcedure;
                this.objComando.CommandText = strSpNome;

                this.addParam(lstObjSpParamametro);

                intResultado = (int)this.objComando.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.desconectar();
            }

            #endregion Ações

            return intResultado;
        }

        /// <summary>
        /// Executa "script sql" complexo no banco de dados.
        /// </summary>
        public abstract List<string> execScript(string sqlScript);

        /// <summary>
        /// Executa um "SQl" no banco de dados que não retorna valor algum.
        /// </summary>
        public void execSql(string sql)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.objExecSqlLock)
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
                this.desconectar();
                this.booExecutandoSql = false;
            }

            #endregion Ações
        }

        /// <summary>
        /// Apelido para <see cref="execSqlStr(string)"/>
        /// </summary>
        /// <returns></returns>
        public bool execSqlBoo(string sql)
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = this.execSqlStr(sql);

                if (string.IsNullOrEmpty(strResultado))
                {
                    return false;
                }

                switch (strResultado.ToLower())
                {
                    case "1":
                    case "s":
                    case "sim":
                    case "t":
                    case "true":
                        return true;

                    default:
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

        /// <summary>
        /// Executa um "SQl" no banco de dados e retorna o respectivo objeto "DataTable" com os dados encontrados.
        /// </summary>
        public DataTable execSqlDataTable(string sql)
        {
            #region Variáveis

            DataSet dts;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(sql))
                {
                    return null;
                }

                dts = new DataSet();

                this.abrirConexao();
                this.objComando.CommandText = sql;
                this.objAdapter.Fill(dts);

                return dts.Tables[0];
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao executar SQL (" + sql + ").\n" + ex.Message);
            }
            finally
            {
                this.desconectar();
            }

            #endregion Ações
        }

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string sql)".
        /// </summary>
        public decimal execSqlDec(string sql)
        {
            return Convert.ToDecimal(this.execSqlStr(sql));
        }

        /// <summary>
        /// Apelido para "public string executaSqlGetStr(string sql)".
        /// </summary>
        public int execSqlInt(string sql)
        {
            return (int)this.execSqlDec(sql);
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno a coluna passada como
        /// parâmetro em forma de um "List<itn>". </summary>
        public List<int> execSqlLstInt(Coluna cln)
        {
            #region Variáveis

            List<int> lstIntResultado;
            List<string> lstStr;

            #endregion Variáveis

            #region Ações

            try
            {
                lstIntResultado = new List<int>();

                lstStr = this.execSqlLstStr(cln);

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
        public List<string> execSqlLstStr(Coluna cln)
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

                lstStrResultado = this.execSqlLstStrColuna(sql);
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
        public List<string> execSqlLstStrColuna(string sql)
        {
            #region Variáveis

            List<string> lstStrLinhaValor = new List<string>();

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.objExecSqlLstStrColunaLock)
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
                this.desconectar();
                this.booExecutandoSql = false;
            }

            #endregion Ações

            return lstStrLinhaValor;
        }

        /// <summary> Executa um "SQl" no banco de dados que tem como retorno uma única linha em
        /// forma de um "List<String>". </summary>
        public List<string> execSqlLstStrLinha(string sql)
        {
            #region Variáveis

            List<string> lstStrResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                this.aguardarExecucao();

                lock (this.objExecSqlLstStrLinhaLock)
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

                    if (!this.objReader.HasRows)
                    {
                        return lstStrResultado;
                    }

                    while (this.objReader.Read())
                    {
                        if (this.objReader[0] == null)
                        {
                            continue;
                        }

                        lstStrResultado.Add(this.objReader[0].ToString());
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

                this.desconectar();
                this.booExecutandoSql = false;
            }

            #endregion Ações

            return lstStrResultado;
        }

        public object execSqlObj(string sql)
        {
            try
            {
                this.aguardarExecucao();

                lock (this.objExecSqlLstStrLinhaLock)
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

                    return this.objComando.ExecuteScalar();
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

                this.desconectar();
                this.booExecutandoSql = false;
            }
        }

        public string execSqlStr(string sql)
        {
            var objResultado = this.execSqlObj(sql);

            if (objResultado == null)
            {
                return null;
            }

            return objResultado.ToString();
        }

        public bool getBooTabelaExiste(Tabela tbl)
        {
            #region Variáveis

            string sql;

            #endregion Variáveis

            #region Ações

            try
            {
                sql = this.getSqlTabelaExiste(tbl);

                this.execSqlLstStrLinha(sql);

                if (this.intLinhaRetornadaQtd > 0)
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

        public bool getBooViewExiste(View viw)
        {
            if (viw == null)
            {
                return false;
            }

            return this.execSqlBoo(this.getSqlViewExiste(viw));
        }

        public abstract string getSqlTabelaExiste(Tabela objDbTabela);

        public abstract string getSqlUpdateOrInsert();

        public abstract string getSqlViewExiste(View objDbView);

        /// <summary>
        /// Verifica se a conexão pode ser estabelecida.
        /// </summary>
        /// <returns>True caso a conexão possa ser estabelecida. False caso contrário.</returns>
        public bool testarConexao()
        {
            if (ConnectionState.Open.Equals(this.objConexao))
            {
                return true;
            }

            try
            {
                this.objConexao.Open();
            }
            catch
            {
                return false;
            }

            this.desconectar();

            return true;
        }

        /// <summary>
        /// Método chamado logo após a inicialização da classe pelo método <see
        /// cref="inicializar()"/> e deve ser utilizado para executar rotinas de atualização da
        /// estrutura e valores no banco de dados que esta classe representa.
        /// </summary>
        protected virtual void atualizar()
        {
        }

        protected abstract DbDataAdapter getObjAdapter();

        protected abstract DbCommand getObjComando();

        protected abstract DbConnection getObjConexao();

        /// <summary>
        /// Método chamado na construção desta classe e deve ser utilizado para inicializar valores.
        /// </summary>
        protected virtual void inicializar()
        {
        }

        /// <summary>
        /// Método chamado na construção desta classe e deve ser utilizado para inicializar eventos.
        /// </summary>
        protected virtual void setEventos()
        {
        }

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

            #endregion Ações
        }

        private void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.atualizar();
                this.setEventos();
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