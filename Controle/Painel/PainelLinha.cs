using System;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelLinha : PainelBase
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
                this.Dock = System.Windows.Forms.DockStyle.Bottom;
                this.Padding = new Padding(0);
                this.Size = new System.Drawing.Size(50, 40);
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