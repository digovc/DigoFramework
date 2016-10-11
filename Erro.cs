using System;
using System.Windows.Forms;

namespace DigoFramework
{
    public sealed class Erro : Objeto
    {
        #region Constantes

        public enum EnmTipo
        {
            ARQUIVO_XML,
            DATA_BASE,
            ERRO,
            FTP,
            GOOGLE_API,
            NOTIFICACAO,
            SERVER,
        }

        #endregion Constantes

        #region Atributos

        private EnmTipo _enmTipo = EnmTipo.ERRO;
        private Exception _ex;
        private string _strErro;
        private string _strTitulo;

        private EnmTipo enmTipo
        {
            get
            {
                return _enmTipo;
            }

            set
            {
                _enmTipo = value;
            }
        }

        private Exception ex
        {
            get
            {
                return _ex;
            }

            set
            {
                _ex = value;
            }
        }

        private string strErro
        {
            get
            {
                if (!string.IsNullOrEmpty(_strErro))
                {
                    return _strErro;
                }

                _strErro = "Erro desconhecido";

                return _strErro;
            }

            set
            {
                _strErro = value;
            }
        }

        private string strTitulo
        {
            get
            {
                if (!string.IsNullOrEmpty(_strTitulo))
                {
                    return _strTitulo;
                }

                _strTitulo = this.getStrTitulo();

                return _strTitulo;
            }
        }

        #endregion Atributos

        #region Construtores

        public Erro(string strErro, Exception ex, EnmTipo enmTipo = EnmTipo.ERRO)
        {
            this.enmTipo = enmTipo;
            this.ex = ex;
            this.strErro = strErro;

            this.mostrar();
        }

        public Erro(string strErro)
        {
            this.strErro = strErro;

            this.mostrar();
        }

        #endregion Construtores

        #region Métodos

        private string getStrTitulo()
        {
            switch (this.enmTipo)
            {
                case EnmTipo.DATA_BASE:
                    return "Erro no banco de dados";

                case EnmTipo.NOTIFICACAO:
                    return "Notificação";

                default:
                    return "Erro";
            }
        }

        private void mostrar()
        {
            string strErroFormatado;

            if (ex != null)
            {
                strErroFormatado = string.Format("{0}\r\n\r\nDetalhes:\r\n{1}", strErro, ex.Message);
            }
            else
            {
                strErroFormatado = strErro;
            }

            if (AppBase.i != null && AppBase.i.booWeb)
            {
                throw new Exception(strErroFormatado);
            }
            else
            {
                this.mostrar(strErroFormatado);
            }

            Debug.i.log(strErroFormatado);
        }

        private void mostrar(string strErroFormatado)
        {
            if (string.IsNullOrEmpty(strErroFormatado))
            {
                return;
            }

            if (AppBase.i != null && AppBase.i.booConsole)
            {
                return;
            }

            if (AppBase.i != null && AppBase.i.booWeb)
            {
                return;
            }

            if (AppBase.i == null)
            {
                MessageBox.Show(new Form() { TopMost = true }, strErroFormatado, this.strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AppBase.i.frmPrincipal.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(new Form() { TopMost = true }, strErroFormatado, this.strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}