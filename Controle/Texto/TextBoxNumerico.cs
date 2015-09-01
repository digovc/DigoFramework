using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace DigoFramework.Controle.Texto
{
    public class TextBoxNumerico : TextBoxMain
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private decimal _decValor;
        private int _intValor;
        private string _strValor;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal decValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (string.IsNullOrEmpty(this.strValor))
                    {
                        return 0;
                    }

                    _decValor = Convert.ToDecimal(this.strValor);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _decValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _decValor = value;

                    this.strValor = _decValor.ToString();
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
        public int intValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = (int)this.decValor;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _intValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _intValor = value;

                    this.decValor = _intValor;
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

        [DefaultValue("")]
        public string strValor
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strValor = this.Text;

                    foreach (char chr in this.Mask)
                    {
                        if (Char.IsDigit(chr))
                        {
                            continue;
                        }

                        _strValor = _strValor.Replace(chr.ToString(), string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strValor;
            }

            set
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    _strValor = value;

                    this.Text = !string.IsNullOrEmpty(_strValor) ? _strValor : string.Empty;
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new HorizontalAlignment TextAlign
        {
            get
            {
                return base.TextAlign;
            }

            protected set
            {
                base.TextAlign = value;
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
                this.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            #region Variáveis

            NumberFormatInfo objNumberFormatInfo;
            string strDecimalSeparador;
            string strGrupoSeparador;
            string strKeyInput;
            string strSinalNegativo;

            #endregion Variáveis

            #region Ações

            try
            {
                objNumberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
                strDecimalSeparador = objNumberFormatInfo.NumberDecimalSeparator;
                strGrupoSeparador = objNumberFormatInfo.NumberGroupSeparator;
                strSinalNegativo = objNumberFormatInfo.NegativeSign;

                if (strGrupoSeparador == ((char)160).ToString())
                {
                    strGrupoSeparador = " ";
                }

                strKeyInput = e.KeyChar.ToString();

                if (Char.IsDigit(e.KeyChar))
                {
                    // Digits are OK
                }
                else if (strKeyInput.Equals(strDecimalSeparador) || strKeyInput.Equals(strGrupoSeparador) || strKeyInput.Equals(strSinalNegativo))
                {
                    // Decimal separator is OK
                }
                else if (e.KeyChar == '\b')
                {
                    // Backspace key is OK
                }
                else
                {
                    // Consume this invalid key and beep
                    e.Handled = true;
                }
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