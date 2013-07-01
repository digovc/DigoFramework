using System;
using FirebirdSql.Data.FirebirdClient;

namespace DigoFramework
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
                if (System.IO.File.Exists(value)) { _dirBancoDados = value; }
                else { throw new Erro("Arquivo não encontrado!", Erro.ErroTipo.BancoDados); }
            }
        }

        private Int16 _intDialeto = 3;
        public Int16 intDialect { get { return _intDialeto; } set { _intDialeto = value; } }

        private FbCommand _objComando = new FbCommand();
        public FbCommand objComando { get { return _objComando; } set { _objComando = value; } }

        private FbConnection _objConexao;
        public FbConnection objConexao { get { return _objConexao; } set { _objConexao = value; } }

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
            //this.conNpgsql.Open();
        }

        #endregion

        #region MÉTODOS

        public override void carregaDataGrid(DbTabela objDbTabela, System.Windows.Forms.DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            throw new NotImplementedException();

            #endregion
        }

        public override void executaSql(String strSql)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strSql = strSql;
            if (this.strSql != Utils.STRING_VAZIA)
            {
                this.objConexao.Open();
                this.objComando.Connection = this.objConexao;
                this.objComando.CommandText = strSql;
                try
                {
                    this.intNumeroLinhasAfetadas = this.objComando.ExecuteNonQuery();
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

            strConexao = String.Format("User={0};Passowrd={1};Database={2};Port={3};Dialect={4};Charset={5};Connection lifetime=0;Conenection timeout=7;Pooling=True;Packet Size=8192;Server Type=0;", this.strUser, this.strSenha, this.dirBancoDados, this.intPorta, Convert.ToString(this.intDialect), this.strCharSet);
            return strConexao;

            #endregion

        }

        #endregion
    }
}