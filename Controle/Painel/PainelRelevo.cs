using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public partial class PainelRelevo : PainelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private EnmPosicao _enmPosicao = EnmPosicao.INFERIOR;
        private int _intLinhaQtd;

        [DefaultValue(EnmPosicao.INFERIOR)]
        [Description("Indica se o painel se alinhará na parte superior ou inferior.")]
        public EnmPosicao enmPosicao
        {
            get
            {
                return _enmPosicao;
            }

            set
            {
                if (_enmPosicao == value)
                {
                    return;
                }

                _enmPosicao = value;

                this.setEnmPosicao(_enmPosicao);
            }
        }

        [DefaultValue("1")]
        public int intLinhaQtd
        {
            get
            {
                return _intLinhaQtd;
            }

            set
            {
                _intLinhaQtd = value;

                this.Size = new Size(50, _intLinhaQtd * 40 + 10 + _intLinhaQtd);
            }
        }

        #endregion Atributos

        #region Construtores

        public PainelRelevo()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.BackColor = Color.FromArgb(245, 245, 245);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Bottom;
            this.intLinhaQtd = 1;
            this.Padding = new Padding(5);
            this.Size = new Size(50, 50);
        }

        private void setEnmPosicao(EnmPosicao enmPosicao)
        {
            this.Dock = (EnmPosicao.INFERIOR.Equals(enmPosicao)) ? DockStyle.Bottom : DockStyle.Top;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}