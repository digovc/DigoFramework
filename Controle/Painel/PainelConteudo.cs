using System;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public class PainelConteudo : PainelMain
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

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}