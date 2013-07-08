using System;

namespace DigoFramework.Formulário
{
    public partial class FrmEspera : System.Windows.Forms.Form
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Int16 _intProgresso = 0;
        public Int16 intProgresso
        {
            get { return _intProgresso; }
            set
            {
                _intProgresso = value;
                this.objProgressBar.Value = _intProgresso;
            }
        }

        private string _strMensagemDescricao = "Rotina do sistema sendo executada...";
        public string strMensagemDescricao
        {
            get { return _strMensagemDescricao; }
            set
            {
                _strMensagemDescricao = value;
                this.objLblMensagemDescricao.Text = _strMensagemDescricao;
            }
        }

        private string _strMensagemTitulo = "Por favor, aguarde.";
        public string strMensagemTitulo
        {
            get { return _strMensagemTitulo; }
            set
            {
                _strMensagemTitulo = value;
                this.objLblMensagemTitulo.Text = _strMensagemTitulo;
            }
        }

        #endregion

        #region CONSTRUTORES

        public FrmEspera()
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            InitializeComponent();

            #endregion
        }

        #endregion

        #region MÉTODOS
        #endregion
    }
}
