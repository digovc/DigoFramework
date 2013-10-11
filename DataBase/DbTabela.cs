using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using DigoFramework.Formulário;

namespace DigoFramework.DataBase
{
    public class DbTabela : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Aplicativo _aplicativo;
        public Aplicativo aplicativo
        {
            get { return _aplicativo; }
            set
            {
                _aplicativo = value;
                _aplicativo.lstTbl.Add(this);
            }
        }

        public Boolean booChavePrimariaExiste { get { if (this.objDbColunaChavePrimaria == null) { return false; } else { return true; } } }

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private Int16 _intIdTabela;
        public Int16 intIdTabela { get { return _intIdTabela; } set { _intIdTabela = value; } }

        private List<DbColuna> _lstDbObjColuna = new List<DbColuna>();
        public List<DbColuna> lstObjDbColuna
        {
            get
            {
                _lstDbObjColuna.Sort();
                return _lstDbObjColuna;
            }
            set { _lstDbObjColuna = value; }
        }

        public List<DbColuna> lstObjDbColunaVisivel
        {
            get
            {
                List<DbColuna> lstObjDbColunaTemp = new List<DbColuna>();
                foreach (DbColuna objDbColuna in this.lstObjDbColuna)
                {
                    if (objDbColuna.booVisivel)
                    {
                        lstObjDbColunaTemp.Add(objDbColuna);
                    }
                }
                return lstObjDbColunaTemp;
            }
        }

        private List<DbView> _lstObjDbView = new List<DbView>();
        public List<DbView> lstObjDbView { get { return _lstObjDbView; } set { _lstObjDbView = value; } }

        private List<Relatorio> _lstObjRelatorio = new List<Relatorio>();
        public List<Relatorio> lstObjRelatorio { get { return _lstObjRelatorio; } set { _lstObjRelatorio = value; } }

        public DbColuna objDbColunaChavePrimaria
        {
            get
            {
                foreach (DbColuna objDbColuna in this.lstObjDbColuna)
                {
                    if (objDbColuna.booChavePrimaria)
                    {
                        return objDbColuna;
                    }
                }
                throw new Erro("Erro ao tentar encontrar a chave primária da tabela " + this.strNome + ".", new Exception(), Erro.ErroTipo.BancoDados);
            }
        }

        private DataBase _objDataBase;
        public DataBase objDataBase
        {
            get
            {
                if (_objDataBase == null)
                {
                    _objDataBase = Aplicativo.appInstancia.objDataBasePrincipal;
                }
                return _objDataBase;
            }
            set
            {
                _objDataBase = value;
                _objDataBase.lstDbTabela.Add(this);
            }
        }

        private DataTable _objDataTable = new DataTable();
        public DataTable objDataTable
        {
            get
            {
                _objDataTable = this.objDataBase.executaSqlRetornaDataTable(this.getSqlDadosTabela());
                return _objDataTable;
            }
        }

        private Modulo _objModulo;
        public Modulo objModulo
        {
            get { return _objModulo; }
            set
            {
                _objModulo = value;
                _objModulo.lstObjTabelas.Add(this);
            }
        }

        private String _strNomeExibicao = String.Empty;
        public String strNomeExibicao
        {
            get
            {
                return (_strNomeExibicao != Utils.STRING_VAZIA ? Utils.getStrFormataTitulo(_strNomeExibicao) : Utils.getStrFormataTitulo(this.strNome));
            }
            set { _strNomeExibicao = value; }
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

            FrmCadastro frmCadastro = new FrmCadastro();

            #endregion

            #region AÇÕES

            frmCadastro.objDbTabelaPrincipal = this;
            frmCadastro.ShowDialog();

            #endregion
        }

        public void acaoAbrirFormEdicao(Object sender, EventArgs e)
        {
            #region VARIÁVEIS

            FrmEdicao frmEdicao = new FrmEdicao();

            #endregion

            #region AÇÕES

            frmEdicao.objDbTabelaPrincipal = this;
            frmEdicao.ShowDialog();

            #endregion
        }

