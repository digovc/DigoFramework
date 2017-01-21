using System;

namespace DigoFramework.Frm
{
    public partial class FrmInput : FrmBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private static FrmInput _i;

        private string _strDescricao;
        private string _strTitulo;
        private string _strValorDefault;

        public static FrmInput i
        {
            get
            {
                if (_i == null)
                {
                    _i = new FrmInput();
                }

                return _i;
            }
        }

        public string strDescricao
        {
            get
            {
                _strDescricao = this.lbl.Text;

                return _strDescricao;
            }

            set
            {
                _strDescricao = value;

                this.lbl.Text = _strDescricao;
            }
        }

        public string strTitulo
        {
            get
            {
                _strTitulo = this.Text;

                return _strTitulo;
            }

            set
            {
                _strTitulo = value;

                this.Text = _strTitulo;
            }
        }

        public string strValorDefault
        {
            get
            {
                _strValorDefault = this.txt.Text;

                return _strValorDefault;
            }

            set
            {
                _strValorDefault = value;

                this.txt.Text = _strValorDefault;
            }
        }

        #endregion Atributos

        #region Construtores

        private FrmInput()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        #endregion Métodos

        #region Eventos

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                AppBase.i.strInput = this.txt.Text;

                this.Close();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        private void FrmInput_Load(object sender, EventArgs e)
        {
            try
            {
                this.txt.SelectAll();
                this.txt.Focus();
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex);
            }
        }

        #endregion Eventos
    }
}