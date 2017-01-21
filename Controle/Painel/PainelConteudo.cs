using System.ComponentModel;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public partial class PainelConteudo : PainelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booPadding = true;

        [DefaultValue(true)]
        public bool booPadding
        {
            get
            {
                return _booPadding;
            }

            set
            {
                _booPadding = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public PainelConteudo()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.AutoScroll = true;
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Padding = this.booPadding ? (new System.Windows.Forms.Padding(5)) : new System.Windows.Forms.Padding(0);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}