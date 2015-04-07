using DigoFramework.Frm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DigoFramework.DataBase
{
    public abstract class DbTabela : Objeto
    {
        #region CONSTANTES

        #endregion CONSTANTES

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

                #endregion VARIÁVEIS

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

                #endregion AÇÕES
            }
        }

        public bool booChavePrimariaExiste
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

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

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

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

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

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

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_lstCln != null)
                    {
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

                #endregion AÇÕES

                return _lstCln;
            }
        }

        public List<DbColuna> lstClnVisivelCadastro
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

                return _lstClnVisivelCadastro;
            }

            set
            {
                _lstClnVisivelCadastro = value;
            }
        }

        public List<DbColuna> lstClnVisivelConsulta
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

                return _lstClnVisivelConsulta;
            }

            set
            {
                _lstClnVisivelConsulta = value;
            }
        }

        public DataBase objDataBase
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (_objDataBase != null)
                    {
                        return _objDataBase;
                    }

                    _objDataBase = Aplicativo.i.objDbPrincipal;
                    _objDataBase.lstDbTabela.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _objDataBase;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES
            }
        }

        public DataTable objDataTable
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

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

                #endregion AÇÕES

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

                #endregion VARIÁVEIS

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

                #endregion AÇÕES
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public DbTabela(string strNome)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.strNome = strNome;
                this.inicializarColunas(-1);
                this.lstCln.Sort();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        /// <summary>
        /// Abre uma nova tela contendo campos necessários para o cadastro de um novo registro desta
        /// tabela. Retorna o resultado do formulário de cadastro. <param name="intRegistroId">"Int"
        /// que representa o registro caso seja uma edição. Se for passado 0 (zero) o formulário
        /// será preparado para o cadastro de um novo registro.</param> <returns>Retorna
        /// "DialogResult.Yes" caso o registro tenha sido alterado ou "DialogResult.Cancel" caso contrário.</returns>
        /// </summary>
        public DialogResult abrirFrmCadastro(int intRegistroId = 0)
        {
            #region VARIÁVEIS

            FrmCadastro frmCadastro;
            DialogResult objDialogResultResultado;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

            return objDialogResultResultado;
        }

        /// <summary>
        /// Abre uma nova tela contendo os registros desta tabela. Retorna o resultado da tela de consulta.
        /// </summary>
        public DialogResult abrirFrmConsulta()
        {
            #region VARIÁVEIS

            DialogResult objDialogResultResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                Aplicativo.i.tblSelec = this;
                objDialogResultResultado = Aplicativo.i.abrirFrmCache(typeof(FrmConsulta));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

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
            List<String> lstStrClnValor;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sql = "select _cln_nome from _tbl_nome where _cln_filtro_nome = '_cln_filtro_valor';";
                sql = sql.Replace("_cln_nome", this.getStrClnNomes());
                sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);
                sql = sql.Replace("_cln_filtro_nome", clnFiltro.strNomeSimplificado);
                sql = sql.Replace("_cln_filtro_valor", strFiltroValor);

                lstStrClnValor = this.objDataBase.execSqlGetLstStrLinha(sql);

                if (!lstStrClnValor.Count.Equals(this.lstCln.Count))
                {
                    return;
                }

                for (int intTemp = 0; intTemp < this.lstCln.Count; intTemp++)
                {
                    this.lstCln[intTemp].strValor = lstStrClnValor[intTemp];
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

            #endregion AÇÕES
        }

        /// <summary>
        /// Apelido para "public void buscarRegistro(DbColuna clnFiltro, string strFiltroValor)".
        /// </summary>
        public void buscarRegistro(DbColuna clnFiltro, int intFiltroValor)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Busca o registro segundo os critérios de pesquisa indicados pela lista de "dbFiltro".
        /// </summary>
        public void buscarRegistro(List<DbFiltro> lstDbFiltro)
        {
            #region VARIÁVEIS

            bool booPrimeiro;
            List<string> lstStrClnValor;
            string sql = null;
            string strWhere;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                booPrimeiro = true;
                strWhere = String.Empty;

                foreach (DbFiltro objDbFiltro in lstDbFiltro)
                {
                    strWhere += objDbFiltro.getStrFiltroFormatado(booPrimeiro);
                    strWhere += " ";

                    booPrimeiro = false;
                }

                strWhere = Utils.removerUltimaLetra(strWhere);

                sql = "select _cln_nome from _tbl_nme where _where;";

                sql = sql.Replace("_cln_nome", this.getStrClnNomes());
                sql = sql.Replace("_tbl_nme", this.strNomeSimplificado);
                sql = sql.Replace("_where", strWhere);

                lstStrClnValor = this.objDataBase.execSqlGetLstStrLinha(sql);

                if (lstStrClnValor == null || lstStrClnValor.Count == 0)
                {
                    this.zerarCampos();
                    return;
                }

                for (int intTemp = 0; intTemp < this.lstCln.Count - 1; intTemp++)
                {
                    this.lstCln[intTemp].strValor = lstStrClnValor[intTemp];
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

            #endregion AÇÕES
        }

        /// <summary>
        /// Busca o registro segundo o valor da chave primária passada no parâmetro de entrada.
        /// </summary>
        public void buscarRegistro(int intId)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Apelido para "buscarRegistroPorChavePrimaria(int intId)". Sendo que o filtro que será
        /// utilizado para filtrar o registro é o valor atual da coluna de chavé primária.
        /// </summary>
        public void buscarRegistro()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.buscarRegistro(this.clnChavePrimaria.intValor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Popula um "combobox" com os valores das colunas id e nome da tabela.
        /// </summary>
        public void carregarComboBox(ComboBox cmb)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Carrega um objeto "DataGridView" passado como parâmetro com os dados da "viewPrincipal"
        /// relacionada a esta tabela.
        /// </summary>
        public void carregarDataGrid(DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.objDataBase.carregarDataGrid(this, objDataGridView);
                this.carregarDataGridLayout(objDataGridView);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Cria a tabela no banco de dados.
        /// </summary>
        public void criarTabelaNoBancoDeDados()
        {
            #region VARIÁVEIS

            string sql;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        public bool getBooTabelaExiste()
        {
            #region VARIÁVEIS

            bool booResultado;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

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

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                sqlResultado = "select _cln_nome from _tbl_nome;";
                sqlResultado = sqlResultado.Replace("_cln_nome", this.getStrClnVisiveisConsultaNomes());
                sqlResultado = sqlResultado.Replace("_tbl_nome", this.strNomeSimplificado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return sqlResultado;
        }

        /// <summary>
        /// Retorna o "select" desta tabela para montar "DataGrid" para tela de consulta.
        /// </summary>
        public string getSqlSelectTelaConsulta()
        {
            #region VARIÁVEIS

            string sqlResultado;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

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

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (!this.booChavePrimariaExiste)
                {
                    throw new Exception("Tabela não possui chave primária.");
                }
                else if (String.IsNullOrEmpty(this.getStrClnNomesValoresPreenchidos()))
                {
                    throw new Exception("Não existem valores à serem salvos.");
                }

                if (!String.IsNullOrEmpty(this.clnChavePrimaria.strValor))
                {
                    sql = String.Format(this.objDataBase.getSqlUpdateOrInsert(),
                    this.strNome,
                    this.clnChavePrimaria.strNome,
                    this.clnChavePrimaria.strValor,
                    String.Join(",", this.getLstStrClnNomePreenchidas().ToArray()),
                    this.getStrClnValoresPreenchidos(),
                    this.getStrClnNomesValoresPreenchidos());
                    this.objDataBase.execSqlSemRetorno(sql);
                }
                else
                {
                    sql = "insert into _tbl_nome(_cln_nome) values (_cln_valor) returning (_returning);";
                    sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);
                    sql = sql.Replace("_cln_nome", String.Join(",", this.getLstStrClnNomePreenchidas().ToArray()));
                    sql = sql.Replace("_cln_valor", this.getStrClnValoresPreenchidos());
                    sql = sql.Replace("_returning", this.clnChavePrimaria.strNomeSimplificado);

                    this.objDataBase.execSqlSemRetorno(sql);

                    sql = "select max(_cln_nome) from _tbl_nome;";
                    sql = sql.Replace("_cln_nome", this.clnChavePrimaria.strNomeSimplificado);
                    sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);

                    this.clnChavePrimaria.strValor = this.objDataBase.execSqlGetStr(sql);
                }

                this.buscarRegistro();
                intResultado = this.clnChavePrimaria.intValor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return intResultado;
        }

        /// <summary>
        /// Associa o valor "null" para todas as colunas desta tabela.
        /// </summary>
        public void zerarCampos()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

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

            #endregion AÇÕES
        }

        /// <summary>
        /// Método responsável por atrelar as colunas à esta tabela. Este método é chamado na
        /// construção deste objeto para garantir a ligação das colunas com esta tabela.
        /// </summary>
        protected abstract int inicializarColunas(int intOrdem);

        private void carregarDataGridClnDirecao(DataGridViewColumn dgc, DbColuna cln)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (cln.enmGrupo == DbColuna.EnmGrupo.NUMERICO)
                {
                    dgc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void carregarDataGridClnTamanho(DataGridViewColumn dgc, DbColuna cln)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (cln.intTamanho == 0)
                {
                    return;
                }

                dgc.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dgc.Width = cln.intTamanho;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void carregarDataGridLayout(DataGridView objDataGridView)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                for (int i = 0; i < this.lstClnVisivelConsulta.Count; i++)
                {
                    this.carregarDataGridTitulo(objDataGridView.Columns[i], this.lstClnVisivelConsulta[i]);
                    this.carregarDataGridClnTamanho(objDataGridView.Columns[i], this.lstClnVisivelConsulta[i]);
                    this.carregarDataGridClnDirecao(objDataGridView.Columns[i], this.lstClnVisivelConsulta[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void carregarDataGridTitulo(DataGridViewColumn dgc, DbColuna cln)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                dgc.HeaderText = cln.strNomeExibicao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Retorna lista de "String" contendo o nome de todas as colunas desta tabela.
        /// </summary>
        /// <param name="booSomentePreenchidas">
        /// Caso seja "true", retorna somente as colunas que tem algum valor válido.
        /// </param>
        private List<string> getLstStrClnNome(bool booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstStrResultado = new List<String>();

                foreach (DbColuna cln in this.lstCln)
                {
                    if (String.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrResultado.Add(cln.strNomeSimplificado);
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

            #endregion AÇÕES

            return lstStrResultado;
        }

        /// <summary>
        /// Apelido para "getLstStrColunaNome(bool booSomentePreenchidas = false)".
        /// </summary>
        private List<string> getLstStrClnNomePreenchidas()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                return this.getLstStrClnNome(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private List<string> getLstStrClnVisivelConsultaNome()
        {
            #region VARIÁVEIS

            List<string> lstStrResultado;

            #endregion VARIÁVEIS

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

            #endregion AÇÕES

            return lstStrResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes das colunas desta tabela, separadas
        /// pela "string strSeparador" passada como parâmetro.
        /// </summary>
        private string getStrClnNomes(string strSeparador = ", ")
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = String.Join(strSeparador, this.getLstStrClnNome().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes e valores das colunas desta tabela,
        /// separadas pela "strSeparador" passada como parâmetro. O formato é "clnNome =
        /// 'clnValor'[strSeparador]". <param name="strSeparador">Texto que vai separar os
        /// valores.</param> <param name="booSomentePreenchidas">Caso seja "true", retorna somente
        /// as colunas que tem algum valor válido.</param>
        /// </summary>
        private string getStrClnNomesValores(string strSeparador = ",", bool booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrClnValor;
            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstStrClnValor = new List<String>();

                foreach (DbColuna cln in this.lstCln)
                {
                    if (String.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrClnValor.Add(cln.strNomeSimplificado + "=" + cln.strSqlValor);
                }

                strResultado = String.Join(strSeparador, lstStrClnValor.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Apelido para "getStrColunasNomesValores(string strSeparador = ",", Boolean
        /// booSomenteCamposPreenchidos = false)".
        /// </summary>
        private string getStrClnNomesValoresPreenchidos(string strSeparador = ",")
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                return this.getStrClnNomesValores(strSeparador, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de valores das colunas desta tabela,
        /// separadas pela "strSeparador" passada como parâmetro. O formato é
        /// "'clnValor'[strSeparador]". <param name="strSeparador">Texto que vai separar os
        /// valores.</param> <param name="booSomentePreenchidas">Caso seja "true", retorna somente
        /// as colunas que tem algum valor válido.</param>
        /// </summary>
        private string getStrClnValores(string strSeparador = ",", bool booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrClnValor;
            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                lstStrClnValor = new List<String>();

                foreach (DbColuna cln in this.lstCln)
                {
                    if (String.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrClnValor.Add(cln.strSqlValor);
                }

                strResultado = String.Join(strSeparador, lstStrClnValor.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        /// <summary>
        /// Apelido para "getStrColunasValores(string strSeparador = ",", Boolean
        /// booSomenteCamposPreenchidos = false)".
        /// </summary>
        /// <param name="strSeparador"></param>
        /// <returns></returns>
        private string getStrClnValoresPreenchidos(string strSeparador = ",")
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                return this.getStrClnValores(strSeparador, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private string getStrClnVisiveisConsultaNomes(string strSeparador = ",")
        {
            #region VARIÁVEIS

            string strResultado;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                strResultado = String.Join(strSeparador, this.getLstStrClnVisivelConsultaNome().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES

            return strResultado;
        }

        #endregion MÉTODOS
    }
}