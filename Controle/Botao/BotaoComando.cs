using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public class BotaoComando : BotaoMain
    {
        #region CONSTANTES

        public enum EnmTamanho
        {
            PEQUENO,
            MEDIO,
            GRANDE,
        }

        #endregion CONSTANTES

        #region ATRIBUTOS

        private EnmTamanho _enmTamanho;

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

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}