using System;
using System.ComponentModel;

namespace DigoFramework.Controle.DockPanel.Tab
{
    public abstract class TabDocumento : TabBase
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
                base.Text = value;

                if (string.IsNullOrEmpty(base.Text))
                {
                    return;
                }

                base.Text = base.Text + " (" + this.getStrDocumentoTipo() + ")";
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void fechar()
        {
            this.Close();
        }

        protected abstract string getStrDocumentoTipo();

        protected override void inicializar()
        {
            base.inicializar();

            this.Padding = new System.Windows.Forms.Padding(5);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}