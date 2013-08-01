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

        #region

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

        #endregion

        #region MÉTODOS

        public Erro(String strMensagemErro, Exception ex, ErroTipo objErroTipo)
        {
            #region VARIÁVEIS
            String strMensagemFormatada = Utils.STRING_VAZIA;
            #endregion

            #region AÇÕES
            switch (objErroTipo)
            {
                case ErroTipo.BancoDados:
                    this.strMensagemTitulo = "Erro no Banco de Dados";
                    break;

                case ErroTipo.Fatal:
                    this.strMensagemTitulo = "Erro Fatal do Sistema";
                    break;

                case ErroTipo.Notificao:
                    this.strMensagemTitulo = "Notificação do Sistema";
                    break;
                default:
                    break;
            }

            // Formata mensagem
            strMensagemFormatada = String.Format("Descrição do erro: {0}", strMensagemErro);
            // Mostra erro ao usuário
            MessageBox.Show(strMensagemErro + "\n" + ex.Message, this.strMensagemTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);

            #endregion

        }

        #endregion

    }
}
