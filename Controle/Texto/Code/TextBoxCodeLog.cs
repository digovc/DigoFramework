using System;
using System.Collections.Generic;
using DigoFramework.Controle.Texto.Code.Autocomplete;
using DigoFramework.Controle.Texto.Code.Style;
using FastColoredTextBoxNS;

namespace DigoFramework.Controle.Texto.Code
{
    public class TextBoxCodeLog : TextBoxCodeMain
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
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_lstLog != null)
                    {
                        return _lstLog;
                    }

                    _lstLog = new List<Log>();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _lstLog;
            }
        }

        private LogSyntaxHighlighter objLogSyntaxHighlighter
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (_objLogSyntaxHighlighter != null)
                    {
                        return _objLogSyntaxHighlighter;
                    }

                    _objLogSyntaxHighlighter = new LogSyntaxHighlighter();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _objLogSyntaxHighlighter;
            }
        }

        #endregion Atributos

        #region Construtores

        #endregion Construtores

        #region Métodos

        public void adicionar(Log log)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                if (log == null)
                {
                    return;
                }

                this.Text += log.ToString();
                this.Text += Environment.NewLine;

                this.lstLog.Add(log);
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

            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.ReadOnly = true;
                this.SyntaxHighlighter = this.objLogSyntaxHighlighter;

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

        private void click(EventArgs e)
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

                new Erro(e.ToString());
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

        private void click(object sender, EventArgs e)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                this.click(e);
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion Ações
        }

        #endregion Eventos
    }
}