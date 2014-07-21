using DigoFramework.form;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DigoFramework.database
{
    public abstract class DbTabela : Objeto
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Aplicativo _aplicativo;
        private bool _booChavePrimariaExiste;
        private bool _booVisivel = true;
        private DbColuna _clnChavePrimaria;
        private DbColuna _clnNome;
        private Type _clsFrmCadastro;
        private int _intIdRegistroSelecionado;
        private int _intIdTabela;
        private List<DbColuna> _lstCln;
        private List<DbColuna> _lstClnVisivelCadastro;
        private List<DbColuna> _lstClnVisivelConsulta;
        private List<Relatorio> _lstObjRelatorio;
        private DataBase _objDataBase;
        private DataTable _objDataTable;
        private Modulo _objModulo;

        public Aplicativo aplicativo
        {
            get
            {
                return _aplicativo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _aplicativo = value;
                    _aplicativo.lstTbl.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        public bool booChavePrimariaExiste
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _booChavePrimariaExiste = this.clnChavePrimaria != null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _booChavePrimariaExiste;
            }
        }

        public bool booVisivel
        {
            get
            {
                return _booVisivel;
            }

            set
            {
                _booVisivel = value;
            }
        }

        public DbColuna clnChavePrimaria
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_clnChavePrimaria != null)
                    {
                        return _clnChavePrimaria;
                    }

                    foreach (DbColuna cln in this.lstCln)
                    {
                        if (cln.booChavePrimaria)
                        {
                            _clnChavePrimaria = cln;
                            break;
                        }
                    }

                    if (_clnChavePrimaria == null)
                    {
                        throw new Erro("Erro ao tentar encontrar a chave primária da tabela " + this.strNome + ".");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _clnChavePrimaria;
            }

            set
            {
                _clnChavePrimaria = value;
            }
        }

        public DbColuna clnNome
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_clnNome != null)
                    {
                        return _clnNome;
                    }

                    foreach (DbColuna cln in this.lstCln)
                    {
                        if (cln.booNome)
                        {
                            _clnNome = cln;
                            break;
                        }
                    }

                    if (_clnNome == null)
                    {
                        throw new Exception("Erro ao tentar encontrar a chave primária da tabela " + this.strNome + ".");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _clnNome;
            }

            set
            {
                _clnNome = value;
            }
        }

        public Type clsFrmCadastro
        {
            get
            {
                return _clsFrmCadastro;
            }

            set
            {
                _clsFrmCadastro = value;
            }
        }

        public int intIdRegistroSelecionado
        {
            get
            {
                return _intIdRegistroSelecionado;
            }

            set
            {
                _intIdRegistroSelecionado = value;
            }
        }

        public int intIdTabela
        {
            get
            {
                return _intIdTabela;
            }

            set
            {
                _intIdTabela = value;
            }
        }

        public List<DbColuna> lstCln
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstCln != null)
                    {
                        _lstCln.Sort();
                        return _lstCln;
                    }

                    _lstCln = new List<DbColuna>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstCln;
            }
        }

        public List<DbColuna> lstClnVisivelCadastro
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstClnVisivelCadastro != null)
                    {
                        return _lstClnVisivelCadastro;
                    }

                    _lstClnVisivelCadastro = new List<DbColuna>();

                    foreach (DbColuna cln in this.lstCln)
                    {
                        if (cln.booVisivelCadastro)
                        {
                            _lstClnVisivelCadastro.Add(cln);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstClnVisivelCadastro;
            }
            set
            {
            lstClnVisivelCadastro = value;
            }
        }

        public List<DbColuna> lstClnVisivelConsulta
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstClnVisivelConsulta != null)
                    {
                        return _lstClnVisivelConsulta;
                    }

                    _lstClnVisivelConsulta = new List<DbColuna>();

                    foreach (DbColuna cln in this.lstCln)
                    {
                        if (cln.booVisivelConsulta)
                        {
                            _lstClnVisivelConsulta.Add(cln);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstClnVisivelConsulta;
            }
            set
            {
                _lstClnVisivelConsulta = value;
            }
        }

        public List<Relatorio> lstObjRelatorio
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_lstObjRelatorio != null)
                    {
                        return _lstObjRelatorio;
                    }

                    _lstObjRelatorio = new List<Relatorio>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _lstObjRelatorio;
            }
        }

        public DataBase objDataBase
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    if (_objDataBase != null)
                    {
                        return _objDataBase;
                    }

                    _objDataBase = Aplicativo.i.objDataBasePrincipal;
                    _objDataBase.lstDbTabela.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _objDataBase;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _objDataBase = value;
                    _objDataBase.lstDbTabela.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        public DataTable objDataTable
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _objDataTable = this.objDataBase.execSqlGetObjDataTable(this.getSqlDadosTabelaClnVisivelConsulta());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _objDataTable;
            }
        }

        public Modulo objModulo
        {
            get
            {
                return _objModulo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _objModulo = value;
                    _objModulo.lstObjTabelas.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        #endregion

        #region CONSTRUTORES

        public DbTabela(string strNome)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.strNome = strNome;
                this.inicializarColunas(-1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Abre uma nova tela contendo campos necessários para o cadastro de um novo registro desta
        /// tabela. Retorna o resultado do formulário de cadastro. <param name="intRegistroId">"Int"
        /// que representa o registro caso seja uma edição. Se for passado 0 (zero) o formulário
        /// será preparado para o cadastro de um novo registro.</param><returns>Retorna
        /// "DialogResult.Yes" caso o registro tenha sido alterado ou "DialogResult.Cancel" caso contrário.</returns>
        /// </summary>
        public DialogResult abrirFrmCadastro(int intRegistroId = 0)
        {
            #region VARIÁVEIS

            FrmCadastro frmCadastro;
            DialogResult objDialogResultResultado;

            #endregion

            #region AÇÕES

            try
            {
                if (this.clsFrmCadastro == null)
                {
                    frmCadastro = new FrmCadastro();
                }
                else
                {
                    frmCadastro = (FrmCadastro)Activator.CreateInstance(this.clsFrmCadastro);
                }

                this.intIdRegistroSelecionado = intRegistroId;
                frmCadastro.tbl = this;
                objDialogResultResultado = frmCadastro.ShowDialog();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return objDialogResultResultado;
        }

        /// <summary>
        /// Abre uma nova tela contendo os registros desta tabela. Retorna o resultado da tela de consulta.
        /// </summary>
        public DialogResult abrirFrmConsulta()
        {
            #region VARIÁVEIS

            DialogResult objDialogResultResultado;

            #endregion

            #region AÇÕES

            try
            {
                Aplicativo.i.tblSelecionada = this;
                objDialogResultResultado = Aplicativo.i.abrirFrmCache(typeof(FrmConsulta));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return objDialogResultResultado;
        }

        /// <summary>
        /// Busca o registro no banco de dados e preenche as colunas desta tabela. Utiliza a coluna
        /// e filtro indicados como parâmetro para fazer a pesquisa.
        /// </summary>
        public void buscarRegistro(DbColuna clnFiltro, string strFiltroValor)
        {
            #region VARIÁVEIS

            string sql = null;
            List<String> lstStrColunaValor;

            #endregion

            #region AÇÕES

            try
            {
                sql = "select * from _tbl_nome where _cln_filtro_nome = '_cln_filtro_valor';";
                sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);
                sql = sql.Replace("_cln_filtro_nome", clnFiltro.strNomeSimplificado);
                sql = sql.Replace("_cln_filtro_valor", strFiltroValor);

                lstStrColunaValor = this.objDataBase.execSqlGetLstStrLinha(sql);

                for (int intTemp = 0; intTemp < this.lstCln.Count; intTemp++)
                {
                    this.lstCln[intTemp].strValor = lstStrColunaValor[intTemp];
                }
            }
            catch (Exception ex)
            {
                this.zerarCampos();
                throw new Erro("Erro ao tentar recuperar registro no banco de dados.\n" + sql, ex, Erro.ErroTipo.DATA_BASE);
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Apelido para "public void buscarRegistro(DbColuna clnFiltro, string strFiltroValor)".
        /// </summary>
        public void buscarRegistro(DbColuna clnFiltro, int intFiltroValor)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.buscarRegistro(clnFiltro, intFiltroValor.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Busca o registro segundo os critérios de pesquisa indicados pela lista de "dbFiltro".
        /// </summary>
        public void buscarRegistro(List<DbFiltro> lstDbFiltro)
        {
            #region VARIÁVEIS

            bool booPrimeiro;
            string sql = null;
            string strWhere;
            List<string> lstStrColunaValor;

            #endregion

            #region AÇÕES

            try
            {
                booPrimeiro = true;
                strWhere = Utils.STR_VAZIA;

                foreach (DbFiltro objDbFiltro in lstDbFiltro)
                {
                    strWhere += objDbFiltro.getStrFiltroFormatado(booPrimeiro);
                    strWhere += " ";

                    booPrimeiro = false;
                }

                sql = "select * from _tbl_nme where _where;";
                sql = sql.Replace("_tbl_nme", this.strNomeSimplificado);
                sql = sql.Replace("_where", strWhere);

                lstStrColunaValor = this.objDataBase.execSqlGetLstStrLinha(sql);

                for (int intTemp = 0; intTemp < this.lstCln.Count; intTemp++)
                {
                    this.lstCln[intTemp].strValor = lstStrColunaValor[intTemp];
                }
            }
            catch (Exception ex)
            {
                this.zerarCampos();
                throw new Erro("Erro ao tentar recuperar registro no banco de dados.\n" + sql, ex, Erro.ErroTipo.DATA_BASE);
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Busca o registro segundo o valor da chave primária passada no parâmetro de entrada.
        /// </summary>
        public void buscarRegistroPorChavePrimaria(int intId)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.buscarRegistro(this.clnChavePrimaria, intId.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Apelido para "buscarRegistroPorChavePrimaria(int intId)". Sendo que o filtro que será
        /// utilizado para filtrar o registro é o valor atual da coluna de chavé primária.
        /// </summary>
        public void buscarRegistroPorChavePrimaria()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.buscarRegistroPorChavePrimaria(this.clnChavePrimaria.intValor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Popula um "combobox" com os valores das colunas id e nome da tabela.
        /// </summary>
        public void carregarComboBox(ComboBox cmb)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                cmb.DataSource = this.objDataTable;
                cmb.ValueMember = this.clnChavePrimaria.strNomeSimplificado;
                cmb.DisplayMember = this.clnNome.strNomeSimplificado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Carrega um objeto "DataGridView" passado como parâmetro com os dados da "viewPrincipal"
        /// relacionada a esta tabela.
        /// </summary>
        public void carregarDataGrid(DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                this.objDataBase.carregarDataGrid(this, objDataGridView);
                this.carregarDataGridTitulo(objDataGridView);
                this.carregarDataGridClnTamanho(objDataGridView);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Cria a tabela no banco de dados.
        /// </summary>
        public void criarTabelaNoBancoDeDados()
        {
            #region VARIÁVEIS

            string sql;

            #endregion

            #region AÇÕES

            try
            {
                sql = "create table _tbl_nome ();";
                sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);

                this.objDataBase.execSqlGetLstStrLinha(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        public bool getBooTabelaExiste()
        {
            #region VARIÁVEIS

            bool booResultado;

            #endregion

            #region AÇÕES

            try
            {
                booResultado = this.objDataBase.getBooTabelaExiste(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return booResultado;
        }

        /// <summary>
        /// Retorna "select" básico e sem nenhum tipo de filtro dos registros desta tabela no banco
        /// de dados. Apresenta apenas as colunas que são visíveis na tela de consulta.
        /// </summary>
        public string getSqlDadosTabelaClnVisivelConsulta()
        {
            #region VARIÁVEIS

            string sqlResultado;

            #endregion

            #region AÇÕES

            try
            {
                sqlResultado = "select _cln_nome from _tbl_nome;";
                sqlResultado = sqlResultado.Replace("_cln_nome", this.getStrColunasVisiveisConsultaNomes());
                sqlResultado = sqlResultado.Replace("_tbl_nome", this.strNomeSimplificado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return sqlResultado;
        }

        /// <summary>
        /// Retorna o "select" desta tabela para montar "DataGrid" para tela de consulta.
        /// </summary>
        public string getSqlSelectTelaConsulta()
        {
            #region VARIÁVEIS

            string sqlResultado;

            #endregion

            #region AÇÕES

            try
            {
                sqlResultado = this.getSqlDadosTabelaClnVisivelConsulta();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return sqlResultado;
        }

        /// <summary>
        /// Persiste os valores das colunas no banco de dados. Caso a coluna "clnIntId" contiver um
        /// id novo, cria um novo registro. Do contrário ele faz um "update" dos valores no
        /// registro. <returns>Retorna o id do registro.</returns>
        /// </summary>
        public int salvarRegistro()
        {
            #region VARIÁVEIS

            string sql;
            int intResultado = 0;

            #endregion

            #region AÇÕES

            try
            {
                if (!this.booChavePrimariaExiste)
                {
                    throw new Exception("Tabela não possui chave primária.");
                }
                else if (String.IsNullOrEmpty(this.getStrColunasNomesValoresPreenchidos()))
                {
                    throw new Exception("Não existem valores à serem salvos.");
                }

                if (!String.IsNullOrEmpty(this.clnChavePrimaria.strValor))
                {
                    sql = String.Format(this.objDataBase.getSqlUpdateOrInsert(),
                    this.strNome,
                    this.clnChavePrimaria.strNome,
                    this.clnChavePrimaria.strValor,
                    String.Join(",", this.getLstStrColunaNomePreenchidas().ToArray()),
                    this.getStrColunasValoresPreenchidos(),
                    this.getStrColunasNomesValoresPreenchidos());
                    this.objDataBase.execSqlSemRetorno(sql);
                }
                else
                {
                    sql = "insert into _tbl_nome(_cln_nome) values (_cln_valor) returning (_returning);";
                    sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);
                    sql = sql.Replace("_cln_nome", String.Join(",", this.getLstStrColunaNomePreenchidas().ToArray()));
                    sql = sql.Replace("_cln_valor", this.getStrColunasValoresPreenchidos());
                    sql = sql.Replace("_returning", this.clnChavePrimaria.strNomeSimplificado);

                    this.objDataBase.execSqlSemRetorno(sql);

                    sql = "select max(_cln_nome) from _tbl_nome;";
                    sql = sql.Replace("_cln_nome", this.clnChavePrimaria.strNomeSimplificado);
                    sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);

                    this.clnChavePrimaria.strValor = this.objDataBase.execSqlGetStr(sql);
                }

                this.buscarRegistroPorChavePrimaria();
                intResultado = this.clnChavePrimaria.intValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return intResultado;
        }

        /// <summary>
        /// Associa o valor "null" para todas as colunas desta tabela.
        /// </summary>
        public void zerarCampos()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                foreach (DbColuna cln in this.lstCln)
                {
                    cln.strValor = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Método responsável por atrelar as colunas à esta tabela. Este método é chamado na
        /// construção deste objeto para garantir a ligação das colunas com esta tabela.
        /// </summary>
        protected abstract int inicializarColunas(int intOrdem);

        /// <summary>
        /// Altera os tamanhos das colunas presentes no componente "DataGrid" passado como parâmetro
        /// com os tamanhos indicados nas colunas da tabela.
        /// </summary>
        private void carregarDataGridClnTamanho(DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                for (int intIndex = 0; intIndex < this.lstClnVisivelConsulta.Count; intIndex++)
                {
                    if (this.lstClnVisivelConsulta[intIndex].intTamanho == 0)
                    {
                        continue;
                    }

                    objDataGridView.Columns[intIndex].Width = this.lstClnVisivelConsulta[intIndex].intTamanho * 2;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Altera os títulos das colunas presentes no componente "DataGrid" passado como parâmetro
        /// com os nomes de exibição das colunas da tabela.
        /// </summary>
        private void carregarDataGridTitulo(DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                for (int intIndex = 0; intIndex < this.lstClnVisivelConsulta.Count; intIndex++)
                {
                    objDataGridView.Columns[intIndex].HeaderText = this.lstClnVisivelConsulta[intIndex].strNomeExibicao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Retorna lista de "String" contendo o nome de todas as colunas desta tabela.
        /// </summary>
        /// <param name="booSomentePreenchidas">
        /// Caso seja "true", retorna somente as colunas que tem algum valor válido.
        /// </param>
        private List<string> getLstStrColunaNome(Boolean booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion

            #region AÇÕES

            try
            {
                lstStrResultado = new List<String>();

                foreach (DbColuna objColuna in this.lstCln)
                {
                    if (String.IsNullOrEmpty(objColuna.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrResultado.Add(objColuna.strNomeSimplificado);
                }

                if (lstStrResultado.Count.Equals(0))
                {
                    lstStrResultado.Add("*");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return lstStrResultado;
        }

        /// <summary>
        /// Apelido para "getLstStrColunaNome(Boolean booSomentePreenchidas = false)".
        /// </summary>
        private List<string> getLstStrColunaNomePreenchidas()
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                return this.getLstStrColunaNome(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        private List<string> getLstStrColunaVisivelConsultaNome()
        {
            #region VARIÁVEIS

            List<string> lstStrResultado;

            #endregion

            #region AÇÕES

            try
            {
                lstStrResultado = new List<String>();

                foreach (DbColuna cln in this.lstClnVisivelConsulta)
                {
                    lstStrResultado.Add(cln.strNomeSimplificado);
                }

                if (lstStrResultado.Count == 0)
                {
                    lstStrResultado.Add("*");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return lstStrResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes das colunas desta tabela, separadas
        /// pela "string strSeparador" passada como parâmetro.
        /// </summary>
        private string getStrColunasNomes(string strSeparador = ",")
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = String.Join(strSeparador, this.getLstStrColunaNome().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes e valores das colunas desta tabela,
        /// separadas pela "strSeparador" passada como parâmetro. O formato é "clnNome =
        /// 'clnValor'[strSeparador]". <param name="strSeparador">Texto que vai separar os
        /// valores.</param><param name="booSomentePreenchidas">Caso seja "true", retorna somente as
        /// colunas que tem algum valor válido.</param>
        /// </summary>
        private string getStrColunasNomesValores(string strSeparador = ",", bool booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor;
            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                lstStrColunaValor = new List<String>();

                foreach (DbColuna cln in this.lstCln)
                {
                    if (String.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrColunaValor.Add(cln.strNomeSimplificado + "=" + cln.strSqlValor);
                }

                strResultado = String.Join(strSeparador, lstStrColunaValor.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Apelido para "getStrColunasNomesValores(string strSeparador = ",", Boolean
        /// booSomenteCamposPreenchidos = false)".
        /// </summary>
        private string getStrColunasNomesValoresPreenchidos(string strSeparador = ",")
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                return this.getStrColunasNomesValores(strSeparador, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de valores das colunas desta tabela,
        /// separadas pela "strSeparador" passada como parâmetro. O formato é
        /// "'clnValor'[strSeparador]". <param name="strSeparador">Texto que vai separar os
        /// valores.</param><param name="booSomentePreenchidas">Caso seja "true", retorna somente as
        /// colunas que tem algum valor válido.</param>
        /// </summary>
        private string getStrColunasValores(string strSeparador = ",", bool booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor;
            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                lstStrColunaValor = new List<String>();

                foreach (DbColuna cln in this.lstCln)
                {
                    if (String.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrColunaValor.Add(cln.strSqlValor);
                }

                strResultado = String.Join(strSeparador, lstStrColunaValor.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        /// <summary>
        /// Apelido para "getStrColunasValores(string strSeparador = ",", Boolean
        /// booSomenteCamposPreenchidos = false)".
        /// </summary>
        /// <param name="strSeparador"></param>
        /// <returns></returns>
        private string getStrColunasValoresPreenchidos(string strSeparador = ",")
        {
            #region VARIÁVEIS

            #endregion

            #region AÇÕES

            try
            {
                return this.getStrColunasValores(strSeparador, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion
        }

        private string getStrColunasVisiveisConsultaNomes(string strSeparador = ",")
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion

            #region AÇÕES

            try
            {
                strResultado = String.Join(strSeparador, this.getLstStrColunaVisivelConsultaNome().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion

            return strResultado;
        }

        #endregion
    }
}