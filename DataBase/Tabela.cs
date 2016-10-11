using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DigoFramework.DataBase
{
    public abstract class Tabela : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booVisivel = true;
        private Coluna _clnChavePrimaria;
        private Coluna _clnNome;
        private Type _clsFrmCadastro;
        private int _intIdRegSelec;
        private int _intIdTabela;
        private List<Coluna> _lstCln;
        private List<Coluna> _lstClnCadastro;
        private List<Coluna> _lstClnConsulta;
        private DataBase _objDataBase;
        private DataTable _objDataTable;
        private Modulo _objModulo;

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

        public Coluna clnChavePrimaria
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnChavePrimaria != null)
                    {
                        return _clnChavePrimaria;
                    }

                    _clnChavePrimaria = this.lstCln[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _clnChavePrimaria;
            }

            internal set
            {
                _clnChavePrimaria = value;
            }
        }

        public Coluna clnNome
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_clnNome != null)
                    {
                        return _clnNome;
                    }

                    _clnNome = this.clnChavePrimaria;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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

        public int intIdRegSelec
        {
            get
            {
                return _intIdRegSelec;
            }

            set
            {
                _intIdRegSelec = value;
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

        public List<Coluna> lstCln
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstCln != null)
                    {
                        return _lstCln;
                    }

                    _lstCln = new List<Coluna>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstCln;
            }
        }

        public List<Coluna> lstClnCadastro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstClnCadastro != null)
                    {
                        return _lstClnCadastro;
                    }

                    _lstClnCadastro = new List<Coluna>();

                    foreach (Coluna cln in this.lstCln)
                    {
                        if (!cln.booVisivelCadastro)
                        {
                            continue;
                        }

                        _lstClnCadastro.Add(cln);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstClnCadastro;
            }

            internal set
            {
                _lstClnCadastro = value;
            }
        }

        public List<Coluna> lstClnConsulta
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstClnConsulta != null)
                    {
                        return _lstClnConsulta;
                    }

                    _lstClnConsulta = new List<Coluna>();

                    foreach (Coluna cln in this.lstCln)
                    {
                        if (!cln.booVisivelConsulta)
                        {
                            continue;
                        }

                        _lstClnConsulta.Add(cln);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstClnConsulta;
            }

            internal set
            {
                _lstClnConsulta = value;
            }
        }

        public DataBase objDataBase
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objDataBase != null)
                    {
                        return _objDataBase;
                    }

                    _objDataBase = AppBase.i.objDbPrincipal;
                    _objDataBase.lstTbl.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objDataBase;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _objDataBase = value;
                    _objDataBase.lstTbl.Add(this);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações
            }
        }

        public DataTable objDataTable
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _objDataTable = this.objDataBase.execSqlDataTable(this.getSqlDadosTabelaClnVisivelConsulta());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

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
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
            }
        }

        #endregion Atributos

        #region Construtores

        public Tabela(string strNome)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos


     

        /// <summary>
        /// Busca o registro no banco de dados e preenche as colunas desta tabela. Utiliza a coluna e
        /// filtro indicados como parâmetro para fazer a pesquisa.
        /// </summary>
        public void buscarRegistro(Coluna clnFiltro, string strFiltroValor)
        {
            #region Variáveis

            string sql = null;
            List<string> lstStrClnValor;

            #endregion Variáveis

            #region Ações

            try
            {
                sql = "select _cln_nome from _tbl_nome where _cln_filtro_nome = '_cln_filtro_valor';";
                sql = sql.Replace("_cln_nome", this.getStrClnNomes());
                sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);
                sql = sql.Replace("_cln_filtro_nome", clnFiltro.strNomeSimplificado);
                sql = sql.Replace("_cln_filtro_valor", strFiltroValor);

                lstStrClnValor = this.objDataBase.execSqlLstStrLinha(sql);

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
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Apelido para "public void buscarRegistro(DbColuna clnFiltro, string strFiltroValor)".
        /// </summary>
        public void buscarRegistro(Coluna clnFiltro, int intFiltroValor)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Busca o registro segundo os critérios de pesquisa indicados pela lista de "dbFiltro".
        /// </summary>
        public void buscarRegistro(List<Filtro> lstDbFiltro)
        {
            #region Variáveis

            bool booPrimeiro;
            List<string> lstStrClnValor;
            string sql = null;
            string strWhere;

            #endregion Variáveis

            #region Ações

            try
            {
                booPrimeiro = true;
                strWhere = string.Empty;

                foreach (Filtro objDbFiltro in lstDbFiltro)
                {
                    strWhere += objDbFiltro.getStrFiltroFormatado(booPrimeiro);
                    strWhere += " ";

                    booPrimeiro = false;
                }

                strWhere = Utils.removerCaracter(strWhere);

                sql = "select _cln_nome from _tbl_nme where _where;";

                sql = sql.Replace("_cln_nome", this.getStrClnNomes());
                sql = sql.Replace("_tbl_nme", this.strNomeSimplificado);
                sql = sql.Replace("_where", strWhere);

                lstStrClnValor = this.objDataBase.execSqlLstStrLinha(sql);

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
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Busca o registro segundo o valor da chave primária passada no parâmetro de entrada.
        /// </summary>
        public void buscarRegistro(int intId)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Apelido para "buscarRegistroPorChavePrimaria(int intId)". Sendo que o filtro que será
        /// utilizado para filtrar o registro é o valor atual da coluna de chavé primária.
        /// </summary>
        public void buscarRegistro()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Popula um "combobox" com os valores das colunas id e nome da tabela.
        /// </summary>
        public void carregarComboBox(ComboBox cmb)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Carrega um objeto "DataGridView" passado como parâmetro com os dados da "viewPrincipal"
        /// relacionada a esta tabela.
        /// </summary>
        public void carregarDataGrid(DataGridView objDataGridView)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.objDataBase.carregarGrid(this, objDataGridView);
                this.carregarDataGridLayout(objDataGridView);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        /// <summary>
        /// Cria a tabela no banco de dados.
        /// </summary>
        public void criarTabelaNoBancoDeDados()
        {
            #region Variáveis

            string sql;

            #endregion Variáveis

            #region Ações

            try
            {
                sql = "create table _tbl_nome ();";
                sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);

                this.objDataBase.execSqlLstStrLinha(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        public bool getBooTabelaExiste()
        {
            #region Variáveis

            bool booResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return booResultado;
        }

        /// <summary>
        /// Retorna "select" básico e sem nenhum tipo de filtro dos registros desta tabela no banco
        /// de dados. Apresenta apenas as colunas que são visíveis na tela de consulta.
        /// </summary>
        public string getSqlDadosTabelaClnVisivelConsulta()
        {
            #region Variáveis

            string sqlResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return sqlResultado;
        }

        /// <summary>
        /// Retorna o "select" desta tabela para montar "DataGrid" para tela de consulta.
        /// </summary>
        public string getSqlSelectTelaConsulta()
        {
            #region Variáveis

            string sqlResultado;

            #endregion Variáveis

            #region Ações

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

            #endregion Ações

            return sqlResultado;
        }

        /// <summary>
        /// Persiste os valores das colunas no banco de dados. Caso a coluna "clnIntId" contiver um
        /// id novo, cria um novo registro. Do contrário ele faz um "update" dos valores no registro.
        /// <returns>Retorna o id do registro.</returns>
        /// </summary>
        public int salvarRegistro()
        {
            #region Variáveis

            string sql;
            int intResultado = 0;

            #endregion Variáveis

            #region Ações

            try
            {
                if (string.IsNullOrEmpty(this.getStrClnNomesValoresPreenchidos()))
                {
                    throw new Exception("Não existem valores à serem salvos.");
                }

                if (!string.IsNullOrEmpty(this.clnChavePrimaria.strValor))
                {
                    sql = string.Format(this.objDataBase.getSqlUpdateOrInsert(),
                    this.strNome,
                    this.clnChavePrimaria.strNome,
                    this.clnChavePrimaria.strValor,
                    string.Join(",", this.getLstStrClnNomePreenchidas().ToArray()),
                    this.getStrClnValoresPreenchidos(),
                    this.getStrClnNomesValoresPreenchidos());
                    this.objDataBase.execSql(sql);
                }
                else
                {
                    sql = "insert into _tbl_nome(_cln_nome) values (_cln_valor) returning (_returning);";
                    sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);
                    sql = sql.Replace("_cln_nome", string.Join(",", this.getLstStrClnNomePreenchidas().ToArray()));
                    sql = sql.Replace("_cln_valor", this.getStrClnValoresPreenchidos());
                    sql = sql.Replace("_returning", this.clnChavePrimaria.strNomeSimplificado);

                    this.objDataBase.execSql(sql);

                    sql = "select max(_cln_nome) from _tbl_nome;";
                    sql = sql.Replace("_cln_nome", this.clnChavePrimaria.strNomeSimplificado);
                    sql = sql.Replace("_tbl_nome", this.strNomeSimplificado);

                    this.clnChavePrimaria.strValor = this.objDataBase.execSqlStr(sql);
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

            #endregion Ações

            return intResultado;
        }

        /// <summary>
        /// Associa o valor "null" para todas as colunas desta tabela.
        /// </summary>
        public void zerarCampos()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                foreach (Coluna cln in this.lstCln)
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

            #endregion Ações
        }

        /// <summary>
        /// Método responsável por atrelar as colunas à esta tabela. Este método é chamado na
        /// construção deste objeto para garantir a ligação das colunas com esta tabela.
        /// </summary>
        protected abstract int inicializarColunas(int intOrdem);

        private void carregarDataGridClnDirecao(DataGridViewColumn dgc, Coluna cln)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (cln.enmGrupo == Coluna.EnmGrupo.NUMERICO)
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

            #endregion Ações
        }

        private void carregarDataGridClnTamanho(DataGridViewColumn dgc, Coluna cln)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void carregarDataGridLayout(DataGridView objDataGridView)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                for (int i = 0; i < this.lstClnConsulta.Count; i++)
                {
                    this.carregarDataGridTitulo(objDataGridView.Columns[i], this.lstClnConsulta[i]);
                    this.carregarDataGridClnTamanho(objDataGridView.Columns[i], this.lstClnConsulta[i]);
                    this.carregarDataGridClnDirecao(objDataGridView.Columns[i], this.lstClnConsulta[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        private void carregarDataGridTitulo(DataGridViewColumn dgc, Coluna cln)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Retorna lista de "String" contendo o nome de todas as colunas desta tabela.
        /// </summary>
        /// <param name="booSomentePreenchidas">
        /// Caso seja "true", retorna somente as colunas que tem algum valor válido.
        /// </param>
        private List<string> getLstStrClnNome(bool booSomentePreenchidas = false)
        {
            #region Variáveis

            List<string> lstStrResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstStrResultado = new List<string>();

                foreach (Coluna cln in this.lstCln)
                {
                    if (string.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
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

            #endregion Ações

            return lstStrResultado;
        }

        /// <summary>
        /// Apelido para "getLstStrColunaNome(bool booSomentePreenchidas = false)".
        /// </summary>
        private List<string> getLstStrClnNomePreenchidas()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private List<string> getLstStrClnVisivelConsultaNome()
        {
            #region Variáveis

            List<string> lstStrResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstStrResultado = new List<string>();

                foreach (Coluna cln in this.lstClnConsulta)
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

            #endregion Ações

            return lstStrResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes das colunas desta tabela, separadas
        /// pela "string strSeparador" passada como parâmetro.
        /// </summary>
        private string getStrClnNomes(string strSeparador = ", ")
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = string.Join(strSeparador, this.getLstStrClnNome().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de nomes e valores das colunas desta tabela,
        /// separadas pela "strSeparador" passada como parâmetro. O formato é "clnNome =
        /// 'clnValor'[strSeparador]". <param name="strSeparador">Texto que vai separar os
        /// valores.</param><param name="booSomentePreenchidas">Caso seja "true", retorna somente as
        /// colunas que tem algum valor válido.</param>
        /// </summary>
        private string getStrClnNomesValores(string strSeparador = ",", bool booSomentePreenchidas = false)
        {
            #region Variáveis

            List<string> lstStrClnValor;
            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstStrClnValor = new List<string>();

                foreach (Coluna cln in this.lstCln)
                {
                    if (string.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrClnValor.Add(cln.strNomeSimplificado + "=" + cln.strValorSql);
                }

                strResultado = string.Join(strSeparador, lstStrClnValor.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        /// <summary>
        /// Apelido para "getStrColunasNomesValores(string strSeparador = ",", Boolean
        /// booSomenteCamposPreenchidos = false)".
        /// </summary>
        private string getStrClnNomesValoresPreenchidos(string strSeparador = ",")
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Retorna uma "String" formatada com a lista de valores das colunas desta tabela, separadas
        /// pela "strSeparador" passada como parâmetro. O formato é "'clnValor'[strSeparador]".
        /// <param name="strSeparador">Texto que vai separar os valores.</param><param
        /// name="booSomentePreenchidas">Caso seja "true", retorna somente as colunas que tem algum
        /// valor válido.</param>
        /// </summary>
        private string getStrClnValores(string strSeparador = ",", bool booSomentePreenchidas = false)
        {
            #region Variáveis

            List<string> lstStrClnValor;
            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstStrClnValor = new List<string>();

                foreach (Coluna cln in this.lstCln)
                {
                    if (string.IsNullOrEmpty(cln.strValor) && booSomentePreenchidas)
                    {
                        continue;
                    }

                    lstStrClnValor.Add(cln.strValorSql);
                }

                strResultado = string.Join(strSeparador, lstStrClnValor.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

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
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private string getStrClnVisiveisConsultaNomes(string strSeparador = ",")
        {
            #region Variáveis

            string strResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                strResultado = string.Join(strSeparador, this.getLstStrClnVisivelConsultaNome().ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return strResultado;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}