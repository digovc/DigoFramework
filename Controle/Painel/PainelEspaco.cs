using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelEspaco : PainelMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            set
            {
                base.Dock = value;
            }
        }

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
                this.Size = new Size(5, 5);
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