using System;
using System.Windows.Forms;

namespace DigoFramework.Formulário
{
    public partial class FrmEspera : System.Windows.Forms.Form
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS E PROPRIEDADES

        private Boolean _booConcluido = false;
        public Boolean booConcluido
        {
            get { return _booConcluido; }
            set
            {
                _booConcluido = value;
                if (_booConcluido)
                {
                    this.Close();
                }
            }
        }

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
        public string strTarefaDescricao
        {
            get { return _strMensagemDescricao; }
            set
            {
                _strMensagemDescricao = value;
                this.objLblMensagemDescricao.Text = _strMensagemDescricao;
            }
        }

        private string _strMensagemTitulo = "Por favor, aguarde.";
        public string strTarefaTitulo
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

        #region EVENTOS

        private void FrmEspera_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            #region VARIÁVEIS
            #endregion

            #region AÇÕES

            if (!this.booConcluido)
            {
                e.Cancel = true;
            }

            #endregion
        }

        #endregion
    }
}
