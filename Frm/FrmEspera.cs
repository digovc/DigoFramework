using System;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmEspera : FrmMain
    {
        #region CONSTANTES

        #endregion CONSTANTES

        #region ATRIBUTOS

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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _booConcluido = value;

                    if (!_booConcluido)
                    {
                        return;
                    }

                    try
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            this.decProgresso = 0;
                            this.decProgressoTarefa = 0;
                            this.pgbParcial.Visible = false;
                            this.Close();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _decProgresso = value;

                    try
                    {
                        this.pgbTotal.Invoke((MethodInvoker)delegate
                        {
                            if (_intProgressoMaximo != this.pgbTotal.Maximum)
                            {
                                this.pgbTotal.Maximum = _intProgressoMaximo;
                            }

                            if (_decProgresso >= this.pgbTotal.Maximum)
                            {
                                this.pgbTotal.Value = this.pgbTotal.Maximum;
                                this.pgbTotal.Refresh();
                                return;
                            }

                            this.pgbTotal.Style = ProgressBarStyle.Blocks;
                            this.pgbTotal.Value = Convert.ToInt32(_decProgresso);
                            this.pgbTotal.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _decProgressoTarefa = value;

                    try
                    {
                        this.pgbParcial.Invoke((MethodInvoker)delegate
                        {
                            if (_intProgressoMaximoTarefa != this.pgbParcial.Maximum)
                            {
                                this.pgbParcial.Maximum = _intProgressoMaximoTarefa;
                            }

                            if (_decProgressoTarefa >= this.pgbParcial.Maximum)
                            {
                                this.pgbParcial.Visible = false;
                                this.pgbParcial.Refresh();
                                return;
                            }

                            this.pgbParcial.Style = ProgressBarStyle.Blocks;
                            this.pgbParcial.Visible = true;
                            this.pgbParcial.Value = Convert.ToInt32(_decProgressoTarefa);
                            this.pgbParcial.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
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
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intProgressoMaximo = value;

                    try
                    {
                        this.pgbTotal.Invoke((MethodInvoker)delegate
                        {
                            this.pgbTotal.Maximum = _intProgressoMaximo;
                            this.pgbTotal.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public int intProgressoMaximoTarefa
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intProgressoMaximoTarefa = this.pgbParcial.Maximum;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _intProgressoMaximoTarefa;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _intProgressoMaximoTarefa = value;

                    try
                    {
                        this.pgbParcial.Invoke((MethodInvoker)delegate
                        {
                            this.pgbParcial.Maximum = _intProgressoMaximoTarefa;
                            this.pgbParcial.Refresh();
                        });
                    }
                    catch
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public string strTarefaDescricao
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strTarefaDescricao))
                    {
                        return _strTarefaDescricao;
                    }

                    _strTarefaDescricao = "Rotina do sistema sendo executada...";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _strTarefaDescricao;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _strTarefaDescricao = value;
                    try
                    {
                        this.lblDescricao.Invoke((MethodInvoker)delegate
                        {
                            this.lblDescricao.Text = _strTarefaDescricao;
                            this.lblDescricao.Refresh();
                        });
                    }
                    catch
                    {
                        this.lblDescricao.Text = _strTarefaDescricao;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        public string strTarefaTitulo
        {
            get
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    if (!String.IsNullOrEmpty(_strTarefaTitulo))
                    {
                        return _strTarefaTitulo;
                    }

                    _strTarefaTitulo = "Por favor, aguarde.";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES

                return _strTarefaTitulo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion VARIÁVEIS

                #region AÇÕES

                try
                {
                    _strTarefaTitulo = value;
                    try
                    {
                        this.lblTitulo.Invoke((MethodInvoker)delegate
                        {
                            this.lblTitulo.Text = _strTarefaTitulo;
                            this.lblTitulo.Refresh();
                        });
                    }
                    catch
                    {
                        this.lblTitulo.Text = _strTarefaTitulo;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion AÇÕES
            }
        }

        #endregion ATRIBUTOS

        #region CONSTRUTORES

        public FrmEspera()
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.InitializeComponent();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion CONSTRUTORES

        #region MÉTODOS

        protected override void inicializar()
        {
            base.inicializar();

            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion MÉTODOS

        #region EVENTOS

        private void FrmEspera_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            #region VARIÁVEIS

            #endregion VARIÁVEIS

            #region AÇÕES

            try
            {
                if (!this.booConcluido)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                new Erro("Erro inesperado.\n", ex, Erro.ErroTipo.FATAL);
            }
            finally
            {
            }

            #endregion AÇÕES
        }

        #endregion EVENTOS
    }
}