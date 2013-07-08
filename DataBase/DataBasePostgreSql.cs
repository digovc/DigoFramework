using System;
using Npgsql;
using System.Collections.Generic;
using System.Data;

namespace DigoFramework.DataBase
{
    public class DataBasePostgreSql : DataBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES        

        private NpgsqlDataReader _objNpgsqlDataReader;
        public NpgsqlDataReader objNpgsqlDataReader { get { return _objNpgsqlDataReader; } set { _objNpgsqlDataReader = value; } }

        #endregion

        #region CONSTRUTORES

        public DataBasePostgreSql(Aplicativo objAplicativo, String strServer = "127.0.0.1", Int32 intPorta = 5432, String strUser = "postgres", String strSenha = "postgres", String strDbNome = "postgres")
        {
            // EXTERNOS
            // VARIÁVEIS
            // AÇÕES
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

        #endregion

        #region MÉTODOS        

        public override String getSqlTabelaExiste(DbTabela objDbTabela)
        {
            #region VARIÁVEIS

            String sqlTabelaExiste = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            return sqlTabelaExiste = String.Format("SELECT relname FROM pg_class WHERE relname = '{0}' AND relkind='r';", objDbTabela.strNomeSimplificado);

            #endregion
        }

        public override String getSqlViewExiste(DbView objDbView)
        {
            #region VARIÁVEIS

            //String sqlViewExiste = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            throw new NotImplementedException();
            //return sqlViewExiste = String.Format("", objDbView.strNomeSimplificado);

            #endregion
        }

        private String getStrConexao()
        {
            #region VARIÁVEIS

            String strConexao = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strConexao = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", this.strServer, Convert.ToString(this.intPorta), this.strUser, this.strSenha, this.strDbNome);
            return strConexao;

            #endregion

        }

        #endregion
    }
}