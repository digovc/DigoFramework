using System;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public class PainelConteudo : PainelMain
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
                this.AutoScroll = true;
                this.BackColor = Color.White;
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Dock = System.Windows.Forms.DockStyle.Fill;
                this.Padding = new System.Windows.Forms.Padding(5);
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