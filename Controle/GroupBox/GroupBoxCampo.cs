using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.GroupBox
{
    public class GroupBoxCampo : GroupBoxBase
    {
        #region CONSTANTES

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

        #endregion CONSTANTES

        #region ATRIBUTOS

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
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
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
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
                this.Dock = DockStyle.Left;
                this.enmTamanho = EnmTamanho.GRANDE;
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