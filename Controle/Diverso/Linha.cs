using DigoFramework.Controle.Painel;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Diverso
{
    public class Linha : PainelMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

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
                this.BackColor = Color.Gray;
                this.Dock = DockStyle.Bottom;
                this.Size = new Size(1, 1);
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