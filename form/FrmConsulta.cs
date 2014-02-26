using DigoFramework.database;
using System;
using System.Windows.Forms;


namespace DigoFramework.form
{
    public partial class FrmConsulta : FrmBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private DbTabela _tbl = null;
        public DbTabela tbl
        {
            get
            {
                #region VARIÁVEIS
                #endregion
                try
                {
                    #region AÇÕES

                    _tbl = Aplicativo.i.tblSelecionada;

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                return _tbl;
            }
        }

        #endregion

        #region CONSTRUTORES

        public FrmConsulta()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            InitializeComponent();

            #endregion
        }

        #endregion

        #region MÉTODOS

        /// <summary>
        /// Carrega os dados do "DataGrid" com os registros da
        /// tabela selecionada.
        /// </summary>
        private void carregarDataGrid()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.tbl.carregarDataGrid(this.dgvPrincipal);

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

        protected override void verificarAtalhoAcionado(KeyEventArgs e)
        {

            base.verificarAtalhoAcionado(e);

            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                if (e.Control && e.KeyCode == Keys.N)
                {
                    this.btnNovo_Click(this, e);
                }

                if (e.Control && e.KeyCode == Keys.E)
                {
                    this.btnEditar_Click(this, e);
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

        #region EVENTOS

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.Close();

            #endregion
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            int intId;

            #endregion
            try
            {
                #region AÇÕES

                intId = Convert.ToInt32(this.dgvPrincipal.SelectedRows[0].Cells[this.tbl.clnChavePrimaria.strNomeSimplificado].Value);

                if (this.tbl.abrirFrmCadastro(intId) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.carregarDataGrid();
                }

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.Fatal);
            }
            finally
            {
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES


                if (this.tbl.abrirFrmCadastro() == System.Windows.Forms.DialogResult.Yes)
                {
                    this.carregarDataGrid();
                }

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmConsulta_Shown(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.carregarDataGrid();
                this.carregarTitulo(this.tbl.strNomeExibicao);

                #endregion
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.Fatal);
            }
            finally
            {
            }
        }

        #endregion
    }
}