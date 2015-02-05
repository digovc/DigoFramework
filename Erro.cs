using System;
using System.Windows.Forms;

namespace DigoFramework
{
    public sealed class Erro : Exception
    {
        #region CONSTANTES

        public enum ErroTipo
        {
            ARQUIVO_XML,
            DATA_BASE,
            FATAL,
            FTP,
            GOOGLE_API,
            NOTIFICACAO
        };

        #endregion CONSTANTES

        #region ATRIBUTOS

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strMensagemErro))
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

                #endregion AÇÕES

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strMensagemTitulo))
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

                #endregion AÇÕES

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strTituloJanela))
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

                #endregion AÇÕES

                return _strTituloJanela;
            }

            set
            {
                _strTituloJanela = value;
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public Erro(string strMensagemErro, Exception ex, ErroTipo objErroTipo)
        {
            #region VARIÁVEIS

            string strMensagemFormatada = Utils.STR_VAZIA;

            #endregion VARIÁVEIS

            #region AÇÕES

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
                    strMensagemFormatada = String.Format("{0}\n{1}", strMensagemErro, ex.Message);
                }
                else
                {
                    strMensagemFormatada = String.Format("{0}", strMensagemErro);
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

            #endregion AÇÕES
        }

        public Erro(string strMensagemErro)
        {
            #region VARIÁVEIS

            string strMensagemFormatada = Utils.STR_VAZIA;

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.strMensagemTitulo = "Notificação do Sistema";

                strMensagemFormatada = String.Format("{0}", strMensagemErro);

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

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        private void mostrarMensagem(string strMensagemFormatada)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (Aplicativo.i.frmPrincipal.IsAccessible)
                {
                    Aplicativo.i.frmPrincipal.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(strMensagemFormatada, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });

                    return;
                }

                MessageBox.Show(strMensagemFormatada, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
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