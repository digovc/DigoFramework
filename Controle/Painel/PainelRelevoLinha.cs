using System;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelRelevoLinha : PainelMain
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
                this.Dock = DockStyle.Bottom;
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

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}