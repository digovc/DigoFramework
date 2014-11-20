using DigoFramework.DataBase;
using System;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmConsulta : FrmMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private DbTabela _tbl;

        public DbTabela tbl
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _tbl = Aplicativo.i.tblSelecionada;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _tbl;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public FrmConsulta()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.InitializeComponent();
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

        protected override void verificarAtalhoAcionado(KeyEventArgs e)
        {
            base.verificarAtalhoAcionado(e);

            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (e.Control && e.KeyCode == Keys.N)
                {
                    this.btnNovo_Click(this, e);
                }

                if (e.Control && e.KeyCode == Keys.E)
                {
                    this.btnEditar_Click(this, e);
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
        /// Carrega os dados do "DataGrid" com os registros da tabela selecionada.
        /// </summary>
        private void carregarDataGrid()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.tbl.carregarDataGrid(this.dgvPrincipal);
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

        #endregion MÉTODOS

        #region EVENTOS

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            int intId;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                intId = Convert.ToInt32(this.dgvPrincipal.SelectedRows[0].Cells[this.tbl.clnChavePrimaria.strNomeSimplificado].Value);

                if (this.tbl.abrirFrmCadastro(intId) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.carregarDataGrid();
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (this.tbl.abrirFrmCadastro() == System.Windows.Forms.DialogResult.Yes)
                {
                    this.carregarDataGrid();
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        private void FrmConsulta_Shown(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.carregarDataGrid();
                this.carregarTitulo(this.tbl.strNomeExibicao);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion EVENTOS
    }
}