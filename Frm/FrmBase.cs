using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public class FrmBase : Form
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        protected ToolTip ttpDica;

        private static int _intFrmIdStatic;
        private bool _booSairEsc = true;
        private int _intFrmId;

        private IContainer components;

        protected bool booSairEsc
        {
            get
            {
                return _booSairEsc;
            }

            set
            {
                _booSairEsc = value;
            }
        }

        protected int intFrmId
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_intFrmId > 0)
                    {
                        return _intFrmId;
                    }

                    _intFrmId = FrmBase.intFrmIdStatic++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _intFrmId;
            }
        }

        private static int intFrmIdStatic
        {
            get
            {
                return _intFrmIdStatic;
            }

            set
            {
                _intFrmIdStatic = value;
            }
        }

        #endregion Atributos

        #region Construtores

        protected FrmBase()
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

        /// <summary>
        /// Carrega o título do formulário com o nome de exibição da tabela.
        /// </summary>
        protected void carregarTitulo(string strTitulo)
        {
            #region Variáveis

            string strTituloDefault = string.Empty;

            #endregion Variáveis

            #region Ações

            try
            {
                strTituloDefault += string.IsNullOrEmpty(strTitulo) ? "" : " ";
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

            #endregion Ações
        }

        protected virtual void inicializar()
        {
        }

        /// <summary>
        /// Método chamado dentro do "load" do formulário para configurar componentes e outras
        /// alterações de layout.
        /// </summary>
        protected virtual void montarLayout()
        {
        }

        protected virtual void setEventos()
        {
        }

        /// <summary>
        /// Método que deve ser sobescrito para interceptar os atalhos do teclado acionados.
        /// </summary>
        protected virtual void verificarAtalhoAcionado(KeyEventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (e.KeyCode == Keys.Escape && this.booSairEsc)
                {
                    this.UseWaitCursor = true;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.UseWaitCursor = false;
            }

            #endregion Ações
        }

        private void iniciar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.montarLayout();
                this.setEventos();
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

        private void InitializeComponent()
        {
            this.components = new Container();
            this.ttpDica = new ToolTip(this.components);
            this.SuspendLayout();
            // FrmBase
            this.ClientSize = new Size(284, 262);
            this.Font = new Font("Tahoma", 8.25F);
            this.KeyPreview = true;
            this.Name = "FrmBase";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.ResumeLayout(false);
        }

        #endregion Métodos

        #region Eventos

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.iniciar();
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