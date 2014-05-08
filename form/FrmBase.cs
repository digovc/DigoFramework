using System;
using System.Windows.Forms;

namespace DigoFramework.form
{
    public class FrmBase : Form
    {
        #region CONSTANTES
        #endregion

        #region ATRIBUTOS

        private static int _intIndex;
        private static int intIndex { get { return _intIndex; } set { _intIndex = value; } }

        private int _intId;
        protected int intId { get { return _intId; } set { _intId = value; } }

        #endregion

        #region CONSTRUTORES

        public FrmBase()
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.InitializeComponent();
                this.intId = ++FrmBase.intIndex;

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
        /// Carrega o título do formulário com o nome de exibição da tabela.
        /// </summary>
        protected void carregarTitulo(String strTitulo)
        {
            #region VARIÁVEIS

            String strTituloDefault = Utils.STRING_VAZIA;

            #endregion
            try
            {
                #region AÇÕES

                if (this.GetType() == typeof(FrmCadastro))
                {
                    strTituloDefault += "Cadastro";
                }

                if (this.GetType() == typeof(FrmConsulta))
                {
                    strTituloDefault += "Consulta";
                }

                strTituloDefault += String.IsNullOrEmpty(strTitulo) ? "" : " ";
                strTituloDefault += strTitulo;

                this.Text = strTituloDefault;

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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmBase
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.KeyPreview = true;
            this.Name = "FrmBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBase_KeyDown);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Método que deve ser sobescrito para interceptar os atalhos do teclado
        /// acionados.
        /// </summary>
        protected virtual void verificarAtalhoAcionado(KeyEventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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

        protected void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            #region VARIÁVEIS
            #endregion
            try
            {
                #region AÇÕES

                this.verificarAtalhoAcionado(e);

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
