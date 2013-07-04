using System;
using System.Collections.Generic;

namespace DigoFramework.DataBase
{
    public class DbTabela : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private Int16 _intIdTabela;
        public Int16 intIdTabela { get { return _intIdTabela; } set { _intIdTabela = value; } }

        private List<DbColuna> _lstDbObjColuna = new List<DbColuna>();
        public List<DbColuna> lstObjDbColuna { get { return _lstDbObjColuna; } set { _lstDbObjColuna = value; } }

        private List<DbView> _lstObjDbView = new List<DbView>();
        public List<DbView> lstObjDbView { get { return _lstObjDbView; } set { _lstObjDbView = value; } }

        private List<Relatorio> _lstObjRelatorio = new List<Relatorio>();
        public List<Relatorio> lstObjRelatorio { get { return _lstObjRelatorio; } set { _lstObjRelatorio = value; } }

        private DataBase _objDataBase;
        public DataBase objDataBase { get { return _objDataBase; } set { _objDataBase = value; } }

        private Modulo _objModulo;
        public Modulo objModulo
        {
            get { return _objModulo; }
            set
            {
                _objModulo = value;
                value.lstObjTabelas.Add(this);
            }
        }

        #endregion

        #region CONSTRUTORES

        public DbTabela() { }
        public DbTabela(DataBase objDataBase)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDataBase = objDataBase;

            #endregion
        }
        public DbTabela(DataBase objDataBase, String strNome)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDataBase = objDataBase;
            this.strNome = strNome;

            #endregion
        }
        public DbTabela(DataBase objDataBase, String strNome, Modulo mdlModulo)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDataBase = objDataBase;
            this.strNome = strNome;
            this.objModulo = mdlModulo;

            #endregion

        }

        #endregion

        #region MÉTODOS

        public void acaoAbrirFormCadastro(Object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDataBase.objAplicativo.objTabelaSelecionada = this;
            this.objDataBase.objAplicativo.frmCadastro.ShowDialog();

            #endregion
        }

        public void acaoAbrirFormEdicao(Object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDataBase.objAplicativo.frmEdicao.ShowDialog();

            #endregion
        }

        public void carregaDataGrid(System.Windows.Forms.DataGridView objDataGridView)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objDataBase.carregaDataGrid(this, objDataGridView);

            #endregion
        }

        public void criarTabelaNoBancoDeDados()
        {
            #region VARIÁVEIS

            String strSql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            //strSql = "CREATE TABLE pessoa ();";
            strSql = String.Format("CREATE TABLE {0} ();", this.strNomeSimplificado);
            this.objDataBase.executaSqlRetornaUmaLinha(strSql);

            #endregion
        }

        public Boolean getBooTabelaExiste()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            return this.objDataBase.getBooTabelaExiste(this);

            #endregion
        }

        private List<String> getLstStrNomeColunaVisivel()
        {
            #region VARIÁVEIS

            List<String> lstStrColunaVisivel = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objColuna in this.lstObjDbColuna)
            {
                if (objColuna.booVisivel)
                {
                    lstStrColunaVisivel.Add(objColuna.strNomeSimplificado);
                }
            }
            return lstStrColunaVisivel;

            #endregion
        }

        public void buscaRegistro(DbColuna objDbColunaFiltro, String strValorFiltro)
        {
            #region VARIÁVEIS

            String sqlPesquisa = Utils.STRING_VAZIA;
            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            sqlPesquisa = String.Format("SELECT {0} FROM {1} WHERE {2} = {3};", this.getStrNomesColunasVisiveis(), this.strNomeSimplificado, objDbColunaFiltro.strNomeSimplificado, strValorFiltro);
            lstStrColunaValor = this.objDataBase.executaSqlRetornaUmaLinha(sqlPesquisa);

            for (int intTemp = 0; intTemp < this.lstObjDbColuna.Count; intTemp++)
            {
                if (this.lstObjDbColuna[intTemp].booVisivel)
                {
                    this.lstObjDbColuna[intTemp].strValor = lstStrColunaValor[intTemp];
                }
            }

            #endregion
        }

        private String getStrNomesColunasVisiveis(String strSeparador = ",")
        {
            #region VARIÁVEIS

            String strNomesColunasVisiveis = Utils.STRING_VAZIA;
            List<string> lstStrNomeColunaVisivel = this.getLstStrNomeColunaVisivel();

            #endregion

            #region AÇÕES

            strNomesColunasVisiveis = String.Join(strSeparador, lstStrNomeColunaVisivel.ToArray());
            return strNomesColunasVisiveis;

            #endregion
        }

        public String getSqlDadosTabela()
        {
            #region VARIÁVEIS

            String strSql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strSql = String.Format("select {0} from {1};", this.getStrNomesColunasVisiveis(), this.strNomeSimplificado);
            return strSql;

            #endregion
        }

        public String getSqlViewPadrao()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (this.lstObjDbView.Count > 0)
            {
                foreach (DbView objDbView in this.lstObjDbView)
                {
                    if (objDbView.booPrincipal)
                    {
                        return objDbView.strNomeSimplificado;
                    }
                }
            }
            return this.getSqlDadosTabela();

            #endregion
        }

        #endregion

    }
}