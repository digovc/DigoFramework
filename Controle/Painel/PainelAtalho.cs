using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public partial class PainelAtalho : PainelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public PainelAtalho()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = System.Windows.Forms.DockStyle.Top;
            //this.Padding = new System.Windows.Forms.Padding(0);
            this.Size = new Size(100, 25);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}