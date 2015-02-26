using System;
using System.Drawing;

namespace DigoFramework.Controle.Painel
{
    public abstract class PainelEspacoBase : PainelBase
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
                this.Size = new Size(5, 5);
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