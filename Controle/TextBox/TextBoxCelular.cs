using System;
using System.ComponentModel;

namespace DigoFramework.Controle.Texto
{
    public class TextBoxCelular : TexBoxTelefone
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booPadraoAntigo;

        public bool booPadraoAntigo
        {
            get
            {
                return _booPadraoAntigo;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

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

                #endregion Ações
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

            #endregion Ações
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}