using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Painel
{
    public class PainelRelevo : PainelBase
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private int _intLinhaQtd;

        [DefaultValue("1")]
        public int intLinhaQtd
        {
            get
            {
                return _intLinhaQtd;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

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
                this.BackColor = Color.FromArgb(245, 245, 245);
                this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.Dock = System.Windows.Forms.DockStyle.Bottom;
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

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        #endregion EVENTOS
    }
}