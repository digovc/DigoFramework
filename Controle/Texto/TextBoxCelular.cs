using System;
using System.ComponentModel;

namespace DigoFramework.Controle.Texto
{
    public class TextBoxCelular : TexBoxTelefone
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

        private bool _booPadraoAntigo;

        public bool booPadraoAntigo
        {
            get
            {
                return _booPadraoAntigo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booPadraoAntigo = value;

                    if (_booPadraoAntigo)
                    {
                        this.Mask = "(00) 0000 0000";
                        return;
                    }

                    this.Mask = "(00) 0 0000 0000";
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

        protected virtual void inicializar()
        {
            base.inicializar();

            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.Mask = "(00) 0 0000 0000";
                this.Text = "(  )            ";
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