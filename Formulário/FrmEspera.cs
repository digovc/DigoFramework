using System;
using System.Windows.Forms;

namespace DigoFramework.Formulário
{
    public partial class FrmEspera : Form
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booConcluido = false;
        public Boolean booConcluido
        {
            get { return _booConcluido; }
            set
            {
                _booConcluido = value;
                if (_booConcluido)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                }
            }
        }

        private Double _dblProgresso = 0;
        public Double dblProgresso
        {
            get { return _dblProgresso; }
            set
            {
                _dblProgresso = value;
                if (_dblProgresso > 0)
                {
                    this.progressBar.Invoke((MethodInvoker)delegate
                    {
                        this.progressBar.Style = ProgressBarStyle.Blocks;
                        this.progressBar.Value = Convert.ToInt32(_dblProgresso);
                    });
                }
            }
        }

        private string _strTarefaDescricao = "Rotina do sistema sendo executada...";
        public string strTarefaDescricao
        {
            get { return _strTarefaDescricao; }
            set
            {
                _strTarefaDescricao = value;
                try
                {
                    this.lblTarefaDescricao.Invoke((MethodInvoker)delegate
                    {
                        this.lblTarefaDescricao.Text = _strTarefaDescricao;
                    });
                }
                catch
                {
                    this.lblTarefaDescricao.Text = _strTarefaDescricao;
                }
            }
        }

        private string _strTarefaTitulo = "Por favor, aguarde.";
        public string strTarefaTitulo
        {
            get { return _strTarefaTitulo; }
            set
            {
                _strTarefaTitulo = value;
                try
                {
                    this.lblTarefaTitulo.Invoke((MethodInvoker)delegate
                    {
                        this.lblTarefaTitulo.Text = _strTarefaTitulo;
                    });
                }
                catch
                {
                    this.lblTarefaTitulo.Text = _strTarefaTitulo;
                }
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
