using System;
using System.Windows.Forms;

namespace DigoFramework.form
{
    public partial class FrmEspera : FrmMain
    {
        #region CONSTANTES

        #endregion

        #region ATRIBUTOS

        private Boolean _booConcluido = false;
        private Double _dblProgresso = 0;
        private Double _dblProgressoTarefa = 0;
        private int _intProgressoMaximo;
        private int _intProgressoMaximoTarefa;
        private string _strTarefaDescricao = "Rotina do sistema sendo executada...";
        private string _strTarefaTitulo = "Por favor, aguarde.";

        public Boolean booConcluido
        {
            get
            {
                return _booConcluido;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

                    _booConcluido = value;
                    if (_booConcluido)
                    {
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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        public Double dblProgresso
        {
            get
            {
                return _dblProgresso;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        public Double dblProgressoTarefa
        {
            get
            {
                return _dblProgressoTarefa;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
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

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
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

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        public string strTarefaDescricao
        {
            get
            {
                return _strTarefaDescricao;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                }
            }
        }

        public string strTarefaTitulo
        {
            get
            {
                return _strTarefaTitulo;
            }

            set
            {
                #region VARIÁVEIS

                #endregion

                try
                {
                    #region AÇÕES

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

                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
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