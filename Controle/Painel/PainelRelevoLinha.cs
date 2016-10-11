using System;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelRelevoLinha : PainelBase
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

            this.Dock = DockStyle.Bottom;
            this.Padding = new Padding(0);
            this.Size = new System.Drawing.Size(50, 40);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}