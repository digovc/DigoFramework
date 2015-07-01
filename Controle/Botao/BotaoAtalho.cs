using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public class BotaoAtalho : BotaoMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            protected set
            {
                base.Text = value;
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
                this.BackgroundImageLayout = ImageLayout.Stretch;
                this.Dock = DockStyle.Left;
                this.FlatAppearance.BorderSize = 0;
                this.FlatStyle = FlatStyle.Flat;
                this.Size = new Size(30, 30);
                this.Text = string.Empty;
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