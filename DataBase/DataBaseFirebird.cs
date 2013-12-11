using System;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;

namespace DigoFramework.DataBase
{
    public class DataBaseFirebird : DataBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private String _dirBancoDados = String.Empty;
        public String dirBancoDados
        {
            get { return _dirBancoDados; }
            set
            {
                _dirBancoDados = value;
                if (!System.IO.File.Exists(_dirBancoDados))
                {
                    new Erro("Não foi possível encontrar o banco de dados '" + _dirBancoDados + "'. Algumas funções do sistema não irão funcionar.");
                }
            }
        }

        private Int16 _intDialeto = 3;
        public Int16 intDialect { get { return _intDialeto; } set { _intDialeto = value; } }

        private String _strCharSet = "UTF8";
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
            this.objAdapter = new FbDataAdapter();
            this.objComando = new FbCommand();

            //this.objConexao.Open();
        }

        #endregion

        #region MÉTODOS

        public override void addProcedureParametros(List<SpParametro> lstObjSpParametro)
        {
            #region VARIÁVEIS

            FbCommand objFbCommandTemp = (FbCommand)this.objComando;

            #endregion
            try
            {
                #region AÇÕES

                foreach (SpParametro objSpParamNome in lstObjSpParametro)
                {
                    switch (objSpParamNome.enmTipoGrupo)
                    {
                        case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Text).Value = objSpParamNome.strValor;
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.BOOLEANO:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Boolean).Value = objSpParamNome.strValor;
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.TimeStamp).Value = objSpParamNome.strValor;
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Numeric).Value = objSpParamNome.strValor;
                            break;
                        default:
                            objFbCommandTemp.Parameters.Add("@" + objSpParamNome.strNome, FbDbType.Text).Value = objSpParamNome.strValor;
                            break;
                    }
                }
                this.objComando = objFbCommandTemp;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public override String getSqlUpdateOrInserte()
        {
            #region VARIÁVEIS

            String sql = @"update or insert into {0} ({3}) values ({4}) matching ({1});";

            #endregion

            #region AÇÕES

            return sql;

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