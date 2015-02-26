using System;
using System.ComponentModel;

namespace DigoFramework.Controle.Texto
{
    public class TextBoxDocCnpj : TextBoxDocBase
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new string Mask
        {
            get
            {
                return base.Mask;
            }

            protected set
            {
                base.Mask = value;
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
                this.Mask = "00.000.000/0000-00";
                this.Text = "  ,   ,   /    -  ";
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