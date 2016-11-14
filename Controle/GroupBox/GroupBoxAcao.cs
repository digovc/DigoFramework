using System.Windows.Forms;

namespace DigoFramework.Controle.GroupBox
{
    public partial class GroupBoxAcao : GroupBoxBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public GroupBoxAcao()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = DockStyle.Fill;
            this.Padding = new Padding(0, 0, 0, 2);
            this.Text = "";
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}