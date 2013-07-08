using System;
using FirebirdSql.Data.FirebirdClient;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public class DataBaseFirebird : DataBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private String _dirBancoDados = String.Empty;
        public String dirBancoDados
        {
            get { return _dirBancoDados; }
            set
            {
                //if (System.IO.File.Exists(value)) { _dirBancoDados = value; }
                //else { throw new Erro("Arquivo não encontrado!", Erro.ErroTipo.BancoDados); }
                _dirBancoDados = value;
            }
        }

        private Int16 _intDialeto = 3;
        public Int16 intDialect { get { return _intDialeto; } set { _intDialeto = value; } }

        private FbDataAdapter _objAdapter = new FbDataAdapter();
        public FbDataAdapter objAdapter { get { return _objAdapter; } set { _objAdapter = value; } }

        private FbCommand _objComando = new FbCommand();
        public FbCommand objComando { get { return _objComando; } set { _objComando = value; } }

        private FbConnection _objConexao;
        public FbConnection objConexao { get { return _objConexao; } set { _objConexao = value; } }

        private FbDataReader _objFbDataReader;
        public FbDataReader objFbDataReader
        {
            get { return _objFbDataReader; }
            set
            {
                _objFbDataReader = value;
                //this.objDbDataReader = _objFbDataReader;
                //while (_objFbDataReader.Read()) {
                //    String teste = _objFbDataReader.GetString(0);
                //}                
            }
        }

        private FbTransaction _objFbTransaction;
        public FbTransaction objFbTransaction { get { return _objFbTransaction; } set { _objFbTransaction = value; } }

        private String _strCharSet = "NONE";
        public String strCharSet { get { return _strCharSet; } set { _strCharSet = value; } }

        #endregion

        #region CONSTRUTORES

        public DataBaseFirebird(Aplicativo objAplicativo, String dirBancoDados, String strServer = "127.0.0.1", Int32 intPorta = 3050, String strUser = "SYSDBA", String strSenha = "masterkey")
        {
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
            this.objAplicativo = objAplicativo;
            this.dirBancoDados = dirBancoDados;
            this.strServer = strServer;
            this.intPorta = intPorta;
            this.strUser = strUser;
            this.strSenha = strSenha;
            this.objConexao = new FbConnection(this.getStrConexao());

            //this.objConexao.Open();
        }

        #endregion

        #region MÉTODOS

        public override void carregaDataGrid(DbTabela objDbTabela, System.Windows.Forms.DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            System.Data.DataSet objDataSet = new System.Data.DataSet();

            #endregion

            #region AÇÕES

            try
            {
                this.objAdapter.SelectCommand = new FbCommand(objDbTabela.getSqlViewPadrao(), this.objConexao);
                this.objAdapter.Fill(objDataSet, objDbTabela.strNomeSimplificado);
                objDataGridView.DataSource = objDataSet.Tables[objDbTabela.strNomeSimplificado];
            }
            catch (Exception ex)
            {
                throw new Erro(ex.Message, Erro.ErroTipo.BancoDados);
            }
            finally
            {
                this.objConexao.Close();
            }

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
                    this.objComando.Connection = this.objConexao;
                    this.objComando.CommandText = strSql;
                    this.objFbDataReader = this.objComando.ExecuteReader();
                    while (this.objFbDataReader.Read())
                    {
                        try { lstStrLinhaValor.Add(this.objFbDataReader.GetString(0)); }
                        catch (Exception) { }
                    }
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                Erro errErro = new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", Erro.ErroTipo.BancoDados);
            }

            return lstStrLinhaValor;

            #endregion
        }

        public override List<String> executaSqlRetornaUmaLinha(String strSql)
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
                    this.objComando.Connection = this.objConexao;
                    this.objComando.CommandText = strSql;
                    this.objFbDataReader = this.objComando.ExecuteReader();
                    this.objFbDataReader.Read();
                    for (int intTemp = 0; intTemp < this.objFbDataReader.FieldCount; intTemp++)
                    {
                        try { lstStrColunaValor.Add(this.objFbDataReader.GetString(intTemp)); }
                        catch (Exception) { }
                    }
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                Erro errErro = new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", Erro.ErroTipo.BancoDados);
            }

            return lstStrColunaValor;

            #endregion
        }

        public override void executaSqlSemRetorno(String strSql)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strSql = strSql;
            if (this.strSql != Utils.STRING_VAZIA)
            {
                try
                {
                    try{this.objConexao.Open();}
                    catch (Exception){}                    
                    this.objFbTransaction = this.objConexao.BeginTransaction();
                    this.objComando.Transaction = this.objFbTransaction;
                    this.objComando.Connection = this.objConexao;
                    this.objComando.CommandText = strSql;
                    this.objComando.ExecuteNonQuery();
                    this.objFbTransaction.Commit();
                }
                finally
                {
                    this.objConexao.Close();
                }
            }
            else
            {
                Erro errErro = new Erro("Estrutura do SQL não pode estar em branco. Comando não executado", Erro.ErroTipo.BancoDados);
            }

            #endregion
        }

        public override String getSqlTabelaExiste(DbTabela objDbTabela)
        {
            #region VARIÁVEIS

            String sqlTabelaExiste = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            return sqlTabelaExiste = String.Format("SELECT RDB$RELATION_NAME FROM RDB$RELATIONS WHERE RDB$VIEW_BLR IS NULL AND RDB$RELATION_NAME = '{0}';", objDbTabela.strNomeSimplificado);

            #endregion
        }

        public override String getSqlViewExiste(DbView objDbView)
        {
            #region VARIÁVEIS

            String sqlViewExiste = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            return sqlViewExiste = String.Format("SELECT RDB$RELATION_NAME FROM RDB$RELATIONS WHERE NOT RDB$VIEW_BLR IS NULL AND RDB$RELATION_NAME = '{0}';", objDbView.strNomeSimplificado);

            #endregion
        }

        private String getStrConexao()
        {
            #region VARIÁVEIS

            String strConexao = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strConexao = String.Format("User={0};Password={1};Database={2};DataSource={3};Port={4};Dialect={5};Charset={6};Role=;Connection lifetime=15;Pooling=true;MinPoolSize=0;MaxPoolSize=50;Packet Size=8192;ServerType=0", this.strUser, this.strSenha, this.dirBancoDados, this.strServer, this.intPorta.ToString(), this.intDialect.ToString(), this.strCharSet);
            return strConexao;

            #endregion

        }

        #endregion
    }
}