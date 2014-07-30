using System;
using System.Windows.Forms;

namespace DigoFramework.Frm
{
    public partial class FrmEspera : FrmMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private bool _booConcluido;
        private double _dblProgresso;
        private double _dblProgressoTarefa;
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

                #endregion

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
                            this.dblProgresso = 0;
                            this.dblProgressoTarefa = 0;
                            this.progressBarTarefa.Visible = false;
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

                #endregion
            }
        }

        public double dblProgresso
        {
            get
            {
                return _dblProgresso;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _dblProgresso = value;

                    try
                    {
                        this.progressBar.Invoke((MethodInvoker)delegate
                        {
                            if (_dblProgresso >= this.progressBar.Maximum)
                            {
                                this.progressBar.Value = this.progressBar.Maximum;
                                this.progressBar.Refresh();
                                return;
                            }

                            this.progressBar.Style = ProgressBarStyle.Blocks;
                            this.progressBar.Value = Convert.ToInt32(_dblProgresso);
                            this.progressBar.Refresh();
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

                #endregion
            }
        }

        public double dblProgressoTarefa
        {
            get
            {
                return _dblProgressoTarefa;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _dblProgressoTarefa = value;

                    try
                    {
                        this.progressBarTarefa.Invoke((MethodInvoker)delegate
                        {
                            if (_dblProgressoTarefa >= this.progressBarTarefa.Maximum)
                            {
                                this.progressBarTarefa.Visible = false;
                                this.progressBarTarefa.Refresh();
                                return;
                            }

                            this.progressBarTarefa.Style = ProgressBarStyle.Blocks;
                            this.progressBarTarefa.Visible = true;
                            this.progressBarTarefa.Value = Convert.ToInt32(_dblProgressoTarefa);
                            this.progressBarTarefa.Refresh();
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

                #endregion
            }
        }

        public int intProgressoMaximo
        {
            get
            {
                _intProgressoMaximo = this.progressBar.Maximum;
                return _intProgressoMaximo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _intProgressoMaximo = value;
                    try
                    {
                        this.progressBar.Invoke((MethodInvoker)delegate
                        {
                            this.progressBar.Maximum = _intProgressoMaximo;
                            this.progressBar.Refresh();
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

                #endregion
            }
        }

        public int intProgressoMaximoTarefa
        {
            get
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _intProgressoMaximoTarefa = this.progressBarTarefa.Maximum;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion

                return _intProgressoMaximoTarefa;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _intProgressoMaximoTarefa = value;

                    try
                    {
                        this.progressBarTarefa.Invoke((MethodInvoker)delegate
                        {
                            this.progressBarTarefa.Maximum = _intProgressoMaximoTarefa;
                            this.progressBarTarefa.Refresh();
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

                #endregion
            }
        }

        public string strTarefaDescricao
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _strTarefaDescricao;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _strTarefaDescricao = value;
                    try
                    {
                        this.lblTarefaDescricao.Invoke((MethodInvoker)delegate
                        {
                            this.lblTarefaDescricao.Text = _strTarefaDescricao;
                            this.lblTarefaDescricao.Refresh();
                        });
                    }
                    catch
                    {
                        this.lblTarefaDescricao.Text = _strTarefaDescricao;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        public string strTarefaTitulo
        {
            get
            {
                #region VARIÁVEIS

                #endregion

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

                #endregion

                return _strTarefaTitulo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                #region AÇÕES

                try
                {
                    _strTarefaTitulo = value;
                    try
                    {
                        this.lblTarefaTitulo.Invoke((MethodInvoker)delegate
                        {
                            this.lblTarefaTitulo.Text = _strTarefaTitulo;
                            this.lblTarefaTitulo.Refresh();
                        });
                    }
                    catch
                    {
                        this.lblTarefaTitulo.Text = _strTarefaTitulo;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }

                #endregion
            }
        }

        #endregion

        #region CONSTRUTORES

        public FrmEspera()
        {
            #region VARIÁVEIS

            #endregion

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

            #endregion
        }

        #endregion
    }
}