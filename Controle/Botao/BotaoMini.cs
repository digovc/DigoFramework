using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    [ToolboxBitmap(typeof(Button))]
    public class BotaoMini : BotaoBase
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
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = DockStyle.Right;
            this.Size = new Size(25, 25);
            this.Text = "";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}