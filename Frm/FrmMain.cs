using System;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public class FrmMain : Form
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private static int _intIndex;
        protected ToolTip ttp;
        private System.ComponentModel.IContainer components;
        private int _intId;

        protected int intId
        {
            get
            {
                return _intId;
            }

            set
            {
                _intId = value;
            }
        }

        private static int intIndex
        {
            get
            {
                return _intIndex;
            }

            set
            {
                _intIndex = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public FrmMain()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.InitializeComponent();
                this.intId = ++FrmMain.intIndex;
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
        /// Carrega o título do formulário com o nome de exibição da tabela.
        /// </summary>
        protected void carregarTitulo(string strTitulo)
        {
            #region VARIÁVEIS

            string strTituloDefault = Utils.STR_VAZIA;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
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
        /// Método chamado dentro do "load" do formulário para configurar componentes e outras
        /// alterações de layout.
        /// </summary>
        protected virtual void montarLayout()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
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
        /// Método que deve ser sobescrito para interceptar os atalhos do teclado acionados.
        /// </summary>
        protected virtual void verificarAtalhoAcionado(KeyEventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ttp = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // FrmMain
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBase_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion MÉTODOS

        #region EVENTOS

        protected void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.verificarAtalhoAcionado(e);
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

        private void FrmMain_Load(object sender, EventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.montarLayout();
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