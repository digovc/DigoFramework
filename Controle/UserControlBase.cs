using System;
using System.Windows.Forms;

namespace DigoFramework.Controle
{
    public partial class UserControlBase : UserControl
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public UserControlBase()
        {
            this.InitializeComponent();

            this.iniciar();
        }

        #endregion Construtores

        #region Métodos

        private void iniciar()
        {
            this.inicializar();
        }

        protected virtual void inicializar()
        {            
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}