using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Texto
{
    public abstract class TextBoxBase : MaskedTextBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Color _BackColorNormal;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            protected set
            {
                base.Dock = value;
            }
        }

        private Color BackColorNormal
        {
            get
            {
                return _BackColorNormal;
            }

            set
            {
                _BackColorNormal = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public TextBoxBase()
        {
            this.inicializar();
        }

        #endregion Construtores

        #region Métodos

        protected virtual void inicializar()
        {
            this.Dock = DockStyle.Fill;
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            this.BackColorNormal = this.BackColor;
            this.BackColor = Color.FromArgb(227, 235, 253);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            this.BackColor = this.BackColorNormal;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}