        public void carregaDataGrid(System.Windows.Forms.DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            Int16 intClnIndex = 0;

            #endregion

            #region AÇÕES

            this.objDataBase.carregaDataGrid(this, objDataGridView);
            foreach (DbColuna cln in this.lstObjDbColunaVisivel)
            {
                try
                {
                    objDataGridView.Columns[intClnIndex].HeaderText = cln.strNomeExibicao;

                    switch (cln.enmDbColunaTipoGrupo)
                    {
                        case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.BOOLEANO:
                            //objDataGridView.Columns[intClnIndex].CellTemplate = new DataGridViewCheckBoxCell();
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                intClnIndex++;
            }

            #endregion
        }

        public void buscaRegistro(DbColuna objDbColunaFiltro, String strValorFiltro)
        {
            #region VARIÁVEIS

            String sqlPesquisa = Utils.STRING_VAZIA;
            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            try
            {
                sqlPesquisa = String.Format("SELECT {0} FROM {1} WHERE {2} = {3};", this.getStrColunasNomes(), this.strNomeSimplificado, objDbColunaFiltro.strNomeSimplificado, strValorFiltro);
                lstStrColunaValor = this.objDataBase.executaSqlRetornaUmaLinha(sqlPesquisa);
                for (int intTemp = 0; intTemp < this.lstObjDbColuna.Count; intTemp++)
                {
                    this.lstObjDbColuna[intTemp].strValor = lstStrColunaValor[intTemp];
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro ao tentar recuperar Registro no Banco de Dados.\n" + sqlPesquisa, ex, Erro.ErroTipo.BancoDados);
                for (int intTemp = 0; intTemp < this.lstObjDbColuna.Count; intTemp++)
                {
                    if (this.lstObjDbColuna[intTemp].booVisivel) { this.lstObjDbColuna[intTemp].strValor = Utils.STRING_VAZIA; }
                }
            }

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

        private String getStrColunasNomes(String strSeparador = ",")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            return String.Join(strSeparador, this.getLstStrColunaNome().ToArray());

            #endregion
        }

        private String getStrColunasNomesValores(String strSeparador = ",")
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objDbColuna in this.lstObjDbColuna)
            {
                switch (objDbColuna.enmDbColunaTipoGrupo)
                {
                    case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                        lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'" + objDbColuna.strValor + "'");
                        break;
                    case DbColuna.EnmDbColunaTipoGrupo.BOOLEANO:
                        if (objDbColuna.booValor)
                        {
                            lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'T'");
                        }
                        else
                        {
                            lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'F'");
                        }
                        break;
                    case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                        lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'" + objDbColuna.strValor + "'");
                        break;
                    case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
                        lstStrColunaValor.Add(objDbColuna.strNome + " = " + objDbColuna.strValor);
                        break;
                    default:
                        break;
                }
            }
            return String.Join(strSeparador, lstStrColunaValor.ToArray());

            #endregion
        }

        private String getStrColunasNomesValoresPreenchidos(String strSeparador = ",")
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objDbColuna in this.lstObjDbColuna)
            {
                if (objDbColuna.strValor != Utils.STRING_VAZIA)
                {
                    switch (objDbColuna.enmDbColunaTipoGrupo)
                    {
                        case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                            lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'" + objDbColuna.strValor + "'");
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                            lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'" + objDbColuna.strValor + "'");
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
                            lstStrColunaValor.Add(objDbColuna.strNome + " = " + objDbColuna.strValor);
                            break;
                        default:
                            lstStrColunaValor.Add(objDbColuna.strNome + " = " + "'" + objDbColuna.strValor + "'");
                            break;
                    }
                }
            }
            return String.Join(strSeparador, lstStrColunaValor.ToArray());

