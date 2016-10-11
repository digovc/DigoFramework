using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Texto
{
    public abstract class TextBoxBase : MaskedTextBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

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

        #endregion Atributos

        #region Construtores

        public TextBoxBase()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Construtores

        #region Métodos

        protected virtual void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);

            #region Variáveis

            #endregion Variáveis

            #region Ações

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

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}