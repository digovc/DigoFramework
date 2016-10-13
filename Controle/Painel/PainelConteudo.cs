using System;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public partial class PainelConteudo : PainelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        #endregion Atributos

        #region Construtores

        public PainelConteudo()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.AutoScroll = true;
            this.BackColor = Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Padding = new System.Windows.Forms.Padding(5);
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}