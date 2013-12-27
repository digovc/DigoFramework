using System;
using System.Windows.Forms;

namespace DigoFramework
{
    public sealed class Erro : Exception
    {
        #region CONSTANTES

        public enum ErroTipo
        {
            ArquivoXml,
            BancoDados,
            Fatal,
            Ftp,
            GoogleApi,
            Notificao
        };

        #endregion

        #region ATRIBUTOS

        private Aplicativo _objAplicativo = null;
        public Aplicativo objAppAplicativo { get { return _objAplicativo; } set { _objAplicativo = value; } }

        private ErroTipo _objErroTipo = ErroTipo.Notificao;
        public ErroTipo objErroTipo { get { return _objErroTipo; } set { _objErroTipo = value; } }

        //private String _strMensagemComplementar = "Mensagem";
        //public String strMensagemComplementar { get { return _strMensagemComplementar; } set { _strMensagemComplementar = value; } }

        private String _strMensagemErro = "Erro desconhecido";
        public String strMensagemErro { get { return _strMensagemErro; } set { _strMensagemErro = value; } }

        private String _strMensagemTitulo = "Erro";
        public String strMensagemTitulo { get { return _strMensagemTitulo; } set { _strMensagemTitulo = value; } }

        private String _strTituloJanela = "Erro";
        public String strTituloJanela { get { return _strTituloJanela; } set { _strTituloJanela = value; } }

        #endregion

        #region CONSTRUTORES

        public Erro(String strMensagemErro, Exception ex, ErroTipo objErroTipo)
        {
            #region VARIÁVEIS
            String strMensagemFormatada = Utils.STRING_VAZIA;
            #endregion

            #region AÇÕES
            switch (objErroTipo)
            {
                case ErroTipo.BancoDados:
                    this.strMensagemTitulo = "Erro no banco de dados";
                    break;

                case ErroTipo.Fatal:
                    this.strMensagemTitulo = "Erro fatal";
                    break;

                case ErroTipo.Notificao:
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
                MessageBox.Show(strMensagemFormatada, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }
        public Erro(String strMensagemErro)
        {
            #region VARIÁVEIS

            String strMensagemFormatada = Utils.STRING_VAZIA;

            #endregion

            #region AÇÕES

            this.strMensagemTitulo = "Notificação do Sistema";

            strMensagemFormatada = String.Format("{0}", strMensagemErro);

            // Mostra erro ao usuário
            if (Aplicativo.i.booAplicativoWeb)
            {
                throw new Exception(strMensagemFormatada);
            }
            else
            {
                MessageBox.Show(strMensagemFormatada, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion
        }

        #endregion

        #region MÉTODOS
        #endregion
    }
}
