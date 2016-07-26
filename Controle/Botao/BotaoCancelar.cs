using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public class BotaoCancelar : BotaoComando
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image Image
        {
            get
            {
                return base.Image;
            }

            protected set
            {
                base.Image = value;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            protected set
            {
                base.Text = value;
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
                this.BackColor = Color.FromArgb(225, 225, 225);
                this.Text = "Cancelar";

                this.Click += this.click;
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

        private void click()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                ((Form)this.TopLevelControl).Close();
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

        private void click(object objSender, EventArgs objEventArgs)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.click();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Eventos
    }
}