using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelRelevo : PainelBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private EnmPosicao _enmPosicao = EnmPosicao.INFERIOR;
        private int _intLinhaQtd;

        [DefaultValue(EnmPosicao.INFERIOR)]
        [Description("Indica se o painel se alinhará na parte superior ou inferior.")]
        public EnmPosicao enmPosicao
        {
            get
            {
                return _enmPosicao;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _enmPosicao = value;

                    this.atualizarEnmPosicao();
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

        [DefaultValue("1")]
        public int intLinhaQtd
        {
            get
            {
                return _intLinhaQtd;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intLinhaQtd = value;

                    this.Size = new Size(50, _intLinhaQtd * 40 + 10 + _intLinhaQtd);
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
                this.BackColor = Color.FromArgb(245, 245, 245);
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Dock = DockStyle.Bottom;
                this.intLinhaQtd = 1;
                this.Padding = new Padding(5);
                this.Size = new Size(50, 50);
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

        private void atualizarEnmPosicao()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.Dock = (EnmPosicao.INFERIOR.Equals(this.enmPosicao)) ? DockStyle.Bottom : DockStyle.Top;
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