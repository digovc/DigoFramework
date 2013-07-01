using System;
using System.Windows.Forms;

namespace DigoFramework
{
    public partial class FrmCadastro : Form
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private DbTabela _objTabelaPrincipal = null;
        public DbTabela objTabelaPrincipal { get { return _objTabelaPrincipal; } set { _objTabelaPrincipal = value; } }

        #endregion

        #region CONSTRUTORES

        public FrmCadastro(DbTabela objTabelaPrincipal)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            this.objTabelaPrincipal = objTabelaPrincipal;
            this.Text = "Cadastro de " + this.objTabelaPrincipal.strNome;
            InitializeComponent();

            #endregion
        }

        #endregion

        #region MÉTODOS

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}