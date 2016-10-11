using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Label
{
    public class LabelTitulo : LabelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
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
                this.AutoSize = false;
                this.BackColor = System.Drawing.Color.White;
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Dock = DockStyle.Bottom;
                this.Location = new Point(-1, -1);
                this.Size = new Size(20, 20);
                this.TextAlign = ContentAlignment.MiddleCenter;
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