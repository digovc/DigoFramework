using System;
using DigoFramework.DataBase;

namespace DigoFramework.Formulário
{
    public partial class FrmCadastro : FrmBase
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private DbTabela _objTabelaPrincipal = null;
        public DbTabela objDbTabelaPrincipal { get { return _objTabelaPrincipal; } set { _objTabelaPrincipal = value; } }
        public DbTabela tbl { get { return objDbTabelaPrincipal; } set { objDbTabelaPrincipal = value; } }

        #endregion

        #region CONSTRUTORES

        public FrmCadastro()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            InitializeComponent();

            #endregion
        }

        #endregion

        #region MÉTODOS
        #endregion
        
        #region EVENTOS

        private void btnFechar_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.Close();
            
            #endregion
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.objDbTabelaPrincipal.acaoAbrirFormEdicao(this, null);

                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmCadastro_Shown(object sender, EventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            //FrmEspera frmTemp = Program.objAplicativoGetemp.mostraFormularioEspera("Tabela sendo carregada com registro.");
            this.objDbTabelaPrincipal.carregaDataGrid(this.dgvPrincipal);
            //frmTemp.booConcluido = true;

            #endregion
        }

        #endregion
    }
}