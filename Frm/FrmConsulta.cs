using System;
using System.Data;
using System.Windows.Forms;
using DigoFramework.DataBase;

namespace DigoFramework.Frm
{
    public partial class FrmConsulta : FrmMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private DataBase.Tabela _tbl;

        public Tabela tbl
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _tbl = Aplicativo.i.tblSelec;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _tbl;
            }
        }

        #endregion Atributos

        #region Construtores

        public FrmConsulta()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        protected override void montarLayout()
        {
            base.montarLayout();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.ActiveControl = this.txtPesquisa;
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

        protected override void verificarAtalhoAcionado(KeyEventArgs e)
        {
            base.verificarAtalhoAcionado(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        /// <summary>
        /// Carrega os dados do "DataGrid" com os registros da tabela selecionada.
        /// </summary>
        private void carregarDataGrid()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void limparPesquisa()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                (this.dgvPrincipal.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
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

        private void pesquisar()
        {
            #region Variáveis

            string strFiltro;
            string strPesquisa;

            #endregion Variáveis

            #region Ações

            try
            {
                strPesquisa = this.txtPesquisa.Text;

                if (string.IsNullOrEmpty(strPesquisa))
                {
                    this.limparPesquisa();
                    return;
                }

                strFiltro = "[_cln_nome] like '%_pesquisa_valor%'";

                strFiltro = strFiltro.Replace("_cln_nome", this.tbl.clnNome.strNomeSimplificado);
                strFiltro = strFiltro.Replace("_pesquisa_valor", strPesquisa);

                (this.dgvPrincipal.DataSource as DataTable).DefaultView.RowFilter = strFiltro;
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

        #endregion Métodos

        #region Eventos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            #region Variáveis

            int intId;

            #endregion Variáveis

            #region Ações

            try
            {
                intId = Convert.ToInt32(this.dgvPrincipal.SelectedRows[0].Cells[this.tbl.clnChavePrimaria.strNomeSimplificado].Value);

                if (this.tbl.abrirFrmCadastro(intId) == DialogResult.Yes)
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

            #endregion Ações
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (this.tbl.abrirFrmCadastro() == DialogResult.Yes)
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

            #endregion Ações
        }

        private void FrmConsulta_Shown(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.pesquisar();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Eventos
    }
}