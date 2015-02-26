using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DigoFramework.Controle.Botao
{
    public class BotaoCancelar : BotaoComando
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

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

            #endregion AÇÕES
        }

        private void click()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

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

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        private void click(object objSender, EventArgs objEventArgs)
        {
            #region VARIÁVEIS
            #endregion VARIÁVEIS

            #region AÇÕES
            try
            {
                this.click();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }
            #endregion AÇÕES
        }

        #endregion EVENTOS
    }
}