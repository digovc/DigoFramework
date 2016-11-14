using System.Drawing;
using System.Windows.Forms;
using DigoFramework.Controle.Painel;

namespace DigoFramework.Controle.Diverso
{
    public partial class Linha : PainelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public Linha()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.BackColor = Color.Gray;
            this.Dock = DockStyle.Bottom;
            this.Size = new Size(1, 1);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}