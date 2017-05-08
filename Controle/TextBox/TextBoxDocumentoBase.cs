using System.ComponentModel;
using System.Windows.Forms;

namespace DigoFramework.Controle.TextBox
{
    public partial class TextBoxDocumentoBase : TextBoxAlfanumerico
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new HorizontalAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }

            protected set
            {
                base.TextAlign = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public TextBoxDocumentoBase()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.TextAlign = HorizontalAlignment.Center;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}