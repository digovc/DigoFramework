using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Texto
{
    public abstract class TextBoxMain : MaskedTextBox
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private Color _BackColorNormal;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DockStyle Dock
        {
            get
            {
                return base.Dock;
            }

            protected set
            {
                base.Dock = value;
            }
        }

        private Color BackColorNormal
        {
            get
            {
                return _BackColorNormal;
            }

            set
            {
                _BackColorNormal = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public TextBoxMain()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.inicializar();
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

        #endregion CONSTRUTORES

        #region MÉTODOS

        protected virtual void inicializar()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.Dock = DockStyle.Fill;
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

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.BackColorNormal = this.BackColor;
                this.BackColor = Color.FromArgb(227, 235, 253);
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

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.BackColor = this.BackColorNormal;
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