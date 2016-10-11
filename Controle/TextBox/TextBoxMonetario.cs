using System;
using System.ComponentModel;

namespace DigoFramework.Controle.Texto
{
    public class TextBoxMonetario : TextBoxNumerico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Mask
        {
            get
            {
                return base.Mask;
            }

            protected set
            {
                base.Mask = value;
            }
        }

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
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Mask = "R$ 9999999,999.00";
            this.Text = "(  )          ";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}