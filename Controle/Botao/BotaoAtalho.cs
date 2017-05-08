using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public partial class BotaoAtalho : BotaoBase
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

        public BotaoAtalho()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Dock = DockStyle.Left;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = FlatStyle.Flat;
            this.Size = new Size(25, 25);
            this.Text = string.Empty;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}