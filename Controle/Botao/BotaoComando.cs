using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public class BotaoComando : BotaoMain
    {
        #region Constantes

        public enum EnmTamanho
        {
            PEQUENO,
            MEDIO,
            GRANDE,
        }

        #endregion Constantes

        #region Atributos

        private EnmTamanho _enmTamanho;

        public EnmTamanho enmTamanho
        {
            get
            {
                return _enmTamanho;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _enmTamanho = value;

                    switch (_enmTamanho)
                    {
                        case EnmTamanho.MEDIO:
                            this.Size = new Size(125, 40);
                            return;

                        case EnmTamanho.GRANDE:
                            this.Size = new Size(175, 40);
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

                #endregion Ações
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
                this.Dock = DockStyle.Right;
                this.Size = new Size(100, 40);
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