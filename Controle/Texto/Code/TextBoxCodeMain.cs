using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DigoFramework.Controle.Texto.Code.Autocomplete;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code
{
    public abstract class TextBoxCodeMain : FastColoredTextBox
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private AutocompleteMenu _ctrAutoComplete;

        private AutocompleteMenu ctrAutoComplete
        {
            get
            {
                #region Variáveis

                List<string> lstStr;

                #endregion Variáveis

                #region Ações

                try
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
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _ctrAutoComplete;
            }
        }

        #endregion Atributos

        #region Construtores

        public TextBoxCodeMain()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.inicializar();
                this.montarLayout();
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

        protected abstract void calcularAutoCompleteItemPropriedade(List<AutocompleteItem> lstObjAutocompleteItem);

        protected virtual void calcularAutoCompleteItemSnippet(List<AutocompleteItem> lstResultado)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (lstResultado == null)
                {
                    return;
                }

                lstResultado.Add(this.getObjAutocompleteItemSnippetIf());
                lstResultado.Add(this.getObjAutocompleteItemSnippetIfElse());
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

        protected abstract Snippet getObjAutocompleteItemSnippetIf();

        protected abstract Snippet getObjAutocompleteItemSnippetIfElse();

        protected virtual void inicializar()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.BorderStyle = BorderStyle.FixedSingle;
                this.Dock = DockStyle.Fill;

                this.KeyDown += this.onKeyDown;
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

        protected virtual void montarLayout()
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
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

        private List<AutocompleteItem> calcularAutoCompleteItem()
        {
            #region Variáveis

            List<AutocompleteItem> lstResultado;

            #endregion Variáveis

            #region Ações

            try
            {
                lstResultado = new List<AutocompleteItem>();

                this.calcularAutoCompleteItemSnippet(lstResultado);
                this.calcularAutoCompleteItemPropriedade(lstResultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion Ações

            return lstResultado;
        }

        private void onKeyDown(KeyEventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (e == null)
                {
                    return;
                }

                if (e.KeyData == (Keys.Control | Keys.Space))
                {
                    this.ctrAutoComplete.Items.SetAutocompleteItems(this.calcularAutoCompleteItem());
                    this.ctrAutoComplete.Show(true);
                    return;
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

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.onKeyDown(e);
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