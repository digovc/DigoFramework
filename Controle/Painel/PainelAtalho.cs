using System;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public class PainelAtalho : PainelBase
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

            this.Dock = System.Windows.Forms.DockStyle.Top;
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new Size(100, 40);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}