using System;
using System.Data.Common;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public abstract class DataBase : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Int64 _intNumeroLinhasAfetadas;
        public Int64 intNumeroLinhasAfetadas { get { return _intNumeroLinhasAfetadas; } set { _intNumeroLinhasAfetadas = value; } }

        private Int64 _intNumeroLinhasRetornadas;
        public Int64 intNumeroLinhasRetornadas { get { return _intNumeroLinhasRetornadas; } set { _intNumeroLinhasRetornadas = value; } }

        private Int32 _intPorta;
        public Int32 intPorta { get { return _intPorta; } set { _intPorta = value; } }

        private Aplicativo _objAplicativo = null;
        public Aplicativo objAplicativo { get { return _objAplicativo; } set { _objAplicativo = value; } }

        //private DbDataReader _objDbDataReader;
        //public DbDataReader objDbDataReader { get { return _objDbDataReader; } set { _objDbDataReader = value; } }

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
        public String strSql { get { return _strSql; } set { _strSql = value; } }

        //private String _strUser = "postgres";
        private String _strUser;
        public String strUser { get { return _strUser; } set { _strUser = value; } }

        #endregion

        #region CONSTRUTORES

        #endregion

        #region MÉTODOS

        public abstract void carregaDataGrid(DbTabela objDbTabela, System.Windows.Forms.DataGridView objDataGridView);

        public abstract List<String> executaSqlRetornaUmaColuna(String strSql);

        public List<String> executaSqlRetornaUmaColuna(DbColuna objDbColuna)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.strSql = String.Format("SELECT {0} FROM {1};", objDbColuna.strNomeSimplificado, objDbColuna.objDbTabela.strNomeSimplificado);
            return this.executaSqlRetornaUmaColuna(this.strSql);

            #endregion

        }

        public abstract List<String> executaSqlRetornaUmaLinha(String strSql);

        public abstract void executaSqlSemRetorno(String strSql);

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

        public abstract String getSqlViewExiste(DbView objDbView);

        #endregion
    }
}