using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework.Controle.Texto.Code.Autocomplete;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code
{
    public abstract class TextBoxCodeBase : FastColoredTextBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private AutocompleteMenu _ctrAutoComplete;

        private AutocompleteMenu ctrAutoComplete
        {
            get
            {
                if (_ctrAutoComplete != null)
                {
                    return _ctrAutoComplete;
                }

                _ctrAutoComplete = new AutocompleteMenu(this);

                _ctrAutoComplete.BackColor = Color.DarkGray;
                _ctrAutoComplete.ForeColor = Color.White;
                _ctrAutoComplete.Items.MaximumSize = new System.Drawing.Size(200, 300);
                _ctrAutoComplete.Items.Width = 200;
                _ctrAutoComplete.MinFragmentLength = 5;
                _ctrAutoComplete.SelectedColor = Color.DarkCyan;

                return _ctrAutoComplete;
            }
        }

        #endregion Atributos

        #region Construtores

        public TextBoxCodeBase()
        {
            this.inicializar();
            this.montarLayout();
        }

        #endregion Construtores

        #region Métodos

        protected abstract void calcularAutoCompleteItemPropriedade(List<AutocompleteItem> lstObjAutocompleteItem);

        protected virtual void calcularAutoCompleteItemSnippet(List<AutocompleteItem> lstResultado)
        {
            if (lstResultado == null)
            {
                return;
            }

            lstResultado.Add(this.getObjAutocompleteItemSnippetIf());
            lstResultado.Add(this.getObjAutocompleteItemSnippetIfElse());
        }

        protected abstract Snippet getObjAutocompleteItemSnippetIf();

        protected abstract Snippet getObjAutocompleteItemSnippetIfElse();

        protected virtual void inicializar()
        {
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Dock = DockStyle.Fill;

            this.KeyDown += this.onKeyDown;
        }

        protected virtual void montarLayout()
        {
        }

        private List<AutocompleteItem> calcularAutoCompleteItem()
        {
            List<AutocompleteItem> lstResultado;

            lstResultado = new List<AutocompleteItem>();

            this.calcularAutoCompleteItemSnippet(lstResultado);
            this.calcularAutoCompleteItemPropriedade(lstResultado);

            return lstResultado;
        }

        private void onKeyDown(KeyEventArgs arg)
        {
            if (arg == null)
            {
                return;
            }

            if (arg.KeyData == (Keys.Control | Keys.Space))
            {
                this.ctrAutoComplete.Items.SetAutocompleteItems(this.calcularAutoCompleteItem());
                this.ctrAutoComplete.Show(true);
                return;
            }
        }

        #endregion Métodos

        #region Eventos

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                this.onKeyDown(e);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.EnmTipo.ERRO);
            }
        }

        #endregion Eventos
    }
}