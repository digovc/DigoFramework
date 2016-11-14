﻿using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.GroupBox
{
    public partial class GroupBoxCampo : GroupBoxBase
    {
        #region Constantes

        public enum EnmTamanho
        {
            GRANDE,
            MEDIO,
            MINIMO,
            PEQUENO,
            X_GRANDE,
            XX_GRANDE,
            XXX_GRANDE,
        }

        #endregion Constantes

        #region Atributos

        private EnmTamanho _enmTamanho;

        [DefaultValue(typeof(EnmTamanho), "GRANDE")]
        public EnmTamanho enmTamanho
        {
            get
            {
                return _enmTamanho;
            }

            set
            {
                _enmTamanho = value;

                switch (_enmTamanho)
                {
                    case EnmTamanho.MINIMO:
                        this.Size = new Size(50, 40);
                        return;

                    case EnmTamanho.MEDIO:
                        this.Size = new Size(150, 40);
                        return;

                    case EnmTamanho.GRANDE:
                        this.Size = new Size(250, 40);
                        return;

                    case EnmTamanho.X_GRANDE:
                        this.Size = new Size(300, 40);
                        return;

                    case EnmTamanho.XX_GRANDE:
                        this.Size = new Size(500, 40);
                        return;

                    case EnmTamanho.XXX_GRANDE:
                        this.Size = new Size(800, 40);
                        return;

                    default:
                        this.Size = new Size(100, 40);
                        return;
                }
            }
        }

        #endregion Atributos

        #region Construtores

        public GroupBoxCampo()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.Dock = DockStyle.Left;
            this.enmTamanho = EnmTamanho.GRANDE;
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}