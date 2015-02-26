using System;
using System.Windows.Forms;

namespace DigoFramework.Controle.CheckBox
{
    public class CheckBoxGeral : CheckBoxBase
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        #endregion CONSTRUTORES

        #region MÉTODOS

        protected override void inicializar()
        {
            base.inicializar();

            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.Dock = DockStyle.Fill;
                this.RightToLeft = RightToLeft.Yes;
                this.Text = "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}