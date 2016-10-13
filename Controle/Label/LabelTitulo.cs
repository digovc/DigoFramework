using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Label
{
    public class LabelTitulo : LabelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.AutoSize = false;
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Bottom;
            this.Location = new Point(-1, -1);
            this.Size = new Size(20, 20);
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}