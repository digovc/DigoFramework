using System;
using System.Collections.Generic;
using DigoFramework.Controle.TextBox.Code.Autocomplete;
using DigoFramework.Controle.TextBox.Code.Style;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.TextBox.Code
{
    public partial class TextBoxCodeLog : TextBoxCodeBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private List<Log> _lstLog;
        private LogSyntaxHighlighter _objLogSyntaxHighlighter;

        private List<Log> lstLog
        {
            get
            {
                if (_lstLog != null)
                {
                    return _lstLog;
                }

                _lstLog = new List<Log>();

                return _lstLog;
            }
        }

        private LogSyntaxHighlighter objLogSyntaxHighlighter
        {
            get
            {
                if (_objLogSyntaxHighlighter != null)
                {
                    return _objLogSyntaxHighlighter;
                }

                _objLogSyntaxHighlighter = new LogSyntaxHighlighter();

                return _objLogSyntaxHighlighter;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void adicionar(Log log)
        {
            if (log == null)
            {
                return;
            }

            this.Text += log.ToString();
            this.Text += Environment.NewLine;

            this.lstLog.Add(log);
        }

        protected override void calcularAutoCompleteItemPropriedade(List<AutocompleteItem> lstObjAutocompleteItem)
        {
            return;
        }

        protected override Snippet getObjAutocompleteItemSnippetIf()
        {
            return null;
        }

        protected override Snippet getObjAutocompleteItemSnippetIfElse()
        {
            return null;
        }

        protected override void inicializar()
        {
            base.inicializar();

            this.ReadOnly = true;
            this.SyntaxHighlighter = this.objLogSyntaxHighlighter;

            this.Click += this.click;
        }

        private void click(EventArgs e)
        {
            if (e == null)
            {
                return;
            }

            new Erro(e.ToString());
        }

        #endregion Métodos

        #region Eventos

        private void click(object sender, EventArgs e)
        {
            try
            {
                this.click(e);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}