            #endregion
        }

        private String getStrColunasValores(String strSeparador = ",")
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objDbColuna in this.lstObjDbColuna)
            {
                switch (objDbColuna.enmDbColunaTipoGrupo)
                {
                    case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                        lstStrColunaValor.Add("'" + objDbColuna.strValor + "'");
                        break;
                    case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                        lstStrColunaValor.Add("'" + objDbColuna.strValor + "'");
                        break;
                    case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
                        lstStrColunaValor.Add(objDbColuna.strValor);
                        break;
                    default:
                        break;
                }
            }
            return String.Join(strSeparador, lstStrColunaValor.ToArray());

            #endregion
        }

        private String getStrColunasValoresPreenchidos(String strSeparador = ",")
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objDbColuna in this.lstObjDbColuna)
            {
                if (objDbColuna.strValor != Utils.STRING_VAZIA)
                {
                    switch (objDbColuna.enmDbColunaTipoGrupo)
                    {
                        case DbColuna.EnmDbColunaTipoGrupo.ALFANUMERICO:
                            lstStrColunaValor.Add("'" + objDbColuna.strValor + "'");
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.BOOLEANO:
                            if (objDbColuna.booValor)
                            {
                                lstStrColunaValor.Add("'T'");
                            }
                            else
                            {
                                lstStrColunaValor.Add("'F'");
                            }
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.TEMPORAL:
                            lstStrColunaValor.Add("'" + objDbColuna.strValor + "'");
                            break;
                        case DbColuna.EnmDbColunaTipoGrupo.NUMERICO:
                            lstStrColunaValor.Add("'" + objDbColuna.strValor + "'");
                            break;
                        default:
                            lstStrColunaValor.Add("'" + objDbColuna.strValor + "'");
                            break;
                    }
                }
            }
            return String.Join(strSeparador, lstStrColunaValor.ToArray());

            #endregion
        }

        private String getStrColunasVisiveisNomes(String strSeparador = ",")
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            return String.Join(strSeparador, this.getLstStrColunaVisivelNome().ToArray());

            #endregion
        }

        private List<String> getLstStrColunaNome()
        {
            #region VARIÁVEIS

            List<String> lstStrColuna = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objColuna in this.lstObjDbColuna)
            {
                lstStrColuna.Add(objColuna.strNomeSimplificado);
            }
            if (lstStrColuna.Count == 0)
            {
                lstStrColuna.Add("*");
            }
            return lstStrColuna;

            #endregion
        }

        private List<String> getLstStrColunaNomePreenchidas()
        {
            #region VARIÁVEIS

            List<String> lstStrColuna = new List<String>();

            #endregion

            #region AÇÕES

            foreach (DbColuna objDbColuna in this.lstObjDbColuna)
            {
                if (objDbColuna.strValor != Utils.STRING_VAZIA)
                {
                    lstStrColuna.Add(objDbColuna.strNomeSimplificado);
                }
            }
            //if (lstStrColuna.Count == 0)
            //{
            //    lstStrColuna.Add("*");
            //}
            return lstStrColuna;

            #endregion
        }

        private List<String> getLstStrColunaVisivelNome()
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
            if (lstStrColunaVisivel.Count == 0)
            {
                lstStrColunaVisivel.Add("*");
            }
            return lstStrColunaVisivel;

            #endregion
        }

        public String getSqlDadosTabela()
        {
            #region VARIÁVEIS

            String strSql = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            strSql = String.Format("select {0} from {1};", this.getStrColunasVisiveisNomes(), this.strNomeSimplificado);
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

        public bool salvarRegistro()
        {
            #region VARIÁVEIS

            String sql = Utils.STRING_VAZIA;
            String strNomeTabela = this.strNome;
            String strNomeTabelaChavePrimariaNome = this.objDbColunaChavePrimaria.strNome;
            String strNomeTabelaChavePrimariaValor = this.objDbColunaChavePrimaria.strValor;
            String strColunasNomes = String.Join(",", this.getLstStrColunaNomePreenchidas().ToArray());
            String strColunasValores = this.getStrColunasValoresPreenchidos();
            String strColunasNomesValores = this.getStrColunasNomesValoresPreenchidos();

            #endregion

            #region AÇÕES

            if (!this.booChavePrimariaExiste)
            {
                throw new Exception("Tabela não possui chave primária.");
            }
            else if (strColunasNomesValores == Utils.STRING_VAZIA)
            {
                throw new Exception("Não existem valores à serem salvos.");
            }
            else
            {
                if (strNomeTabelaChavePrimariaValor != Utils.STRING_VAZIA)
                {
                    sql = String.Format(this.objDataBase.getSqlUpdateOrInserte(),
                    this.strNome,
                    strNomeTabelaChavePrimariaNome,
                    strNomeTabelaChavePrimariaValor,
                    strColunasNomes,
                    strColunasValores,
                    strColunasNomesValores);
                }
                else
                {
                    sql = String.Format("INSERT INTO {0}({1}) VALUES ({2});",
                    this.strNome,
                    strColunasNomes,
                    strColunasValores);
                }
                this.objDataBase.executaSqlSemRetorno(sql);
                return true;
            }

            #endregion
        }

        #endregion
    }
}