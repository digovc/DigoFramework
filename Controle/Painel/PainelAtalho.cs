using System;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public class PainelAtalho : PainelMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.Dock = System.Windows.Forms.DockStyle.Top;
                this.Padding = new System.Windows.Forms.Padding(5);
                this.Size = new Size(100, 40);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}