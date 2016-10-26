using System;
using System.Windows.Forms;

namespace DigoFramework.Controle.CheckBox
{
    public partial class CheckBoxGeral : CheckBoxBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public CheckBoxGeral()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = DockStyle.Fill;
            this.RightToLeft = RightToLeft.Yes;
            this.Text = "";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}