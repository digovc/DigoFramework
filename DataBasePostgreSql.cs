﻿using System;
using Npgsql;

namespace DigoFramework
{
    public class DataBasePostgreSql : DataBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private NpgsqlDataAdapter _objAdapter = new NpgsqlDataAdapter();
        public NpgsqlDataAdapter objAdapter { get { return _objAdapter; } set { _objAdapter = value; } }

        private NpgsqlCommand _objComando = new NpgsqlCommand();
        public NpgsqlCommand objComando { get { return _objComando; } set { _objComando = value; } }

        private NpgsqlConnection _objConexao;
        public NpgsqlConnection objConexao { get { return _objConexao; } set { _objConexao = value; } }

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
            //this.conNpgsql.Open();
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
                this.objAdapter.SelectCommand = new NpgsqlCommand(objDbTabela.getSqlViewPadrao(), this.objConexao);
                this.objAdapter.Fill(objDataSet, objDbTabela.strNomeSimplificado);
                objDataGridView.DataSource = objDataSet.Tables[objDbTabela.strNomeSimplificado];
            }
            catch (Exception ex)
            {
                throw new Erro(ex.Message, Erro.ErroTipo.BancoDados);
            }

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
                    this.objConexao.Clone();
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