using System;
using System.Windows.Forms;

namespace DigoFramework
{
    public sealed class Erro : Exception
    {
        #region Constantes

        public enum ErroTipo
        {
            ARQUIVO_XML,
            DATA_BASE,
            FATAL,
            FTP,
            GOOGLE_API,
            NOTIFICACAO,
            SERVER,
        };

        #endregion Constantes

        #region Atributos

        private Aplicativo _objAplicativo;
        private ErroTipo _objErroTipo = ErroTipo.NOTIFICACAO;
        private string _strMensagemErro;
        private string _strMensagemTitulo;
        private string _strTituloJanela;

        public Aplicativo objAppAplicativo
        {
            get
            {
                return _objAplicativo;
            }

            set
            {
                _objAplicativo = value;
            }
        }

        public ErroTipo objErroTipo
        {
            get
            {
                return _objErroTipo;
            }

            set
            {
                _objErroTipo = value;
            }
        }

        public string strMensagemErro
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_strMensagemErro))
                    {
                        return _strMensagemErro;
                    }

                    _strMensagemErro = "Erro desconhecido";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strMensagemErro;
            }

            set
            {
                _strMensagemErro = value;
            }
        }

        public string strMensagemTitulo
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_strMensagemTitulo))
                    {
                        return _strMensagemTitulo;
                    }

                    _strMensagemTitulo = "Erro";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strMensagemTitulo;
            }

            set
            {
                _strMensagemTitulo = value;
            }
        }

        public string strTituloJanela
        {
            get
            {
                #region Variáveis

                #endregion Variáveis

                #region Ações

                try
                {
                    if (!string.IsNullOrEmpty(_strTituloJanela))
                    {
                        return _strTituloJanela;
                    }

                    _strTituloJanela = "Erro";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion Ações

                return _strTituloJanela;
            }

            set
            {
                _strTituloJanela = value;
            }
        }

        #endregion Atributos

        #region Construtores

        public Erro(string strMensagemErro, Exception ex, ErroTipo objErroTipo)
        {
            #region Variáveis

            string strMensagemFormatada = string.Empty;

            #endregion Variáveis

            #region Ações

            try
            {
                switch (objErroTipo)
                {
                    case ErroTipo.DATA_BASE:
                        this.strMensagemTitulo = "Erro no banco de dados";
                        break;

                    case ErroTipo.FATAL:
                        this.strMensagemTitulo = "Erro fatal";
                        break;

                    case ErroTipo.NOTIFICACAO:
                        this.strMensagemTitulo = "Notificação";
                        break;

                    default:
                        break;
                }

                // Formata mensagem
                if (ex != null)
                {
                    strMensagemFormatada = string.Format("{0}\n{1}", strMensagemErro, ex.Message);
                }
                else
                {
                    strMensagemFormatada = string.Format("{0}", strMensagemErro);
                }
                // Mostra erro ao usuário
                if (Aplicativo.i.booAplicativoWeb)
                {
                    throw new Exception(strMensagemFormatada);
                }
                else
                {
                    this.mostrarMensagem(strMensagemFormatada);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
            }

            #endregion Ações
        }

        public Erro(string strMensagemErro)
        {
            #region Variáveis

            string strMensagemFormatada = string.Empty;

            #endregion Variáveis

            #region Ações

            try
            {
                this.strMensagemTitulo = "Notificação do Sistema";

                strMensagemFormatada = string.Format("{0}", strMensagemErro);

                // Mostra erro ao usuário
                if (Aplicativo.i.booAplicativoWeb)
                {
                    throw new Exception(strMensagemFormatada);
                }
                else
                {
                    this.mostrarMensagem(strMensagemFormatada);
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

        #endregion Construtores

        #region Métodos

        private void mostrarMensagem(string strMensagemFormatada)
        {
            #region Variáveis

            #endregion Variáveis

            #region Ações

            try
            {
                // TODO: Criar uma tela de erro.
                if (!Aplicativo.i.frmPrincipal.IsAccessible)
                {
                    MessageBox.Show(new Form()
                    {
                        TopMost = true
                    }, strMensagemFormatada, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                Aplicativo.i.frmPrincipal.Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(new Form()
                    {
                        TopMost = true
                    }, strMensagemFormatada, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
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