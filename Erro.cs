using System;
using System.Windows.Forms;

namespace DigoFramework
{
    public sealed class Erro : Objeto
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private Exception _ex;
        private string _strErro;

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

        #endregion Atributos

        #region Construtores

        public Erro(string strErro, Exception ex)
        {
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

            Log.i.erro(strErroFormatado);

            if (AppBase.i == null)
            {
                return;
            }

            if (AppBase.i.frmPrincipal == null)
            {
                return;
            }

            if (!AppBase.i.frmPrincipal.IsAccessible)
            {
                return;
            }

            AppBase.i.frmPrincipal.Invoke((MethodInvoker)delegate
            {
                MessageBox.Show(new Form() { TopMost = true }, strErroFormatado, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        #endregion Métodos

        #region Eventos

        #endregion Eventos
    }
}