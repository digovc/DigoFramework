﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace DigoFramework.Controle.Texto
{
    public class TextBoxNumerico : TextBoxBase
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
                if (string.IsNullOrEmpty(this.strValor))
                {
                    return 0;
                }

                _decValor = Convert.ToDecimal(this.strValor);

                return _decValor;
            }

            set
            {
                _decValor = value;

                this.strValor = _decValor.ToString();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int intValor
        {
            get
            {
                _intValor = (int)this.decValor;

                return _intValor;
            }

            set
            {
                _intValor = value;

                this.decValor = _intValor;
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
                _strValor = this.Text;

                foreach (char chr in this.Mask)
                {
                    if (char.IsDigit(chr))
                    {
                        continue;
                    }

                    _strValor = _strValor.Replace(chr.ToString(), string.Empty);
                }

                return _strValor;
            }

            set
            {
                _strValor = value;

                this.Text = !string.IsNullOrEmpty(_strValor) ? _strValor : string.Empty;
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

            this.TextAlign = HorizontalAlignment.Right;
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo objNumberFormatInfo;
            string strDecimalSeparador;
            string strGrupoSeparador;
            string strKeyInput;
            string strSinalNegativo;

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

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}