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
                return _intProgressoMaximo = this.pgbTotal.Maximum;
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
                _intProgressoMaximoTarefa = this.pgbParcial.Maximum;

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

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.lblDescricao.Text = this.strTarefaDescricao;
            this.lblTitulo.Text = this.strTarefaTitulo;
            this.pgbParcial.Maximum = this.intProgressoMaximoTarefa;
            this.pgbParcial.Value = (int)this.decProgressoTarefa;
            this.pgbTotal.Maximum = this.intProgressoMaximo;
            this.pgbTotal.Value = (int)this.decProgresso;
        }

        private void setBooConcluido(bool booConcluido)
        {
            if (!booConcluido)
            {
                return;
            }

            this.decProgresso = 0;
            this.decProgressoTarefa = 0;

            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.pgbParcial.Visible = false;

                    this.Close();
                });
            }
            catch
            {
            }
        }

        private void setDecProgresso(decimal decProgresso)
        {
            try
            {
                if (!this.IsAccessible)
                {
                    return;
                }

                this.pgbTotal.Invoke((MethodInvoker)delegate
                {
                    if (this.intProgressoMaximo != this.pgbTotal.Maximum)
                    {
                        this.pgbTotal.Maximum = this.intProgressoMaximo;
                    }

                    if (decProgresso >= this.pgbTotal.Maximum)
                    {
                        this.pgbTotal.Value = this.pgbTotal.Maximum;
                        this.pgbTotal.Refresh();
                        return;
                    }

                    this.pgbTotal.Style = ProgressBarStyle.Blocks;
                    this.pgbTotal.Value = Convert.ToInt32(decProgresso);
                    this.pgbTotal.Refresh();
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
                if (!this.IsAccessible)
                {
                    return;
                }

                this.pgbParcial.Invoke((MethodInvoker)delegate
                {
                    if (this.intProgressoMaximoTarefa != this.pgbParcial.Maximum)
                    {
                        this.pgbParcial.Maximum = this.intProgressoMaximoTarefa;
                    }

                    if (decProgressoTarefa >= this.pgbParcial.Maximum)
                    {
                        this.pgbParcial.Visible = false;
                        this.pgbParcial.Refresh();
                        return;
                    }

                    this.pgbParcial.Style = ProgressBarStyle.Blocks;
                    this.pgbParcial.Visible = true;
                    this.pgbParcial.Value = Convert.ToInt32(decProgressoTarefa);
                    this.pgbParcial.Refresh();
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
                if (!this.IsAccessible)
                {
                    return;
                }

                this.pgbTotal.Invoke((MethodInvoker)delegate
                {
                    this.pgbTotal.Maximum = intProgressoMaximo;
                    this.pgbTotal.Refresh();
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
                if (!this.IsAccessible)
                {
                    return;
                }

                this.pgbParcial.Invoke((MethodInvoker)delegate
                {
                    this.pgbParcial.Maximum = intProgressoMaximoTarefa;
                    this.pgbParcial.Refresh();
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
                if (!this.IsAccessible)
                {
                    return;
                }

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
                if (!this.IsAccessible)
                {
                    return;
                }

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