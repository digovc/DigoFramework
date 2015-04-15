﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Label
{
    public class LabelTitulo : LabelMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

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

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}