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
        public Aplicativo aplicativo
        {
            get { return _aplicativo; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _aplicativo = value;
                    _aplicativo.lstTbl.Add(this);

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        private Boolean _booChavePrimariaExiste;
        public Boolean booChavePrimariaExiste
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _booChavePrimariaExiste = this.clnChavePrimaria != null;

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _booChavePrimariaExiste;
            }
        }

        private Boolean _booVisivel = true;
        public Boolean booVisivel { get { return _booVisivel; } set { _booVisivel = value; } }

        private DbColuna _clnChavePrimaria;
        public DbColuna clnChavePrimaria
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnChavePrimaria == null)
                    {
                        foreach (DbColuna cln in this.lstCln)
                        {
                            if (cln.booChavePrimaria)
                            {
                                _clnChavePrimaria = cln;
                                break;
                            }
                        }
                    }

                    if (_clnChavePrimaria == null)
                    {
                        throw new Erro("Erro ao tentar encontrar a chave primária da tabela " + this.strNome + ".");
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _clnChavePrimaria;
            }
            set { _clnChavePrimaria = value; }
        }

        private DbColuna _clnNome;
        public DbColuna clnNome
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_clnNome == null)
                    {
                        foreach (DbColuna cln in this.lstCln)
                        {
                            if (cln.booNome)
                            {
                                _clnNome = cln;
                                break;
                            }
                        }
                    }

                    if (_clnNome == null)
                    {
                        throw new Exception("Erro ao tentar encontrar a chave primária da tabela " + this.strNome + ".");
                    }


                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _clnNome;
            }
            set { _clnNome = value; }
        }

        private Type _clsFrmCadastro;
        public Type clsFrmCadastro { get { return _clsFrmCadastro; } set { _clsFrmCadastro = value; } }

        private int _intIdRegistroSelecionado;
        public int intIdRegistroSelecionado { get { return _intIdRegistroSelecionado; } set { _intIdRegistroSelecionado = value; } }

        private Int16 _intIdTabela;
        public Int16 intIdTabela { get { return _intIdTabela; } set { _intIdTabela = value; } }

        private List<DbColuna> _lstCln;
        public List<DbColuna> lstCln
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstCln == null)
                    {
                        _lstCln = new List<DbColuna>();
                    }

                    _lstCln.Sort();

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _lstCln;
            }
            set { _lstCln = value; }
        }

        private List<DbColuna> _lstClnVisivelCadastro;
        public List<DbColuna> lstClnVisivelCadastro
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstClnVisivelCadastro == null)
                    {
                        _lstClnVisivelCadastro = new List<DbColuna>();

                        foreach (DbColuna cln in this.lstCln)
                        {
                            if (cln.booVisivelCadastro)
                            {
                                _lstClnVisivelCadastro.Add(cln);
                            }
                        }
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _lstClnVisivelCadastro;
            }
            set
            {
                _lstClnVisivelCadastro = value;
            }
        }

        private List<DbColuna> _lstClnVisivelConsulta;
        public List<DbColuna> lstClnVisivelConsulta
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstClnVisivelConsulta == null)
                    {
                        _lstClnVisivelConsulta = new List<DbColuna>();

                        foreach (DbColuna cln in this.lstCln)
                        {
                            if (cln.booVisivelConsulta)
                            {
                                _lstClnVisivelConsulta.Add(cln);
                            }
                        }
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _lstClnVisivelConsulta;
            }
            set
            {
                _lstClnVisivelConsulta = value;
            }
        }

        private List<Relatorio> _lstObjRelatorio;
        public List<Relatorio> lstObjRelatorio
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_lstObjRelatorio == null)
                    {
                        _lstObjRelatorio = new List<Relatorio>();
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _lstObjRelatorio;
            }
            set { _lstObjRelatorio = value; }
        }

        private DataBase _objDataBase;
        public DataBase objDataBase
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    if (_objDataBase == null)
                    {
                        _objDataBase = Aplicativo.i.objDataBasePrincipal;
                        _objDataBase.lstDbTabela.Add(this);
                    }

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _objDataBase;
            }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _objDataBase = value;
                    _objDataBase.lstDbTabela.Add(this);

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        private DataTable _objDataTable;
        public DataTable objDataTable
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _objDataTable = this.objDataBase.executaSqlGetObjDataTable(this.getSqlDadosTabelaClnVisivelConsulta());

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _objDataTable;
            }
        }

        private Modulo _objModulo;
        public Modulo objModulo
        {
            get { return _objModulo; }
            set
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _objModulo = value;
                    _objModulo.lstObjTabelas.Add(this);

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        #endregion

        #region CONSTRUTORES

        public DbTabela(String strNome)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.strNome = strNome;
                this.inicializarColunas();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Abre uma nova tela contendo campos necessários para o cadastro
        /// de um novo registro desta tabela. Retorna o resultado do formulário de cadastro.
        /// <param name="intRegistroId">"Int" que representa o registro caso seja uma edição.
        /// Se for passado 0 (zero) o formulário será preparado para o cadastro de um novo
        /// registro.</param>
        /// <returns>Retorna "DialogResult.Yes" caso o registro tenha sido alterado ou
        /// "DialogResult.Cancel" caso contrário.</returns>
        /// </summary>
        public DialogResult abrirFrmCadastro(int intRegistroId = 0)
        {
            #region VARIÁVEIS

            FrmCadastro frmCadastro;
            DialogResult objDialogResultResultado;

            #endregion
            try
            {
                #region AÇÕES

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

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return objDialogResultResultado;
        }

        /// <summary>
        /// Abre uma nova tela contendo os registros desta tabela.
        /// Retorna o resultado da tela de consulta.
        /// </summary>
        public DialogResult abrirFrmConsulta()
        {
            #region VARIÁVEIS

            FrmConsulta frmConsulta;
            DialogResult objDialogResultResultado;

            #endregion
            try
            {
                #region AÇÕES

                Aplicativo.i.tblSelecionada = this;
                objDialogResultResultado = Aplicativo.i.abrirFrmCache(typeof(FrmConsulta));

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return objDialogResultResultado;
        }

        /// <summary>
        /// Busca o registro no banco de dados e preenche as colunas desta tabela. Utiliza a coluna e filtro
        /// indicados como parâmetro para fazer a pesquisa.
        /// </summary>
        public void buscarRegistro(DbColuna clnFiltro, String strFiltroValor)
        {
            #region VARIÁVEIS

            String sql = null;
            List<String> lstStrColunaValor;

            #endregion
            try
            {
                #region AÇÕES

                sql = String.Format("SELECT {0} FROM {1} WHERE {2} = '{3}';", this.getStrColunasNomes(), this.strNomeSimplificado, clnFiltro.strNomeSimplificado, strFiltroValor);
                lstStrColunaValor = this.objDataBase.executaSqlGetLstStrLinha(sql);

                for (int intTemp = 0; intTemp < this.lstCln.Count; intTemp++)
                {
                    this.lstCln[intTemp].strValor = lstStrColunaValor[intTemp];
                }

                #endregion
            }
            catch (Exception ex)
            {
                this.zerarCampos();
                throw new Erro("Erro ao tentar recuperar registro no banco de dados.\n" + sql, ex, Erro.ErroTipo.BancoDados);
            }
        }

        /// <summary>
        /// Apelido para "public void buscarRegistro(DbColuna clnFiltro, String strFiltroValor)".
        /// </summary>
        public void buscarRegistro(DbColuna clnFiltro, int intFiltroValor)
        {
            this.buscarRegistro(clnFiltro, intFiltroValor.ToString());
        }

        /// <summary>
        /// Busca o registro segundo os critérios de pesquisa indicados pela lista de "dbFiltro".
        /// </summary>
        public void buscarRegistro(List<DbFiltro> lstDbFiltro)
        {
            #region VARIÁVEIS

            Boolean booPrimeiro;
            String sql = null;
            String strWhere;
            List<String> lstStrColunaValor;

            #endregion
            try
            {
                #region AÇÕES

                booPrimeiro = true;
                strWhere = Utils.STRING_VAZIA;

                foreach (DbFiltro objDbFiltro in lstDbFiltro)
                {
                    strWhere += objDbFiltro.getStrFiltroFormatado(booPrimeiro);
                    strWhere += " ";

                    booPrimeiro = false;
                }

                sql = String.Format("SELECT {0} FROM {1} WHERE {2};", this.getStrColunasNomes(), this.strNomeSimplificado, strWhere);
                lstStrColunaValor = this.objDataBase.executaSqlGetLstStrLinha(sql);

                for (int intTemp = 0; intTemp < this.lstCln.Count; intTemp++)
                {
                    this.lstCln[intTemp].strValor = lstStrColunaValor[intTemp];
                }

                #endregion
            }
            catch (Exception ex)
            {
                this.zerarCampos();
                throw new Erro("Erro ao tentar recuperar registro no banco de dados.\n" + sql, ex, Erro.ErroTipo.BancoDados);
            }
        }

        /// <summary>
        /// Busca o registro segundo o valor da chave primária passada no parâmetro de entrada.
        /// </summary>
        public void buscarRegistroPorChavePrimaria(int intId)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.buscarRegistro(this.clnChavePrimaria, intId.ToString());

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Apelido para "buscarRegistroPorChavePrimaria(int intId)". Sendo que o filtro que será
        /// utilizado para filtrar o registro é o valor atual da coluna de chavé primária.
        /// </summary>
        public void buscarRegistroPorChavePrimaria()
        {
            this.buscarRegistroPorChavePrimaria(this.clnChavePrimaria.intValor);
        }

        /// <summary>
        /// Popula um "combobox" com os valores das colunas id e nome da tabela.
        /// </summary>
        public void carregarComboBox(ComboBox cmb)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                cmb.DataSource = this.objDataTable;
                cmb.ValueMember = this.clnChavePrimaria.strNomeSimplificado;
                cmb.DisplayMember = this.clnNome.strNomeSimplificado;

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Carrega um objeto "DataGridView" passado como parâmetro com os dados da "viewPrincipal"
        /// relacionada a esta tabela.
        /// </summary>
        public void carregarDataGrid(DataGridView objDataGridView)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.objDataBase.carregaDataGrid(this, objDataGridView);
                this.carregarDataGridTitulo(objDataGridView);
                this.carregarDataGridClnTamanho(objDataGridView);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Altera os tamanhos das colunas presentes no componente "DataGrid" passado
        /// como parâmetro com os tamanhos indicados nas colunas da tabela.
        /// </summary>
        private void carregarDataGridClnTamanho(DataGridView objDataGridView)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                for (int intIndex = 0; intIndex < this.lstClnVisivelConsulta.Count; intIndex++)
                {
                    if (this.lstClnVisivelConsulta[intIndex].intTamanho == 0)
                    {
                        continue;
                    }

                    objDataGridView.Columns[intIndex].Width = this.lstClnVisivelConsulta[intIndex].intTamanho * 2;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Altera os títulos das colunas presentes no componente "DataGrid" passado
        /// como parâmetro com os nomes de exibição das colunas da tabela.
        /// </summary>
        private void carregarDataGridTitulo(DataGridView objDataGridView)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                for (int intIndex = 0; intIndex < this.lstClnVisivelConsulta.Count; intIndex++)
                {
                    objDataGridView.Columns[intIndex].HeaderText = this.lstClnVisivelConsulta[intIndex].strNomeExibicao;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        /// <summary>
        /// Cria a tabela no banco de dados.
        /// </summary>
        public void criarTabelaNoBancoDeDados()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.objDataBase.executaSqlGetLstStrLinha(String.Format("CREATE TABLE {0} ();", this.strNomeSimplificado));

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        public Boolean getBooTabelaExiste()
        {
            #region VARIÁVEIS

            Boolean booResultado;

            #endregion
            try
            {
                #region AÇÕES

                booResultado = this.objDataBase.getBooTabelaExiste(this);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return booResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes das colunas desta
        /// tabela, separadas pela "String strSeparador" passada como parâmetro.
        /// </summary>
        private String getStrColunasNomes(String strSeparador = ",")
        {
            #region VARIÁVEIS

            String strResultado;

            #endregion
            try
            {
                #region AÇÕES

                strResultado = String.Join(strSeparador, this.getLstStrColunaNome().ToArray());

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes e valores das
        /// colunas desta tabela, separadas pela "strSeparador" passada como parâmetro.
        /// O formato é "clnNome = 'clnValor'[strSeparador]".
        /// <param name="strSeparador">Texto que vai separar os valores.</param>
        /// <param name="booSomentePreenchidas">Caso seja "true", retorna somente as colunas
        /// que tem algum valor válido.</param>
        /// </summary>
        private String getStrColunasNomesValores(String strSeparador = ",", Boolean booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor;
            String strResultado;

            #endregion
            try
            {
                #region AÇÕES


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

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        /// <summary>
        /// Apelido para "getStrColunasNomesValores(String strSeparador = ",", Boolean booSomenteCamposPreenchidos = false)".
        /// </summary>
        private String getStrColunasNomesValoresPreenchidos(String strSeparador = ",")
        {
            return this.getStrColunasNomesValores(strSeparador, true);
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de valores das
        /// colunas desta tabela, separadas pela "strSeparador" passada como parâmetro.
        /// O formato é "'clnValor'[strSeparador]".
        /// <param name="strSeparador">Texto que vai separar os valores.</param>
        /// <param name="booSomentePreenchidas">Caso seja "true", retorna somente as colunas
        /// que tem algum valor válido.</param>
        /// </summary>
        private String getStrColunasValores(String strSeparador = ",", Boolean booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrColunaValor;
            String strResultado;

            #endregion
            try
            {
                #region AÇÕES

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

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;

        }

        /// <summary>
        /// Apelido para "getStrColunasValores(String strSeparador = ",", Boolean booSomenteCamposPreenchidos = false)".
        /// </summary>
        /// <param name="strSeparador"></param>
        /// <returns></returns>
        private String getStrColunasValoresPreenchidos(String strSeparador = ",")
        {
            return this.getStrColunasValores(strSeparador, true);
        }

        private String getStrColunasVisiveisConsultaNomes(String strSeparador = ",")
        {
            #region VARIÁVEIS

            String strResultado;

            #endregion
            try
            {
                #region AÇÕES

                strResultado = String.Join(strSeparador, this.getLstStrColunaVisivelConsultaNome().ToArray());

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return strResultado;
        }

        /// <summary>
        /// Retorna lista de "String" contendo o nome de todas as colunas desta
        /// tabela.
        /// </summary>
        /// <param name="booSomentePreenchidas">Caso seja "true", retorna somente as colunas
        /// que tem algum valor válido.</param>
        private List<String> getLstStrColunaNome(Boolean booSomentePreenchidas = false)
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion
            try
            {
                #region AÇÕES

                lstStrResultado = new List<String>();

                foreach (DbColuna objColuna in this.lstCln)
                {
                    if (String.IsNullOrEmpty(objColuna.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrResultado.Add(objColuna.strNomeSimplificado);
                }

                if (lstStrResultado.Count == 0)
                {
                    lstStrResultado.Add("*");
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return lstStrResultado;
        }

        /// <summary>
        /// Apelido para "getLstStrColunaNome(Boolean booSomentePreenchidas = false)".
        /// </summary>
        private List<String> getLstStrColunaNomePreenchidas()
        {
            return this.getLstStrColunaNome(true);
        }

        private List<String> getLstStrColunaVisivelConsultaNome()
        {
            #region VARIÁVEIS

            List<String> lstStrResultado;

            #endregion
            try
            {
                #region AÇÕES

                lstStrResultado = new List<String>();

                foreach (DbColuna cln in this.lstClnVisivelConsulta)
                {
                    lstStrResultado.Add(cln.strNomeSimplificado);
                }

                if (lstStrResultado.Count == 0)
                {
                    lstStrResultado.Add("*");
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return lstStrResultado;
        }

        /// <summary>
        /// Retorna "select" básico e sem nenhum tipo de filtro dos registros desta tabela
        /// no banco de dados. Apresenta apenas as colunas que são visíveis na tela de
        /// consulta.
        /// </summary>
        public String getSqlDadosTabelaClnVisivelConsulta()
        {
            #region VARIÁVEIS

            String sqlResultado;

            #endregion
            try
            {
                #region AÇÕES

                sqlResultado = String.Format("select {0} from {1};", this.getStrColunasVisiveisConsultaNomes(), this.strNomeSimplificado);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return sqlResultado;
        }

        /// <summary>
        /// Retorna o "select" desta tabela para montar "DataGrid" para 
        /// tela de consulta.
        /// </summary>
        public String getSqlSelectTelaConsulta()
        {
            #region VARIÁVEIS

            String sqlResultado;

            #endregion
            try
            {
                #region AÇÕES

                sqlResultado = this.getSqlDadosTabelaClnVisivelConsulta();

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return sqlResultado;
        }

        /// <summary>
        /// Método responsável por atrelar as colunas à esta tabela.
        /// Este método é chamado na construção deste objeto para garantir
        /// a ligação das colunas com esta tabela.
        /// </summary>
        protected abstract void inicializarColunas();

        /// <summary>
        /// Persiste os valores das colunas no banco de dados.
        /// Caso a coluna "clnIntId" contiver um id novo, cria
        /// um novo registro. Do contrário ele faz um "update"
        /// dos valores no registro.
        /// <returns>Retorna o id do registro.</returns>
        /// </summary>
        public int salvarRegistro()
        {
            #region VARIÁVEIS

            String sql;
            int intResultado = 0;

            #endregion
            try
            {
                #region AÇÕES

                if (!this.booChavePrimariaExiste)
                {
                    throw new Exception("Tabela não possui chave primária.");
                }
                else if (this.getStrColunasNomesValoresPreenchidos() == Utils.STRING_VAZIA)
                {
                    throw new Exception("Não existem valores à serem salvos.");
                }
                else
                {
                    if (!String.IsNullOrEmpty(this.clnChavePrimaria.strValor))
                    {
                        sql = String.Format(this.objDataBase.getSqlUpdateOrInsert(),
                        this.strNome,
                        this.clnChavePrimaria.strNome,
                        this.clnChavePrimaria.strValor,
                        String.Join(",", this.getLstStrColunaNomePreenchidas().ToArray()),
                        this.getStrColunasValoresPreenchidos(),
                        this.getStrColunasNomesValoresPreenchidos());
                    }
                    else
                    {
                        sql = String.Format("insert into {0}({1}) values ({2}) returning ({3});",
                        this.strNome,
                        String.Join(",", this.getLstStrColunaNomePreenchidas().ToArray()),
                        this.getStrColunasValoresPreenchidos(),
                        this.clnChavePrimaria.strNomeSimplificado);
                    }

                    this.objDataBase.executaSqlSemRetorno(sql);

                    sql = String.Format("select max({0}) from {1};",
                        this.clnChavePrimaria.strNomeSimplificado,
                        this.strNomeSimplificado
                        );

                    this.clnChavePrimaria.intValor = Convert.ToInt32(this.objDataBase.executaSqlGetLstStrLinha(sql)[0]);
                    this.buscarRegistroPorChavePrimaria();
                    intResultado = this.clnChavePrimaria.intValor;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            return intResultado;
        }

        /// <summary>
        /// Associa o valor "null" para todas as colunas desta tabela.
        /// </summary>
        public void zerarCampos()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                foreach (DbColuna cln in this.lstCln)
                {
                    cln.strValor = null;
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        #endregion
    }
}