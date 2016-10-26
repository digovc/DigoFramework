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
        }

        #endregion Construtores

        #region Métodos

        protected virtual void inicializar()
        {
        }

        protected virtual void setEventos()
        {
        }

        private void iniciar()
        {
            this.inicializar();
            this.setEventos();
        }

        #endregion Métodos

        #region Eventos

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            try
            {
                this.SuspendLayout();

                this.iniciar();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
            finally
            {
                this.ResumeLayout();
            }
        }

        #endregion Eventos
    }
}