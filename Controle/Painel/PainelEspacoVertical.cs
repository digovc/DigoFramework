using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelEspacoVertical : PainelEspacoBase
    {
        #region CONSTANTES

        public enum EnmLado
        {
            DIREITA,
            ESQUERDA,
        }

        #endregion CONSTANTES

        #region ATRIBUTOS

        private EnmLado _enmLado;

        [DefaultValue(typeof(EnmLado), "DIREITA")]
        public EnmLado enmLado
        {
            get
            {
                return _enmLado;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _enmLado = value;

                    this.Dock = _enmLado == EnmLado.DIREITA ? DockStyle.Right : DockStyle.Left;
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
                this.enmLado = EnmLado.DIREITA;
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