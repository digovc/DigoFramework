using System;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmEspera : FrmBase
    {
        #region Constantes

        #endregion Constantes

        #region Atributos

        private bool _booConcluido;
        private decimal _decProgresso;
        private decimal _decProgressoTarefa;
        private int _intProgressoMaximo;
        private int _intProgressoMaximoTarefa;
        private string _strTarefaDescricao;
        private string _strTarefaTitulo;

        public bool booConcluido
        {
            get
            {
                return _booConcluido;
            }

            set
            {
                _booConcluido = value;

                this.setBooConcluido(_booConcluido);
            }
        }

        public decimal decProgresso
        {
            get
            {
                return _decProgresso;
            }

            set
            {
                if (_decProgresso == value)
                {
                    return;
                }

                _decProgresso = value;

                this.setDecProgresso(_decProgresso);
            }
        }

        public decimal decProgressoTarefa
        {
            get
            {
                return _decProgressoTarefa;
            }

            set
            {
                if (_decProgressoTarefa == value)
                {
                    return;
                }

                _decProgressoTarefa = value;

                this.setDecProgressoTarefa(_decProgressoTarefa);
            }
        }

        public int intProgressoMaximo
        {
            get
            {
                return _intProgressoMaximo = this.pgb.Maximum;
            }

            set
            {
                if (_intProgressoMaximo == value)
                {
                    return;
                }

                _intProgressoMaximo = value;

                this.setIntProgressoMaximo(_intProgressoMaximo);
            }
        }

        public int intProgressoMaximoTarefa
        {
            get
            {
                _intProgressoMaximoTarefa = this.pgbTarefa.Maximum;

                return _intProgressoMaximoTarefa;
            }

            set
            {
                if (_intProgressoMaximoTarefa == value)
                {
                    return;
                }

                _intProgressoMaximoTarefa = value;

                this.setIntProgressoMaximoTarefa(_intProgressoMaximoTarefa);
            }
        }

        public string strTarefaDescricao
        {
            get
            {
                if (_strTarefaDescricao != null)
                {
                    return _strTarefaDescricao;
                }

                _strTarefaDescricao = "Rotina sendo executada.";

                return _strTarefaDescricao;
            }

            set
            {
                if (_strTarefaDescricao == value)
                {
                    return;
                }

                _strTarefaDescricao = value;

                this.setStrTarefaDescricao(_strTarefaDescricao);
            }
        }

        public string strTarefaTitulo
        {
            get
            {
                if (_strTarefaTitulo != null)
                {
                    return _strTarefaTitulo;
                }

                _strTarefaTitulo = "Por favor aguarde";

                return _strTarefaTitulo;
            }

            set
            {
                if (_strTarefaTitulo == value)
                {
                    return;
                }

                _strTarefaTitulo = value;

                this.setStrTarefaTitulo(_strTarefaTitulo);
            }
        }

        #endregion Atributos

        #region Construtores

        public FrmEspera()
        {
            this.InitializeComponent();
        }

        #endregion Construtores

        #region Métodos

        protected override void inicializar()
        {
            base.inicializar();

            this.TopMost = true;

            this.lblDescricao.Text = this.strTarefaDescricao;
            this.lblTitulo.Text = this.strTarefaTitulo;

            this.pgb.Style = ProgressBarStyle.Marquee;
            this.pgb.Value = (int)this.decProgresso;

            this.pgbTarefa.Style = ProgressBarStyle.Blocks;
            this.pgbTarefa.Value = (int)this.decProgressoTarefa;
        }

        private void setBooConcluido(bool booConcluido)
        {
            this.decProgresso = 0;
            this.decProgressoTarefa = 0;

            if (!booConcluido)
            {
                return;
            }

            try
            {
                this.Invoke(new Action(() =>
                {
                    this.pgbTarefa.Visible = false;

                    this.Close();
                }));

                AppBase.i?.frmPrincipal?.Invoke(new Action(() =>
                {
                    AppBase.i.frmPrincipal.Activate();
                }));
            }
            catch
            {
            }
        }

        private void setDecProgresso(decimal decProgresso)
        {
            try
            {
                this.pgb.Invoke((MethodInvoker)delegate
                {
                    this.pgb.Maximum = _intProgressoMaximo;
                    this.pgb.Style = ProgressBarStyle.Blocks;

                    if (decProgresso >= this.pgb.Maximum)
                    {
                        this.pgb.Value = this.pgb.Maximum;

                        this.pgb.Refresh();
                        return;
                    }

                    this.pgb.Value = Convert.ToInt32(decProgresso);

                    this.pgb.Refresh();
                });
            }
            catch
            {
            }
        }

        private void setDecProgressoTarefa(decimal decProgressoTarefa)
        {
            try
            {
                this.pgbTarefa.Invoke((MethodInvoker)delegate
                {
                    this.pgbTarefa.Maximum = _intProgressoMaximoTarefa;
                    this.pgbTarefa.Style = ProgressBarStyle.Blocks;

                    if (decProgressoTarefa >= this.pgbTarefa.Maximum)
                    {
                        this.pgbTarefa.Visible = false;

                        this.pgbTarefa.Refresh();
                        return;
                    }

                    this.pgbTarefa.Visible = true;
                    this.pgbTarefa.Value = Convert.ToInt32(decProgressoTarefa);

                    this.pgbTarefa.Refresh();
                });
            }
            catch
            {
            }
        }

        private void setIntProgressoMaximo(int intProgressoMaximo)
        {
            try
            {
                this.pgb.Invoke((MethodInvoker)delegate
                {
                    this.pgb.Maximum = intProgressoMaximo;

                    this.pgb.Refresh();
                });
            }
            catch
            {
            }
        }

        private void setIntProgressoMaximoTarefa(int intProgressoMaximoTarefa)
        {
            try
            {
                this.pgbTarefa.Invoke((MethodInvoker)delegate
                {
                    this.pgbTarefa.Maximum = intProgressoMaximoTarefa;

                    this.pgbTarefa.Refresh();
                });
            }
            catch
            {
            }
        }

        private void setStrTarefaDescricao(string strTarefaDescricao)
        {
            try
            {
                this.lblDescricao.Invoke((MethodInvoker)delegate
                {
                    this.lblDescricao.Text = strTarefaDescricao;

                    this.lblDescricao.Refresh();
                });
            }
            catch
            {
            }
        }

        private void setStrTarefaTitulo(string strTarefaTitulo)
        {
            try
            {
                this.lblTitulo.Invoke((MethodInvoker)delegate
                {
                    this.lblTitulo.Text = strTarefaTitulo;

                    this.lblTitulo.Refresh();
                });
            }
            catch
            {
            }
        }

        #endregion Métodos

        #region Eventos

        private void FrmEspera_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.booConcluido)
            {
                e.Cancel = true;
            }
        }

        #endregion Eventos
    }
}