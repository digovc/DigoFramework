using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public partial class BotaoCancelar : BotaoComando
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }

            protected set
            {
                base.Image = value;
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

        public BotaoCancelar()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.BackColor = Color.FromArgb(225, 225, 225);
            this.Text = "Cancelar";

            this.Click += this.click;
        }

        private void click()
        {
            ((Form)this.TopLevelControl).Close();
        }

        #endregion Métodos

        #region Eventos

        private void click(object objSender, EventArgs objEventArgs)
        {
            this.click();
        }

        #endregion Eventos
    }
}