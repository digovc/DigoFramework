using System;
using System.ComponentModel;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public abstract class TabDocumento : TabMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            protected set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    base.Text = value;

                    if (String.IsNullOrEmpty(base.Text))
                    {
                        return;
                    }

                    base.Text = base.Text + " (" + this.getStrDocumentoTipo() + ")";
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

        #endregion Construtores

        #region Métodos

        public void fechar()
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
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        protected abstract string getStrDocumentoTipo();

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.Padding = new System.Windows.Forms.Padding(5);
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

        #endregion Eventos
    }
}